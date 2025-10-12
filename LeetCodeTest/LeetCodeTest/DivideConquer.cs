namespace LeetCodeTest
{
    public class DivideConquer
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return Build(nums, 0, nums.Length - 1);
        }

        private TreeNode Build(int[] nums, int left, int right)
        {
            if (left > right) return null;

            int mid = (left + right) / 2;
            TreeNode node = new TreeNode(nums[mid]);

            node.left = Build(nums, left, mid - 1);
            node.right = Build(nums, mid + 1, right);

            return node;
        }

        public ListNode SortList1(ListNode head)
        {
            if (head.next == null) return head;

            ListNode per = head;
            ListNode node = per.next;

            while (node != null)
            {
                if (node.val < per.val)
                {
                    int val = per.val;
                    per.val = node.val;
                    node.val = val;
                }
                if (node.next == null)
                {
                    node = per.next;
                    per = per.next;
                    continue;
                }

                node = node.next;
            }
            return head;
        }
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            List<int> list = new List<int>();   
            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }
            list.Sort();
            int count=0;
            head = new ListNode(0);
            ListNode node= head;
            while (count < list.Count)
            {
                node.next=new ListNode(list[count]);
                node = node.next;
                count++;
            }
            
            return head.next;
        }
    }
}
