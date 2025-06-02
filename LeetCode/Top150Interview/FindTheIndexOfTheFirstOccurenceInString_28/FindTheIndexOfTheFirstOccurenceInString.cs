namespace LeetCode.Top150Interview.FindTheIndexOfTheFirstOccurenceInString_28;

public partial class Solution
{
    public int FindTheIndexOfTheFirstOccurenceInString(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(haystack) || 
            string.IsNullOrEmpty(needle)   || 
            needle.Length > haystack.Length)
        {
            return -1;
        }

        int needlePointer = 0;
        for (int i = 0; i < haystack.Length; i++)
        {
            if ((haystack.Length - i) < needle.Length)
            {
                return -1;
            }

            int haystackPointer = i;
            while (haystack[haystackPointer] == needle[needlePointer])
            {
                haystackPointer++;
                needlePointer++;

                if (needlePointer == needle.Length)
                {
                    return haystackPointer - needlePointer;
                }
            }
            needlePointer = 0;
        }

        return -1;
    }
}
