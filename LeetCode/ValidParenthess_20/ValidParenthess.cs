namespace LeetCode.ValidParenthess_20;

public partial class Solution
{
    /// <summary>
    /// Less efficient, ~3ms
    /// </summary>
    public bool IsValid_1(string s)
    {
        int len = s.Length;
        if (len <= 1) return false;

        char[] openingParenthess = ['(', '[', '{'];
        int OpeningCount = 0;

        char[] closingParenthess = [')', ']', '}'];
        int ClosingCount = 0;
        
        Stack<char> parenthess = [];

        for (int i = 0; i < len; i++)
        {
            if (openingParenthess.Contains(s[i]))
            {
                parenthess.Push(s[i]);
                OpeningCount++;
            }
            else
            {
                if (parenthess.Count == 0) return false;
                int idxOpen   = Array.IndexOf(openingParenthess, parenthess.Peek());
                int idxClosed = Array.IndexOf(closingParenthess, s[i]);
                if (idxOpen != idxClosed) return false;

                ClosingCount++;
                parenthess.Pop();
            }
        }
        
        return ClosingCount == OpeningCount;
    }


    /// <summary>
    /// More efficient, ~2ms
    /// </summary>
    public bool IsValid_2(string s)
    {
        if (s.Length % 2 != 0) return false;

        Stack<char> queue = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '[' || s[i] == '(' || s[i] == '{')
            {
                queue.Push(s[i]);
            }

            if (queue.Count > 0)
            {
                if (s[i] == queue.Peek()) continue;


                if (s[i] - queue.Peek() != 1 && s[i] - queue.Peek() != 2)
                {
                    return false;
                }

                queue.Pop();
            }
            else
            {
                if (i != 0) return false;
            }
        }

        return queue.Count == 0;
    }
}
