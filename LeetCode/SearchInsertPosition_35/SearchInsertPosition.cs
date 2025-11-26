using System;

namespace LeetCode.SearchInsertPosition_35;

public partial class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            throw new ArgumentException("Array is null or empty");

        int l = 0, r = nums.Length - 1;

        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }
        // Если не нашли:
        // l - индекс первого элемента, который больше target
        // r - индекс первого элемента, который меньше target 

        return l; 
    }
}
