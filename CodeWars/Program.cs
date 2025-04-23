using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CodeWars;


namespace CodeWars
{
   /*
| Method      | Mean     | Error     | StdDev    |
|------------ |---------:|----------:|----------:|
| StartNonRec | 6.188 us | 0.1059 us | 0.0990 us |
| StartRec    | 6.199 us | 0.1213 us | 0.1534 us |
really no diff here, so I wonder why leetcode asks for non-recursive version
    */
    public class PreorderTraversal
    {
        private static TreeNode GenerateTree()
        {
            var root = new TreeNode(1);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int value = 2; // Start assigning values from 2
            while (value <= 1000)
            {
                var current = queue.Dequeue();

                // Add left child
                if (value <= 1000)
                {
                    current.left = new TreeNode(value++);
                    queue.Enqueue(current.left);
                }

                // Add right child
                if (value <= 1000)
                {
                    current.right = new TreeNode(value++);
                    queue.Enqueue(current.right);
                }
            }

            return root;
        }
        [Benchmark]
        public IList<int> StartNonRec()
        {
            var root = GenerateTree();
            return PreorderTraversalNonRec(root).ToList();
        }
        
        public IList<int> PreorderTraversalNonRec(TreeNode root) {
            if (root == null)
            {
                return new List<int>(0);
            }
            IList<int> result = new List<int>();
            Order(root, result);
            return result;
        }
        
        [Benchmark]
        public IList<int> StartRec()
        {
            var root = GenerateTree();
            return PreorderTraversalRec(root).ToList();
        }
        
       
        public IList<int> PreorderTraversalRec(TreeNode root) {
            if (root == null)
            {
                return new List<int>(0);
            }
            IList<int> result = new List<int>();
            OrderRec(root, result);
            return result;
        }

        void Order(TreeNode node, IList<int> result)
        {
            while (true)
            {
                if (node == null)
                {
                    return;
                }

                result.Add(node.val);
                if (node.left != null)
                {
                    Order(node.left, result);
                }

                // we are at most depth for left side here, so time to add rights and then return back up
                if (node.right != null)
                {
                    node = node.right;
                    continue;
                }

                break;
            }
        }
        
        void OrderRec(TreeNode node, IList<int> result)
        {
            if (node == null)
            {
                return;
            }
            result.Add(node.val);
            if (node.left != null)
            {
                Order(node.left, result);
            }
            if (node.right != null)
            {
                Order(node.right, result);
            }
        }
    }
    
    class Program
    {
       
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<PreorderTraversal>();
        }
    }
}