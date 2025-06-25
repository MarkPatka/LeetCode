namespace LeetCode.Top150Interview.ContainerWithMostWater_11;

public partial class Solution
{
    /// <summary>
    /// The most efficient and uses two-pointers approach more clearly
    /// </summary>
    public int MaxArea2(int[] height)
    {
        int maxArea = 0;
        int left = 0;
        int right = height.Length - 1;

        while (left < right)
        {
            int currentHeight = Math.Min(height[left], height[right]);
            int currentWidth = right - left;
            int currentArea = currentHeight * currentWidth;

            maxArea = Math.Max(maxArea, currentArea);

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }

    /// <summary>
    /// More straightforward, less efficient
    /// </summary>
    public int MaxArea1(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;

        int maxSq = -1;

        for (; right > left; right--)
        {
            maxSq = CheckMax(height, left, right, maxSq);

            if (height[right] >= height[left])
            {
                for (; left < right; left++)
                {
                    maxSq = CheckMax(height, left, right, maxSq);

                    if (height[left] >= height[right])
                    {
                        break;
                    }
                }
            }
        }

        return maxSq;
    }

    private static int CheckMax(int[] height, int left, int right, int maxSq)
    {
        int x = right - left;
        int y = Math.Min(height[left], height[right]);
        int sq = x * y;
        if (maxSq < sq) maxSq = sq;
        return maxSq;
    }
}
