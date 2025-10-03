namespace LeetCodeTest
{
    public class GraphGeneral
    {
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;

            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        DFS(grid, i, j, m, n);
                    }
                }
            }

            return count;
        }

        private void DFS(char[][] grid, int i, int j, int m, int n)
        {
            if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == '0') return;

            grid[i][j] = '0'; // belgilab qo‘yamiz (visited)

            DFS(grid, i + 1, j, m, n); // past
            DFS(grid, i - 1, j, m, n); // yuqori
            DFS(grid, i, j + 1, m, n); // o‘ng
            DFS(grid, i, j - 1, m, n); // chap
        }
        public int NumIslandsBFS(char[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;

            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        Queue<(int, int)> q = new Queue<(int, int)>();
                        q.Enqueue((i, j));
                        grid[i][j] = '0';

                        while (q.Count > 0)
                        {
                            var (r, c) = q.Dequeue();

                            int[][] dirs = new int[][] {
                            new int[]{1,0}, new int[]{-1,0},
                            new int[]{0,1}, new int[]{0,-1}
                        };

                            foreach (var d in dirs)
                            {
                                int nr = r + d[0], nc = c + d[1];
                                if (nr >= 0 && nr < m && nc >= 0 && nc < n && grid[nr][nc] == '1')
                                {
                                    q.Enqueue((nr, nc));
                                    grid[nr][nc] = '0';
                                }
                            }
                        }
                    }
                }
            }

            return count;
        }
    }
}
