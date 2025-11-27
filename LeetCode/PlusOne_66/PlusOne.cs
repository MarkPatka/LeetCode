namespace LeetCode.PlusOne_66;

public partial class Solution
{
    public int[] PlusOne(int[] digits)
    {
        int i = digits.Length - 1;
        while (digits[i] == 9 && i >= 0)
        {
            digits[i--] = 0;

            if (i < 0) 
            {
                int[] result = new int[digits.Length + 1];
                result[0] = 1;
                return result;
            }
        }
        
        digits[i]++;

        return digits;
    }
}
