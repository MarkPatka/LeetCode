namespace LeetCode.Top150Interview.MinimumSizeSubarraySum_209;

public partial class Solution
{

    public int MinSubArrayLen(int target, int[] nums)
    {
        int minLength = int.MaxValue;
        int left = 0;
        int right = 0;
        int currentSum = 0;

        for (; right < nums.Length; right++)
        {
            currentSum += nums[right];

            while (currentSum >= target)
            {
                minLength = Math.Min(minLength, right - left + 1);
                currentSum -= nums[left];
                left++;
            }
        }

        return minLength == int.MaxValue ? 0 : minLength;
    }
}
