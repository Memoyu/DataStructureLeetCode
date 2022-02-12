namespace 链表;

public class _141_环形链表
{
    // Topic: https://leetcode-cn.com/problems/linked-list-cycle/

    /*
     * 审题：
     * 1、如果为环形链表，则不存在末尾节点，即某个next节点为空；
     * 2、如果为环形链表，则一旦进入环就会无限循环；
     */

    /// <summary>
    /// 思路：
    /// 引入概念：快慢指针；
    /// 顾名思义，存在两个指针变量，快、慢指针：慢指针"走一步"（slowNode = slowNode.next），同时，快指针"走两步"（fastNode = fastNode.next.next）;
    /// 假设，当前链表存在环；且当快、慢指针进入环时，会陷入循环，则在循环到某个节点时，快、慢节点会产生"碰撞"，此时就证明存在环；
    /// 举个例子：你在环形跑到上跑步，同时，有几个跑得很快的体育生与你一同跑（你的速度当然不如体育生）；在持续的跑环下，某个时间点你们总会相遇，因为体育生跑完了一圈，也许你才跑半圈；
    /// </summary>
    /// <param name="head">头节点</param>
    /// <returns></returns>
    public static bool HasCycle(ListNode head)
    {
        if (head == null || head.next == null) return false;
        var slowNode = head;
        var fastNode = head.next;

        while (fastNode != null && fastNode.next != null)
        {
            slowNode = slowNode.next;
            fastNode = fastNode.next.next;
            if (slowNode == fastNode) return true;
        }

        return false;
    }

    /// <summary>
    /// 思路：
    /// 比较简单，将遍历过的节点存储到HasSet中，如果Add() 返回 false说明插入元素失败，也就证明该节点已存在过，故存在环
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static bool HasCycle_1(ListNode head)
    {
        if (head == null || head.next == null) return false;
        HashSet<ListNode> set = new HashSet<ListNode> ();

        while (head != null)
        {
            if (!set.Add(head)) return true;
            head = head.next;
        }

        return false;
    }
}
