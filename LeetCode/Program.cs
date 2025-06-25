using LeetCode.Top150Interview._3Sum_15;

Console.WriteLine("*** LeetCode PlayGroud ***");

Solution solution = new();

int[] nums1 = [-1, 0, 1, 2, -1, -4];
int[] nums2 = [3, -2, 1, 0];
int[] nums3 = [0, 0, 0];

var result1 = solution.ThreeSum(nums1);
var result2 = solution.ThreeSum(nums2);
var result3 = solution.ThreeSum(nums3);

Console.ReadLine();
