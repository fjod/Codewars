using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

public class Averages
{
/*
 *  | Method          | Mean     | Error    | StdDev   | Median   |
    |---------------- |---------:|---------:|---------:|---------:|
    | FindMaxAverage  | 646.4 ns | 12.85 ns | 19.62 ns | 641.4 ns |
    | FindMaxAverage2 | 276.8 ns |  5.52 ns | 11.02 ns | 272.2 ns |

 */
    

    private List<int> nums = new List<int>
    {
        482, 163, 412, -726, 688, -906, -182, 157, -592, -954, 424, -13, -238, -928, 456, 871, -825, -894, 312, -749,
        -953, 977, 918, 672, 47, -919, 359, -593, 827, -750, 703, 820, -55, -911, 445, -412, -517, 22, -267, -302, -920,
        613, 944, -353, -675, -212, 321, 873, -955, -856, 268, 953, 149, 820, -194, 621, 453, 930, 424, -120, 409, -455,
        -261, 14, -244, -869, -714, 850, 949, -877, -215, 45, -718, -334, -596, 765, 238, -779, -203, 13, 637, 7, 148,
        44, -541, -892, -944, -186, -514, 852, 202, -759, -169, 975, -272, 280, 417, -1, -513, 1, -169, 844, 965, -743,
        -217, 34, 836, -940, 25, 187, 869, -653, 567, -25, 883, -760, -964, 861, -826, 257, -564, 12, 189, 983, 415,
        -961, 127, -729, 42, -795, -463, -20, 594, 405, -722, 806, 509, 993, 747, 503, 479, 330, 161, 98, 535, -588,
        -590, 637, 470, -736, 439, -531, -32, -357, -535, -699, -366, 416, -87, 800, 117, -892, -638, 752, -866, 619,
        -325, 716, 743, -423, -126, 752, 756, -178, -392, 908, 572, 117, 366, -180, 204, -735, -337, -582, 137, 818,
        714, 492, 806, 79, 763, 245, 730, -237, -141, 995, 52, -560, -504, -920, -923, -366, -101, -703, -527, -733,
        -115, -512, 454, 43, 969, -391, 702, -676, -436, 541, 111, 805, 524, 608, -452, 542, -834, 979, -875, -127, 584,
        432, -895, 33, 468, 857, 77, 84, -418, 635, 559, -838, 99, -691, 185, 58, 599, -328, -261, 409, -393, 56, -730,
        -133, -105, -616, -624, -820, -146, -644, 388, 703, -942, -571, 661, 5, -290, -962, 358, -192, -231, -248, -369,
        240, -5, -796, -667, -899, -321, -476, 190, -37, -171, -269, -290, 24, -288, 30, 747, 327, -140, -852, -802,
        -84, -609, -836, 332, 407, 360, 901, 561, 202, 780, 669, 340, 114, 190, 170, 727, 794, -858, -891, 224, 968,
        -874, -905, 613, -328, -148, -566, -853, -509, -533, 779, -620, -530, -342, -977, 264, -912, 197, 443, 822,
        -906, -31, 308, -381, -145, -71, 321, -937, 1000, 972, 332, 597, -902, 450, -939, -416, 776, -105, -517, -237,
        298, -646, 502, 455, -73, -623, 22, 831, 220, 427, 292, -803, -93, 576, -29, 450, -827, -282, -564, -377, -411,
        -42, 565, -913, -35, 170, 31, -716, -223, -295, 234, 598, -84, 321, 866, -343, 403, 730, 977, -880, -591, 982,
        373, 737, -334, 880, -563, 174, -362, -737, 988, 503, -770, 51, -914, 279, 2, 229, 758, -839, 141, -196, 358,
        683, 68, -559, -234, -704, -76, -15, 648, 167, 886, -828, 228, 412, 26, -857, 746, 790, 946, -478, 667, 684,
        -195, 968, 288, -35, 559, -907, 785, 872, -736, -156, -644, 941, -644, 734, -420, 990, 786, -682, -767, -57,
        335, 97, -163, 596, 295, -158, 825, 603, -638, 451, 379, -517, -782, 605, 386, 972, 560, -335, -86, 500, 538,
        394, -668, -587, -587, 418, -610, -781, -155, 48, 442, -849, 750, -216, 627, -561, -979, -847, -100, 423, 357,
        -493, -141, 451, -13, -988, 981, 465, -848, -403, -517, 41, 623, -111, 982, 438, -988, -504, 380, 777, -229,
        768, -275, -944, 695, -222, -696, -929, 402, -56, 342, 159, 254, 153, -525, -82, 661, -389, -504, -992, 277,
        210, 655, -853, -799, 612, 88, -457, -602, -760, -373, -100, -430, -424, 341, -125, 621, 439, -87, 62, -300,
        389, -735, 420, -377, -111, -828, 406, -284, 596, -163, -859, -227, -883, 509, 903, 918, 141, 592, -218, -227,
        232, 72, 152, -888, 829, 387, 12, -450, -883, -783, -387, 354, -839, 444, 1, -563, -565, -300, -739, -798, 218,
        -573, -260, 437, 412, 726, 905, 324, 145, -145, 939, 681, 645, 180, -513, 866, -60, 62, 410, 974, 980, -777,
        -121, -229, -769, -129, 924, -723, 330
    };
    private int k = 4;
    [Benchmark]
    public double FindMaxAverage() {
        int max = int.MinValue;
        for (int i = 0; i <= nums.Count - k; i++){
            var newSum = 0;
            for (int j = i; j < i+k; j++)
            {
                newSum += nums[j];
            }
            max = Math.Max(max, newSum);
        }
        return max/(double)k;
    }
    
    [Benchmark]
    public double FindMaxAverage2()
    {
        var sum = nums[..k].Sum();
        var max = sum;
        
        for (var right = k; right < nums.Count; right++)
        {
            sum += nums[right] - nums[right - k];

            max = Math.Max(max, sum);
        }

        return (double)max / k;
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
    public struct B
    {
        public int i;
    }
    public class A
    {
        public string Q;
        public string T;
        public B qqq;
    }
    static void Main(string[] args)
    {
       var A = new A();
       Console.WriteLine(A.qqq.i);
       
    }
    
}
