using System.Runtime.CompilerServices;

namespace LeetCode.Top150Interview.SetMatrixZeroes_73;

public partial class Solution
{
    /// <summary>
    /// Much better and uses only 1 row and 1 col as markers for row/col zeros
    /// Allocate only 2 bool vars
    /// </summary>
    public void SetZeroes(int[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        // scan row, determine placement of zeros, MARK rows/cols to be zeroed, do zeroization

        // could use extra space to know where to mark, but will be using the matrix memory space
        var firstRowHasZeroes = false;
        var firstColHasZeroes = false;

        // check all rows in first col for zeroes
        for (int row = 0; row < rows; row++)
        {
            if (matrix[row][0] == 0)
            {
                firstColHasZeroes = true;
                break;
            }
        }
        // check all cols in first row for zeroes
        for (int col = 0; col < cols; col++)
        {
            if (matrix[0][col] == 0)
            {
                firstRowHasZeroes = true;
                break;
            }
        }

        // now firstRow and firstCol are available as markers for rest of matrix
        // scan rest of matrix
        for (int row = 1; row < rows; row++)
        {
            for (int col = 1; col < cols; col++)
            {
                if (matrix[row][col] == 0)
                {
                    // mark in first row and first col
                    matrix[0][col] = 0;
                    matrix[row][0] = 0;
                }
            }
        }

        // now zeroize the marked rows/cols
        for (int row = 1; row < rows; row++)
        {
            if (matrix[row][0] == 0)
            {
                for (int col = 1; col < cols; col++)
                {
                    matrix[row][col] = 0;
                }
            }
        }
        for (int col = 1; col < cols; col++)
        {
            if (matrix[0][col] == 0)
            {
                for (int row = 1; row < rows; row++)
                {
                    matrix[row][col] = 0;
                }
            }
        }

        // then set the first row and first col if the markers are true
        if (firstRowHasZeroes)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[0][col] = 0;
            }
        }
        if (firstColHasZeroes)
        {
            for (int row = 0; row < rows; row++)
            {
                matrix[row][0] = 0;
            }
        }
    }

    /// <summary>
    /// Uses List(int, int) heap allocation which the worst decision.
    /// If multiple zeros exist in the same row/column, it reprocesses the same rows/columns repeatedly
    ///     First loop:  O(m×n) to find zeros.
    ///     Second loop: For each zero, does O(m) + O(n) work(setting rows/columns).
    ///     Worst case:  O(m×n × (m+n)) → O(n³) for square matrices.
    /// Allocates new arrays for entire rows (slow, triggers GC) in "matrix[i] = new int[jLen];".
    /// </summary>
    public void SetZeroes_1(int[][] matrix)
    {
        int iLen = matrix.Length;
        int jLen = matrix[0].Length;

        List<(int i, int j)> zerosPositions = new(matrix.Length * matrix[0].Length);

        for ((int i, int j) = (0, 0); i < iLen;)
        {
            if (j == jLen)
            {
                j = 0;
                if (++i == iLen) break;
            }

            if (matrix[i][j] == 0)
            {
                zerosPositions.Add((i, j));
            }

            j++;
        }

        foreach (var (i, j) in zerosPositions)
        {
            foreach (var row in matrix)
            {
                row[j] = 0;
            }

            matrix[i] = new int[jLen];
        }
    }

    /// <summary>
    /// The best one implementation and very clever solution with a 256x256 bitmask for pointing the zeros
    /// It takes time to figure out what is going on but it worth to get these technics
    /// </summary>
    public unsafe void SetZeroes_3(int[][] matrix)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void markBit(ulong* mask, int idx, ulong val) =>
            mask[idx >>> 6] |= val << idx;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool readBit(ulong* mask, int idx) =>
            (mask[idx >>> 6] & (1UL << idx)) != 0;

        var rowMask = stackalloc ulong[4];
        var colMask = stackalloc ulong[4];

        for (var y = 0; y < matrix.Length; ++y)
        {
            for (var x = 0; x < matrix[y].Length; ++x)
            {
                var curr = matrix[y][x];
                var val = (ulong)(~(curr | -curr) >>> 31);
                markBit(rowMask, y, val);
                markBit(colMask, x, val);
            }
        }

        for (var y = 0; y < matrix.Length; ++y)
        {
            for (var x = 0; x < matrix[y].Length; ++x)
            {
                if (readBit(rowMask, y) | readBit(colMask, x))
                    matrix[y][x] = 0;
            }
        }
    }
}
