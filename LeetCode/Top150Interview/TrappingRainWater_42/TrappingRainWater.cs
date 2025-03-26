namespace LeetCode.Top150Interview.TrappingRainWater_42;

public partial class Solution
{
    /// It`s need to improve performance
    /// But the solution logic is correct
    public int Trap(int[] height)
    {
        int len = height.Length;
        int max = height.Max();
        int sum = 0;

        for (int j = 0; j <= max; j++)
        {
            int startFrom = 0;
            int endFrom = 0;

            for (int i = 0; i < len; i++)
            {
                if (height[i] >= j)
                {
                    startFrom = i;
                    break;
                }
            }

            for (int i = len - 1; i >= 0; i--)
            {
                if (height[i] >= j)
                {
                    endFrom = i;
                    break;
                }
            }

            for (int i = startFrom; i < endFrom; i++)
            {
                if (height[i] < j)
                {
                    sum++;
                }
            }
        }
        return sum;
    }
}
