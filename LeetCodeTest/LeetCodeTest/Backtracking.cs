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


    }
}
