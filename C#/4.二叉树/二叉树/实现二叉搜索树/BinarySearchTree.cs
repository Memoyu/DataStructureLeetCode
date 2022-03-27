namespace 二叉树.实现二叉搜索树;

public class BinarySearchTree<T>
{
    private int _size;

    private Node<T> _root;

    private IComparer<T> _comparer;

    public BinarySearchTree()
    {
    }

    public BinarySearchTree(IComparer<T> comparer)
    {
        _comparer = comparer;
    }

    public int Size() => _size;

    public bool IsEmpty() => _size == 0;

    public void Clear()
    {

    }

    public void Add(T value)
    {
        ValueNotNullCheck(value);

        // 如果是根节点
        if (_root == null)
        {
            _root = new Node<T>(value, null);
            _size++;
            return;
        }

        // 否则不是根节点
        var node = _root; // 初始化搜索节点
        var parent = _root; // 当前新增节点的父节点
        int cmp = 0; // 方向，记录该节点是插入在父节点的左边还是右边
        while (node != null)
        {
            parent = node;
            cmp = Compare(value, node.Value);
            if (cmp > 0)
            {
                node = node.Right;
            }
            else if (cmp < 0)
            {
                node = node.Left;
            }
            else
            {
                // 相等时，将覆盖节点的值
                node.Value = value;
                return;
            }
        }

        var newNode = new Node<T>(value, parent);
        if (cmp > 0)
        {
            parent.Right = newNode;
        }
        else if (cmp < 0)
        {
            parent.Left = newNode;
        }
        _size++;
    }

    public void Remove(T value)
    {

    }

    public bool Contains(T value)
    {
        return false;
    }

    /// <summary>
    /// 当 value1 等于 value2时，返回0；当 value1 大于 value2时，返回大于0；当 value1 小于 value2时，返回小于0;
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <returns></returns>
    private int Compare(T value1, T value2)
    {
        if (_comparer != null)
        {
            return _comparer.Compare(value1, value2);
        }

        return ((IComparable<T>)value1).CompareTo(value2);
    }

    private void ValueNotNullCheck(T value)
    {
        if (value == null) throw new ArgumentNullException("value is not null");
    }

    private class Node<T>
    {
        public T Value { set; get; }

        public Node<T> Left { set; get; }

        public Node<T> Right { set; get; }

        public Node<T> Parent { set; get; }

        public Node(T value, Node<T> parent)
        {
            Value = value;
            Parent = parent;
        }
    }
}
