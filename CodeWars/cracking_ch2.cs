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
}