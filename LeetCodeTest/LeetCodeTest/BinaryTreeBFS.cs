namespace LeetCodeTest
{
    public class BinaryTreeBFS
    {
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                    // Agar oxirgi tugun bo‘lsa → result ga qo‘shamiz
                    if (i == size - 1)
                    {
                        result.Add(node.val);
                    }

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return result;
        }

        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> result = new List<double>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                double sum = 0;

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                result.Add(sum / size);
            }

            return result;
        }
    }
}
