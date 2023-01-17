using System;
using System.Runtime.Versioning;

namespace CodeWars
{

  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }

      public override string ToString()
      {
          return $"{val} + {next == null}";
      }
  }

    class Program
    {
        public static ListNode ReverseList(ListNode head) {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode prev = null;
            ListNode current = head;
            while (current != null)
            {
                ListNode nextForCurrent = current.next;
                current.next = prev;
                prev = current;
                current = nextForCurrent;
            }

            return prev;
        }

        public static ListNode ReverseListRec(ListNode current) {
            if (current.next == null)
            {
                return current;
            }

            ListNode last = ReverseListRec(current.next);
            current.next.next = current;
            current.next = null;
            return last;
        }
 
       

        static void Main(string[] args)
        {
            var third = new ListNode(3);
            var second = new ListNode(2, third);
            //var second = new ListNode(2);
            var first = new ListNode(1, second);
            ReverseListRec(first);
        }
    }
}