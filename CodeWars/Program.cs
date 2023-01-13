using System;

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
        private static int _counter = 0;
        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            if (head.next == null)
            {
                return head;
            }

            Swap(head);
            return start;
        }

        private static bool exit = false;
        private static ListNode prev = null;
        private static ListNode start = null;
        private static void Swap(ListNode node)
        {
            if (exit || node == null) return;
           
            if (_counter == 0 && node.next != null)
            {
                //swap nodes
                var left = node;
                var right = node.next;
                if (prev == null)
                {
                    left.next = right.next;
                    right.next = left;
                    start = right;
                }
                else
                {
                    prev.next = right;
                    var rightNext = right.next;
                    right.next = left;
                    left.next = rightNext;
                }

                _counter = 1;
                prev = left;
                Swap(node);
            }

            if (node == null || node.next == null)
            {
                exit = true;
                return;
            };
            _counter--;
            prev = node;
            Swap(node.next);
        }

        static void Main(string[] args)
        {
            var fourth = new ListNode(4);
           var third = new ListNode(3, fourth);
            var second = new ListNode(2, third);
            //var second = new ListNode(2);
            var first = new ListNode(1, second);
            SwapPairs(first);
        }
    }
}