namespace 二叉树.二叉树.Base;

public class TreeNode<T>
{
    public T Value { set; get; }

    public TreeNode<T> Left { set; get; } = null!;

    public TreeNode<T> Right { set; get; } = null!;

    public TreeNode<T> Parent { set; get; } = null!;

    public TreeNode(T value, TreeNode<T> parent)
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

    /// <summary>
    /// 是否为父节点的 左 子节点
    /// </summary>
    /// <returns></returns>
    public bool IsLeftChild() => Parent != null && this == Parent.Left;

    /// <summary>
    /// 是否为父节点的 右 子节点
    /// </summary>
    /// <returns></returns>
    public bool IsRightChild() => Parent != null && this == Parent.Right;

    /// <summary>
    /// 节点的 兄弟节点
    /// </summary>
    /// <returns></returns>
    public TreeNode<T> Sibling()
    {
        if (IsLeftChild())
        {
            return Parent.Right;
        }

        if (IsRightChild())
        {
            return Parent.Left;
        }

        return null;
    }
}
