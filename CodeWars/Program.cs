using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }

        public static bool IsValidBST(TreeNode current, long low, long high)
        {
            if (current == null) return true;
            if (current.val <= low || current.val >= high) return false;

            return IsValidBST(current.left, low, current.val) && IsValidBST(current.right, current.val, high);
        }
        //76 / 82 testcases passed
        public bool IsValidBST2(TreeNode root)
        {
            if (root == null) return true;
            bool left = true;
            bool right = true;
            if (root.left != null)
            {
                if (root.left.val >= root.val) return false;
                left = IsValidBST(root.left);
            }
            
            if (root.right != null)
            {
                if (root.right.val <= root.val) return false;
                right = IsValidBST(root.right);
            }

            return left && right && isValidSiblings(root.left, root.right);
        }

        bool isValidSiblings(TreeNode left, TreeNode right)
        {
            if(left == null && right == null) return true;
            if (left != null && right != null)
            {
                int? leftVal = left.val;
                int? rightVal = right.val;
                int? leftLeft = left.left?.val;
                int? leftright = left.right?.val;
                int? rightLeft = right.left?.val;
                int? rightRight = right.right?.val;
                List<int?> lefts = new List<int?> {leftVal, leftLeft, leftright};
                List<int?> rInts = new List<int?> {rightVal, rightLeft, rightRight};
                foreach (var l in lefts)
                {
                    if (rInts.Any(r => r <= l)) return false;
                }
            }
            
            return true;
        }

        static void Main(string[] args)
        {
            var node27 = new TreeNode {val = 27};
            var node19 = new TreeNode {val = 19};
            var node26 = new TreeNode {val = 26, left = node19};
            var node56 = new TreeNode {val = 56, left = node27};
            var node47 = new TreeNode {val = 47, right = node56};
            var node32 = new TreeNode {val = 32, right = node47, left = node26};
            var test = IsValidBST(node32);
        }
    }
}