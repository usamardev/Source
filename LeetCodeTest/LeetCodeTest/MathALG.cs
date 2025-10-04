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
    }
}
