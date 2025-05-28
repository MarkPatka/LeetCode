using System.Text;

namespace LeetCode.Top150Interview.ZigzagConversion_6;

public partial class Solution
{
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
