namespace LeetCode.Top150Interview.LengthOfLastWord_58;

public partial class Solution
{
    public int LengthOfLastWord(string s)
    {
        string mes = s.TrimEnd();
        int len = mes.Length - 1;

        for (; len >= 0; len--)
        {
            if (mes[len] == ' ')
            {
                return mes.Length - 1 - len ;
            }
        }
        return mes.Length;
    }
}
