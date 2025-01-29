namespace LeetCode.Top150Interview.RemoveDuplicatesSortedArray_80;

public class RemoveDuplicates
{
    public int Remove1(int[] nums)
    {
        if (nums.Length <= 2) return nums.Length;

        int l = 0;
        int r = 0;


        for (; r < nums.Length; r++)
        {
            if (nums[r] != nums[l])
            {
                int shift = (r - l) - 2;
                if (shift <= 0) continue;

                for (int i = r; i < nums.Length; i++)
                {
                    nums[i - shift] = nums[i];
                }
                r = l + 1;
                l = r + 1;
                continue;
            }
        }
        return l + 1;
    }
    public int Remove2(int[] nums)
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
    public int Remove3(int[] nums)
    {
        int l = 0;
        int r = 0;

        while (r < nums.Length)
        {
            int count = 1;
            while (r + 1 < nums.Length && nums[r] == nums[r + 1])
            {
                r++;
                count++;
            }

            var min = Math.Min(2, count);
            for (int i = 0; i < min; i++)
            {
                nums[l] = nums[r];
                l++;
            }
            r++;
        }
        return l;
    }


}
