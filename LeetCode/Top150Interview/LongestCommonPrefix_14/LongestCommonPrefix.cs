namespace LeetCode.Top150Interview.LongestCommonPrefix_14;

public partial class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        string minStr = strs[0];
        if (strs.Length == 1) return minStr;

        for (int i = 1; i < strs.Length; i++) 
        {
            if (string.IsNullOrEmpty(strs[i]))
            {
                return strs[i];
            }

            if (strs[i].Length < minStr.Length)
            {
                minStr = strs[i];
            }
        }

        for (int i = minStr.Length - 1; i >= 0 ; i--)
        {
            string prefix = minStr[..(i + 1)];
            int cnt = 0;
            foreach (string str in strs)
            {
                if (!str.StartsWith(prefix))
                {
                    break;
                }
                cnt++;
            }

            if (cnt == strs.Length)
            {
                return prefix;
            }
        }

        return "";
    }
}
