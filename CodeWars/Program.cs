using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace CodeWars;

/*
| Method    | Mean     | Error     | StdDev    |
|---------- |---------:|----------:|----------:|
| StartMine | 3.307 us | 0.0232 us | 0.0193 us |
| StartGrok | 3.255 us | 0.0628 us | 0.0617 us | 
 */
public class RemoveLinkedListElement
{
    private ListNode ListNodeGenerate()
    {
        Random random = new Random();
        var head = new ListNode(1);
        var current = head;
        for (int i = 2; i <= 1000; i++)
        {
            current.next = new ListNode(random.Next(0, 100));
            current = current.next;
        }
        return head;
    }
    
    [Benchmark]
    public ListNode StartMine()
    {
        var root = ListNodeGenerate();
        return RemoveElementsMine(root, 7);
    }
    
    [Benchmark]
    public ListNode StartGrok()
    {
        var root = ListNodeGenerate();
        return RemoveElementsGrok(root, 7);
    }
    
    public ListNode RemoveElementsGrok(ListNode head, int val) {
        // Create a dummy node to handle cases where head needs to be removed
        ListNode dummy = new ListNode(0, head);
        ListNode current = dummy;

        // Traverse the list
        while (current.next != null) {
            if (current.next.val == val) {
                // Skip the node with the target value
                current.next = current.next.next;
            } else {
                // Move to the next node
                current = current.next;
            }
        }

        return dummy.next;
    }
    
    public ListNode RemoveElementsMine(ListNode head, int val) {
        if (head == null)
            return head;

        // skip all elements at the start
        if (head.val == val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }

            // all elements are removed?
            if (head == null)
            {
                return null;
            }
        }
        
        var current = head;
        while (current.next != null)
        {
            if (current.next.val == val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }

        return head;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<RemoveLinkedListElement>();
    }
}