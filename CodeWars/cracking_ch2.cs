using System.Numerics;

namespace CodeWars;

public static class cracking_ch2
{
    public static ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null) return head;
        var current = head;
        while (current.next != null)
        {
            var next = current.next;
            if (current.val == next.val)
            {
                while (next != null && current.val == next.val)
                {
                    next = next.next;
                }
                current.next = next == null ? null : next;
                current = next;
                if (current == null) break;
            }
            else
                current = next;
        }

        return head;
    }
    
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var n1 = Create(l1);
        var n2 = Create(l2);
        var str = (n1 + n2).ToString();
            
        var ret = new ListNode(int.Parse(str[^1].ToString()));
        var start = ret;
        for (int i = str.Length - 2; i >=0; i--)
        {
            var node =  new ListNode(int.Parse(str[i].ToString()));
            ret.next = node;
            ret = node;
        }

        return start;
    }

    private static BigInteger Create(ListNode l1)
    {
        var node = l1;
        BigInteger ret = 0;
        BigInteger counter = 1;
        while (node != null)
        {
            ret += counter * node.val;
            counter *= 10;
            node = node.next;
        }

        return ret;
    }
}