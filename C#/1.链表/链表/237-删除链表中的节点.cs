namespace 链表;

public class _237_删除链表中的节点
{
    // Topic:https://leetcode-cn.com/problems/delete-node-in-a-linked-list/

    /*
     * 审题：
     * 1、该方法仅传入一个指定要删除的节点，所以只能获取到下个节点；
     * 2、需要时链表中有效节点；
     * 3、传入的node不能为末尾节点；
     */
    
    /// <summary>
    /// 思路：
    /// PS：在传统做法中，我们需要获取到当前需要删除节点(node)的 上一个节点(preNode) 及 下一个节点(nextNode)，然后将preNode.next = nextNode进行链接，此时node没有了引用，则达到效果；
    /// 此题中，无法获取preNode，但可以取到nextNode；此时，我们需要保持preNode对node的next引用，则node不能直接移除，做法则是将nextNode内容(val、next)覆盖到node中，然后移除nextNode；
    /// </summary>
    /// <param name="node"></param>
    public static void DeleteNode(ListNode node)
    {
        if (node == null || node.next == null) return;
        node.val = node.next.val;
        node.next = node.next.next;
    }
}
