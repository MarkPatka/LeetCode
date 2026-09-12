using LeetCode.Common;

namespace LeetCode.InvertBinaryTree_226;

public partial class Solution
{
    public TreeNode? InvertTree(TreeNode? root)
    {
        if (root == null) return null;

        Queue<TreeNode> nodes = [];
        nodes.Enqueue(root);
        while (nodes.Count != 0)
        {
            TreeNode node = nodes.Dequeue();

            SwapNodes(node);

            if (node.left != null)
            {
                nodes.Enqueue(node.left);
            }
            
            if (node.right != null) 
            {
                nodes.Enqueue(node.right);
            }
        }
        return root;
    }

    private static void SwapNodes(TreeNode node) 
        => (node.left, node.right) = (node.right, node.left);
}
