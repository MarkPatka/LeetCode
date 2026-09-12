namespace LeetCode.BinarySearch_704;

public partial class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (right >= left)
        {
            int mid = (right + left) / 2;
            
            if (nums[mid] > target) 
                right = mid - 1;
            else if (nums[mid] < target) 
                left = mid + 1;
            else 
                return mid;
        }
        return -1;
    }
}
