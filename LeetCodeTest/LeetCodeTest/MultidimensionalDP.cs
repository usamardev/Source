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

    }
}
