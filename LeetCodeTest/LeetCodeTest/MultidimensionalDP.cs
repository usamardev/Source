namespace LeetCodeTest
{
    public class MultidimensionalDP
    {
        //120. Triangle
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int min = 0;

            foreach (List<int> item in triangle)
            {
                min += item.Min();
            }
            return min;

            //int[] lastItems = triangle[triangle.Count - 1].ToArray();
            //for (int row = triangle.Count - 2; row >= 0; row--)
            //{
            //    for (int col = 0; col < triangle[row].Count; col++)
            //    {
            //        lastItems[col] = triangle[row][col] + Math.Min(lastItems[col], lastItems[col + 1]);
            //    }
            //}
            //return lastItems[0];
        }
    }
}
