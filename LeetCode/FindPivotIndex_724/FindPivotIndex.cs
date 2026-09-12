namespace LeetCode.FindPivotIndex_724;

public partial class Solution 
{
    public int PivotIndex(int[] nums)
    {
        int[] prefixSum = BuildPrefixSum(nums);

        int maxRightPivot = prefixSum[^1];

        for (int i = 1; i < prefixSum.Length; i++)
        {
            if (prefixSum[i - 1] == maxRightPivot - prefixSum[i])
            {
                return i - 1;
            }
        }
        return -1;
    }

    private static int[] BuildPrefixSum(int[] nums)
    {
        int[] prefixSum = new int[nums.Length + 1];
        prefixSum[0] = 0;
        int acc = 0;

        for (int i = 1; i < prefixSum.Length; i++)
        {
            acc += nums[i - 1];
            prefixSum[i] = acc;
        }

        return prefixSum;
    }
}

