using System.Diagnostics;
using System.Text;

namespace 二叉树.实现二叉搜索树;

public class BinarySearchTree<T>
{
    private int _size;

    private Node<T> _root = null!;

    private IComparer<T> _comparer = null!;

    public BinarySearchTree()
    {
    }

    public BinarySearchTree(IComparer<T> comparer)
    {
        _comparer = comparer;
    }

    public int Size() => _size;

    public bool IsEmpty() => _size == 0;

    public int Height()
    {
        return Height(_root);
    }

    private int Height(Node<T> node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(Height(node.Left), Height(node.Right));
    }

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
    public void PreorderTraversal(Action<T> action)
    {
        PreorderTraversal(_root, action);
    }

    private void PreorderTraversal(Node<T> node, Action<T> action)
    {
        if (node == null) return;
        action(node.Value);
        PreorderTraversal(node.Left, action);
        PreorderTraversal(node.Right, action);
    }

    /// <summary>
    /// 中序遍历节点
    /// </summary>
    public void InorderTraversal(Action<T> action)
    {
        IneorderTraversal(_root, action);
    }

    private void IneorderTraversal(Node<T> node, Action<T> action)
    {
        if (node == null) return;
        IneorderTraversal(node.Left, action);
        action(node.Value);
        IneorderTraversal(node.Right, action);
    }

    /// <summary>
    /// 后序遍历节点
    /// </summary>
    public void PostorderTraversal(Action<T> action)
    {
        PostorderTraversal(_root, action);
    }

    private void PostorderTraversal(Node<T> node, Action<T> action)
    {
        if (node == null) return;
        PostorderTraversal(node.Left, action);
        PostorderTraversal(node.Right, action);
        action(node.Value);
    }

    /// <summary>
    /// 层序遍历
    /// </summary>
    public void LevelOrderTraversal(Action<T> action)
    {
        if (_root == null) return;
        Queue<Node<T>> queue = new Queue<Node<T>>();
        queue.Enqueue(_root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            action.Invoke(node.Value);
            var ln = node.Left;
            var rn = node.Right;
            if (ln != null) queue.Enqueue(ln);
            if (rn != null) queue.Enqueue(rn);
        }
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

    public override string ToString()
    {
        var sb = new StringBuilder();
        ToString(_root, sb, "");
        return sb.ToString();
    }

    private void ToString(Node<T> node, StringBuilder sb, string prefix)
    {
        if (node == null) return;
        sb.Append(prefix).Append(node.Value).Append("\r\n");
        ToString(node.Left, sb, $"{prefix}[L]");
        ToString(node.Right, sb, $"{prefix}[R]");
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
