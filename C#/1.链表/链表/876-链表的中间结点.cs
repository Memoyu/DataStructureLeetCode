namespace 链表;

public class _876_链表的中间结点
{
    // Topic: https://leetcode-cn.com/problems/middle-of-the-linked-list/

    /*
     * 审题：
     * 1、
     */

    public static ListNode MiddleNode(ListNode head)
    {
        var arr = new ListNode[100];
        var i = 0;
        while (head != null)
        {
            arr[i++] = head;
            head = head.next;
        }
        return arr[i / 2];
    }


    public static ListNode MiddleNode_1(ListNode head)
    {
        ListNode currNode = head;
        var n = 0;
        while (currNode != null)
        {
            n++;
            currNode = currNode.next;
        }

        var t = 0;
        currNode = head;
        while (t != n / 2)
        {
            t++;
            currNode = currNode.next;
        }

        return currNode;
    }

    public static ListNode MiddleNode_2(ListNode head)
    {
        ListNode slowNode = head;
        ListNode fastNode = head;
        while (fastNode != null && fastNode.next != null)
        { 
            slowNode = slowNode.next;
            fastNode = fastNode.next.next;
        }

        return slowNode;
    }
}
