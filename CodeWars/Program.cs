namespace CodeWars
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private static bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;// both null - no children, ok
            if (left == null || right == null) return false; // one is null - no symmetry
            return (left.val == right.val && //values are equal  
                    IsMirror(left.left, right.right) && // outer children values are ok
                    IsMirror(left.right, right.left) // outer children values are ok
                );
        }

        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return IsMirror(root.left, root.right);
        }

        static void Main(string[] args)
        {
        }
    }
}