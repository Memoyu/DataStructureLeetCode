namespace 链表;

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode()
    {

    }
    public ListNode(int x)
    {
        val = x;
    }

    public ListNode(int x, ListNode node)
    {
        val = x;
        next = node;
    }

    public override string ToString()
    {
        return val.ToString(); 
    }
}
