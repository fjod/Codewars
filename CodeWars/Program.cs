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
    public bool hasDuplicate(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Add(nums[i]))
                return true;
        }
        return false;
    }
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
            return false;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (dict.TryGetValue(s[i], out int value))
                dict[s[i]] = ++value;
            else
                dict[s[i]] = 1;
            
            if (dict.TryGetValue(t[i], out int v2))
                dict[t[i]] = --v2;
            else
                dict[t[i]] = -1;
        }
        foreach (var kvp in dict)
        {
            if (kvp.Value != 0)
                return false;
        }
        return true;
    }
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (dict.TryGetValue(complement, out int index))
            {
                return [index, i];
            }
            dict[nums[i]] = i;
        }
        
        return [];
    }
    public List<List<string>> GroupAnagrams(string[] strs) {
        /* another way is to use count of chars in string (26 length array, create one array for all hashing) and hash it via
         var hashCode = new HashCode(); foreach (int value in intArray) 
        {
            hashCode.Add(value);
        }
        */
        int getHash(string str1)
        {
            var a = str1.ToCharArray();
            Array.Sort(a);
            return new string(a).GetHashCode();
        }

        Dictionary <int, List<string>> dict = new Dictionary<int, List<string>>();
        foreach (var str in strs)
        {
            var hash = getHash(str);
            if (dict.TryGetValue(hash, out var list))
            {
                list.Add(str);
            }
            else
            {
                dict[hash] = new List<string>{ str };
            }
        }
        
        return new List<List<string>>(dict.Values);
    }
    public static int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> countDict = new Dictionary<int, int> (); // value, amount
        Dictionary<int, List<int>> keysDict = new Dictionary<int, List<int>> ();
        
        foreach (var num in nums)
        {
            if (countDict.TryGetValue(num, out int count))
                countDict[num] = ++count;
            else
                countDict[num] = 1;
        }

        foreach (var kvp in countDict)
        {
            var key = kvp.Value; // value
            if (keysDict.TryGetValue(key, out var list))
            {
                list.Add(kvp.Key);
            }
            else
            {
                keysDict.Add(kvp.Value, new List<int>{kvp.Key});
            }
        }
/* better idea to use this
 * var minHeap = new PriorityQueue<int, int>();
    
    foreach (var kvp in freqMap)
    {
        minHeap.Enqueue(kvp.Key, kvp.Value);
        if (minHeap.Count > k)
            minHeap.Dequeue(); // Remove least frequent
    }
    
    // Extract results
    var result = new int[k];
    for (int i = k - 1; i >= 0; i--)
        result[i] = minHeap.Dequeue();
        
    return result;
 */
        var ret = keysDict.Keys.OrderByDescending(k=>k).Take(k);
        var retArr = new List<int>(k);
        int index = 0;
       
            foreach (var freq in ret)
            {
                var kvp = keysDict[freq];
                if (index < k)
                {
                    foreach (var val in kvp)
                    {
                        retArr.Add(val);
                        index++;
                        if (index == k)
                            break;
                    }
                }
                else
                    break;
            }
        
        var res = new int[k];
        for (int i = 0; i < k; i++)
        {
            res[i] = retArr[i];
        }
        return res;
    }

    public static int[] ProductExceptSelf(int[] nums) {
        
        if(nums.Length == 2)
            return new []{nums[1], nums[0]};
        
        var prefix = new int[nums.Length];
        prefix[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] = prefix[i-1] * nums[i];
        }
        
        var postfix = new int[nums.Length];
        postfix[nums.Length-1] = nums[nums.Length-1];
        for (int i = nums.Length-2; i != -1; i--)
        {
            postfix[i] = postfix[i+1] * nums[i];
        }
        
        var res = new int[nums.Length];
        res[0] = postfix[1];
        res[nums.Length-1] = prefix[nums.Length-2];
        for (int i = 1; i < nums.Length-1; i++)
        {
            res[i] = prefix[i-1]* postfix[i+1];
        }

        return res;
    }

    public int LongestConsecutive(int[] nums) {
        if(nums.Length == 0)
            return 0;
        if(nums.Length == 1)
            return 1;
      
        HashSet<int> hashSet = new HashSet<int>(nums.Length);
        foreach (int num in nums) {
            hashSet.Add(num);
        }
        int maxLength = 0;
    
        foreach (int num in hashSet) {
            // Only start counting if this is the beginning of a sequence
            if (!hashSet.Contains(num - 1)) {
                int currentNum = num;
                int currentLength = 1;
            
                // Count consecutive numbers
                while (hashSet.Contains(currentNum + 1)) {
                    currentNum++;
                    currentLength++;
                }
            
                maxLength = Math.Max(maxLength, currentLength);
            }
        }
    
        return maxLength;
    }
    
    public static bool IsPalindrome(string s) {
        if (string.IsNullOrEmpty(s))
            return true;
        if (string.IsNullOrWhiteSpace(s))
            return true;
        
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            var cur = s[i];
            if (char.IsLetterOrDigit(cur)) sb.Append(char.ToLowerInvariant(cur));
        }
        
        var str = sb.ToString();
        if (str.Length <=1)
            return true;
        var mid = str.Length / 2;
        for (int i = 0; i <= mid; i++)
        {
            var s1 = str[i];
            var s2 = str[str.Length - i - 1];
            if (s1 != s2)
                return false;
        }

        return true;
    }
    
    public int[] TwoSum2(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length - 1;
        while (left < right)
        {
            var sum = numbers[left] + numbers[right];
            if (sum == target)
            {
                return new[] { left + 1, right+1 };
            }

            if (sum > target)
                right--;
            else
                left++;
        }
        
        return null;
    }
    
    public  static int MaxArea(int[] heights) {
        int left = 0;
        int right = heights.Length - 1;
        int maxArea = (right-left)*Math.Min(heights[left], heights[right]);
        while (left < right)
        {
            if (heights[left] < heights[right])
            {
                left = left + 1;
                var newArea = (right-left)*Math.Min(heights[left], heights[right]);
                maxArea = Math.Max(maxArea, newArea);
            }
            else
            {
                right = right - 1;
                var newArea = (right-left)*Math.Min(heights[left], heights[right]);
                maxArea = Math.Max(maxArea, newArea);
            }
        }
        return maxArea;
    }
    
    public static int Trap(int[] height) {
        int left = 0;
        int center = left + 1;
        int right = center + 1;
        var sum = 0;
        while (right < height.Length)
        {
            int biggerLeft = findBiggerLeft(left, height);
            int biggerRight = findBiggerRight(right, height);
            var s = Math.Min(biggerLeft, biggerRight) - height[center];
            if (s > 0) sum += s;
            left++;
            center++;
            right++;
        }
        return sum;
    }

    private static int findBiggerLeft(int left, int[] height)
    {
        if (left == 0) return height[left];
        var maxV = height[left];
        var maxI = left;
        for (int i = 0; i < left; i++)
        {
            if (height[i] > maxV)
            {
                maxV = height[i];
                maxI = i;
            }
        }
        return maxI;
        
    }
    
    private static int findBiggerRight(int right, int[] height)
    {
        if (right == height.Length - 1) return height[right];
        var maxV = height[right];
        var maxI = right;
        for (int i = right; i < height.Length; i++)
        {
            if (height[i] > maxV)
            {
                maxV = height[i];
                maxI = i;
            }
        }
        return maxI;
    }

    public int MaxProfit(int[] prices) {
        if (prices.Length <=1) return 0;
        var buyIndex = 0; // has minimum buy price on the left of i
        var maxProfit = prices[1] -  prices[buyIndex]; // buy on 0 day, sell on 1 day
        for (int i = 2; i < prices.Length; i++) // move day forward
        {
            if (prices[i - 1] < prices[buyIndex]) // check if prev day has less buy price
            {
                buyIndex = i - 1;
            }
            var curProfit = prices[i] -  prices[buyIndex]; // profit of current day versys lowest index on the left
            if (curProfit > maxProfit)
            {
                maxProfit = curProfit;
            }
        }
        
        return maxProfit > 0 ? maxProfit : 0;
    }
    
    public int LengthOfLongestSubstring(string s)
    {
        var maxLength = 0;
        var left = 0;
        Dictionary<char, int> pos = new Dictionary<char, int>();   
        for (int i = 0; i < s.Length; i++)
        {
            var cur = s[i];
            if (pos.ContainsKey(cur))
            {
                // we saw this char before
                if (pos[cur] >= left)
                {
                    // move left to new boundary
                    left = pos[cur] + 1; // also skip duplicate
                }
            }
            
            pos[cur] = i; // update current char position
            maxLength = Math.Max(maxLength, i - left + 1);
        }
        
        return maxLength;
    }
    
    public int CharacterReplacement(string s, int k) {
        Dictionary<char, int> count = new Dictionary<char, int>();
        int res = 0;

        int left = 0, maxf = 0;
        for (int right = 0; right < s.Length; right++) {
            var cur = s[right];
            if (!count.TryAdd(cur, 1)) {
                count[cur]++;
            }

            maxf = Math.Max(maxf, count[cur]); // how many times we have seen this char in the window (i.e. what char is better to replace)

            while ((right - left + 1) - maxf > k) { // if we cant replace in window, move left
                count[s[left]]--; // decrease left freq
                left++; // move left forward
            }
            res = Math.Max(res, right - left + 1);
        }
        return res;
    }

    public static bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) return false;
        Dictionary<char, int> input = new Dictionary<char, int>();
        foreach (var c in s1)
        {
            if (!input.TryAdd(c, 1))
            {
                input[c]++;
            }
        }

        var l = s2.Length - s1.Length;
        Dictionary<char, int> subD = new Dictionary<char, int>();
        for (int i = 0; i <= l; i++)
        {
            var sub = s2.Substring(i, s1.Length);
            subD.Clear();
            foreach (var c in sub) // freq in substring
            {
                if (!subD.TryAdd(c, 1))
                {
                    subD[c]++;
                }
            }

            bool freqAreSame = true;
            foreach (var subKvp in subD) // if freq is the same for all chars, return true
            {
                if (!input.ContainsKey(subKvp.Key))
                {
                    freqAreSame = false;
                    break;
                }

                if (subKvp.Value != input[subKvp.Key])
                {
                    freqAreSame = false;
                    break;
                }
            }
            
            if (freqAreSame)
                return true;
        }
        return false;
    }
    
    public bool IsValid(string s) {
        if (s.Length <= 1) return false;
       Stack<char> stack = new Stack<char>();
       foreach (var c in s)
       {
           if (c == '(' || c == '[' || c == '{')
           {
               stack.Push(c);
           }
           else if (c == ')' || c == ']' || c == '}')
           {
               if (stack.Count == 0) return false;
               var pop = stack.Pop();
               if (c == ')' && pop != '(') return false;
               if (c == ']' && pop != '[') return false;
               if (c == '}' && pop != '{') return false;
           }
       }
       return stack.Count == 0;
    }
    
    public static int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        foreach (var token in tokens)
        {
            if (int.TryParse(token, out var i))
            {
                stack.Push(i);
            }
            else
            {
                if (token == "+")
                {
                    var o1 = stack.Pop();
                    var o2 = stack.Pop();
                    stack.Push(o1 + o2);
                }
                else if (token == "-")
                {
                    var o1 = stack.Pop();
                    var o2 = stack.Pop();
                    stack.Push(o2 - o1);
                }
                else if (token == "*")
                {
                    var o1 = stack.Pop();
                    var o2 = stack.Pop();
                    stack.Push(o1 * o2);
                }
                else if (token == "/")
                {
                    var o1 = stack.Pop();
                    var o2 = stack.Pop();
                    stack.Push(o2 / o1);
                }
            }
        }

        return stack.Pop();
    }
    
    public List<string> GenerateParenthesis(int n)
    {
        List<string> ret = new List<string>();
        GenerateInner(ret, 0, 0, n, "");
        return ret;
    }

    private void GenerateInner(List<string> ret, int open, int close, int n, string current)
    {
        if (open == n && close == n)
        {
            ret.Add(current);
            return;
        }
    
        if (open < n)
        {
            GenerateInner(ret, open + 1, close, n, current + "(");
        }
    
        if (close < open)
        {
            GenerateInner(ret, open, close + 1, n, current + ")");
        }
    }

    public static int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            var cur =  nums[mid];
            if (cur == target)
            {
                return mid;
            }

            if (cur > target)
            {
                right = mid - 1;
            }
            else if (cur < target)
            {
                left = mid + 1;
            }
        }
        return -1;
    }
    
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1; // min rate is 1
        int right = piles.Max(); // max rate is max in pile
        int res = right; // so far it's the fastest rate, but not optimal
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            var time = 0;
            foreach (int p in piles) {
                time += (int)Math.Ceiling((double)p / mid);
            }

            if (time <= h) {
                res = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        return res;
    }
    
    public ListNode ReverseList(ListNode head) {
        if (head == null)
        {
            return null;
        }

        if (head.next == null)
        {
            return head;
        }
        var cur = head;
        var next = head.next;
        head.next = null; // reverse first element
        while (next != null)
        {
            var tmp = next.next; // save next
            next.next = cur; // reverse arrow
            cur = next; // move forward current
            next = tmp;  // move forward next
        }
        return cur;
    }
    
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        var start = list1.val < list2.val ? list1 : list2;
        var other = start == list1 ? list2 : list1;
        var head = start;  // Keep reference to the head  - need to return it in the end
        var result = start;
        start = start.next;
        while (true)
        {
            if (other == null && start == null) break;
            if (other == null)
            {
                result.next = start;
                start = start.next;
                result = result.next;
                continue;
            }
            if (start == null)
            {
                result.next = other;
                other = other.next;
                result = result.next;
                continue;
            }

            if (start.val < other.val)
            {
                result.next = start;
                start = start.next;
                result = result.next;
                continue;
            }
            else
            {
                result.next = other;
                other = other.next;
                result = result.next;
                continue;
            }
        }

        return head;
    }
    
    public bool HasCycle(ListNode head)
    {
        if (head == null)
            return false;
        var slow = head;
        var fast = head;
       
        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
            if (slow.Equals(fast))
                return true;
        }
        return false;
    }
    
    public TreeNode InvertTree(TreeNode root) {
        if (root == null)
            return null;
        if (root.left == null && root.right == null)
            return root;
        (root.left, root.right) = (root.right, root.left);
        InvertTree(root.left);
        InvertTree(root.right);
     
        return root;
    }
    
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var len = 0;
        var s1 = head;
        while (s1 != null)
        {
            len++;
            s1 = s1.next;
        }

        if (len == n)
            return head.next;

        var nth = len - n;
        var s2 = head;
        // Move to the node just before the one to remove
        for (int i = 0; i < nth - 1; i++)
        {
            s2 = s2.next;
        }
   
        s2.next = s2.next.next;
        return head;
    }

    public void SelectionSort(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            var minIndex = i;
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] < nums[minIndex])
                {
                    minIndex = j;
                }
            }
            (nums[i], nums[minIndex]) = (nums[minIndex], nums[i]); // swap
        }
    }
    
    public int MaxDepth(TreeNode root) {
        if (root == null) return 0;
        return depth(root, 1);
    }

    private int depth(TreeNode root, int currentDepth)
    {
        if (root == null) return currentDepth;
        var left = currentDepth;
        var right = currentDepth;
        if (root.left != null)
        {
            left = depth(root.left, currentDepth + 1);
        }

        if (root.right != null)
        {
            right = depth(root.right, currentDepth + 1);
        }
        return Math.Max(left,right);
    }
    
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int res = 0;
        diam(root, ref res);
        return res;
    }
    
    private int diam(TreeNode root, ref int res)
    {
        if (root == null) return 0;
        var left = diam(root.left, ref res);
        var right = diam(root.right, ref res);
        res = Math.Max(res, left + right); // max on current level

        return 1 + Math.Max(left,right); // return max to prev lvl
    }
    
    public bool IsBalanced(TreeNode root) {
        if (root == null) return true;
        var h = Height(root);
        return h.isBalanced;
    }

    struct balanceInfo
    {
        public bool isBalanced;
        public int height;
    }
    
    balanceInfo Height(TreeNode root) {
        if (root == null) {
           return new balanceInfo { isBalanced = true, height = 0 };
        }
        
        var left = Height(root.left);
        var right = Height(root.right);
        var balanced = left.isBalanced && right.isBalanced && Math.Abs(left.height - right.height) <= 1;
        var height = 1 + Math.Max(left.height, right.height);
        return new balanceInfo { isBalanced = balanced, height = height };
    }
    
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p == null && q != null) return false;
        if (q == null && p != null) return false;
        if (p.val != q.val) return false;
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
    
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if (subRoot == null) {
            return true;
        }
        if (root == null) {
            return false;
        }

        if (IsSameTree(root, subRoot)) { // find the same tree - return true
            return true;
        }
        return IsSubtree(root.left, subRoot) || // tree is not the same - keep looking in left and right subtrees
               IsSubtree(root.right, subRoot);
    }
    
    public List<int> RightSideView(TreeNode root)
    { //dfs - my solution xD
        if (root == null) return new List<int>();
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict.Add(0, root.val);
        RightSide(dict, root.right, 1);
        LeftSide(dict, root.left, 1);
        return dict.Values.ToList();
    }

    private void RightSide(Dictionary<int, int> dict, TreeNode root, int level)
    {
        if (root == null) return;
        dict.Add(level, root.val);
        if (root.right != null)
        {
            RightSide(dict, root.right, level + 1);
        }
        else if (root.left != null)
        {
            RightSide(dict, root.left, level + 1);
        }
    }
    
    private void LeftSide(Dictionary<int, int> dict, TreeNode root, int level)
    {
        if (root == null) return;
        if (!dict.ContainsKey(level))
        {
            dict.Add(level, root.val);
        }
        if (root.right != null)
        {
            LeftSide(dict, root.right, level + 1);
        }
        else if (root.left != null)
        {
            LeftSide(dict, root.left, level + 1);
        }
    }
    
    public List<int> RightSideViewBfs(TreeNode root)
    { 
        if (root == null) return new List<int>();
        List<int> res = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode right = null;
            var levelSize = queue.Count; // check level size and find the rightmost item on the level
            for (int i = 0; i < levelSize; i++)
            {
                var current = queue.Dequeue();
                right = current;
                if (current != null)
                {
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }
            if (right != null)
                res.Add(right.val);
        }
        return res;
    }
    public int GoodNodes(TreeNode root)
    {
        if (root == null) return 0;
        int total = 1;
        GoodInner(root.left, root.val, ref total);
        GoodInner(root.right, root.val, ref total);
        return total;
    }

    private void GoodInner(TreeNode root, int prevMax, ref int total)
    {
        if (root == null) return;
        if (root.val >= prevMax)
        {
            total++;
            prevMax = root.val;
        }
        GoodInner(root.left, prevMax, ref total);
        GoodInner(root.right, prevMax, ref total);
    }
    
    public int GoodNodesBfs(TreeNode root)
    {
        if (root == null) return 0;
        int total = 0;
        Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>(); // track prevMax for the node, we cant use global var here, because prevMax is different for each branch
        queue.Enqueue((root, int.MinValue));
        while (queue.Count > 0)
        {
            var (current, prevMax) = queue.Dequeue();
            if (current.val >= prevMax)
            {
                total++;
                prevMax = current.val;
            }
            if (current.left != null)
                queue.Enqueue((current.left, Math.Max(prevMax, current.val)));
            if (current.right != null)
                queue.Enqueue((current.right, Math.Max(prevMax, current.val)));
        }
        
        return total;
    }

    public bool IsValidBST(TreeNode root) {
        if (root == null) return true; // must track all range of parents, not only immediate one
    
        Queue<(TreeNode node, long min, long max)> queue = new Queue<(TreeNode, long, long)>();
        queue.Enqueue((root, long.MinValue, long.MaxValue));
    
        while (queue.Count > 0)
        {
            var (node, min, max) = queue.Dequeue();
        
            // Check if current node violates the range
            if (node.val <= min || node.val >= max)
                return false;
        
            // Left child must be in range (min, node.val)
            if (node.left != null)
                queue.Enqueue((node.left, min, node.val));
        
            // Right child must be in range (node.val, max)
            if (node.right != null)
                queue.Enqueue((node.right, node.val, max));
        }
    
        return true;
    }
    
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> test = new PriorityQueue<int, int>();
        foreach (var i in stones)
        {
            test.Enqueue(i, -i);
        }
        while (test.Count > 1)
        {
            var first = test.Dequeue(); // -6
            var second = test.Dequeue(); // -4
            if (second > first) // -4 > -6
            {
                test.Enqueue(first - second, (first - second)); // -2 , -2
            }
        }
        
        test.Enqueue(0, 0); // might be empty, so add 0
        return Math.Abs(test.Peek());
    }
    
    public List<List<int>> Subsets(int[] nums) {
  
        var hashedLists = new Dictionary<int, List<int>>();
        SubsetsInner(hashedLists, nums, new List<int>(), 0);
        return hashedLists.Values.ToList();
    }

    private void SubsetsInner(Dictionary<int, List<int>> hashedLists, int[] nums, List<int> current, int start)
    {
        if (current.Count > nums.Length)
            return;
        var hash = 0;
        for (int i = 0; i < current.Count; i++)
        {
            var t = HashCode.Combine(i, current[i]);
            hash = HashCode.Combine(hash, t);
        }
        if (!hashedLists.ContainsKey(hash))
        {
            hashedLists.Add(hash, new List<int>(current));
        }
        for (int i = start; i < nums.Length; i++)
        {
            //if (!current.Contains(nums[i])) // avoid duplicates
            {
                current.Add(nums[i]);
                SubsetsInner(hashedLists, nums, current, start + 1);
                current.RemoveAt(current.Count - 1); // backtrack
            }
        }
    }
    
    public static int ClimbStairs(int n) {
        if  (n <= 2) return n;
        var arr = new int[n+1];
        arr[0] = 0;
        arr[1] = 1;
        arr[2] = 2;
        if (arr[n] != 0) return arr[n];
        return ClimbStairsInner(n, arr);
    }
    public static int ClimbStairsInner(int n, int[] arr) {
       if (arr[n] != 0) return arr[n];
        arr[n] =  ClimbStairsInner(n - 1, arr) + ClimbStairsInner(n - 2, arr);
        return arr[n];
    }
    
    public static bool CanJump(int[] nums) {
        bool?[] memo = new bool?[nums.Length];
        return CanJumpFrom(0, nums, memo);
    }

    private static bool CanJumpFrom(int position, int[] nums, bool?[] memo)
    {
        if (position >= nums.Length - 1) return true;
                             if (memo[position] != null) return memo[position].Value;
                             int maxJump = nums[position];
                             for (int jumpSize = 1; jumpSize <= maxJump; jumpSize++) {
                                 if (CanJumpFrom(position + jumpSize, nums, memo)) {
                                     memo[position] = true;
                                     return true;
                                 }
                             }
                         
                             memo[position] = false;
                             return false;
    }

    public int CountNicePairs(int[] nums) {
        Dictionary<int ,int> dict = new Dictionary<int, int>();
        long totalCount = 0;
        int MOD = 1000000007;
        foreach (var i in nums)
        {
            var revi = ReverseNumber(i);
            var dif = i - revi;
            if (dict.TryGetValue(dif, out int count))
            {
                totalCount += count;
                dict[dif] = count + 1;
            }
            else
            {
                dict[dif] = 1;
            }
        }

        return (int)(totalCount % MOD);
    }
    
    public static int ReverseNumber(int number)
    {
        int reversed = 0;
        int sign = number < 0 ? -1 : 1;
        number = Math.Abs(number);
    
        while (number > 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }
    
        return reversed * sign;
    }
    
    public int MaxWidthOfVerticalArea(int[][] points)
    {
        HashSet<int> hashSet = new HashSet<int>(points.Length);
        foreach (var p in points)
        {
            hashSet.Add(p[0]);
        }
        
        int[] ret = new int[hashSet.Count];
        hashSet.CopyTo(ret);
        Array.Sort(ret);

        int minDist = 0;
        for (int i = 0; i < ret.Length - 1; i++)
        {
            minDist = Math.Max(minDist, Math.Abs(ret[i] - ret[i + 1]));
        }
        
        return minDist;
    }
    
    /*
     * List<int> x = new List<int>(points.Length);
        foreach (var p in points)
        {
            if (!x.Contains(p[0])) x.Add(p[0]);
        }
        x = x.OrderBy(x => x).ToList();
        

        int minDist = 0;
        for (int i = 0; i < x.Count - 1; i++)
        {
            minDist = Math.Max(minDist, Math.Abs(x[i] - x[i + 1]));
        }
        
        return minDist;
    }
     */

    public static int ClosestTarget(string[] words, string target, int startIndex)
    {
        List<int> targetIndex = new List<int>(); 
            ;
        for (int i = 0; i < words.Length; i++)
        {
            var cur = words[i];
            if (cur == target)
            {
                targetIndex.Add(i);
            }
        }

        if (targetIndex.Count == 0)
            return -1;

        if (targetIndex.Count == 1 && targetIndex[0] == startIndex)
            return 0;

        var min = int.MaxValue;
        foreach (var t in targetIndex)
        {
            if (startIndex > t)
            {
                var forward = startIndex - t;
                var backward = t + words.Length - startIndex;
                min = Math.Min(Math.Min(forward, backward), min);
                continue;
            }

            var forward2 = t - startIndex;
            var backward2 = words.Length - t + startIndex;
            min = Math.Min(Math.Min(forward2, backward2), min);
        }

        return min;
    }
    
    
    public int MinimumSwap(string s1, string s2)
    {// this code does not work, one should not try to swap at all, just count swaps
        // and I am bad at math
        /*
         * int xy = 0, yx = 0;
        for (int i = 0; i < s1.Length; i++) {
            if (s1[i] == 'x' && s2[i] == 'y') xy++;
            else if (s1[i] == 'y' && s2[i] == 'x') yx++;
        }
        if ((xy + yx) % 2 != 0) return -1;
        return xy / 2 + yx / 2 + (xy % 2) * 2;
        
         int[] sample = new int[2];
        int len = s1.Length;
        for(int i = 0; i < len; i++)
        {
            char c1 = s1[i], c2 = s2[i];
            if(c1 == 'x' && c2 == 'y')
                sample[0]++;
            else if(c1 == 'y' && c2 == 'x')
                sample[1]++;
        }

        int res = 0;
        res += sample[0]/2;
        sample[0] %= 2;
        res += sample[1]/2;
        sample[1] %= 2;
        if(sample[0] != sample[1])
            return -1;
        
        if(sample[0] == 1)
            res += 2;

        return res;
         */
        char[] arr1 = s1.ToCharArray();
        char[] arr2 = s2.ToCharArray();
        int totalCount = 0;
        
        for (int i = 0; i < arr1.Length; i++) {
            if (arr1[i] != arr2[i]) {
                // Find a position j where swapping helps
                bool swapped = false;
                for (int j = i + 1; j < arr2.Length; j++) { // First Loop (1-Swap Attempt)
                    if (arr1[i] == arr2[j] && arr2[i] == arr1[j]) {  // looking for xy && yx or yx && xy
                        (arr1[i], arr2[j]) = (arr2[j], arr1[i]);
                        totalCount++;
                        swapped = true;
                        break;
                    }
                }
                if (!swapped) { // Second Loop (2-Swap Attempt) xx yy
                    for (int j = i + 1; j < arr2.Length; j++) {
                        if (arr1[i] == arr2[j]) {
                            // Swap to create a fixable pattern
                            (arr1[i], arr2[j]) = (arr2[j], arr1[i]);
                            totalCount++;
                            // Need another swap to fix the new mismatch
                            for (int k = i + 1; k < arr2.Length; k++) {
                                if (arr1[i] == arr2[k] && arr2[i] == arr1[k]) {
                                    (arr1[i], arr2[k]) = (arr2[k], arr1[i]);
                                    totalCount++;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
        
        // Verify strings are equal
        for (int i = 0; i < arr1.Length; i++) {
            if (arr1[i] != arr2[i]) {
                return -1; // Impossible to make equal
            }
        }
        
        return totalCount;
    }
    
    public int[] NextGreaterElements(int[] nums) {
        int[] ret = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            var cur = nums[i];
            bool found = false;
            // go forward
            for (int j = i; j < nums.Length; j++)
            {
                var next = nums[j];
                if (next > cur)
                {
                    ret[i] = next;
                    found = true;
                    break;
                }
            }
            if (found) continue;
            // go from start to i
            for (int j = 0; j < i; j++)
            {
                var next = nums[j];
                if (next > cur)
                {
                    ret[i] = next;
                    found = true;
                    break;
                }
            }
            if (!found) ret[i] = -1;
        }
        return ret;
    }
    
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

    static void Main(string[] args)
    {
        AverageOfLevels(new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))));
    }
    
}