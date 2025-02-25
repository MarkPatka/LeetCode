using LeetCode.Top150Interview.BestTimeToBuyAndSellStock_122;
using LeetCode.Top150Interview.HIndex_274;
using LeetCode.Top150Interview.JumpGame_55;
using LeetCode.Top150Interview.JumpGame2_45;
using LeetCode.Top150Interview.Majority_Element_169;
using LeetCode.Top150Interview.MergeSortedArray;
using LeetCode.Top150Interview.RemoveDuplicatesSortedArray_26;
using LeetCode.Top150Interview.RemoveElement_27;
using LeetCode.Top150Interview.RotateArray_189;


HIndex hidx = new();
int[] arr1 = [3, 0, 6, 1, 5, 3, 2];
int[] arr2 = [1, 3, 1];
int[] arr3 = [100];
var res1 = hidx.GetHIndex(arr1);
var res2 = hidx.GetHIndex(arr2);
var res3 = hidx.GetHIndex(arr3);

Console.ReadLine();