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

        //153. Find Minimum in Rotated Sorted Array
        public int FindMin(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (min > nums[i])
                    min = nums[i];
            }
            return min;
        }
        public int FindMinAnotherWay(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l < r)
            {
                int m = l + (r - l) / 2;

                if (nums[m] < nums[r])
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            return nums[l];
        }

        //4. Median of Two Sorted Arrays
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();
            int m=nums1.Length;
            int n=nums2.Length;

            for (int i = 0; i < m; i++)
            {
                result.Add(nums1[i]);
            }
            for (int i = 0; i < n; i++)
            {
                result.Add(nums2[i]);
            }
            result.Sort();

            double sum = ((m + n) % 2 == 0) ? (result[(n + m) / 2 - 1] + result[(n + m) / 2]) / 2.0 : result[(n + m) / 2];

            return sum;
        }
    }
}
