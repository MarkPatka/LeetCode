namespace LeetCode.IntersectionOfTwoLinkedLists_160;

public partial class Solution
{
    public class ListNode(int x)
    {
        public int val = x;
        public ListNode? next;
    }
    public ListNode? GetIntersectionNode(ListNode? headA, ListNode? headB)
    {
        if (headA == null || headB == null) return null;

        ListNode? pointerA = headA;
        ListNode? pointerB = headB;

        // Этот алгоритм работает, потому что оба указателя пройдут одинаковое расстояние:
        // A + B = B + A, где A - длина до пересечения в первом списке,
        // B - длина до пересечения во втором списке
        while (pointerA != pointerB)
        {
            // Если достигли конца списка A, переключаемся на начало списка B
            pointerA = pointerA == null ? headB : pointerA.next;

            // Если достигли конца списка B, переключаемся на начало списка A
            pointerB = pointerB == null ? headA : pointerB.next;
        }

        // pointerA и pointerB либо указывают на узел пересечения,
        // либо оба равны null (если пересечения нет)
        return pointerA;
    }

    public static ListNode? GetListNode(int val) => new(val);
}
