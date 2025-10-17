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

        public int MySqrt(int x)
        {
            if (x < 2) return x;

            int left = 1, right = x / 2, ans = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                long sq = (long)mid * mid; // overflowdan saqlanish uchun long
                if (sq == x) return mid;
                if (sq < x)
                {
                    ans = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return ans;
        }

        public double MyPow(double x, int n)
        {
            long N = n; // int.MinValue bo‘lganda overflowdan saqlanish uchun
            if (n < 0)
            {
                x = 1 / x;
                N = -N;
            }

            double result = 1.0;
            double current = x;

            while (N > 0)
            {
                if ((N % 2) == 1)
                {
                    result *= current;
                }
                current *= current;
                N /= 2;
            }

            return result;
        }



        public int MaxPoints(int[][] points)
        {
            if (points.Length <= 2)
                return points.Length;

            int maxPoints = 0;

            for (int i = 0; i < points.Length; i++)
            {
                var slopes = new Dictionary<double, int>();
                int duplicates = 0, localMax = 0;

                for (int j = i + 1; j < points.Length; j++)
                {
                    int dx = points[j][0] - points[i][0];
                    int dy = points[j][1] - points[i][1];

                    if (dx == 0 && dy == 0)
                    {
                        duplicates++; // same point
                        continue;
                    }

                    double slope;
                    if (dx == 0) slope = double.PositiveInfinity;
                    else slope = (double)dy / dx;

                    if (!slopes.ContainsKey(slope))
                        slopes[slope] = 1;
                    else
                        slopes[slope]++;

                    localMax = Math.Max(localMax, slopes[slope]);
                }

                maxPoints = Math.Max(maxPoints, localMax + duplicates + 1);
            }

            return maxPoints;
        }

        public int MaxPointsBetter(int[][] points)
        {
            int n = points.Length;
            int ans = 1;
            for (int i = 0; i < n; i++)
            {
                int x1 = points[i][0];
                int y1 = points[i][1];
                for (int j = i + 1; j < n; j++)
                {
                    int x2 = points[j][0];
                    int y2 = points[j][1];
                    int cnt = 2;
                    for (int k = j + 1; k < n; k++)
                    {
                        int x3 = points[k][0];
                        int y3 = points[k][1];
                        int firstdiff = (y2 - y1) * (x3 - x1);
                        int seonddiff = (y3 - y1) * (x2 - x1);
                        if (firstdiff == seonddiff)
                            cnt++;
                    }
                    if (ans < cnt)
                        ans = cnt;
                }
            }
            return ans;
        }
    }
}
