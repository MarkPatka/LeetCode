using LeetCode.Top150Interview.SubstringwithConcatenationofAllWords_30;

Console.WriteLine("*** LeetCode PlayGroud ***");

Solution solution = new();

string s = "barfoothefoobarman";
string[] words = ["foo", "bar"];

var res = solution.FindSubstring(s, words);

Console.ReadLine();
