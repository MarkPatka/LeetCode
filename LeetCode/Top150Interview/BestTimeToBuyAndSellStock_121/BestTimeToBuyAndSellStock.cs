namespace LeetCode.Top150Interview.BestTimeToBuyAndSellStock_121;

public class BestTimeToBuyAndSellStock
{
    /// <summary>
    /// Time complexity is huge
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit1(int[] prices)
    {
        int maxProfit = 0;
        for (int i = 0; i < prices.Length - 1; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                int profit = prices[j] - prices[i];
                if (profit > maxProfit) 
                {
                    maxProfit = profit;
                }
            }
        }
        return maxProfit;
    }

    /// <summary>
    /// The best solution
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit2(int[] prices)
    {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int currentPrice in prices)
        {
            minPrice = Math.Min(currentPrice, minPrice);
            maxProfit = Math.Max(maxProfit, currentPrice - minPrice);
        }
        return maxProfit;
    }

    /// <summary>
    /// Time complexity is better but still huge
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit3(int[] prices)
    {
        int[] deltas = new int[prices.Length - 1];
        int maxProfit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            int res = prices[i] - prices[0];
            deltas[i - 1] = res;
            if (res > maxProfit)
            {
                maxProfit = res;
            }
        }

        for (int i = 1; i < prices.Length - 1; i++)
        {
            int diff = prices[0] - prices[i];
            if (diff > 0)
            {
                int profit = Max(deltas, i - 1) + diff;
                
                if (maxProfit < profit)
                    maxProfit = profit;
            }
        }
        return maxProfit;
    }

    static int Max(int[] prices, int fromIndex = 0)
    {
        int max = prices[fromIndex];
        for (;  fromIndex < prices.Length; fromIndex++)
        {
            if (prices[fromIndex] > max)
            {
                max = prices[fromIndex];
            }
        }
        return max;
    }
}
