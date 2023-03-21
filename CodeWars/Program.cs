using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        private Dictionary<Node, Node> map = new Dictionary<Node, Node>();
        public Node CloneGraph(Node node)
        {
            if (node == null) return null;
            if (!map.ContainsKey(node))
            {
                map.Add(node, new Node(node.val));
                foreach (var n in node.neighbors)
                {
                    map[node].neighbors.Add(CloneGraph(n));
                }
            }

            return map[node];
        }

        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }


}