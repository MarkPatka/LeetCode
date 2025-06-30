namespace LeetCode.Top150Interview.LongestSubstringWithoutRepeatingCharacters_3;

public partial class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> freq = [];
        int r = 0, l = 0, length = 0;

        for (; r < s.Length; r++)
        {
            if (freq.TryGetValue(s[r], out int value) && value >= l)
            {
                l = value + 1;
            }
            freq[s[r]] = r;
            length = Math.Max(length, r - l + 1);
        }

        return length;
    }

    /// <summary>
    /// Too slow
    /// </summary>
    public int LengthOfLongestSubstring_2(string s)
    {
        if (s.Length <= 1) return s.Length;

        int l = 0;
        int r = 0;
        int len = s.Length - 1;

        List<int> substringsLengthes = new(s.Length);
        
        while (r < len)
        {
            r++;
            Span<char> chars = [.. s[l..r]];
            if (chars.Contains(s[r]))
            {
                substringsLengthes.Add(chars.Length);
                while (l < r)
                {
                    l++;
                    if (s[l] != s[r])
                    {
                        break;
                    }
                }
                r--;
            }

            if (r == len)
            {
                substringsLengthes.Add(r - l + 1);
            }
        }

        return substringsLengthes.Max();
    }
}
