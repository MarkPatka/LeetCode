using System.ComponentModel;

namespace LeetCode.SquaresofSortedArray_977;

public partial class Solution 
{
    public int[] SortedSquares(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;
        int write = right;

        int[] squares = new int[nums.Length];

        while (left <= right)
        {
            int l = nums[left] * nums[left];
            int r = nums[right] * nums[right];

            if (l > r)
            {
                squares[write] = l;
                left++;
            }
            else 
            {
                squares[write] = r;
                right--;
            }

            write--;
        }

        return squares;
    }
}
