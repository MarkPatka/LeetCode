namespace LeetCode.Top150Interview.RomanToInteger_13;

public partial class Solution
{
    private static readonly Dictionary<char, int> roman = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    /// <summary>
    /// Not the best solution, but it is correct 
    /// And it has O(n) time and space complexity
    /// </summary>
    public int RomanToInt(string s)
    {
        int result = 0;
        int i = s.Length - 1;

        for (; i >= 0; i--) 
        {
            int right = roman[s[i]];
            int left = i - 1;

            for (; left >= 0; left--)
            {
                if (roman[s[left]] >= right)
                {
                    break;
                }
                right -= roman[s[left]];
            }
            i = left + 1;
            result += right;
        }
        return result;
    }
    public int RomanToInt_2(string s)
    {
        int total = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (roman[s[i]] < roman[s[i + 1]])
            {
                total -= roman[s[i]]; 
            }
            else
            {
                total += roman[s[i]]; 
            }
        }

        total += roman[s[^1]];

        return total;
    }
}
