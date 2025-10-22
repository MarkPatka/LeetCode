namespace LeetCode.Top150Interview.JumpGame2_45;

public partial class Solution
{
    /// <summary>
    /// Bad performance and memory consumption
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int JumpGame2(int[] nums)
    {
        int target = nums.Length - 1;
        if (target > 1)
        {
            int minimalReachIndex = -1;
            int jumps = 1;
            if (nums[0] >= target) return jumps;
            while (target > 0)
            {
                for (int i = target - 1; i > 0; i--)
                {
                    if (nums[i] >= target - i) minimalReachIndex = i;
                }
                if (minimalReachIndex <= nums[0]) return jumps += 1;
                else jumps++;

                target = minimalReachIndex;
                minimalReachIndex = -1;
            }
            return jumps;
        }
        else return target;
    }
}
