namespace LeetCode.Top150Interview.TwoSum_167;

public partial class Solution
{
    /// <summary>
    /// The less straightforward solution uses dictionary space creation overhead 
    /// </summary>
    public int[] TwoSum_1(int[] numbers, int target)
    {
        int[] result = new int[2];
        Dictionary<int, int> kvp = []; 
        
        for (int i = 0; i < numbers.Length; i++)
        {
            kvp.TryAdd(numbers[i], i + 1);
        }
                
        for (int i = 0; i < numbers.Length; i++)
        {
            int key = target - numbers[i];
            if (kvp.TryGetValue(key, out int val))
            {
                result[0] = i + 1;
                result[1] = val == i + 1 ? val + 1 : val;
                return result;
            }
        }
        return result;
    }

    /// <summary>
    /// Simpe, efficient and straightforward solution
    /// uses non descending order constraint and two pointers approach
    /// </summary>
    public int[] TwoSum_2(int[] numbers, int target)
    {
        int[] arr = new int[2];
        int l = 0, r = numbers.Length - 1;
        while (l < r)
        {
            if (numbers[l] + numbers[r] == target)
            {
                arr[0] = l + 1;
                arr[1] = r + 1;
                return arr;
            }
            else if (numbers[l] + numbers[r] > target)
            {
                r--;
            }
            else
            {
                l++;
            }
        }
        return arr;
    }


}
