using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 二叉树.二叉树.Base;

namespace 二叉树.二叉树.二叉搜索树;

/// <summary>
/// 红黑树
/// </summary>
/// <typeparam name="T"></typeparam>
public class RBT<T> : BST<T>
{
    public RBT()
    {
    }

    public RBT(IComparer<T> comparer) : base(comparer)
    {
    }

    protected override void AfterAdd(TreeNode<T> node)
    {
    }

    protected override void AfterRemove(TreeNode<T> node)
    {
    }

    /// <summary>
    /// 更改节点颜色
    /// </summary>
    /// <param name="node"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    private TreeNode<T> Color(TreeNode<T> node, bool color)
    {
        if (node == null) return node;
        ((RBNode<T>)node).Color = color;
        return node;
    }

    /// <summary>
    /// 更改节点为红色
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private TreeNode<T> NodeRed(TreeNode<T> node)
    {
        return Color(node, ConstValue.RED);
    }

    /// <summary>
    /// 更改节点为黑色
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private TreeNode<T> NodeBlack(TreeNode<T> node)
    {
        return Color(node, ConstValue.BLACK);
    }

    /// <summary>
    /// 节点颜色
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private bool ColorOf(TreeNode<T> node)
    {
        return node == null ? ConstValue.BLACK : ((RBNode<T>)node).Color;
    }

    /// <summary>
    /// 节点是否为红色
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private bool IsRed(TreeNode<T> node)
    {
        return ColorOf(node) == ConstValue.RED;
    }

    /// <summary>
    /// 节点是否为黑色
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private bool IsBlack(TreeNode<T> node)
    {
        return ColorOf(node) == ConstValue.BLACK;
    }
}

public class RBNode<T> : TreeNode<T>
{
    /// <summary>
    /// 红黑树 节点颜色
    /// </summary>
    public bool Color { get; set; }

    public RBNode(T value, TreeNode<T> parent) : base(value, parent)
    {
    }
}

