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

        public void Solve(char[][] board)
        {
            if (board == null || board.Length == 0) return;

            int m = board.Length;
            int n = board[0].Length;

            // 1. Chegaradagi 'O' larni DFS bilan belgila
            for (int i = 0; i < m; i++)
            {
                DFS(i, 0);       // chap ustun
                DFS(i, n - 1);   // o‘ng ustun
            }
            for (int j = 0; j < n; j++)
            {
                DFS(0, j);       // yuqori qator
                DFS(m - 1, j);   // pastki qator
            }

            // 2. Boardni yangilash
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X'; // o‘rab olingan region
                    }
                    else if (board[i][j] == '#')
                    {
                        board[i][j] = 'O'; // chetga bog‘langan
                    }
                }
            }

            // DFS yordamchi
            void DFS(int i, int j)
            {
                if (i < 0 || j < 0 || i >= m || j >= n || board[i][j] != 'O') return;

                board[i][j] = '#'; // vaqtincha belgilash
                DFS(i + 1, j);
                DFS(i - 1, j);
                DFS(i, j + 1);
                DFS(i, j - 1);
            }
        }

        private Dictionary<NodeList, NodeList> visited = new Dictionary<NodeList, NodeList>();

        public NodeList CloneGraph(NodeList node)
        {
            if (node == null) return null;

            // Agar oldin klon qilinsa, qaytar
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            // Yangi node yaratamiz (neighbors bo‘sh holat)
            NodeList cloneNode = new NodeList(node.val, new List<NodeList>());
            visited[node] = cloneNode;

            // Har bir qo‘shnini klon qilamiz
            foreach (var neighbor in node.neighbors)
            {
                cloneNode.neighbors.Add(CloneGraph(neighbor));
            }

            return cloneNode;
        }
    }
    public class NodeList
    {
        public int val;
        public IList<NodeList> neighbors;

        public NodeList()
        {
            val = 0;
            neighbors = new List<NodeList>();
        }

        public NodeList(int _val)
        {
            val = _val;
            neighbors = new List<NodeList>();
        }

        public NodeList(int _val, List<NodeList> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
