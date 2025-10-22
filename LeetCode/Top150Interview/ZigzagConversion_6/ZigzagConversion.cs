using System.Text;

namespace LeetCode.Top150Interview.ZigzagConversion_6;

public partial class Solution
{
    /// <summary>
    /// Common sufficient solution
    /// </summary>
    public string ZigzagConversion_4(string s, int numRows)
    {
        if (numRows == 1 || s.Length <= numRows) return s;

        StringBuilder[] rows = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
        {
            rows[i] = new StringBuilder();
        }

        int currentRow = 0;
        bool goingDown = false;

        foreach (char c in s)
        {
            rows[currentRow].Append(c);
            if (currentRow == 0 || currentRow == numRows - 1)
            {
                goingDown = !goingDown;
            }
            currentRow += goingDown ? 1 : -1;
        }

        StringBuilder result = new StringBuilder();
        foreach (var row in rows)
        {
            result.Append(row);
        }

        return result.ToString();
    }

    /// <summary>
    /// The most time and space efficient solution
    /// </summary>
    public string ZigzagConversion_3(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }

        Span<char> result = stackalloc char[s.Length];

        var resultIndex = 0;
        var period = numRows * 2 - 2;

        for (int row = 0; row < numRows; row++)
        {
            var increment = 2 * row;

            for (int i = row; i < s.Length; i += increment)
            {
                result[resultIndex++] = s[i];

                if (increment != period)
                {
                    increment = period - increment;
                }
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// The worst one
    /// </summary>
    public string ZigzagConversion_2(string s, int numRows)
    {
        if (numRows == 1) return s;
        if (numRows < 1) return "";

        int row = 0;
        int col = 0;

        char[,] strings = new char[numRows, s.Length];
        
        for (int i = 0; i < s.Length; i++)
        {
            if (row == numRows)
            {
                row -= 2;
                while (row > 0 && i < s.Length)
                {
                    col++;
                    strings[row, col] = s[i];
                    i++;
                    row--;
                }
                i--;
                row = 0;
                col++;
            }
            else
            {
                strings[row, col] = s[i];
                row++;
            }
        }

        StringBuilder zigZagBuilder = new(s.Length);
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < col + 1; j++)
            {
                if (strings[i, j] != '\0')
                {
                    zigZagBuilder.Append(strings[i, j]);
                }
            }
        }

        return zigZagBuilder.ToString();
    }

    /// <summary>
    /// A bit faster than the worst one
    /// </summary>
    public string ZigzagConversion(string s, int numRows)
    {
        if (numRows == 1) return s;
        if (numRows < 1)  return "";
        
        int len = s.Length;
        int blocks = 0;
        int interimBlocks = numRows - 2;

        while (len > numRows)
        {
            blocks += (1 + interimBlocks);
            len -= (numRows + interimBlocks);
        }
        if (len > 0) blocks++; 

        char[][] strings = new char[blocks][];

        int nextFull = 0;
        int strIdx = 0;
        int tmpIdx = numRows - 2;
        bool needReverse = false;

        for (int i = 0; i < blocks; i++)
        {
            char[] part = new char[numRows];
            if (i == nextFull)
            {
                tmpIdx = numRows - 2;
                if (!needReverse)
                {
                    int to = (strIdx + numRows);
                    if (to > s.Length) to = s.Length;

                    string partStr = s[strIdx..to];
                    for (int j = 0; j < partStr.Length; j++)
                    {
                        part[j] = partStr[j];
                    }
                    strings[i] = part;
                    needReverse = true;
                }
                else
                {

                    int to = (strIdx + numRows);
                    if (to > s.Length) to = s.Length;

                    string partStr = s[strIdx..to];
                    int j = partStr.Length - 1;
                    for (; j >= 0; j--)
                    {
                        part[j] = partStr[j];
                    }
                    strings[i] = part;
                    needReverse = false;
                }
                strIdx += numRows;
                nextFull += interimBlocks + 1;

            }
            else
            {
                part[tmpIdx] = s[strIdx];
                strings[i] = part;
                tmpIdx--;
                strIdx++;
            }
            if (strIdx >= s.Length) break;
        }

        StringBuilder zigZagBuilder = new(s.Length);
        for (int i = 0; i < numRows; i++) 
        {
            foreach (var block in strings)
            {
                if (block != null)
                {
                    if (block[i] != '\0')
                        zigZagBuilder.Append(block[i]);
                }
            }
        }

        return zigZagBuilder.ToString();
    }
}
