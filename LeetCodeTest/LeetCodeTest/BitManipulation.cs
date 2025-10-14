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
    }

}
