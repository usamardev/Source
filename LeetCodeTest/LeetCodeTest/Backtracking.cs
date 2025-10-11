namespace LeetCodeTest
{
    public class Backtracking
    {
        private static readonly Dictionary<char, string> map = new Dictionary<char, string>
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

        public IList<string> LetterCombinations(string digits)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(digits)) return result;

            Backtrack(digits, 0, "", result);
            return result;
        }

        private void Backtrack(string digits, int index, string current, List<string> result)
        {
            if (index == digits.Length)
            {
                result.Add(current);
                return;
            }

            string letters = map[digits[index]];
            foreach (char c in letters)
            {
                Backtrack(digits, index + 1, current + c, result);
            }
        }

        public IList<string> LetterCombinations2(string digits)
        {
            if (string.IsNullOrEmpty(digits)) return new List<string>();
            string[] map = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            List<string> result = new List<string> { "" };

            foreach (char d in digits)
            {
                List<string> temp = new List<string>();
                foreach (string comb in result)
                {
                    foreach (char c in map[d - '0'])
                    {
                        temp.Add(comb + c);
                    }
                }
                result = temp;
            }

            return result;
        }

        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();
            BacktrackCombine(1, n, k, new List<int>(), result);
            return result;
        }

        private void BacktrackCombine(int start, int n, int k, List<int> current, List<IList<int>> result)
        {
            // ✅ 1. To‘liq kombinatsiya tayyor bo‘lsa
            if (current.Count == k)
            {
                result.Add(new List<int>(current));
                return;
            }

            // ✅ 2. Navbatdagi sonlarni tanlash
            for (int i = start; i <= n; i++)
            {
                current.Add(i);                 // sonni tanlaymiz
                BacktrackCombine(i + 1, n, k, current, result); // keyingi bosqich
                current.RemoveAt(current.Count - 1);     // orqaga qaytamiz (backtrack)
            }
        }

        public IList<IList<int>> CombineIntervalVertion(int n, int k)
        {
            var result = new List<IList<int>>();
            int[] comb = Enumerable.Range(1, k).ToArray();

            while (true)
            {
                result.Add(comb.ToArray());

                int i = k - 1;
                while (i >= 0 && comb[i] == n - k + i + 1) i--;
                if (i < 0) break;

                comb[i]++;
                for (int j = i + 1; j < k; j++)
                    comb[j] = comb[j - 1] + 1;
            }

            return result;
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            Generate(nums, 0, result);
            return result;
        }

        private void Generate(int[] nums, int start, List<IList<int>> result)
        {
            if (start == nums.Length)
            {
                result.Add(nums.ToArray());
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                (nums[start], nums[i]) = (nums[i], nums[start]);  // swap
                Generate(nums, start + 1, result);
                (nums[start], nums[i]) = (nums[i], nums[start]);  // backtrack (undo swap)
            }
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();

            GenerateComSum(candidates,0, target,new List<int>(), result);

            return result;
        }
        private void GenerateComSum(int[] candidates,int start, int target, List<int> current, List<IList<int>> result)
        {
            for (int i = start; i < candidates.Length; i++)
            {
                current.Add(candidates[i]);       
                if (current.Sum() == target)
                    result.Add(new List<int>(current));
                if (current.Sum() < target)
                {
                    GenerateComSum(candidates, i, target, current, result);
                }
                current.RemoveAt(current.Count - 1);   
            }
        }

        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            BacktrackParent(result, "", 0, 0, n);
            return result;
        }

        private void BacktrackParent(List<string> result, string current, int open, int close, int max)
        {
            // ✅ 1. To‘liq qavslar tayyor
            if (current.Length == max * 2)
            {
                result.Add(current);
                return;
            }
            // ✅ 2. Agar hali ochish mumkin bo‘lsa
            if (open < max)
                BacktrackParent(result, current + "(", open + 1, close, max);

            // ✅ 3. Agar yopish mumkin bo‘lsa
            if (close < open)
                BacktrackParent(result, current + ")", open, close + 1, max);
        }

        public bool Exist(char[][] board, string word)
        {
            int rows = board.Length;
            int cols = board[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Dfs(board, i, j, word, 0))
                        return true;
                }
            }

            return false;
        }

        private bool Dfs(char[][] board, int i, int j, string word, int index)
        {
            // 1️⃣ — So‘z to‘liq topilgan bo‘lsa
            if (index == word.Length)
                return true;

            // 2️⃣ — Tashqariga chiqib ketgan yoki mos kelmasa
            if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length || board[i][j] != word[index])
                return false;

            // 3️⃣ — Hozirgi katakni vaqtincha “ishlatilgan” deb belgilaymiz
            char temp = board[i][j];
            board[i][j] = '#';

            // 4️⃣ — To‘rt yo‘nalishda davom etamiz
            bool found =
                Dfs(board, i + 1, j, word, index + 1) ||
                Dfs(board, i - 1, j, word, index + 1) ||
                Dfs(board, i, j + 1, word, index + 1) ||
                Dfs(board, i, j - 1, word, index + 1);

            // 5️⃣ — Orqaga qaytishda katakni tiklaymiz
            board[i][j] = temp;

            return found;
        }
        private int result = 0;
        public int TotalNQueens(int n)
        {
            if (n == 1) return 1;

            int[] ints=new int[n];

            BacktrackTotalNQueens(ints, 0, new HashSet<string>(), n);
            return result;
        }

        private void BacktrackTotalNQueens(int[] nums, int row, HashSet<string> xZone, int n)
        {
            if(row==n) return;

            for (int i = 0; i < n; i++)
            {
                if (xZone.Contains((row,i).ToString())) continue;
                if (row == n - 1)
                    result++;
                else
                {
                    var save = new HashSet<string>(xZone);
                    CreateXZones(xZone, row, i, n);
                    BacktrackTotalNQueens(nums, row + 1, xZone, n);
                    xZone = new HashSet<string>(save);
                }
            }
        }

        private void CreateXZones(HashSet<string> num, int row, int col,int n)
        {
            for (int i = 0; i < n; i++)
            {
                num.Add((row,i).ToString());
                num.Add((i,col).ToString());
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i - j == row-col) 
                        num.Add((i,j).ToString());
                }
                for (int j = 0; j < n; j++)
                {
                    if (j + i == col + row)
                        num.Add((i, j).ToString());
                }
            }
        }

        public int TotalNQueensFaster(int n)
        {
            int count = 0;
            int mask = (1 << n) - 1;
            void dfs(int cols, int diags, int antiDiags)
            {
                if (cols == mask) { count++; return; }
                int available = mask & ~(cols | diags | antiDiags);
                while (available != 0)
                {
                    int bit = available & -available;
                    available -= bit;
                    dfs(cols | bit, (diags | bit) << 1, (antiDiags | bit) >> 1);
                }
            }
            dfs(0, 0, 0);
            return count;
        }
    }
}
