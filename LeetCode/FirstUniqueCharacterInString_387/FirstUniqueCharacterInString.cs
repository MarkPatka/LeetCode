namespace LeetCode.FirstUniqueCharacterInString_387;

public partial class Solution
{
    public int FirstUniqChar(string s)
    {
        // MORE EFFICIENT:
        if (s == null || s.Length == 0) return -1;

        var count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (count[s[i] - 'a'] == 1) return i;
        }

        return -1;

        // MORE STRAIGHTFORWARD:
        //Dictionary<char, int> freq = new(s.Length);

        //foreach (var c in s)
        //{
        //    if (freq.ContainsKey(c))
        //    {
        //        freq[c]++;
        //    }
        //    else
        //    {
        //        freq.Add(c, 1);
        //    }
        //}

        //foreach (var c in freq)
        //{
        //    if (c.Value == 1)
        //    {
        //        return s.IndexOf(c.Key);
        //    }
        //}

        //return -1;
    }
}
