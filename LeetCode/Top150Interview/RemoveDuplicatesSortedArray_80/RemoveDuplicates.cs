namespace LeetCode.Top150Interview.RemoveDuplicatesSortedArray_80;

public class RemoveDuplicates
{
    //  In: [1,2,2]; [1,1,1] 
    public int Remove(int[] nums)
    {
        if (nums.Length <= 2) return nums.Length;

        int l = 0;
        int r = 0;
        int res = 0;

        for (; r < nums.Length; r++) // -1?
        {
            if (nums[r] != nums[l])
            {
                int shift = (r - l) - 2;
                if (shift <= 0) continue;

                res += shift;
                for (int i = r; i < nums.Length; i++)
                {
                    nums[i - shift] = nums[i];
                }
                r = l + 1;
                l = r + 1;
                continue;
            }
            res++;
        }
        return (nums.Length - res) + 1;
    }

    static int[] Shift(int[] array, int k)
    {
        var result = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            if ((i + k) >= array.Length)
                result[(i + k) - array.Length] = array[i];
            else
                result[i + k] = array[i];
        }
        return result;
    }

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
}
