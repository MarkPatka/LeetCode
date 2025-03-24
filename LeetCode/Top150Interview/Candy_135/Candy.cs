using System.Net.Http.Headers;

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

        for (int i = 1; i < l; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                dist[i]++;
            }
        }
        for (int i = l - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {
                dist[i]++;
            }
        }

        if (ratings[0] > ratings[1]) dist[0]++;
        if (ratings[^2] < ratings[^1]) dist[^1]++;

        for (int i = 0; i < l; i++)
        {
            if (dist[i] == 0) dist[i]++;
        }

        return dist.Sum();
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
