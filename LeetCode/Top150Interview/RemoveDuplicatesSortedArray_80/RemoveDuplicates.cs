namespace LeetCode.Top150Interview.RemoveDuplicatesSortedArray_80;

public class RemoveDuplicates
{
    //  In: [0,0,1,1,1,1,2,3,3];

    ///Out: [0, 1, 1, 3, 3, 8, 10, 10, 12]
    public int Remove(int[] nums)
    {
        //int l = 0;
        //int r = 0;

        //while (r < nums.Length)
        //{
        //    int count = 1;
        //    while (r + 1 < nums.Length && nums[r] == nums[r + 1])
        //    {
        //        r++;
        //        count++;
        //    }

        //    var min = Math.Min(2, count);
        //    for (int i = 0; i < min; i++) 
        //    {
        //        nums[l] = nums[r];
        //        l++;
        //    }
        //    r++;
        //}



        //int curr = 0;
        //int next = 1;
        //for (; curr < nums.Length - 1; curr++)
        //{
        //    if (nums[curr] != nums[next])
        //    {
        //        if (Math.Abs(next - curr) < 2)
        //        {
        //            next++;
        //            continue;
        //        }

        //        int shiftIdx = next + 1;
        //        for (int i = curr; i < nums.Length; i++)
        //        {
        //            nums[shiftIdx] = nums[i];
        //            shiftIdx++;
        //        }
        //        curr = next + 1;
        //        next = curr + 1;
        //    }
        //}
        return l;
    }
}
