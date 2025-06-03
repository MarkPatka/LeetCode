namespace LeetCode.Top150Interview.IsSubsequence_392;

public partial class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        if (t.Length < s.Length) return false;
        if (s.Length == 0) return true;

        int tIndex = 0;
        foreach (char c in s)
        {
            while (tIndex < t.Length && t[tIndex] != c)
            {
                tIndex++;
            }

            if (tIndex == t.Length)
            {
                return false;
            }
            tIndex++;
        }
        return true;
    }
}
