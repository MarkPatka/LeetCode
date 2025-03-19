namespace LeetCode.Top150Interview.RemoveDuplicatesSortedArray_26;

public partial class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        var nextDistinctElementIndex = 1;

        for (var currentIndex = 1; currentIndex < nums.Length; currentIndex++)
        {
            var previousIndex = currentIndex - 1;
            if (nums[currentIndex] != nums[previousIndex])
            {
                nums[nextDistinctElementIndex] = nums[currentIndex];
                nextDistinctElementIndex++;
            }
        }
        return nextDistinctElementIndex;
    }


    //public int RemoveDuplicates(int[] nums)
    //{
    //    if (nums.Length == 0) { return 0; }

    //    int k = 0;
    //    List<int> unique = [];

    //    for (int i = 0; i < nums.Length; i++) 
    //    {
    //        bool isDuplicate = false;
    //        for (int j = 0; j < unique.Count; j++)
    //        {
    //            if (nums[i] == unique[j])
    //            {
    //                isDuplicate = true;
    //                break;
    //            }
    //        }

    //        if (!isDuplicate)
    //        {
    //            unique.Add(nums[i]);
    //            k++;
    //        }
    //    }

    //    for (int i = 0; i < k; i++) 
    //    {
    //        nums[i] = unique[i];
    //    }
    //    return k;
    //}
}
