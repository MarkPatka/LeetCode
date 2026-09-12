namespace LeetCode.MergeIntervals_56;

public partial class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        // quick sort the intervals by x2 in each inner arr[x1, x2]
        Sort(intervals, 0, intervals.Length - 1);

        // go through all sorted arrays and select those who supposed to be merged
        int r = 1;
        int[] mergedInterval = intervals[0];
        List<int[]> result = [];
        while (r < intervals.Length)
        {
            if (mergedInterval[1] >= intervals[r][0])
            {
                mergedInterval[1] = Math.Max(intervals[r][1], mergedInterval[1]);
            }
            else
            {
                result.Add(mergedInterval);
                mergedInterval = intervals[r];
            }
            r++;
        }
        result.Add(mergedInterval);

        return [.. result];
    }

    private static void Sort(int[][] arr, int low, int hight)
    {
        if (low < hight)
        {
            int pivot = Partition(arr, low, hight);

            Sort(arr, low, pivot - 1);
            Sort(arr, pivot + 1, hight);
        }
    }

    private static int Partition(int[][] arr, int low, int hight)
    {
        int[] pivot = arr[hight];
        int i = low - 1;

        for (int j = low; j < hight;  j++)
        {
            if (arr[j][0] < pivot[0])
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
            
        (arr[i + 1], arr[hight]) = (arr[hight], arr[i + 1]);
        return i + 1;
    }
}
