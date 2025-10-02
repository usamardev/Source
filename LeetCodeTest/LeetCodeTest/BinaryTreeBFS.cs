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

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            result.Add(new List<int>() { root.val});
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                List<int> list = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.left != null) list.Add(node.left.val);
                    if (node.right != null) list.Add(node.right.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                if (list.Count != 0)
                    result.Add(list);
            }
            return result;
        }
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            result.Add(new List<int>() { root.val });
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool zigzak = true;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                List<int> list = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.left != null) list.Add(node.left.val);
                    if (node.right != null) list.Add(node.right.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                if (list.Count != 0)
                {
                    if (zigzak)
                    {
                        list.Reverse();
                        result.Add(list);
                    }else
                    {
                        result.Add(list);
                    }
                    zigzak=!zigzak;
                }
            }
            return result;
        }
    }
}
