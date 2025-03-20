namespace LeetCode.Top150Interview.Candy_135;

public partial class Solution
{
    //Input: ratings = [1, 0, 2]
    //Output: 5 =>     [2, 1, 2]
 
    //Input: ratings = [1, 2, 2]
    //Output: 4 =>     [1, 2, 1]
    public int Candy(int[] ratings)
    {
        int l = ratings.Length;
        if (l == 1) return 1;
        if (l == 2) return ratings[0] == ratings[1] ? 2 : 3;
        
        int[] dist = new int[l];
        Array.Fill(dist, 1);

        var leftBorder = ProcessBorders(ratings[0], ratings[1]);
        dist[0] += leftBorder.l;
        dist[1] += leftBorder.r;

        var rightBorder = ProcessBorders(ratings[^2], ratings[^1]);
        dist[^2] += rightBorder.l;
        dist[^1] += rightBorder.r;

        for (int i = 1; i < l - 1; i++)
        {
            int leftPoint = ratings[i];
            int rightPoint = ratings[i + 1];

            if (leftPoint != rightPoint)
            {
                dist[i]++;
            }
        }
        return 0;
    }

    private (int l, int r) ProcessBorders(int left, int right)
    {
        (int l, int r) = (0, 0);

        if (left != right)
        {
            if (left > right)
            {
                l++;
            }
            else
            {
                r++;
            }
        }
        return (l, r);

    }
}
