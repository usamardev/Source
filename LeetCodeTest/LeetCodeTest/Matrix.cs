namespace LeetCodeTest
{
    public class Matrix
    {
        public void SetZeroes(int[][] matrix)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        set.Add((i + 1) * 1);
                        set.Add((j + 1) * -1);
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (set.Contains((i + 1) * 1) || set.Contains((j + 1) * -1))
                    {
                        matrix[i][j] = 0;
                        continue;
                    }
                }
            }
        }


        /*num + " in box " + (i/3) + "-" + (j/3)
        Sudoku 3x3 bo‘laklarga bo‘lingan.        
        (i/3, j/3) orqali qaysi 3x3 qutiga tegishli ekanini topamiz.        
        Masalan: (i=4, j=5) bo‘lsa → (4/3, 5/3) = (1,1) → bu o‘rta quti.        
        String qilib yozsak: "5 in box 1-1".
        */
        public bool IsValidSudoku(char[][] board) 
        {
            bool[,] rows = new bool[9, 9];
            bool[,] cols = new bool[9, 9];
            bool[,] boxes = new bool[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        int num = board[i][j] - '1';
                        int boxIndex = (i / 3) * 3 + (j / 3);

                        if (rows[i, num] || cols[j, num] || boxes[boxIndex, num])
                        {
                            return false;
                        }

                        rows[i, num] = cols[j, num] = boxes[boxIndex, num] = true;
                    }
                }
            }
            return true;

            //HashSet<string> seen = new HashSet<string>();

            //for (int i = 0; i < 9; i++)
            //{
            //    for (int j = 0; j < 9; j++)
            //    {
            //        char num = board[i][j];
            //        if (num == '.') continue;

            //        if (!seen.Add(num + " in row " + i) ||
            //            !seen.Add(num + " in col " + j) ||
            //            !seen.Add(num + " in box " + (i / 3) + "-" + (j / 3)))
            //        {
            //            return false;
            //        }
            //    }
            //}
            //return true;
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            int col = 0;
            int row = 0;

            int count = 0;
            int l = matrix[0].Length;
            int r = matrix.Length;
            bool right=true, left=false,down=false,up=false;

            List<int> list = new List<int>();
            for (int i = 0;i < r *l; i++)
            {
                if (right)
                {
                    list.Add(matrix[row][col++]);
                    if (col == l-count)
                    {
                        right = false;
                        down = true; col--; row++;
                        continue;
                    }
                }
                if(down)
                {
                    list.Add(matrix[row++][col]);
                    if(row == r-count)
                    {
                        down = false;
                        left = true; row--; col--;
                        continue;
                    }
                }
                if (left)
                {
                    list.Add(matrix[row][col]);
                    if(col==count)
                    {
                        left = false;
                        up = true;row--; count++;
                        continue;
                    }
                    else
                        col--;
                }
                if(up)
                {
                    list.Add(matrix[row][col]);
                    if(row==count)
                    {
                        up = false;
                        right=true; col++;
                    }
                    else
                        row--;
                }
            }

            return list;    
        }


        public void GameOfLife(int[][] board)
        {
            int m = board.Length, n = board[0].Length;
            int[] dirs = { -1, 0, 1 };

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    int live = 0;
                    foreach (int dx in dirs)
                        foreach (int dy in dirs)
                        {
                            if (dx == 0 && dy == 0) continue;
                            int x = i + dx, y = j + dy;
                            if (x >= 0 && x < m && y >= 0 && y < n)
                                live += board[x][y] & 1;
                        }

                    if (board[i][j] == 1 && (live == 2 || live == 3))
                        board[i][j] |= 2; // tirik qoladi
                    if (board[i][j] == 0 && live == 3)
                        board[i][j] |= 2; // yangi tiriladi
                }

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    board[i][j] >>= 1; // keyingi avlodga o‘tish
        }
    }
}
 