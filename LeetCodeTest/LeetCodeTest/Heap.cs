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
    }
}
