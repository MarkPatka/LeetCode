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

    public int Trap_2(int[] height)
    {
        int len = height.Length - 1;

        int leftPosition = 0;
        int rightPosition = 2;

        int result = 0;
        for (int i = 1; i < len; i++)
        {
            if ((height[leftPosition] > height[i]) && 
                (height[leftPosition] <= height[rightPosition]))
            {
                result = 0;
                int sq = height[leftPosition] * (i - leftPosition);
                int extract = height[(leftPosition + 1) .. rightPosition].Sum();
                result += sq - extract;

                leftPosition = rightPosition;
                rightPosition++;
                continue;
            }

            if (height[i] < height[rightPosition] && 
                height[rightPosition] < height[leftPosition])
            {
                result += height[rightPosition] - height[i];
            }

            // If height[i] = 0 and If height[i + 1] ... = 0
            // we need to consider the length of height[i] == 0

            rightPosition++;
        }

        return result;
    }
}
