using Xunit;
using 链表;

namespace DataStructure.Test;
public class 链表Test
{
    [Fact]
    public void _141_环形链表Test()
    {
        var linkedList = GetLinkedList();
        linkedList.Add(new ListNode(6, linkedList.Node(1)));
        var res = _141_环形链表.HasCycle(linkedList.Head);
        Assert.True(res);
    }

    [Fact]
    public void _206_反转链表Test()
    {
        var linkedList = GetLinkedList();

        // 迭代
        // var newHead = _206_反转链表.ReverseList(linkedList.Head);

        // 递归
        var newHead = _206_反转链表.ReverseList_1(linkedList.Head);
        linkedList.SetHead(newHead);
        Assert.Equal("[9, 1, 5, 4]", linkedList.ToString());
    }

    [Fact]
    public void _237_删除链表中的节点Test()
    {
        var linkedList = GetLinkedList();
        var node = linkedList.Node(1);
        _237_删除链表中的节点.DeleteNode(node);
        linkedList.ReduceSize();
        Assert.Equal("[4, 1, 9]", linkedList.ToString());
    }

    [Fact]
    public void _876_链表的中间结点Test()
    {
        var linkedList = GetLinkedList();
        var midNode = _876_链表的中间结点.MiddleNode(linkedList.Head);
        Assert.Equal(midNode, linkedList.Node(2));
    }

    private LinkedList GetLinkedList()
    {
        var linkedList = new LinkedList();
        var vals = new[] { 4, 5, 1, 9 };
        foreach (var item in vals)
        {
            linkedList.Add(item);
        }
        return linkedList;
    }

}