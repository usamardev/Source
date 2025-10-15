namespace LeetCodeTest
{
    public class KadanesAlgorithm
    {
        public int MaxSubArray(int[] nums)
        {
            int currentSum = nums[0];
            int maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }

        public int MaxSubarraySumCircular(int[] nums)
        {
            int total = 0;
            int maxSum = nums[0], curMax = 0;
            int minSum = nums[0], curMin = 0;

            foreach (int n in nums)
            {
                curMax = Math.Max(n, curMax + n);
                maxSum = Math.Max(maxSum, curMax);

                curMin = Math.Min(n, curMin + n);
                minSum = Math.Min(minSum, curMin);

                total += n;
            }

            // agar hamma sonlar manfiy bo‘lsa
            if (maxSum < 0)
                return maxSum;

            return Math.Max(maxSum, total - minSum);
        }
    }
}
