namespace LeetCode.Top150Interview._3Sum_15;

public partial class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        //CountingSort(nums); - We get the best memory-efficience
        Array.Sort(nums); // - We get the better time-efficience
        IList<IList<int>> result = [];
        int i = 0;

        for (; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            var (j, k) = (i + 1, nums.Length - 1);

            while (j < k)
            {
                int total = nums[i] + nums[j] + nums[k];

                if (total < 0) 
                {
                    j++;
                }
                else if (total > 0)
                {
                    k--;
                }
                else
                {
                    result.Add([nums[i], nums[j], nums[k]]);
                    
                    while (j < k && nums[j] == nums[j + 1])
                        j++;

                    while (j < k && nums[k] == nums[k - 1])
                        k--;

                    j++;
                    k--;
                }

            }

        }
        return result;
    }

    private void CountingSort(int[] nums)
    {
        const int minVal = -10000;
        const int maxVal = 10000;

        int[] count = new int[maxVal - minVal + 1];
        foreach (int num in nums)
        {
            count[num - minVal]++;
        }

        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                nums[index++] = i + minVal;
                count[i]--;
            }
        }
    }
}
