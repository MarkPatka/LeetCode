using System.Text;

namespace LeetCode.Top150Interview.TextJustification_68;

public partial class Solution 
{


    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        List<StringBuilder> justified = [];
        justified.Add(new StringBuilder(maxWidth));
        int currentRow = 0;
        int currentRowLen = 0;

        string space = " ";
        int spacesCount = 0;
        foreach (string word in words) 
        {
            if (word.Length + currentRowLen < maxWidth)
            {
                if (currentRowLen != 0)
                { 
                    justified[currentRow].Append(space);
                    spacesCount++;
                    currentRowLen++;
                }
                justified[currentRow].Append(word);                
                currentRowLen += word.Length;
            }
            else if (word.Length == maxWidth)
            {

                if (justified[currentRow].Length == 0)
                {
                    justified[currentRow].Append(word);
                    justified.Add(new StringBuilder(maxWidth));
                    currentRow++;
                }
                else
                {
                    NormalizeString(maxWidth, justified, currentRow, currentRowLen, space, spacesCount);
                    justified.Add(new StringBuilder(maxWidth));
                    currentRow++;
                    justified[currentRow].Append(word);
                    justified.Add(new StringBuilder(maxWidth));
                    currentRow++;
                }
            }
            else
            {
                if (justified[currentRow].Length > 0)
                {
                    NormalizeString(maxWidth, justified, currentRow, currentRowLen, space, spacesCount);
                    justified.Add(new StringBuilder(maxWidth));
                    currentRow++;
                }
                
                justified[currentRow].Append(word);
                currentRowLen = word.Length;
                spacesCount = 0;
            }
        }

        var lastRow = justified[^1];
        if (lastRow.Length == 0)
        {
            if (justified[^2].Length != maxWidth)
            {
                int empty = maxWidth - currentRowLen;
                for (int i = 0; i < empty; i++)
                {
                    justified[currentRow - 1].Append(space);
                }
            }
            return [.. justified[0..^1].Select(x => x.ToString())];
        }
        else if (lastRow.Length != maxWidth)
        {
            int empty = maxWidth - currentRowLen;
            for (int i = 0; i < empty; i++)
            {
                justified[currentRow].Append(space);
            }
        }

        return [.. justified.Select(x => x.ToString())];
    }

    private static void NormalizeString(int maxWidth, List<StringBuilder> justified, int currentRow, int currentRowLen, string space, int spacesCount)
    {
        int empty = maxWidth - currentRowLen;
        if (empty > 0)
        {
            if (spacesCount == 0)
            {
                for (int i = 0; i < empty; i++)
                {
                    justified[currentRow].Append(space);
                }
            }
            else if (empty % spacesCount == 0)
            {
                int adjustEachSpaceWith = empty / spacesCount;
                string adjustSpace = space;
                for (int i = 0; i < adjustEachSpaceWith; i++)
                {
                    adjustSpace += space;
                }
                justified[currentRow].Replace(space, adjustSpace);
            }
            else
            {
                int i = 0;
                var row = justified[currentRow];

                while (empty > 0)
                {
                    if (char.Equals(row[i], ' '))
                    {
                        row.Insert(i, ' ');
                        empty--;
                        i++;
                    }
                    i++;
                    if (i == row.Length) i = 0;
                }
            }
        }
    }

}
