using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) return null;
            if (list1 == null) return list2;
            if (list2 == null) return list1;
            return MergeTwoListsInner(list1, list2, null);
        }

        public static ListNode MergeTwoListsInner(ListNode list1, ListNode list2, ListNode ret)
        {
            if (list1 == null && list2 == null) return ret;
            if (ret == null && list1 == null) return ret;
            if (ret == null && list2 == null) return ret;

            if (ret == null)
            {
                if (list1.val < list2.val)
                {
                    var r1 = new ListNode(list1.val);
                    return MergeTwoListsInner(list1.next, list2, r1);
                }

                var r2 = new ListNode(list2.val);
                return MergeTwoListsInner(list2.next, list1, r2);
            }

            var lastNode = GetLastNode(ret);
            if (list1 == null)
            {
                lastNode.next = list2;
                return ret;
            }
            if (list2 == null)
            {
                lastNode.next = list1;
                return ret;
            }
            
            if (list1.val < list2.val)
            {
                lastNode.next = new ListNode(list1.val);
                return MergeTwoListsInner(list1.next, list2, ret);
            }

            lastNode.next = new ListNode(list2.val);
            return MergeTwoListsInner(list1, list2.next, ret);
        }
        private static ListNode GetLastNode(ListNode listNode)
        {
            if (listNode.next == null) return listNode;
            return GetLastNode(listNode.next);
        }

        static void Main(string[] args)
        {
            var node4left = new ListNode(4);
            var node2left = new ListNode(2, node4left);
            var node1left = new ListNode(1, node2left);
            
            var node4r = new ListNode(4);
            var node3r = new ListNode(3, node4r);
            var node1r = new ListNode(1, node3r);

            var q = MergeTwoLists(node1left, node1r);
            Console.ReadKey();
        }
    }
}