namespace LeetCodeTest
{
    public class _1DDP
    {

        public int ClimbStairs(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;

            int fib1 = 1;
            int fib2 = 2;

            for (int i = 3; i <= n; i++)
            {
                int fib = fib1 + fib2;
                fib1 = fib2;
                fib2 = fib;
            }
            return fib2;
        }
    }
}
