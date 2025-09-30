using System.Xml.Linq;

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

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder is null || !preorder.Any() ||
               inorder is null || !inorder.Any()) return null;

            TreeNode root = new TreeNode(preorder[0]);
            int middle = Array.IndexOf(inorder, preorder[0]);
            root.left = BuildTree(preorder[1..(middle + 1)], inorder[..middle]);
            root.right = BuildTree(preorder[(middle + 1)..], inorder[(middle + 1)..]);

            return root;
        }
        public TreeNode BuildTree2(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0 && postorder.Length == 0) return null;

            int a=postorder.Last();
            int index=Array.IndexOf(inorder, a);
            TreeNode root = new TreeNode(a);

            root.right = BuildTree2(inorder[(index+1)..], postorder[index..^1]);
            root.left = BuildTree2(inorder[..index], postorder[..index]);

            return root;
        }

        public Node Connect(Node root)
        {
            if (root == null) return null;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int size = q.Count;
                Node prev = null;
                for (int i = 0; i < size; i++)
                {
                    Node node = q.Dequeue();
                    if (prev != null) prev.next = node;
                    prev = node;

                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
            }
            return root;
        }

        public void Flatten(TreeNode root)
        {
            if (root == null) return;

            Flatten(root.left);
            Flatten(root.right);

            // chapni saqlab qo‘yish
            TreeNode left = root.left;
            TreeNode right = root.right;

            // chapni o‘ngga o‘tkazish
            root.left = null;
            root.right = left;

            // oxirigacha borib, o‘ngni ulash
            TreeNode curr = root;
            while (curr.right != null)
            {
                curr = curr.right;
            }
            curr.right = right;
        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            // Agar barg bo'lsa
            if (root.left == null && root.right == null)
            {
                return targetSum == root.val;
            }

            // Rekursiv tekshirish
            return HasPathSum(root.left, targetSum - root.val) ||
                   HasPathSum(root.right, targetSum - root.val);
        }

        public int SumNumbers(TreeNode root)
        {
            if (root == null) return 0;
            return SumSumNumbers(root,0);
        }

        public int SumSumNumbers(TreeNode tree,int sum)
        {
            if(tree == null) return 0;

            sum = (sum * 10) + tree.val;

            if(tree.left==null&&tree.right==null)
            {
                return sum;
            }
            int left = SumSumNumbers(tree.left, sum);
            int right= SumSumNumbers(tree.right, sum);
            return left+right;
        }

        int result = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            MaxPathSumAmount(root);
            return result;
        }
        public int MaxPathSumAmount(TreeNode root)
        {
            if(root == null) return 0;

            int left = MaxPathSumAmount(root.left);
            int right= MaxPathSumAmount(root.right);

            int currentMax = root.val + left + right;
            result = Max(result, currentMax);

            return root.val + Max(left, right);
        }

        public int Max(int a, int b) => a >= b ? a : b;
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
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
