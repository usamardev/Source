namespace LeetCodeTest
{
    public class BitManipulation
    {
        public int ReverseBitsInt(int n)
        {
            long r = 0;
            for (int i = 0; i < 32; i++)
            {
                r = (r << 1) | (n & 1);
                n >>= 1;
            }
            return (int)r; // agar siz natijani signed int koʻrmoqchi bo'lsangiz
        }

        public int ReverseBitsBetter(int n)
        {
            var result = 0;

            for (int i = 0; i < 32; i++)
            {
                var bit = (n >> i) & 1;
                result = result | (bit << 31 - i);
            }

            return result;
        }

        public int HammingWeight(int n)
        {
            int count = 0;

            for(int i = 0;i < 32;i++)
            {
                if ((n & 1) == 1)
                    count++;
                n>>= 1;
            }
            return count;
        }

        public int SingleNumber(int[] nums)
        {
            int res = 0;
            foreach (int n in nums) res ^= n;
            return res;
        }
        public int SingleNumber2(int[] nums)
        {
            int ones = 0, twos = 0;

            foreach (int num in nums)
            {
                ones = (ones ^ num) & ~twos;
                twos = (twos ^ num) & ~ones;
            }

            return ones;
        }

        public int RangeBitwiseAnd(int left, int right)
        {
            int shift = 0;
            while (left < right)
            {
                left >>= 1;   // o'ngga siljit
                right >>= 1;  // o'ngga siljit
                shift++;       // nechta bit yo‘qoldi — eslab qol
            }
            return left << shift; // umumiy prefiksni qayta joyiga siljit
        }

        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            int sIndex = 0, eIndex = 0;

            for (int len = s.Length - 1; len >= 0; len--)
            {
                bool found = false;
                for (int start = 0; start + len < s.Length; start++)
                {
                    int end = start + len;
                    if (IsPalindrome(s, start, end))
                    {
                        sIndex = start;
                        eIndex = end;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            return s.Substring(sIndex, eIndex - sIndex + 1);
        }

        private bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end]) return false;
                start++;
                end--;
            }
            return true;
        }
    }
}
