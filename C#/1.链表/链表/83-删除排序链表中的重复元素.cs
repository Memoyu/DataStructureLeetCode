namespace 链表;

public class _83_删除排序链表中的重复元素
{
    // Topic: https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list/submissions/

    /*
     * 审题：
     * 1、链表为有序
     * 2、只要碰到当前节点的val与next的val相等，就"删除"当前的next指向即可（改变指向next.next）；
     */


    public static ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode currNode = head;
        while (currNode != null)
        {
            if (currNode.next != null)
            {
                if (currNode.val == currNode.next.val)
                {
                    currNode.next = currNode.next.next;
                    continue;
                }
                currNode = currNode.next;
            }
            else
                break;
                
        }
        return head;
    }
}
