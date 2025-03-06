namespace LeetCode.Top150Interview.ProductofArrayExceptSelf_238;

public class ProductofArrayExceptSelf
{
    // USING DIVISION OPERATION
    public int[] ProductExceptSelf1(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        int products = 1;
        int zeros = 0;
        int zeroIdx = -1;
        
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                zeros++;
                zeroIdx = i;
                continue;
            }
            products *= nums[i];
        }
        
        if (zeros == 1)
        {
            ans[zeroIdx] = products;
        }
        else if (zeros == 0)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = products / nums[i];
            }
        }            
        return ans;
    }

    // NOT USING DIVISION OPERATION
    // https://www.youtube.com/watch?v=bNvIQI2wAjk
    public int[] ProductExceptSelf2(int[] nums)
    {
        var result = new int[nums.Length];
        result[0] = 1;

        for (int i = 1; i < nums.Length; i++)
            result[i] = result[i - 1] * nums[i - 1];

        int rightSide = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] = result[i] * rightSide;
            rightSide *= nums[i];
        }

        return result;
    }
}
