namespace LeetCode.Top150Interview.SubstringwithConcatenationofAllWords_30;

public partial class Solution
{
    /// <summary>
    /// It has complexity of ~O(n * m * k) where:
    /// - n is the length of string s
    /// - m is the number of words
    /// - k is the length of each word
    /// And will be running abour 2 sec
    /// Which is to overhead the time limits
    /// </summary>
    public IList<int> FindSubstring_1(string s, string[] words)
    {
        List<int> result = [];
        int l = 0, step = words[0].Length, r = step * words.Length;

        var allWords = words
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());


        while (r <= s.Length)
        {
            if (r > s.Length) break;

            string substring = s[l..r];
            List<string> substrings = [];

            for (int i = 0; i <= substring.Length - step; i += step)
            {
                substrings.Add(substring[i..(i + step)]);
            }

            var subwords = substrings
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            if (AreEqual(subwords, allWords))
            {
                result.Add(l);
            }

            r++;
            l++;
        }
        return result;
    }

    /// <summary>
    /// That`s one is an optimal solution
    /// </summary>
    public IList<int> FindSubstring_2(string s, string[] words)
    {
        List<int> result = [];
        if (words.Length == 0 || s.Length == 0) return result;

        int wordLength = words[0].Length;
        int totalLength = wordLength * words.Length;
        if (s.Length < totalLength) return result;

        // Create frequency map of words
        Dictionary<string, int> wordCount = [];
        foreach (var word in words)
        {
            if (wordCount.TryGetValue(word, out int value))
                wordCount[word] = ++value;
            else
                wordCount[word] = 1;
        }

        // We only need to check starting positions from 0 to wordLength-1
        for (int i = 0; i < wordLength; i++)
        {
            int left = i;
            int count = 0;
            var currentCount = new Dictionary<string, int>();

            for (int j = i; j <= s.Length - wordLength; j += wordLength)
            {
                string currentWord = s.Substring(j, wordLength);

                if (wordCount.ContainsKey(currentWord))
                {
                    // Add to current count
                    if (currentCount.TryGetValue(currentWord, out int value))
                        currentCount[currentWord] = ++value;
                    else
                        currentCount[currentWord] = 1;

                    count++;

                    // If we have more occurrences than needed, move left pointer
                    while (currentCount[currentWord] > wordCount[currentWord])
                    {
                        string leftWord = s.Substring(left, wordLength);
                        currentCount[leftWord]--;
                        count--;
                        left += wordLength;
                    }

                    // If we found all words
                    if (count == words.Length)
                    {
                        result.Add(left);
                        // Move left pointer by one word
                        string leftWord = s.Substring(left, wordLength);
                        currentCount[leftWord]--;
                        count--;
                        left += wordLength;
                    }
                }
                else
                {
                    // Reset everything if we encounter an invalid word
                    currentCount.Clear();
                    count = 0;
                    left = j + wordLength;
                }
            }
        }

        return result;
    }



    static bool AreEqual(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
    {
        if (ReferenceEquals(dict1, dict2)) return true;
        if (dict1 == null || dict2 == null) return false;

        if (dict1.Count != dict2.Count) return false;

        foreach (var pair in dict1)
        {
            if (!dict2.TryGetValue(pair.Key, out int value) || value != pair.Value)
            {
                return false;
            }
        }

        return true;
    }
}
