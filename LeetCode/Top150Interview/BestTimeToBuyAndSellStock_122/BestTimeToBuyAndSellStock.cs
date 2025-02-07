namespace LeetCode.Top150Interview.BestTimeToBuyAndSellStock_122;

public class BestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        int res = 0;
        if (prices.Length < 2) return res;

        for (int i = 0; i < prices.Length - 1; i++)
        {
            int profit = prices[i + 1] - prices[i];
            if (profit > 0)
            {
                res += profit;
            }
        }
        return res;
    }
}
