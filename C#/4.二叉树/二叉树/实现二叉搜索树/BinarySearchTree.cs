using System.Diagnostics;

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
    /// 前序遍历节点
    /// </summary>
    public void PreorderTraversal()
    {
        PreorderTraversal(_root);
        Trace.WriteLine("---------------------");
    }

    private void PreorderTraversal(Node<T> node)
    {
        if (node == null) return;
        Trace.WriteLine(node.Value);
        PreorderTraversal(node.Left);
        PreorderTraversal(node.Right);
    }

    /// <summary>
    /// 中序遍历节点
    /// </summary>
    public void InorderTraversal()
    {
        IneorderTraversal(_root);
        Trace.WriteLine("---------------------");
    }

    private void IneorderTraversal(Node<T> node)
    {
        if (node == null) return;
        IneorderTraversal(node.Left);
        Trace.WriteLine(node.Value);
        IneorderTraversal(node.Right);
    }

    /// <summary>
    /// 后序遍历节点
    /// </summary>
    public void PostorderTraversal()
    {
        PostorderTraversal(_root);
        Trace.WriteLine("---------------------");
    }

    private void PostorderTraversal(Node<T> node)
    {
        if (node == null) return;
        PostorderTraversal(node.Left);
        PostorderTraversal(node.Right);
        Trace.WriteLine(node.Value);
    }

    /// <summary>
    /// 层序遍历
    /// </summary>
    public void LevelOrderTraversal()
    {
        if (_root == null) return;
        Queue<Node<T>> queue = new Queue<Node<T>>();
        queue.Enqueue(_root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            var ln = node.Left;
            var rn = node.Right;
            if (ln != null) queue.Enqueue(ln);
            if (rn != null) queue.Enqueue(rn);

            Trace.WriteLine(node.Value);
        }
        Trace.WriteLine("---------------------");
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

        return ((IComparable<T>)value1!).CompareTo(value2);
    }

    private void ValueNotNullCheck(T value)
    {
        if (value == null) throw new ArgumentNullException("value is not null");
    }

    private class Node<TN>
    {
        public TN Value { set; get; }

        public Node<TN> Left { set; get; } = null!;

        public Node<TN> Right { set; get; } = null!;

        public Node<TN> Parent { set; get; } = null!;

        public Node(TN value, Node<TN> parent)
        {
            Value = value;
            Parent = parent;
        }
    }
}
