namespace LeetCode.Top150Interview.IsSubsequence_392;

public partial class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        if (t.Length < s.Length) return false;
        if (s.Length == 0) return true;

        int left = -1;
        foreach (char c in s)
        {
            int right = GetIndexOfFirstOccurrenceOfChar(t, c, left + 1);
            if (right < 0)
            {
                return false;
            }
            left = right;
        }
        return true;
    }

    public int GetIndexOfFirstOccurrenceOfChar(string source, char target, int index)
    {
        for (; index < source.Length; index++) 
        {
            if (source[index] == target)
            {
                return index;
            }
        }
        return -1;
    }
}
