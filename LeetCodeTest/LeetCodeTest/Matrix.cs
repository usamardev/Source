namespace LeetCodeTest
{
    public class Matrix
    {
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
    }
}
