namespace LeetCode.Top150Interview.MinimumWindowSubstring_76;

public partial class Solution 
{
    /// <summary>
    /// The most efficient solution
    /// </summary>
    public string MinWindow(string s, string t)
    {
        Span<int> map = stackalloc int[128];            // Creates a frequency map (array) of size 128
        for (int i = 0; i < t.Length; i++) map[t[i]]++; // Covering all ASCII characters


        int start = 0, end = 0;         // Window pointers
        int count = 0;                  // Tracks how many required characters we've found
        int minLength = int.MaxValue;   // Tracks the minimum window length found
        int startIndex = -1;            // Tracks start of the minimum window

        while (start < s.Length)
        {
            // If this character is in t (map value was initially positive)
            if (count < t.Length)
            {
                if (end == s.Length) break;
                if (map[s[end]] > 0) count++;

                // Decrement count for this character (even if not in t)
                map[s[end]]--;
                end++;
            }
            else
            {
                // Update minimum window if current is smaller
                if (end - start < minLength) 
                { 
                    minLength = end - start; 
                    startIndex = start; 
                }

                // Return character to frequency map
                map[s[start]]++;

                // If this makes the count positive, we've lost a needed character
                if (map[s[start]] > 0) count--;

                start++;
            }
        }

        return (minLength != int.MaxValue) ? s.Substring(startIndex, minLength) : "";
    }

    /// <summary>
    /// Exceeds time limits
    /// </summary>
    public string MinWindow_2(string s, string t)
    {
        if (t.Length > s.Length) return "";

        Dictionary<char, int> freq = [];
        foreach (char c in t) 
        {
            if (freq.TryGetValue(c, out int cFrequency))
            {
                freq[c] = ++cFrequency;
            }
            else
            {
                freq[c] = 1;
            }
        }

        int right = t.Length - 1;
        for (; right < s.Length; right++) 
        {
            int left = 0;
            for (int i = left; i <= s.Length - right; i++)
            {
                int len = i + right == s.Length 
                    ? right 
                    : right + 1;

                string substring = s.Substring(i, len);

                Dictionary<char, int> currentSubstringFreq = substring.GroupBy(c => c)
                    .ToDictionary(k => k.Key, v => v.Count());

                int validKeysCount = 0;
                foreach (char c in freq.Keys)
                {
                    if (currentSubstringFreq.TryGetValue(c, out int val) && val >= freq[c])
                    {
                        if (++validKeysCount == freq.Keys.Count)
                        {
                            return substring;
                        }
                    }
                }
            }
        }
        return "";
    }
    
    /// <summary>
    /// More time-efficient compare to 2nd. 
    /// But, it still has the worst performance
    /// </summary>
    public string MinWindow_3(string s, string t)
    {
        if (t.Length > s.Length) return "";

        Dictionary<char, int> freq = [];
        foreach (char c in t)
        {
            if (freq.TryGetValue(c, out int cFrequency))
            {
                freq[c] = ++cFrequency;
            }
            else
            {
                freq[c] = 1;
            }
        }

        int right = 0;
        int left = 0;
        string result = "";
        Dictionary<char, int> curFrq = [];

        for (; right < s.Length; right++)
        {

            if (curFrq.TryGetValue(s[right], out int val))
            {
                curFrq[s[right]] = ++val;
            }
            else
            {
                curFrq.Add(s[right], 1);
            }

            while (IsIncluded(freq, curFrq))
            {
                if (string.IsNullOrEmpty(result))
                {
                    result = s[left..(right + 1)];
                }
                else
                {
                    string currentSubstring = s[left..(right + 1)];

                    result = currentSubstring.Length < result.Length
                        ? currentSubstring
                        : result;
                }
                curFrq[s[left]]--;
                left++;
            }

        }
        return result;
    }
    
    private bool IsIncluded(Dictionary<char, int> outer, Dictionary<char, int> inner)
    {
        foreach (char c in outer.Keys)
        {
            bool hasKey = inner.TryGetValue(c, out int value);
            if (!hasKey)
            {
                return false;
            }
            else if (outer[c] > value || value < 0)
            {
                return false;
            }
        }
        return true;
        
    }
}
