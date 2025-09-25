namespace LeetCodeTest
{
    public class BinaryTreeGeneral
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if ((p == null && q != null) || (p != null && q == null))
                return false;
            if (p?.val != q?.val)
                return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root is null) return root;
            TreeNode treeNode = root.left;
            root.left=root.right;
            root.right=treeNode;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }

        public bool IsSymmetric(TreeNode root)
        {
            return check(root.left, root.right);
        }
        public bool check(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;
            if (left?.val != right?.val)
                return false;
            return check(left?.left, right.right) && check(left.right, right.left);
        }

        //public TreeNode BuildTree(int[] preorder, int[] inorder)
        //{
        //    Cut()
        //}

        //public void Cut(out int[] left, out int[] right,int val, int[] inorder)
        //{

        //}

    }
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
    /*
             MaxDepth(3)
         ├── MaxDepth(9)
         │     ├── MaxDepth(null)=0
         │     └── MaxDepth(null)=0
         │     → return 1
         └── MaxDepth(20)
               ├── MaxDepth(15)
               │     ├── null=0
               │     └── null=0
               │     → return 1
               └── MaxDepth(7)
                     ├── null=0
                     └── null=0
                     → return 1
               → return max(1,1)+1 = 2
        
        return max(1,2)+1 = 3
     */
}
