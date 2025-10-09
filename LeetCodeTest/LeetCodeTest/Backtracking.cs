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


    }
}
