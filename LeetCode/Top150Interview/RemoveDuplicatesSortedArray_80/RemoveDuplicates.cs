namespace LeetCode.Top150Interview.RemoveDuplicatesSortedArray_80;

public partial class Solution
{   
    /// <summary>
    /// Correct, but bad performance
    /// </summary>
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 2) return nums.Length;

        int writeIndex = 2; 
        for (int readIndex = 2; readIndex < nums.Length; readIndex++)
        {
            if (nums[readIndex] != nums[writeIndex - 2])
            {
                nums[writeIndex] = nums[readIndex];
                writeIndex++;
            }
        }
        return writeIndex; 
    }
}
