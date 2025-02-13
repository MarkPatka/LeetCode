namespace LeetCode.Top150Interview.JumpGame_55;

public class JumpGame
{
    public bool CanJump_1(int[] nums)
    {
        int target = nums.Length - 1;
        for (var i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] >= target - i) 
                target = i;
        }        
        return target == 0;
    }
    public bool CanJump_2(int[] nums)
    {
        int idx = 0;
        int length = nums.Length - 1;

        while (idx < length) 
        {
            if (nums[idx] >= length)
                return true;

            if (nums[idx] == 0)
            {
                if (CanJumpOver(idx - 1, nums))
                {
                    idx++;
                    continue;
                }                    
                else return false;
            }
            idx++;
        }
        return true;
    }
    static bool CanJumpOver(int index, int[] nums)
    {
        int jumpMin = 2;
        for (; index >= 0; index--)
        {
            if (nums[index] >= jumpMin)
                return true;

            jumpMin++;
        }
        return false;
    }
}
