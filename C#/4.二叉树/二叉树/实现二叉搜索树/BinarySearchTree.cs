﻿using System.Diagnostics;
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


    public Node<T> Root() => _root;

    public int Size() => _size;

    public bool IsEmpty() => _size == 0;

    /// <summary>
    /// 是否为完全二叉树
    /// </summary>
    /// <returns></returns>
    public bool IsComplete()
    {
        // 同样采用层序遍历的形式进行校验

        // 如果树不为空，开始层序遍历二叉树（用队列）
        // 如果 node.left != null，将 node.left 入队
        // 如果 node.left == null && node.right != null，返回 false
        // 如果 node.right != null，将 node.right 入队
        // 如果 node.right == null
        //  ✓ 那么后面遍历的节点应该都为叶子节点，才是完全二叉树
        //  ✓ 否则返回 false
        // 遍历结束，返回 true
        if (_root == null) return false;
        Queue<Node<T>> queue = new Queue<Node<T>>();
        queue.Enqueue(_root);
        bool leaf = false;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            // 如果标注了该状态，则说明接下来遍历的全是子节点，否则不为完全二叉树
            if (!node.IsLeaf()) return false;
            var ln = node.Left;
            var rn = node.Right;
            // 针对上述四种主要情况进行判断
            if (ln != null)
            {
                queue.Enqueue(ln);
            }
            else if (rn != null)
            {
                return false;
            }

            if (rn != null)
            {
                queue.Enqueue(rn);
            }
            else
            {
                // 第四种情况时，说明接下来的节点都为子节点才符合完全二叉树的要求，所以进行状态标注
                leaf = true;
            }

        }
        return true;
    }

    /// <summary>
    /// 使用迭代实现树的高度获取
    /// </summary>
    /// <returns></returns>
    public int HeightByIterate()
    {
        // 采用层序遍历的形式进行处理
        // 遍历到每一层的每一个节点，到最后一个节点时，进行下一层节点数的获取，并进行高度递增
        var height = 0;
        if (_root == null) return height;
        var levelSize = 1;// 存储层的节点数
        Queue<Node<T>> queue = new Queue<Node<T>>();
        queue.Enqueue(_root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            levelSize--;// 每取出一个节点，就进行层节点数的递减
            var ln = node.Left;
            var rn = node.Right;
            if (ln != null) queue.Enqueue(ln);
            if (rn != null) queue.Enqueue(rn);// 将左右节点入队

            // 如果层节点遍历完了，则进行层数递增，并获取下一层的节点数(此时，queue中所有节点则为下一层的所有节点)
            if (levelSize == 0)
            {
                levelSize = queue.Count;
                height++;
            }
        }
        return height;
    }

    /// <summary>
    /// 使用递归实现树的高度获取
    /// </summary>
    /// <returns></returns>
    public int Height()
    {
        return Height(_root);
    }

    private int Height(Node<T> node)
    {
        if (node == null) return 0;
        // 递归 比较树左右两边的高度，哪边高取哪边
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
        if (action == null) return;
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
        if (action == null) return;
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
        if (action == null) return;
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
        if (_root == null || action == null) return;
        Queue<Node<T>> queue = new Queue<Node<T>>();
        queue.Enqueue(_root);
        while (queue.Count > 0)
        {
            // 从队列中出队节点，进行处理
            var node = queue.Dequeue();
            action.Invoke(node.Value);
            var ln = node.Left;
            var rn = node.Right;
            // 将左右节点进行入队
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

    public class Node<TN>
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

        /// <summary>
        /// 是否子节点（完全二叉树时，叶子节点必然是度为0的）
        /// </summary>
        /// <returns></returns>
        public bool IsLeaf() => Left == null && Right == null;

        /// <summary>
        /// 是否度为2
        /// </summary>
        /// <returns></returns>
        public bool IsTowChildren() => Left != null && Right != null;
    }
}
