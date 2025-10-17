namespace LeetCodeTest
{
    public class MultidimensionalDP
    {
        //120. Triangle
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int min = 0;

            foreach (List<int> item in triangle)
            {
                min += item.Min();
            }
            return min;

            //int[] lastItems = triangle[triangle.Count - 1].ToArray();
            //for (int row = triangle.Count - 2; row >= 0; row--)
            //{
            //    for (int col = 0; col < triangle[row].Count; col++)
            //    {
            //        lastItems[col] = triangle[row][col] + Math.Min(lastItems[col], lastItems[col + 1]);
            //    }
            //}
            //return lastItems[0];
        }

        //64. Minimum Path Sum
        public int MinPathSum(int[][] grid)
        {
            //dp[i][j]=grid[i][j]+min(dp[i−1][j],dp[i][j−1])
            int m = grid.Length;
            int n = grid[0].Length;

            int[,] dp = new int[m, n];
            dp[0, 0] = grid[0][0];

            // 1️⃣ Birinchi qatorda faqat o‘ngga yurish mumkin
            for (int j = 1; j < n; j++)
                dp[0, j] = dp[0, j - 1] + grid[0][j];

            // 2️⃣ Birinchi ustunda faqat pastga yurish mumkin
            for (int i = 1; i < m; i++)
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];

            // 3️⃣ Qolgan joylar uchun eng kichik yo‘lni tanlash
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[m - 1, n - 1];
        }

        public int MinPathSumBetter(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0) continue;
                    else if (i == 0)
                        grid[i][j] += grid[i][j - 1];
                    else if (j == 0)
                        grid[i][j] += grid[i - 1][j];
                    else
                        grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
                }
            }

            return grid[m - 1][n - 1];
        }

        //63. Unique Paths II
        public int UniquePathsWithObstacles(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[,] dp = new int[m, n];

            // Start position
            if (grid[0][0] == 1) return 0;
            dp[0, 0] = 1;

            // 1st column
            for (int i = 1; i < m; i++)
            {
                dp[i, 0] = (grid[i][0] == 0 && dp[i - 1, 0] == 1) ? 1 : 0;
            }

            // 1st row
            for (int j = 1; j < n; j++)
            {
                dp[0, j] = (grid[0][j] == 0 && dp[0, j - 1] == 1) ? 1 : 0;
            }

            // Fill the rest
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (grid[i][j] == 0)
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    else
                        dp[i, j] = 0;
                }
            }

            return dp[m - 1, n - 1];
        }

        public int UniquePathsWithObstaclesOPTWay(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            int[] dp = new int[n];
            dp[0] = grid[0][0] == 0 ? 1 : 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1) 
                        dp[j] = 0;
                    else if (j > 0) 
                        dp[j] += dp[j - 1];
                }
            }
            return dp[n - 1];
        }

        //123. Best Time to Buy and Sell Stock III
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0) return 0;

            int buy1 = int.MinValue;
            int sell1 = 0;
            int buy2 = int.MinValue;
            int sell2 = 0;

            foreach (int price in prices)
            {
                buy1 = Math.Max(buy1, -price);
                sell1 = Math.Max(sell1, buy1 + price);
                buy2 = Math.Max(buy2, sell1 - price);
                sell2 = Math.Max(sell2, buy2 + price);
            }

            return sell2;
        }

        //188. Best Time to Buy and Sell Stock IV
        public int MaxProfit(int k, int[] prices)
        {
            if(prices.Length == 0)  return 0;
            
            int buy = int.MinValue;    
            int sell = 0;
            Dictionary<int,BuySeles> keyValuePairs = new Dictionary<int,BuySeles>();
            keyValuePairs.Add(1, new BuySeles { buy = int.MinValue, sell = 0 });
            foreach (int price in prices)
            {
                buy = Math.Max(buy, -price);
                sell = Math.Max(sell, buy + price);

                keyValuePairs[1].buy = buy;
                keyValuePairs[1].sell = sell;

                for (int i = 2; i <= k; i++)
                {
                    if (keyValuePairs.ContainsKey(i))
                    {
                        keyValuePairs[i].buy = Math.Max(keyValuePairs[i].buy, keyValuePairs[i-1].sell - price);
                        keyValuePairs[i].sell = Math.Max(keyValuePairs[i].sell, keyValuePairs[i].buy + price);
                    }
                    else
                    {
                        int buyI = Math.Max(int.MinValue, keyValuePairs[i - 1].sell - price);
                        int sellI = Math.Max(0, buyI + price);
                        keyValuePairs.Add(i,new BuySeles { buy = buyI, sell = sellI });
                    }
                }
            }

            return keyValuePairs[k].sell;
        } 

        class BuySeles
        {
            public int buy { get; set; }
            public int sell { get; set; }
        }

        //188. Best Time to Buy and Sell Stock IV
        public int MaxProfitBetter(int k, int[] prices)
        {
            int n = prices.Length;
            if (k > n / 2)
                return QuickProfit(prices, n);
            int[,] dp = new int[k + 1, n];
            for (int i = 1; i <= k; i++)
            {
                int min = int.MinValue;
                for (int j = 1; j < n; j++)
                {
                    min = Math.Max(min, dp[i - 1, j - 1] - prices[j - 1]);
                    dp[i, j] = Math.Max(min + prices[j], dp[i, j - 1]);
                }
            }
            return dp[k, n - 1];
        }

        public int QuickProfit(int[] prices, int n)
        {
            int profit = 0;
            int i = 1;
            while (i < n)
            {
                profit += prices[i] > prices[i - 1] ? prices[i] - prices[i - 1] : 0;
                i++;
            }
            return profit;
        }

        //221. Maximal Square
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return 0;

            int m = matrix.Length, n = matrix[0].Length;
            int[,] dp = new int[m + 1, n + 1];
            int maxSide = 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i, j] = Math.Min(
                            Math.Min(dp[i - 1, j], dp[i, j - 1]),
                            dp[i - 1, j - 1]
                        ) + 1;
                        maxSide = Math.Max(maxSide, dp[i, j]);
                    }
                }
            }

            return maxSide * maxSide;
        }

    }
}
