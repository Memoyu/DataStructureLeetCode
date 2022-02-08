namespace 链表;

public class _206_反转链表
{
    /// <summary>
    /// 方案1：迭代
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode preNode = null;
        ListNode currNode = head;

        while (currNode != null)
        {
            var next = currNode.next;
            currNode.next = preNode;
            preNode = currNode;
            currNode = next;
        }

        return preNode;
    }

    /// <summary>
    /// 方案2：递归
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static ListNode ReverseList_1(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode currNode = ReverseList_1(head.next);
        head.next.next = head;
        head.next = null;

        return currNode;
    }
}
