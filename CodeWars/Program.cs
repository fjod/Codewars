namespace CodeWars
{
    class Program
    {
        public static TreeNode SearchBST(TreeNode root, int val) {
            if (root == null) return null;
            if (root.val == val) return root;
            if (val > root.val  && root.right != null) return SearchBST(root.right, val);
            if (val < root.val && root.left != null) return SearchBST(root.left, val);
            return null;
        }


        static void Main(string[] args)
        {
            var node1 = new TreeNode {val = 1};
            var node3 = new TreeNode {val = 3};
            var node2 = new TreeNode {val = 2, left = node1, right = node3};
            var node7 = new TreeNode {val = 7};
            var node4 = new TreeNode {val = 4, left = node2, right = node7};
            var ret = SearchBST(node4, 2);
        }
    }
}