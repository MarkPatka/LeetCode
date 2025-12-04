
namespace LeetCode.LinkedListCycle_141;

public partial class Solution
{
    public class ListNode(int x)
    {
        public int val = x;
        public required ListNode? next = null;
    }

    // Most common solution with 103ms with O(n) time-complexity
    // Using Floyd algorithm
    public bool HasCycle_1(ListNode head)
    {
        ListNode? fastPointer, slowPointer;
        fastPointer = slowPointer = head;

        while (fastPointer != null && fastPointer.next != null)
        {
            slowPointer = slowPointer!.next;
            fastPointer = fastPointer!.next.next;

            if (slowPointer == fastPointer)
            {
                return true;
            }
        }

        return false;
    }

    // The most efficient solution with ~77ms 
    // Also seems to be more straightforward
    public bool HasCycle_2(ListNode head)
    {
        if (head is null)
        {
            return false;
        }

        var slowNode = head;
        var fastNode = head.next;

        if (fastNode is null)
        {
            return false;
        }

        while (slowNode is not null && fastNode is not null)
        {
            if (fastNode.next is null)
            {
                return false;
            }

            if (slowNode == slowNode.next || slowNode == fastNode)
            {
                return true;
            }

            slowNode = slowNode.next;
            fastNode = fastNode.next.next;
        }

        return false;
    }
}
