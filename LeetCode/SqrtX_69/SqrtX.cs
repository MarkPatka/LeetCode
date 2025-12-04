namespace LeetCode.SqrtX_69;

public partial class Solution
{
    public int MySqrt(int x)
    {
        if (x <= 1) return x;
        long left = 0;
        long right = x / 2;

        while (left + 1 < right)
        {
            long mid = (left + right) / 2;

            if ((mid * mid) > x)
            {
                right = mid;
            }
            else
            {
                left = mid;
            }
        }

        return (int)left;
    }
}
