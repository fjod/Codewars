using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public class MinStack
        {
            private Node head;

            public MinStack()
            {
                head = null;
            }

            // each node has a value and a minValue for stack for time when the node was added,
            // so on top operation it returns correct value
            public void Push(int x)
            {
                head = head == null ? new Node(x, x) 
                                    : new Node(x, Math.Min(x, head.MinValue), head);
            }

            public void Pop()
            {
                head = head.Next;
            }

            public int Top()
            {
                return head.Value;
            }

            public int GetMin()
            {
                return head.MinValue;
            }

            private class Node
            {
                public Node(int value, int minValue, Node next = null)
                {
                    Value = value;
                    MinValue = minValue;
                    Next = next;
                }


                public int Value { get; }
                public int MinValue { get; }
                public Node Next { get; }
            }
        }
        

        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}