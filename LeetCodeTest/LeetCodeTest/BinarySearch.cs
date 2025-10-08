namespace LeetCodeTest
{
    public class BinarySearch
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return left;
        }

        //74. Search a 2D Matrix
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length == 0 && matrix[0].Length == 0) return false;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == target) return true;
                }
            }
            return false;
        }

        //162. Find Peak Element
        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int result = 0;
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                    result = i;
                }
            }
            return result;
        }

        //33. Search in Rotated Sorted Array
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                    return i;
            }
            return -1;
        }

        //34. Find First and Last Position of Element in Sorted Array
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[] { -1, -1 };
            if (nums.Length == 0) return result;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    if (result[0] == -1)
                    {
                        result[0] = i;
                        result[1] = i;
                    }
                    else
                        result[1] = i;
                }
            }
            return result;
        }
    }
}
