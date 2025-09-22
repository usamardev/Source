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
    }
}
 