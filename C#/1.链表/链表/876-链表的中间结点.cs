namespace 链表;

public class _876_链表的中间结点
{
    // Topic: https://leetcode-cn.com/problems/middle-of-the-linked-list/

    /*
     * 审题：
     * 1、返回链表中中间节点，例如：1 → 2 → 3 → ∅，中间节点为2；1 → 2 → 3 → 4 → ∅，中间节点为3，取左边节点
     */

    /// <summary>
    /// 思路：
    /// 引入数组，用于存储遍历的所有节点，最后从数组中取出中间节点；
    /// 缺点在于如果不确定节点数量时无法使用数组，需要使用动态数组，牺牲空间；
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 思路：
    /// 单指针法：分为两个步骤进行处理；
    /// 1、遍历链表，统计链表节点总数n；
    /// 2、再从头部节点继续遍历，直到 n / 2 时得到的则为中间节点
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 思路：
    /// 快慢指针法：
    /// 该方法比较神奇，是对单指针法的进一步优化，此方式只需要遍历一次链表；
    /// 定义两个节点，初始化为头部节点，在遍历下，slowNode每次向下一个节点，fastNode向下两个节点，当fastNode=null时，则证明节点遍历完成，而slowNode此时正处于中间位置；
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
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
