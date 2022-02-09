namespace 链表;

public class _206_反转链表
{
    // Topic: https://leetcode-cn.com/problems/reverse-linked-list/

    /*
     * 审题：
     * 1、仅可获得头部节点；
     * 2、假设有如下链表：1 → 2 → 3 → ∅，反转后得到：∅ ← 1 ← 2 ← 3，由此看出来节点的next指针发生了变化；
     */


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
