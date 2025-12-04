namespace LeetCode.MergeTwoSortedLists_21;

public partial class Solution
{
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public ListNode MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        var head = new ListNode();
        var current = head;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current!.next = list1;  // в качестве next добавляем узел с меньшим значением (list1 или list2)
                list1 = list1.next;     // двигаем указатель list1 на следующий элемент
            }
            else
            {
                current!.next = list2;  // в качестве next добавляем узел с меньшим значением (val) (list1 или list2)
                list2 = list2.next;     // двигаем указатель list2 на следующий элемент
            }
            current = current.next;     // сдвигаем указатель current на последний добавленный узел
        }

        current!.next = list1 is null ? list2 : list1; // если один из списков закончился, прикрепляем оставшуюся часть другого списка к current.next
        return head.next!; // Возврат head.next — чтобы пропустить вспомогательный пустой узел
    }
}
