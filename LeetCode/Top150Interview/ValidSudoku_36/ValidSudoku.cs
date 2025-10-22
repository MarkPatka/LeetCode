namespace LeetCode.Top150Interview.ValidSudoku_36;

public partial class Solution
{
    /// <summary>
    /// The most efficient one
    /// </summary>
    public bool IsValidSudoku(char[][] board)
    {
        // 9 masks for rows, cols, and 3×3 blocks
        int[] rows = new int[9];
        int[] cols = new int[9];
        int[] blocks = new int[9];         // block index = (r / 3) * 3 + (c / 3)

        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                char ch = board[r][c];
                if (ch == '.') continue;           // empty cell, skip

                int bit = 1 << (ch - '1');         // map '1'..'9' → bit 0..8
                int b = (r / 3) * 3 + (c / 3);   // 0..8 block id

                // if bit already set anywhere ⇒ duplicate
                if ((rows[r] & bit) != 0 ||
                    (cols[c] & bit) != 0 ||
                    (blocks[b] & bit) != 0)
                {
                    return false;
                }

                // mark presence
                rows[r]   |= bit;
                cols[c]   |= bit;
                blocks[b] |= bit;
            }
        }
        return true;   // no conflicts found

    }

    /// <summary>
    /// Optimal solution
    /// </summary>
    public bool IsValidSudoku_1(char[][] board)
    {
        var row = new HashSet<char>[9];
        var column = new HashSet<char>[9];
        var box = new HashSet<char>[9];

        for (var i = 0; i < 9; i++)
        {
            row[i] = [];
            column[i] = [];
            box[i] = [];
        }

        for (var r = 0; r < 9; r++)
        {
            for (var c = 0; c < 9; c++)
            {
                char val = board[r][c];
                if (val == '.') continue;

                var boxIndex = (r / 3) * 3 + c / 3;

                if (row[r].Contains(val) || column[c].Contains(val) || box[boxIndex].Contains(val))
                    return false;

                row[r].Add(val);
                column[c].Add(val);
                box[boxIndex].Add(val);
            }
        }

        return true;
    }


    /// <summary>
    /// More straightforward
    /// </summary>
    public bool IsValidSudoku_2(char[][] board)
    {
        // Check SubBlocks 3x3
        char[,] subBox = new char[3, 3];
        int currentLine = 0;

        for (int block = 0; block < 9; block += 3)
        {
            for (int subLine = 0; subLine < 9; subLine++)
            {
                var line = board[subLine][block..(block + 3)];
                for (int i = 0; i < 3; i++)
                {
                    subBox[currentLine, i] = line[i];
                }

                currentLine++;

                if ((subLine + 1) % 3 == 0)
                {
                    bool validBlock = IsValidSubBox(subBox);
                    if (!validBlock) return false;
                    
                    subBox = new char[3, 3];
                    currentLine = 0;
                }
            }
        }

        for (int i = 0; i < 9; i++)
        {
            // Check horizontal lines
            if (!IsValidLine(board[i]))
                return false;


            // Check vertical lines
            char[] vert = new char[9];
            for (int j = 0; j < 9; j++)
            {
                vert[j] = board[j][i];
            }

            if (!IsValidLine(vert))
                return false;
        }


        return true;
    }
    private bool IsValidSubBox(char[,] subBoard)
    {
        Span<int> span = stackalloc int[58]; 
        foreach (char c in subBoard) 
        {
            if (c == 46) continue;
            
            span[c]++;
            
            if (span[c] > 1) return false;
        }
        return true;
    }
    private bool IsValidLine(char[] line)
    {
        Span<int> span = stackalloc int[58];
        for (int i = 0;  i < line.Length; i++)
        {
            if (line[i] == 46) continue;

            span[line[i]]++;

            if (span[line[i]] > 1) return false;
        }
        return true;
    }

    
}
