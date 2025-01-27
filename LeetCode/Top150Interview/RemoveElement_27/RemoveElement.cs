using System.Runtime.Serialization.Formatters;

namespace LeetCode.Top150Interview.RemoveElement_27;

public class RemoveElement
{
    /// <summary>
    /// WRONG due to constraint: num[i] >= 0 
    /// </summary>
    public int Remove1(int[] nums, int val)
    {
        int len = nums.Length;
        if (len == 0) return 0;
        
        int removedCnt = 0;
        int idx = 0;
        while (idx < len)
        {
            if (nums[idx] == val)
            {
                nums[idx] = -1;
                removedCnt++;
                (nums[idx], nums[^removedCnt]) = (nums[^removedCnt], nums[idx]);
                continue;
            }
            idx++;
        }
        return len - removedCnt;
    }

    public int Remove2(int[] nums, int val)
    {
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[index] = nums[i];
                index++;
            }
        }
        return index;
    }
}
