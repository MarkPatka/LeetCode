namespace LeetCode.CountCompleteTreeNode_222;

public partial class Solution
{
    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null) 
    {
        public int val = val;
        public TreeNode? left = left;
        public TreeNode? right = right;
    }

    public int CountNodes(TreeNode? root)
    {
        int lHeight = CountLeftChildren(root);
        int rHeight = CountRightChildren(root);

        if (lHeight == rHeight)
        {
            return (1 << lHeight) - 1; // Эквивалентно 2^lHeight == last right node val
        }
        else
        {
            return 1 + CountNodes(root!.left) + CountNodes(root!.right); 
        }

    }

    private static int CountRightChildren(TreeNode? root)
    {
        int depth = 0;
        while (root is not null)
        {
            root = root.right;
            depth++;
        }
        return depth;
    }

    private static int CountLeftChildren(TreeNode? root)
    {
        int depth = 0;
        while (root is not null)
        {
            root = root.left;
            depth++;
        }
        return depth;
    }

}
