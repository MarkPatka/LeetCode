using static System.Net.Mime.MediaTypeNames;

namespace LeetCode.HappyNumber_202;

public partial class Solution
{
    public bool IsHappy(int n)
    {
        HashSet<int> seen = [];
        return GetNumberDigitsSquares_1(n, seen);
    }

    // Using HashSet approach overhead
    private bool GetNumberDigitsSquares_1(int n, HashSet<int> seen)
    {
        if (n == 1) return true;
        
        // If we've seen this number before, we're in a cycle
        if (seen.Contains(n)) return false;
        seen.Add(n);

        int sum = 0;

        while (n > 0)
        {
            int curr = n % 10;
            sum += curr * curr;
            n /= 10;
        }
        return GetNumberDigitsSquares_1(sum, seen);
    }
    
    // Using TwoPointers and Floyd Algoritm approach 
    private bool GetNumberDigitsSquares_2(int n)
    {
        int slowPointer = n;
        int fastPointer = n;

        while (true)
        {
            slowPointer = CheckNext(slowPointer);
            fastPointer = CheckNext(CheckNext(fastPointer));

            if (slowPointer == fastPointer) break;
        }

        return slowPointer == 1;
    }
    private int CheckNext(int n)
    {
        var sum = 0;

        while (n > 0)
        {
            int curr = n % 10;
            sum += curr * curr;
            n /= 10;
        }

        return sum;
    }

    /* === Walkthrough with Example === 
  
    For n = 19 (happy number):
    Sequence: 19 → 82 → 68 → 100 → 1 → 1 → 1...
    slowPointer path: 19 → 82 → 68 → 100 → 1 → 1...
    fastPointer path: 19 → 68 → 1 → 1 → 1...
    They meet at 1, return true

    For n = 2 (unhappy number):
    Sequence: 2 → 4 → 16 → 37 → 58 → 89 → 145 → 42 → 20 → 4...
    Cycle: 4 → 16 → 37 → 58 → 89 → 145 → 42 → 20 → 4
    slowPointer will eventually meet fastPointer in this cycle
    Return false
    */
}
