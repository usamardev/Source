using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTest
{
    public class MathALG
    {
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }

            int[] newNumber = new int[digits.Length + 1];
            newNumber[0] = 1;
            return newNumber;
        }

        public int TrailingZeroes(int n)
        {
            /*
                Nol hosil bo‘lishi uchun 2 × 5 = 10 kerak.
                Faktorialda 2-lar juda ko‘p (har bir juft son 2 beradi), lekin 5-lar kamroq.
                Shuning uchun trailing zeroes soni = n! dagi 5 lar soni.
            */
            int count = 0;
            while (n > 0)
            {
                n /= 5;
                count += n;
            }
            return count;
        }

       
    }
}
