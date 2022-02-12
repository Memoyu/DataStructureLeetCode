namespace 链表;

public class _203_移除链表元素
{
    // Topic: https://leetcode-cn.com/problems/remove-linked-list-elements/

    /*
     * 审题：
     * 1、
     */


    public ListNode RemoveElements(ListNode head, int val)
    {
        if (head == null) return head;
        ListNode currNode = head;
        ListNode preNode = null;
        while (currNode != null)
        {
            if (currNode.val == val)
            {
                if (preNode == null)
                    head = currNode.next;
                else
                    preNode.next = currNode.next;
            }
            else
            {
                preNode = currNode;
            }
            currNode = currNode.next;
        }
        return head;
    }
}
