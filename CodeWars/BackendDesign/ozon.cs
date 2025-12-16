using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CodeWars.BackendDesign;

record Request(Guid Id);
record Response(Guid Id);

interface IProcessor{
    Task ReceiveAsync(CancellationToken token); // launched once after app starts
    Task<Response> Send(Request r, CancellationToken token);
    Task StopAsync(CancellationToken token);
}

interface INetworkAdapter{
    Task<Response> ReceiveAsync(CancellationToken token);
    Task<Response> SendAsync(Request r, CancellationToken token);
    Task<bool> IsQueueFull(CancellationToken token);
}

class Processor : IProcessor {
    private readonly INetworkAdapter _networkAdapter;
    private readonly ConcurrentDictionary<Guid, Response> _responses = new();
    private CancellationTokenSource? _receiveCts;
    private Task _receiveTask;
    
    public Processor(INetworkAdapter networkAdapter) => _networkAdapter = networkAdapter;
    public Task ReceiveAsync(CancellationToken token)
    {
        _receiveCts = CancellationTokenSource.CreateLinkedTokenSource(token);
        _receiveTask = Task.Run(async () =>
            {
                while (!_receiveCts.IsCancellationRequested)
                {
                    try
                    {
                        var response = await _networkAdapter.ReceiveAsync(_receiveCts.Token);
                        if (response != null)
                            _responses.TryAdd(response.Id, response);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                }
            }, _receiveCts.Token);
        return _receiveTask;
    }

    public async Task<Response> Send(Request r, CancellationToken token)
    {
        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
            token, 
            _receiveCts?.Token ?? CancellationToken.None
        );
        
        while (!linkedCts.Token.IsCancellationRequested)
        {
            var queueFull = await _networkAdapter.IsQueueFull(token);
            if (!queueFull) break;
            await Task.Delay(100, token);
        }
        await _networkAdapter.SendAsync(r, linkedCts.Token);
        while (!linkedCts.Token.IsCancellationRequested && !_responses.ContainsKey(r.Id))
        {
            await Task.Delay(100, token);
        }
        
        var ret = _responses[r.Id];
        _responses.TryRemove(r.Id, out _);
        return ret;
    }

    public async Task StopAsync(CancellationToken token)
    {
       _receiveCts?.Cancel();
       if (_receiveTask != null)
       {
            var completed = await Task.WhenAny(_receiveTask, Task.Delay(1000, token));
            if (completed != _receiveTask)
            {
                throw new OperationCanceledException(); // timeout
            }
       }
       _receiveCts?.Dispose();
    }
}