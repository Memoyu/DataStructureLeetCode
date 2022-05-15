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
}
