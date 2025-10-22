namespace LeetCode.Top150Interview.ValidPalindrome_125;

public partial class Solution 
{
    public bool IsPalindrome(string s)
    {
        if (s.Length <= 1) return true;
        string lowerS = s.ToLower();

        int left = 0;
        int right = s.Length - 1;

        while (left < right) 
        {
            while (!IsNumber(lowerS[left]) && !IsLowercaseLetter(lowerS[left]))
            {
                if (left == right) break;
                left++;
            }

            while (!IsNumber(lowerS[right]) && !IsLowercaseLetter(lowerS[right]))
            {
                if (right == left) break;
                right--;
            }

            if (lowerS[left] != lowerS[right])
            {
                return false;
            }

            left++;
            right--;
        }
        return true;
    }

    private bool IsNumber(char c)
    {
        return (c >= '0' && c <= '9');
    }
    private bool IsLowercaseLetter(char c)
    {
        return (c >= 'a' && c <= 'z');
    }
}
