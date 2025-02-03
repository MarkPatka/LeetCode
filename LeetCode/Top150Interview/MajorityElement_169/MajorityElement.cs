namespace LeetCode.Top150Interview.Majority_Element_169;

public class MajorityElement
{
    /// <summary>
    /// Bad
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MajorityElement1(int[] nums)
    {
        Array.Sort(nums);
        return nums[nums.Length / 2];
    }


    /// <summary>
    /// Better
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MajorityElement2(int[] nums)
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
