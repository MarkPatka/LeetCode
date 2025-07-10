namespace LeetCode.Top150Interview.RotateImage_48;

public partial class Solution
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;

        // transpose the matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {

                // Slower in practice then usage an explicit temp variable
                // because XOR swaps involve multiple read/write operations
                // and prevent compiler optimizations.
                // 
                // So its better to use tme variable to replace elements
                // because of it’s likely faster in real-world execution
                // due to better CPU optimization
                matrix[i][j] = matrix[i][j] ^ matrix[j][i];
                matrix[j][i] = matrix[i][j] ^ matrix[j][i];
                matrix[i][j] = matrix[i][j] ^ matrix[j][i];
            }
        }

        // reverse each line
        foreach (var line in matrix)
        {
            Array.Reverse(line);
        }
    }
}
