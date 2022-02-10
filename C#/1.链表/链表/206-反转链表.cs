namespace 链表;

public class _206_反转链表
{
    // Topic: https://leetcode-cn.com/problems/reverse-linked-list/

    /*
     * 审题：
     * 1、仅可获得头部节点；
     * 2、假设有如下链表：1 → 2 → 3 → ∅，反转后得到：∅ ← 1 ← 2 ← 3，由此看出来节点的next指针发生了变化,都指向了其上一个节点；
     */


    /// <summary>
    /// 方案1：迭代
    /// 思路：从头节点开始，进行每个节点的next指针的更改，直到最后一个节点为止；使用游标的形式处理；
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
            // 操作指针
            var next = currNode.next;// 获取当前节点原本的next
            currNode.next = preNode;// 更改当前节点的next

            // 移动游标
            preNode = currNode;// 赋值当preNode
            currNode = next;// 赋值当前节点
        }

        return preNode;
    }

    /// <summary>
    /// 方案2：递归
    /// 思路：递归的方式在理解上会有点复杂；
    /// 首先理解递归，每次递归，都会将当次处理进行压栈，递归到最后时，才进行出栈，进行业务处理；
    /// 即，步骤如下：
    ///     1-入栈：head = 1 传入，head.next = 2;
    ///     2-入栈：head = 2 传入，head.next = 3;
    ///     3-入栈：head = 3 传入，head.next = ∅;
    ///     
    ///     4-出栈：此时head.next为null，直接返回head = 3;
    ///     5-出栈：head = 2 传入，currNode = 3，将head.next.next=head，即将当前节点的下一个节点 指向变更为自己，然后移除当前节点的节点指向：head.next = null，此时链表为：3 → 2 ← 1;
    ///     6-出栈：head = 1 传入，currNode = 3，同上，此时链表为：3 → 2 → 1 → ∅;
    ///     
    ///     7-完成出栈，链表：3 → 2 → 1 → ∅
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
