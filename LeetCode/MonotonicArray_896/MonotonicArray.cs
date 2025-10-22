namespace LeetCode.MonotonicArray_896;

partial class Solution
{
    public bool IsMonotonic(int[] nums)
    {
        bool increasing = true;
        bool decreasing = true;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1])
                increasing = false;
            if (nums[i] < nums[i + 1])
                decreasing = false;
        }

        return increasing || decreasing;
    }
}
