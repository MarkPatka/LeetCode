using LeetCode.Common;
using LeetCode.InvertBinaryTree_226;


Console.WriteLine("*** LeetCode PlayGroud ***");

Solution solution = new Solution();

TreeNode root = new(4,
    new TreeNode(2, new TreeNode(1), new TreeNode(3)),
    new TreeNode(7, new TreeNode(6), new TreeNode(9)));

var result = solution.InvertTree(root);
Console.WriteLine(result);
Console.ReadLine();



