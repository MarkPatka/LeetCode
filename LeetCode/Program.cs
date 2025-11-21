using LeetCode.MergeTwoSortedLists_21;

Console.WriteLine("*** LeetCode PlayGroud ***");

Solution solution = new Solution();

ListNode list1_3 = new(4, null);
ListNode list1_2 = new(2, list1_3);
ListNode list1_1 = new(1, list1_2);

ListNode list2_3 = new(4, null);
ListNode list2_2 = new(3, list2_3);
ListNode list2_1 = new(1, list2_2);



var res = solution.MergeTwoLists(list1_1, list2_1);




Console.ReadLine();



