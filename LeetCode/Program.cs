using LeetCode.Top150Interview.SpiralMatrix_54;

Console.WriteLine("*** LeetCode PlayGroud ***");

Solution solution = new Solution();

int[][] matrix1 = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
int[][] matrix2 = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]];

int[][] matrix3 = [[1],[2],[3],[4]];
int[][] matrix4 = [[1, 2, 3 ,4]];
int[][] matrix5 = [[1]];

//var res1 = solution.SpiralOrder(matrix1);
//var res2 = solution.SpiralOrder(matrix2);
var res3 = solution.SpiralOrder(matrix3);
var res4 = solution.SpiralOrder(matrix4);
var res5 = solution.SpiralOrder(matrix5);
Console.ReadLine();



