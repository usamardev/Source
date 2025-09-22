namespace LeetCodeTest
{
    public class Intervals
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> result = new List<int[]>();

            foreach (var interval in intervals)
            {
                if (interval[0] > newInterval[1])
                {
                    result.Add(newInterval);
                    newInterval = interval;
                }
                else if (interval[1] < newInterval[0])
                {
                    result.Add(interval);
                }
                else
                {
                    newInterval[0] = Math.Min(newInterval[0], interval[0]);
                    newInterval[1] = Math.Max(newInterval[1], interval[1]);
                }
            }
            result.Add(newInterval);
            return result.ToArray();
        }

        public int FindMinArrowShots(int[][] points)
        {
            /*
             452. Minimum Number of Arrows to Burst Balloons

            There are some spherical balloons taped onto a flat wall that represents the XY-plane. 
            The balloons are represented as a 2D integer array points where points[i] = [xstart, xend] 
            denotes a balloon whose horizontal diameter stretches between xstart and xend. You do not know the exact y-coordinates of the balloons.

            Arrows can be shot up directly vertically (in the positive y-direction) from different points along the x-axis. 
            A balloon with xstart and xend is burst by an arrow shot at x if xstart <= x <= xend. There is no limit to the number 
            of arrows that can be shot. A shot arrow keeps traveling up infinitely, bursting any balloons in its path.

            Given the array points, return the minimum number of arrows that must be shot to burst all balloons. 

            Solution:
            Birinchi ballon [1,6] → o‘qni x=6 da o‘tamiz.
            Bu [1,6] va [2,8] ni yoradi (chunki 2 <= 6).
            Keyingi ballon [7,12] → 7 > 6 → yangi o‘q kerak (x=12).
            Bu [7,12] va [10,16] ni yoradi.
            
            👉 Umumiy o‘q soni = 2
             */
            if (points.Length == 0) return 0;
            Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
            int arrows = 1;
            int end = points[0][1];
            foreach (var p in points)
            {
                if (p[0] > end)
                {
                    arrows++;
                    end = p[1];
                }
            }
            return arrows;
        }

        public int Max(int a, int b) => (a >= b) ? a : b;
        public int Min(int a, int b) => (a >= b) ? b : a;
    }
}
