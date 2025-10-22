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

    /// <summary>
    /// This one is better than first, 
    /// but kinda brutforce and not optimal, 
    /// despite it has been accepted
    /// </summary>
    public int Trap_2(int[] height)
    {
        int len = height.Length;
        if (len <= 2) return 0;

        int left = 0;
        int right = 1;

        int trapped = 0;
        for (; right < len; right++)
        {
            if (height[left] <= height[right]) { left++; continue; }
            else if (right != len - 1)
            {
                int a = height[left] + 1;
                int i = right;
                int b = 0;
                int r = -1;
                do
                {
                    a--;
                    for (; i < len; i++)
                    {
                        if (height[i] >= a)
                        {
                            b = i - left - 1;
                            r = i;    
                            break;
                        }
                    }
                    i = right;
                }
                while (a > 0 && r < i);
                if (r == -1) return trapped;

                int exclude = height[i..r].Sum();
                trapped += (a * b) - exclude;
                
                right = r;
                left = r;
            }
        }
        return trapped;
    }

    /// <summary>
    /// The best one. 
    /// It does Properly use two-pointers approach. 
    /// And time complexity ~O(n), space complexity ~O(1)
    /// </summary>
    public int Trap_3(int[] height)
    {
        if (height == null || height.Length < 3)
            return 0;

        int left = 0;
        int right = height.Length - 1;
        
        int leftMax = 0;
        int rightMax = 0;
        int result = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax)
                    leftMax = height[left];
                else
                    result += leftMax - height[left];

                left++;
            }
            else
            {
                if (height[right] >= rightMax)
                    rightMax = height[right];
                else
                    result += rightMax - height[right];

                right--;
            }
        }

        return result;

    }
}
