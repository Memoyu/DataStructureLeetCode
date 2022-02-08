using Xunit;

namespace 链表.Test
{
    public class Test
    {
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
}