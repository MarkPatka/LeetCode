namespace LeetCode.Top150Interview.SpiralMatrix_54;

public partial class Solution
{
    /// <summary>
    /// The most efficient and straightforward boundary-shrinking approach
    /// </summary>
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int row = matrix.Length;
        int col = matrix[0].Length;
        List<int> ans = new List<int>();
        int left = 0, right = col - 1;
        int top = 0, bottom = row - 1;

        while (left <= right && top <= bottom)
        {
            for (int i = left; i <= right; i++)
            {
                ans.Add(matrix[top][i]);
            }
            top++;
            for (int i = top; i <= bottom; i++)
            {
                ans.Add(matrix[i][right]);
            }
            right--;
            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                {
                    ans.Add(matrix[bottom][i]);
                }
                bottom--;
            }
            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                {
                    ans.Add(matrix[i][left]);
                }
                left++;
            }
        }
        return ans;
    }



    /// <summary>
    /// Flexible for the more complex scenarios, but less efficient compare to the first one
    /// </summary>
    public IList<int> SpiralOrder_1(int[][] matrix)
    {
        Dictionary<(int, int), int> elements = [];
        int direction = 1 << 3;
        int iLen = matrix.Length;
        int jLen = matrix[0].Length;
        (int i, int j) idx = (0, 0);

        if (matrix.Length == 1)
        {
            return [.. matrix[0]];
        }

        if (jLen == 1) 
        {
            List<int> list = [];
            foreach (int[] i in matrix)
            {
                list.Add(i[0]);
            }
            return list;
        }

        while (true)
        {
            if (idx.i < iLen && idx.j < jLen && elements.TryAdd(idx, matrix[idx.i][idx.j]))
            {
                MoveMatrixIndex(ref idx, ref direction, iLen, jLen);
            }
            else
            {
                MoveBackMatrixIndexWithDirectionChange(ref idx, ref direction, iLen, jLen);
                MoveMatrixIndex(ref idx, ref direction, iLen, jLen);

                if (!elements.TryAdd(idx, matrix[idx.i][idx.j]))
                {
                    break;
                }
                else
                {
                    MoveMatrixIndex(ref idx, ref direction, iLen, jLen);
                }
            }
        }
        return [.. elements.Values];
    }
    
    static void MoveMatrixIndex(ref (int, int) index, ref int directionFlag, int iLen, int jLen)
    {
        switch (directionFlag)
        {
            case 8:
                {
                    if (index.Item2 < jLen - 1)
                    {
                        index.Item2++;
                        break;
                    }
                    else
                    {
                        directionFlag >>= 1;
                        MoveMatrixIndex(ref index, ref directionFlag, iLen, jLen);
                        break;
                    }
                }
            case 4:
                {
                    if (index.Item1 < iLen - 1)
                    {
                        index.Item1++;
                        break;
                    }
                    else
                    {
                        directionFlag >>= 1;
                        MoveMatrixIndex(ref index, ref directionFlag, iLen, jLen);
                        break;
                    }
                }
            case 2:
                {
                    if (index.Item2 > 0)
                    {
                        index.Item2--;
                        break;
                    }
                    else
                    {
                        directionFlag >>= 1;
                        MoveMatrixIndex(ref index, ref directionFlag, iLen, jLen);
                        break;
                    }
                }
            case 1:
                {
                    if (index.Item1 > 0)
                    {
                        index.Item1--;
                        break;
                    }
                    else
                    {
                        directionFlag = 1 << 3;
                        MoveMatrixIndex(ref index, ref directionFlag, iLen, jLen);
                        break;
                    }
                }
            default:
                break;
        }
    }
    static void MoveBackMatrixIndexWithDirectionChange(ref (int, int) index, ref int directionFlag, int iLen, int jLen)
    {
        switch (directionFlag)
        {
            case 8:
                index.Item2--;
                directionFlag >>= 1;
                break;
            case 4:
                index.Item1--;
                directionFlag >>= 1;
                break;
            case 2:
                index.Item2++;
                directionFlag >>= 1;
                break;
            case 1:
                index.Item1++;
                directionFlag = 1 << 3;
                break;
            default:
                break;
        }
    }
}
