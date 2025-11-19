namespace LeetCode.PalindromeNumber_9;

public partial class Solution
{
    /// <summary>
    /// The worst one with a runtime ~2ms
    /// </summary>
    public bool IsPalindrome_1(int x)
    {
        // Negative numbers and numbers ending with 0 (but not zero itself) cannot be palindromes
        if (x < 0 || (x % 10 == 0 && x != 0))
            return false;

        string xStr = x.ToString();
        
        int l = 0;
        int r = xStr.Length - 1;
        
        while (l < r)
        {
            if (xStr[l++] != xStr[r--]) 
                return false;
        }
        return true;
    }

    /// <summary>
    /// The best one with the ~1ms time efficiency
    /// and with no overhead of increment/decrement two pointers
    /// </summary>
    public bool IsPalindrome_2(int x)
    {
        // Negative numbers and numbers ending with 0 (but not zero itself) cannot be palindromes
        if (x < 0 || (x % 10 == 0 && x != 0))
            return false;

        int reversedHalf = 0;

        // Reverse only half of the number
        while (x > reversedHalf)
        {
            int digit = x % 10;
            reversedHalf = reversedHalf * 10 + digit;
            x /= 10;
        }

        // For odd digits, middle number doesn't matter: reversedHalf/10 removes it
        return x == reversedHalf || x == reversedHalf / 10;
    }

}
