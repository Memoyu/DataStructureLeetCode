using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 二叉树.二叉树.Base;

namespace 二叉树.二叉树.二叉搜索树;

/// <summary>
/// AVL 树
/// </summary>
public class AVLT<T> : BST<T>
{
    public AVLT()
    {
    }

    public AVLT(IComparer<T> comparer) : base(comparer)
    {
    }

    protected override void AfterAdd(TreeNode<T> node)
    {
        
    }
}
