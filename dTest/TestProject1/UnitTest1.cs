using CodeWars;
using Xunit;

namespace DictTest;

public class UnitTest1
{
    int amountOfEntries = 1000;
    [Fact]
    public void Basic()
    {
        var sut = new OrderedDict<int, string>();
        for (int i = 0; i < 10; i++)
        {
            sut.Add(i, i.ToString());
        }

        for (int i = 0; i < 10; i++)
        {
            var v = sut[i];
            Assert.Equal(i.ToString(), v);
        }

        sut.Remove(5);
        Assert.False(sut.ContainsKey(5));
        
        for (int i = 0; i < 10; i++)
        {
            if (sut.TryGetValue(i, out var v))
            {
                Assert.Equal(i.ToString(), v);
            }
        }
    }

    [Fact]
    public void OrderInMsDict()
    {
        var sut = new Dictionary<Guid, string>();
        CheckOrder(sut, amountOfEntries);
    }
    
    [Fact]
    public void OrderInMyDict()
    {
        var sut = new OrderedDict<Guid, string>();
        CheckOrder(sut, amountOfEntries);
    }

    private void CheckOrder(IDictionary<Guid, string> dict, int max)
    {
        var sut = dict;
        List<Guid> stack = new List<Guid>();
        for (int i = 0; i < max; i++) //add many
        {
            var g = Guid.NewGuid();
            sut.Add(g, g.ToString());
            stack.Add(g);
        }

        var rand = new Random();
        for (int i = 0; i < max/100; i++) //delete 1%
        {
            var v = rand.Next(0, max);
            var index = stack[v];
            sut.Remove(index);
        }
        
        for (int i = 0; i < max/100; i++) // add new 1%
        {
            var g = Guid.NewGuid();
            sut.Add(g, g.ToString());
            stack.Add(g);
        }

        Guid? prev = null;
        foreach (var v in sut)
        {
            var current = v.Key;
            if (prev == null)
            {
                prev = current;
                continue;
            }

            var previndex = stack.IndexOf(prev.Value);
            var cur = stack.IndexOf(current);
            Assert.True(previndex < cur);
            prev = current;
        }
    }
}