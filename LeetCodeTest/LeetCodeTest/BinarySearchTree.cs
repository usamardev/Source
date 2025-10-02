using System.Xml.Linq;

namespace LeetCodeTest
{
    public class BinarySearchTree
    {
        int minDiff=int.MaxValue;
        int? prev = null; // oldingi tugun qiymati
        public int GetMinimumDifference(TreeNode root)
        {
            if (root == null) return 0;
            GetMinimumDifference(root.left);
            if (prev != null)
            {
                minDiff = Min(minDiff, root.val - prev.Value);
            }
            prev = root.val;
            GetMinimumDifference(root.right);
            return minDiff;
        }

        private int count = 0;
        private int result = 0;
        public int KthSmallest(TreeNode root, int k)
        {
            if (root == null) return 0;

            KthSmallest(root.left, k);

            count++;
            if (count == k)
            {
                result = root.val;
                return result;
            }

            KthSmallest(root.right, k);

            return result;
        }

        public bool IsValidBST(TreeNode root)
        {
            return Validate(root, long.MinValue, long.MaxValue);
        }
        private bool Validate(TreeNode node, long min, long max)
        {
            if (node == null) return true;

            if (node.val <= min || node.val >= max) return false;

            return Validate(node.left, min, node.val) &&
                   Validate(node.right, node.val, max);
        }

        public int Min(int a,int b)=>(a>=b)?b:a;
    }
}
