namespace 链表;

public class _83_删除排序链表中的重复元素
{
    // Topic: https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list/submissions/

    /*
     * 审题：
     * 1、
     */


    public static ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode preNode = head;
        ListNode currNode = head.next;
        while (currNode != null)
        {
            if (preNode == currNode)
                preNode.next = currNode.next;
            else
                preNode = preNode.next;
            currNode = currNode.next;
        }
        return head;
    }
}
