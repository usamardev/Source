namespace LeetCodeTest
{
    public class _1DDP
    {
        public int ClimbStairs(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;

            int fib1 = 1;
            int fib2 = 2;

            for (int i = 3; i <= n; i++)
            {
                int fib = fib1 + fib2;
                fib1 = fib2;
                fib2 = fib;
            }
            return fib2;
        }

        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            int prev2 = 0;      // dp[i-2]
            int prev1 = 0;      // dp[i-1]

            foreach (int x in nums)
            {
                int cur = Math.Max(prev1, prev2 + x);
                prev2 = prev1;
                prev1 = cur;
            }

            return prev1;
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            var wordSet = new HashSet<string>(wordDict);
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        public int CoinChange(int[] coins, int amount)
        {
            int max = amount + 1;
            int[] dp = new int[amount + 1];
            Array.Fill(dp, max);
            dp[0] = 0;

            for (int i = 1; i <= amount; i++)
            {
                foreach (int coin in coins)
                {
                    if (i >= coin)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                    }
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }

        public int LengthOfLIS(int[] nums)
        {
            int n = nums.Length;
            if (n == 0) return 0;

            int[] dp = new int[n];
            Array.Fill(dp, 1);

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            return dp.Max();
        }

        public int LengthOfLIS_BNSearch(int[] nums)
        {
            List<int> tails = new List<int>();

            foreach (int num in nums)
            {
                int left = 0, right = tails.Count;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (tails[mid] < num) left = mid + 1;
                    else right = mid;
                }

                if (left == tails.Count)
                    tails.Add(num);
                else
                    tails[left] = num;
            }
            return tails.Count;
        }

        
    }
}
