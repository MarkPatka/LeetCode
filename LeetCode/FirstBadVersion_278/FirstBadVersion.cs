namespace LeetCode.FirstBadVersion_278;

/* The isBadVersion API is defined in the parent class VersionControl.
  bool IsBadVersion(int version); */

public partial class Solution
{
    public int FirstBadVersion(int n)
    {
        int left = 1;
        int right = n - 1;
        
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (IsBadVersion(mid)) right = mid - 1;
            else left = mid + 1;
        }
        return left;
    }

    // do not copy to answer
    public bool IsBadVersion(int version)
    {
        if (version >= 2) return true;
        else return false;
    }
}
