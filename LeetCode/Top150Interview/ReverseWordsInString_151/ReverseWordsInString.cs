using System.Text;

namespace LeetCode.Top150Interview.ReverseWordsInString_151;

public partial class Solution 
{
    // Right and straightforward but less time-efficient than the second one
    public string ReverseWordsInString(string s)
    {
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var reversedWords = words.Reverse();
        var reversed = new StringBuilder();
        foreach (var word in reversedWords)
        {
            reversed.Append(word);
            reversed.Append(' ');
        }
        return reversed.ToString().TrimEnd();
    }

    // The best time-complexity performance case
    public string ReverseWords_2(string s)
    {
        var phrase = s
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Reverse();

        return string.Join(" ", phrase);
    }


    #region O(1) Space complexity using unsafe code
    public string ReverseWords_3(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;

        unsafe
        {
            fixed (char* pStr = s)
            {
                // Step 1: Trim leading/trailing spaces and compact multiple spaces
                int len = TrimSpaces(pStr, s.Length);

                if (len == 0) return "";

                // Step 2: Reverse the entire string
                Reverse(pStr, 0, len - 1);

                // Step 3: Reverse each word
                ReverseWordsInString(pStr, len);

                // Step 4: Convert back to a managed string (avoids extra allocations)
                return new string(pStr, 0, len);
            }
        }
    }
    // Trims leading/trailing spaces and compacts multiple spaces between words
    // Returns the new length of the trimmed string
    private unsafe int TrimSpaces(char* s, int length)
    {
        int i = 0, j = 0;

        // Skip leading spaces
        while (j < length && s[j] == ' ') j++;

        // Compact multiple spaces between words
        while (j < length)
        {
            if (s[j] != ' ' || (i > 0 && s[i - 1] != ' '))
            {
                s[i++] = s[j];
            }
            j++;
        }

        // Remove trailing space (if any)
        if (i > 0 && s[i - 1] == ' ')
            i--;

        return i;
    }
    // Reverses a portion of the string between `left` and `right` (inclusive)
    private unsafe void Reverse(char* s, int left, int right)
    {
        while (left < right)
        {
            char temp = s[left];
            s[left++] = s[right];
            s[right--] = temp;
        }
    }
    // Reverses each word in the string
    private unsafe void ReverseWordsInString(char* s, int length)
    {
        int start = 0;
        while (start < length)
        {
            // Find the end of the current word
            int end = start;
            while (end < length && s[end] != ' ') end++;

            // Reverse the word
            Reverse(s, start, end - 1);

            // Move to the next word
            start = end + 1;
        }
    }
    #endregion O(1) Space complexity using unsafe code
}