namespace LeetCodeTest
{
    public class Heap
    {
        public int FindKthLargest(int[] nums, int k)
        {
            // Min-heap (PriorityQueue<int, int> — value va priority bir xil)
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            foreach (var num in nums)
            {
                pq.Enqueue(num, num);
                if (pq.Count > k)
                    pq.Dequeue(); // eng kichigini olib tashlaymiz
            }

            return pq.Peek(); // heap ichidagi eng kichik — k-chi eng katta
        }

        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var result = new List<IList<int>>();
            if (nums1.Length == 0 || nums2.Length == 0 || k == 0)
                return result;
            var pq = new PriorityQueue<(int i, int j), int>();

            for (int i = 0; i < Math.Min(nums1.Length, k); i++)
            {
                pq.Enqueue((i, 0), nums1[i] + nums2[0]);
            }

            while (k-- > 0 && pq.Count > 0)
            {
                var (i, j) = pq.Dequeue();
                result.Add(new List<int> { nums1[i], nums2[j] });

                if (j + 1 < nums2.Length)
                {
                    pq.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
                }
            }

            return result;
        }
    }
}
