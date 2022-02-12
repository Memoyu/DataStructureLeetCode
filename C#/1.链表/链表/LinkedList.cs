using System.Text;

namespace 链表;

public class LinkedList
{
    private int size; //元素数量
    private ListNode head;//头指针

    public int Size
    {
        get { return size; }
    }

    public ListNode Head
    {
        get { return head; }
    }

    public void SetHead(ListNode node)
    {
        head = node;
    }

    public void ReduceSize()
    {
        size--;
    }

    public void Add(int value)
    {
        ListNode newNode = new ListNode(value);
        if (head == null)
        {
            //如果链表为空则作为头指针
            head = newNode;
        }
        else
        {
            GetByIndex(size - 1).next = newNode;
        }
        size++;
    }

    public void Add(ListNode node)
    {
        if (head == null)
        {
            //如果链表为空则作为头指针
            head = node;
        }
        else
        {
            GetByIndex(size - 1).next = node;
        }
        size++;
    }

    public ListNode Node(int index)
    {
        return GetByIndex(index);
    }

    ListNode GetByIndex(int index)
    {
        if ((index < 0) || (index >= size))
        {
            throw new ArgumentOutOfRangeException("Index", "");
        }

        ListNode tempNode = head;

        for (int i = 0; i < index; i++)
        {
            tempNode = tempNode.next;
        }

        return tempNode;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        var node = head;
        sb.Append("[");
        for (int i = 0; i < size; i++)
        {
            if (i != 0) sb.Append(", ");
            sb.Append(node.val);
            node = node.next;
        }

        sb.Append("]");
        return sb.ToString();
    }

}

