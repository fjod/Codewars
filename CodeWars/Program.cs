using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CodeWars
{
    public class TreeNode {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
     }

    class Program
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)  
            {  
                // If both n1 and n2 are smaller than 
                // root, then LCA lies in left  
                if (root.val > p.val && root.val > q.val)  
                    root = root.left;  
   
                // If both n1 and n2 are greater than  
                // root, then LCA lies in right  
                else if (root.val < p.val && root.val < q.val)  
                    root = root.right;  
   
                else break;  
            }  
            return root;  
        }
        
        static void Main(string[] args)
        {
          
            Console.ReadKey();
        }
    }
}

//235. Lowest Common Ancestor of a Binary Search Tree
//I had to google solution because I did not know that in BST all left right values are less than all right
// left branches has smaller values that right branches from the top!
//the solution is trivial