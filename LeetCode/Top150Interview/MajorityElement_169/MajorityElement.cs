namespace LeetCode.Top150Interview.Majority_Element_169;

public partial class Solution
{
    public int MajorityElement(int[] nums)
    {
        Dictionary<int, int> map = [];
        int limit = nums.Length / 2;
        int k = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            if (map.TryGetValue(nums[i], out int value))
            {
                map[nums[i]] = ++value;
                if (value > limit)
                {
                    return nums[i];
                }
            }
            else
            {
                map.Add(nums[i], 1);
            }
        }
        return k;
    }
}
