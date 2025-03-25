using System.Net.Http.Headers;

namespace LeetCode.Top150Interview.Candy_135;

public partial class Solution
{
    /// It`s Okay
    public int Candy(int[] ratings)
    {
        int l = ratings.Length;
        if (l == 1) return 1;
        
        int[] dist = new int[l];
        Array.Fill(dist, 1);

        for (int i = 1; i < l; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                dist[i] = dist[i - 1] + 1;
            }
        }

        for (int i = l - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {                
                dist[i] = Math.Max(dist[i], dist[i + 1] + 1);
            }
        }

        return dist.Sum();
    }

    /// this one has best performance
    public int Candy2(int[] ratings)
    {
        int l = ratings.Length;
        if (l == 1) return 1;

        int totalCandies = 1;
        int up = 1, down = 0, peak = 1;

        for (int i = 1; i < l; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                up++;
                down = 0;
                peak = up;
                totalCandies += up;
            }
            else if (ratings[i] < ratings[i - 1])
            {
                down++;
                up = 1;
                totalCandies += down;
                if (peak <= down)
                {
                    totalCandies++;
                }
            }
            else
            {
                up = 1;
                down = 0;
                peak = 1;
                totalCandies += 1;
            }
        }

        return totalCandies;
    }
}
