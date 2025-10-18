namespace LeetCodeTest.AllParts.Arrays
{
    public class ArrayOnePart
    {

        //16. 3Sum Closest
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int closest = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1, right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    // Agar hozirgi yig'indi target'ga yaqin bo'lsa, yangilaymiz
                    if (Math.Abs(sum - target) < Math.Abs(closest - target))
                    {
                        closest = sum;
                    }

                    if (sum < target)
                        left++;
                    else if (sum > target)
                        right--;
                    else
                        return sum; // To‘liq teng bo‘lsa, bu eng yaqin
                }
            }

            return closest;
        }

    }
}
