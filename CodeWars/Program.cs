using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Runtime;


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

static class TestSpan
{
    extension<T>(Span<T> span) where T : INumber<T>
    {
        public T TestSum()
        {
            T ret = T.Zero;
            foreach (var v in span)
            {
                ret += v;
            }
            return ret;
        }
    }
    public static T TestSum2<T>(this Span<T> span) where T : INumber<T>
    {
        T ret = T.Zero;
        foreach (var v in span)
        {
            ret += v;
        }
        return ret;
    }
}

class Program
{
    public static string LargestPalindromic(string num) {
        int[] digits = new int[10];
        foreach (var c in num)
        {
            var number = int.Parse(c.ToString()); 
            digits[number]++;
        }
        
        // do we have single digits? if we do, place largest in the middle
        string ret = "";
        for (int i = digits.Length - 1; i >=0; i--)
        {
            if (digits[i] % 2 == 1) // is even, so put it in the middle
            {
                ret = i.ToString();
                digits[i] -= 1;
                break; // place only one
            }
        }
        
        // add all pairs 
        var start = 1;
        if (digits.Skip(1).Any(d => d > 1)) start = 0; // if there are any pairs, then we can use zeroes
        for (int i = start; i < digits.Length; i++)
        {
            var cur = digits[i];
            if (cur < 2) continue; // now skip all singles
            while (cur > 1) // keep adding to both sides
            {
                ret = $"{i}{ret}{i}"; 
                cur -= 2;
            }
        }
        
        return String.IsNullOrEmpty(ret) ? "0" : ret;
    }

    static void Main(string[] args)
    {

        LargestPalindromic("123");
    }
    
}
