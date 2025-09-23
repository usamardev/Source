using System.Numerics;

namespace LeetCodeTest
{
    public class LinkedList
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return true; // cycle mavjud
                }
            }

            return false; // cycle yo‘q

            //if (head == null) return false;

            //ListNode? slow = head, fast = head;
            //while (fast?.next != null)
            //{
            //    slow = slow?.next;
            //    fast = fast.next?.next;

            //    if (slow == fast) return true;
            //}

            //return false;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1.val == 0 && l1.next == null && l2.next == null && l2.val == 0)
                return new ListNode(0);

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            while (l1 != null)
            {
                list1.Add(l1.val);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                list2.Add(l2.val);
                l2 = l2.next;
            }

            BigInteger summa1 = 0;
            BigInteger summa2 = 0;

            for (int i = list1.Count - 1; i >= 0; i--)
            {
                summa1 *= 10;
                summa1 += list1[i];
            }

            for (int i = list2.Count - 1; i >= 0; i--)
            {
                summa2 *= 10;
                summa2 += list2[i];
            }

            BigInteger sum = summa1 + summa2;
            List<int> result = new List<int>();

            if (sum == 0)
            {
                result.Add(0);
            }
            else
            {
                while (sum > 0)
                {
                    result.Add((int)(sum % 10));
                    sum /= 10;
                }
            }

            ListNode head = new ListNode(result[0]);
            ListNode current = head;

            for (int i = 1; i < result.Count; i++)
            {
                current.next = new ListNode(result[i]);
                current = current.next;
            }

            return head;
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 is null) return list2;
            if (list2 is null) return list1;
            if (list1.val > list2.val) (list1, list2) = (list2, list1);
            ListNode res = list1;
            while (list1 != null && list2 != null)
            {
                ListNode temp = null;
                while (list1 is not null && list1.val <= list2.val)
                {
                    temp = list1;
                    list1 = list1.next;
                }
                temp.next = list2;
                (list1, list2) = (list2, list1);
            }
            return res;
        }
        public ListNode MergeTwoListsTest(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;
            else if (list2 == null)
                return list1;

            ListNode d = new ListNode(0),cur = d;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    cur.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    cur.next = list2;
                    list2 = list2.next;
                }

                cur = cur.next;
            }

            if (list1 != null)
                cur.next = list1;

            if (list2 != null)
                cur.next = list2;

            return d.next; ;
        }

    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}
