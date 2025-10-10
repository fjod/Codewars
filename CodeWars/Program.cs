using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace CodeWars;

public class Sample
{
    public string S1 { get; set; }
    public string S2 { get; set; }
    public string S3 { get; set; }
    public string S4 { get; set; }
    public string S5 { get; set; }
}

public class Samples
{
    public List<Sample> Type { get; set; }
}

/*
| Method                   | Mean     | Error    | StdDev   | Gen0    | Gen1    | Gen2    | Allocated |
|------------------------- |---------:|---------:|---------:|--------:|--------:|--------:|----------:|
| SquashSamplesNoSbSpans   | 35.11 us | 0.704 us | 2.066 us | 47.6074 | 47.6074 | 47.6074 |  150.7 KB | -- if there is no need to create new string in the end, allocations = 0
| SquashSamplesSpans       | 48.80 us | 0.556 us | 0.464 us | 45.4102 | 45.4102 | 45.4102 | 296.66 KB |
| SquashSamplesSpansParams | 47.16 us | 0.528 us | 0.494 us | 45.4102 | 45.4102 | 45.4102 | 289.71 KB |
| SquashSamplesString      | 48.71 us | 0.694 us | 0.649 us | 47.6074 | 47.6074 | 47.6074 | 449.71 KB |


 */

public class CountNodes222
{
    public int CountNodes(TreeNode root) {
        if (root == null)
            return 0;
        if (root.left == null && root.right == null)
            return 1;

        var left = CountLeft(root);
        var right = CountRight(root);
        if (left == right)
        {
            return (int)Math.Pow(2, left ) - 1;
        }

        return CountNodes(root.left) + CountNodes(root.right) + 1;
    }

    private int CountLeft(TreeNode root)
    {
        int count = 0;
        while (root != null)
        {
            count++;
            root = root.left;
        }
        return count;
    }
    private int CountRight(TreeNode root)
    {
        int count = 0;
        while (root != null)
        {
            count++;
            root = root.right;
        }
        return count;
    }
}

[MemoryDiagnoser]
public class TestArrayCopy
{
    [Params(10, 100, 1000, 10000)]
    public int ArrayLength;
    
    [Benchmark]
    public void ToArray()
    {
        List<int> list = new List<int>(ArrayLength);
        for (int i = 0; i < ArrayLength; i++)
        {
            list.Add(i);
        }
        var arr = list.ToArray();
    }
    
    [Benchmark]
    public void ToArrayWithDots()
    {
        List<int> list = new List<int>(ArrayLength);
        for (int i = 0; i < ArrayLength; i++)
        {
            list.Add(i);
        }

        int[] arr = [.. list];
    }
}

[MemoryDiagnoser]
public class Spans
{
    private static readonly List<Sample> Start = GenerateSamples(50);
    
    public static string GenerateRandomString()
    {
        Random random = Random.Shared;
        int length = random.Next(100, 500);
        Span<char> chars = stackalloc char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)random.Next(97, 123); // Generate lowercase letters
        }

        return new string(chars);
    }
    
    static List<Sample> GenerateSamples(int count)
    {
        List<Sample> samples = new List<Sample>();
        for (int i = 0; i < count; i++)
        {
            samples.Add(new Sample
            {
                S1 = GenerateRandomString(),
                S2 = GenerateRandomString(),
                S3 = GenerateRandomString(),
                S4 = GenerateRandomString(),
                S5 = GenerateRandomString()
            });
        }
        return samples;
    }
    
    [Benchmark]
    public void SquashSamplesNoSbSpans()
    {
        var comma = ",".AsSpan();
        int totalLen = 0;
        for (int i = 0; i < Start.Count; i++)
        {
            var cur = Start[i];
            
            var s1 = cur.S1;
            var s2 = cur.S2;
            var s3 = cur.S3;
            var s4 = cur.S4;
            var s5 = cur.S5;
            totalLen += s1.Length + s2.Length + s3.Length + s4.Length + s5.Length + (comma.Length * 4);
        }
        // if len > 500 kb use heap
        Span<char> result = totalLen > 524288 ? new char[totalLen] : stackalloc char[totalLen];
        var offset = 0;
        for (int i = 0; i < Start.Count; i++)
        {
            var cur = Start[i];
            
            var s1 = cur.S1.AsSpan();
            var s2 = cur.S2.AsSpan();
            var s3 = cur.S3.AsSpan();
            var s4 = cur.S4.AsSpan();
            var s5 = cur.S5.AsSpan();
           
            s1.CopyTo(result.Slice(offset, s1.Length));
            offset += s1.Length;
            comma.CopyTo(result.Slice(offset, comma.Length));
            offset += comma.Length;
            s2.CopyTo(result.Slice(offset, s2.Length));
            offset += s2.Length;
            comma.CopyTo(result.Slice(offset, comma.Length));
            offset += comma.Length;
            s3.CopyTo(result.Slice(offset, s3.Length));
            offset += s3.Length;
            comma.CopyTo(result.Slice(offset, comma.Length));
            offset += comma.Length;
            s4.CopyTo(result.Slice(offset, s4.Length));
            offset += s4.Length;
            comma.CopyTo(result.Slice(offset, comma.Length));
            offset += comma.Length;
            s5.CopyTo(result.Slice(offset, s5.Length));
        }
    
        _ = new string(result[..totalLen]);
    }

    [Benchmark]
    public void SquashSamplesSpans()
    {
        var comma = ",".AsSpan();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Start.Count; i++)
        {
            var cur = Start[i];
            
            var s1 = cur.S1.AsSpan();
            var s2 = cur.S2.AsSpan();
            var s3 = cur.S3.AsSpan();
            var s4 = cur.S4.AsSpan();
            var s5 = cur.S5.AsSpan();
            var totalLen = s1.Length + s2.Length + s3.Length + s4.Length + s5.Length + (comma.Length * 4);
            Span<char> result = stackalloc char[totalLen];
            var offset = 0;
            s1.CopyTo(result.Slice(offset, s1.Length));
            offset += s1.Length;
            comma.CopyTo(result.Slice(offset, comma.Length));
            offset += comma.Length;
            s2.CopyTo(result.Slice(offset, s2.Length));
            offset += s2.Length;
            comma.CopyTo(result.Slice(offset, comma.Length));
            offset += comma.Length;
            s3.CopyTo(result.Slice(offset, s3.Length));
            offset += s3.Length;
            comma.CopyTo(result.Slice(offset, comma.Length));
            offset += comma.Length;
            s4.CopyTo(result.Slice(offset, s4.Length));
            offset += s4.Length;
            comma.CopyTo(result.Slice(offset, comma.Length));
            offset += comma.Length;
            s5.CopyTo(result.Slice(offset, s5.Length));
            sb.Append(result);
        }

        _ = sb.ToString();
    }
    
    [Benchmark]
    public void SquashSamplesSpansParams()
    {
        var comma = ",".AsSpan();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Start.Count; i++)
        {
            var cur = Start[i];
            ConcatSpans(comma, sb, cur.S1, cur.S2, cur.S3, cur.S4, cur.S5);
        }

        _ = sb.ToString();
    }
    
    // Helper method to concatenate spans with a separator
    private static void ConcatSpans(ReadOnlySpan<char> separator, StringBuilder sb, params ReadOnlySpan<string> spans)
    {
        // Calculate total length: sum of span lengths + separator lengths
        int totalLen = 0;
        for (int i = 0; i < spans.Length; i++)
        {
            totalLen += spans[i].Length;
            if (i < spans.Length - 1) // Separator between spans (not after last)
            {
                totalLen += separator.Length;
            }
        }

        // Allocate result buffer on stack
        Span<char> result = stackalloc char[totalLen];
        int offset = 0;

        // Copy each span and separator into result
        for (int i = 0; i < spans.Length; i++)
        {
            spans[i].CopyTo(result.Slice(offset, spans[i].Length));
            offset += spans[i].Length;
            if (i < spans.Length - 1) // Add separator between spans
            {
                separator.CopyTo(result.Slice(offset, separator.Length));
                offset += separator.Length;
            }
        }

        sb.Append(result);
    }
    
    [Benchmark]
    public void SquashSamplesString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Start.Count; i++)
        {
            var cur = Start[i];
            var result = string.Join(',', cur.S1, cur.S2, cur.S3, cur.S4, cur.S5);
            sb.Append(result);
        }

        _ = sb.ToString();
    }
}

class Program
{
    public static IList<double> AverageOfLevels(TreeNode root) {
        List<double> ret = new List<double>();
        if (root == null) return ret;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var levelSize = queue.Count;
            var sum = 0.0;
            for (int i = 0; i < levelSize; i++)
            {
                var cur = queue.Dequeue();
                if (cur.left != null) queue.Enqueue(cur.left);
                if (cur.right != null) queue.Enqueue(cur.right);
                sum += cur.val;
            }
            
            ret.Add(sum / levelSize);
          
        }
        return ret;
    }
    
    public static int MincostTicketsWrong(int[] days, int[] costs) {
        // backtracking is wrong here, I failed to understand task
        var m1 = MincostTickets2(1, 0, days, costs, 0, 0);
        var m2 = MincostTickets2(2, 0, days, costs, 0, 0);
        var m3 = MincostTickets2(3, 0, days, costs, 0, 0);
        return Math.Min(m1, Math.Min(m2, m3));
    }

    static int MincostTickets2(int currentPass, int currentTicket, int[] days, int[] costs, int currentPrice, int currentDayIndex)
    {
        if (currentTicket >= days.Last())
            return currentPrice;
        var currentDay = days[currentDayIndex]; // 1
        while (currentTicket >= currentDay) // текущего билета хватает на текущий день
        {
            var diff = days[currentDayIndex + 1] - currentDay; // считаем сколько поездок останется
            currentDayIndex++; // переходим к следующему дню
            currentTicket -= diff; // уменьшаем количество поездок
            if (currentTicket < 0) return int.MaxValue; // если поездок не хватает, возвращаем макс значение так как нет смысла покупать билет такого типа
        }
        
        if (currentPass == 1)
        {
            currentTicket += 1;
            currentPrice += costs[0];
            var m11 = MincostTickets2(1, currentTicket, days, costs, currentPrice, currentDayIndex);
            var m21 = MincostTickets2(2, currentTicket, days, costs, currentPrice, currentDayIndex);
            var m31 = MincostTickets2(3, currentTicket, days, costs, currentPrice, currentDayIndex);
            return Math.Min(m11, Math.Min(m21, m31));
        }

        if (currentPass == 2)
        {
            currentTicket += 7;
            currentPrice += costs[1];
            var m12 = MincostTickets2(1, currentTicket, days, costs, currentPrice, currentDayIndex);
            var m22 = MincostTickets2(2, currentTicket, days, costs, currentPrice, currentDayIndex);
            var m32 = MincostTickets2(3, currentTicket, days, costs, currentPrice, currentDayIndex);
            return Math.Min(m12, Math.Min(m22, m32));
        }

        currentTicket += 30;
        currentPrice += costs[2];
        var m13 = MincostTickets2(1, currentTicket, days, costs, currentPrice, currentDayIndex);
        var m23 = MincostTickets2(2, currentTicket, days, costs, currentPrice, currentDayIndex);
        var m33 = MincostTickets2(3, currentTicket, days, costs, currentPrice, currentDayIndex);
        return Math.Min(m13, Math.Min(m23, m33));
        
    }

    public static int MincostTickets(int[] days, int[] costs) {
      int[] dp = new int[days.Length];
      Array.Fill(dp, int.MaxValue);
      return Helper(days, costs, dp, 0);
    }

    private static int Helper(int[] days, int[] costs, int[] dp, int currentDayIndex)
    {
        if (currentDayIndex >= days.Length) return 0; // дни закончились
        if (dp[currentDayIndex] != int.MaxValue) return dp[currentDayIndex]; // уже подсчитали этот день
        
        // 1 день
        var cost1 = Helper(days, costs, dp, currentDayIndex + 1) + costs[0]; // купили билет на этот день и двигаемся на следующий день (пусть он будет хоть через год, там и купим билет)
        
        // 7 дней 
        int currentOrNext = currentDayIndex;
        while (currentOrNext < days.Length && days[currentOrNext] < days[currentDayIndex] + 7) { // насколько хватит билета на 7 дней если считать от текущего индекса + 7 и не выйти за рамки всего массива
            currentOrNext++;
        }
        int cost7 = costs[1] + Helper(days, costs, dp, currentOrNext);
        
        // 30 дней 
        currentOrNext = currentDayIndex;
        while (currentOrNext < days.Length && days[currentOrNext] < days[currentDayIndex] + 30) {
            currentOrNext++;
        }
        int cost30 = costs[2] + Helper(days, costs, dp, currentOrNext);

        dp[currentDayIndex] = Math.Min(cost30, Math.Min(cost1, cost7));
        return dp[currentDayIndex];
    }

    static void Main(string[] args)
    {
        MincostTickets(new[] {1,4,6,7,8,20}, new[] {2,7,15});
    }
    
}