using System.Diagnostics;
using System.Text;
using 二叉树.二叉树.Base;

namespace 二叉树.二叉树.二叉搜索树;

/// <summary>
/// 二叉搜索树
/// </summary>
/// <typeparam name="T"></typeparam>
public class BST<T> : BinaryTree<T>
{
    private IComparer<T> _comparer = null!;

    public BST()
    {
    }

    public BST(IComparer<T> comparer)
    {
        _comparer = comparer;
    }

    /// <summary>
    /// 添加新的节点
    /// </summary>
    /// <param name="value"></param>
    public void Add(T value)
    {
        ValueNotNullCheck(value);

        // 如果是根节点
        if (_root == null)
        {
            _root = CreateNode(value, null);
            _size++;
            // 添加节点后操作
            AfterAdd(_root);
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

        var newNode = CreateNode(value, parent);
        if (cmp > 0)
        {
            parent.Right = newNode;
        }
        else if (cmp < 0)
        {
            parent.Left = newNode;
        }
        _size++;
        // 添加节点后操作
        AfterAdd(newNode);
    }

    protected virtual void AfterAdd(TreeNode<T> node)
    { 
    }

    /// <summary>
    /// 移除指定值的节点
    /// </summary>
    /// <param name="value"></param>
    public void Remove(T value)
    {
        Remove(GetNode(value));
    }

    /// <summary>
    /// 移除指定节点
    /// </summary>
    /// <param name="node"></param>
    private void Remove(TreeNode<T> node)
    {
        if (node == null) return;
        // 否则节点一定存在，且必须删除，故先减掉size
        _size--;

        // 指定删除节点三种情况：度为2、度为1、度为0，且只需要针对度为2进行特殊处理
        // 指定删除节点当度为2时，可以使用前置节点或后置节点进行覆盖，然后删除后置或前置节点
        if (node.IsTowChildren())
        {
            // 获取后置节点
            var t = Successor(node);
            // 覆盖节点的值
            node.Value = t.Value;
            // 赋值node,交由后续逻辑删除
            node = t;
        }

        // 到这的都是需要删除的节点（node的度必然是1或0）
        var replacement =  node.Left ?? node.Right;
        if (replacement != null) // node的度为1
        {
            // 更改parent
            replacement.Parent = node.Parent;

            // 更改parent 的 left 或 right 指向
            if (node.Parent == null) _root = replacement;
            else if (node == node.Parent.Left) node.Parent.Left = replacement;
            else node.Parent.Right = replacement;
        }
        else if (node.Parent != null) // node是叶子节点，同时也是根节点（就这棵树就这一个节点）
        {
            _root = null;
        }
        else // node是叶子节点,且不是根节点
        {
            if (node.Parent.Left != null) node.Parent.Left = null;
            else node.Parent.Right = null;
        }

        AfterRemove(node);
    }

    protected virtual void AfterRemove(TreeNode<T> node)
    {
    }


    /// <summary>
    /// 二叉搜索树中是否包含传入值的节点
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Contains(T value)
    {
        return GetNode(value) != null;
    }


    /// <summary>
    /// 根据value获取节点
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public TreeNode<T> GetNode(T value)
    {
        var node = _root;
        while (node != null)
        {
            var cmp = Compare(value, node.Value);
            if (cmp == 0) // cmp = 0 说明目标值与当前节点值相等，找到节点
                return node;
            else if (cmp < 0) // cmp < 0 说明目标值值比当前节点的值小，故需要往左边继续找（二叉搜索树的性质决定：节点左子树小，右子树大）
                node = node.Left;
            else // cmp > 0 往右边找 
                node = node.Right;
        }
        return null;
    }


    /// <summary>
    /// Temp method
    /// </summary>
    /// <param name="node"></param>
    /// <param name="action"></param>
    public void PreorderTraversalNode(TreeNode<T> node, Action<TreeNode<T>> action)
    {
        if (node == null) return;
        action(node);
        PreorderTraversalNode(node.Left, action);
        PreorderTraversalNode(node.Right, action);
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
}
