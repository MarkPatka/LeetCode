namespace LeetCode.Top150Interview.MergeSortedArray;

public class MergeSortedArray
{
    public void Merge1(int[] nums1, int m, int[] nums2, int n)
    {
        int nums1Idx = m;
        int nums2Idx = 0;

        while (nums1Idx < nums1.Length && nums2Idx < nums2.Length)
        {
            nums1[nums1Idx] = nums2[nums2Idx];
            nums1Idx++;
            nums2Idx++;
        }

        for (int i = 0; i < nums1.Length; i++)
        {
            for (int j = 0; j < nums1.Length; j++)
            {
                if (nums1[i] < nums1[j])
                {
                    (nums1[i], nums1[j]) = (nums1[j], nums1[i]);
                }
            }
        }
    }
    public void Merge2(int[] nums1, int m, int[] nums2, int n)
    {
        Array.Copy(nums2, 0, nums1, m, n);
        Array.Sort(nums1);
    }

    /// <summary>
    /// If nums1 and nums2 are sorted in non-descending order
    /// </summary>
    public void Merge3(int[] nums1, int m, int[] nums2, int n)
    {
        if (n == 0) return;

        int len1 = nums1.Length;
        int endIdx = len1 - 1;

        while (n > 0 && m > 0)
        {
            if (nums2[n - 1] >= nums1[m - 1])
            {
                nums1[endIdx] = nums2[n - 1];
                n--;
            }
            else
            {
                nums1[endIdx] = nums1[m - 1];
                m--;
            }
            endIdx--;
        }

        while (n > 0)
        {
            nums1[endIdx] = nums2[n - 1];
            n--;
            endIdx--;
        }
    }

}