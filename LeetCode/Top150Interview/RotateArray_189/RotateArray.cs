namespace LeetCode.Top150Interview.RotateArray_189;

public class RotateArray
{
    public void Rotate(int[] nums, int k)
    {
        if (nums.Length == 0 || k == 0) return;
        k %= nums.Length; // Handle cases where k > array length
       
        Reverse(nums, 0, nums.Length - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, nums.Length - 1);
    }

    static void Reverse(int[] arr, int start, int end)
    {
        while (start < end)
        {
            (arr[start], arr[end]) = (arr[end], arr[start]);
            start++;
            end--;
        }
    }
}
