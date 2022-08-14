﻿
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using 二叉树;
using 二叉树.二叉树.二叉搜索树;
using 二叉树.二叉树.Base;

namespace DataStructrue.Test;

public class _4_二叉树Test
{
    private readonly ITestOutputHelper _output;
    public _4_二叉树Test(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void 二叉搜索树遍历Test()
    {
        // List<int> data = Enumerable.Range(1, 10).ToList();
        var data = new List<int> { 7, 4, 9, 2, 5, 8, 11, 1, 3, 10, 12 };
        var bst = new BST<int>();

        foreach (var item in data)
        {
            bst.Add(item);
        }

        var preResult = "";
        var inResult = "";
        var postResult = "";
        var levelResult = "";

        var preAssert = "7 4 2 1 3 5 9 8 11 10 12 ";
        var inAssert = "1 2 3 4 5 7 8 9 10 11 12 ";
        var postAssert = "1 3 2 5 4 8 10 12 11 9 7 ";
        var levelAssert = "7 4 9 2 5 8 11 1 3 10 12 ";

        bst.PreorderTraversal(val =>
        {
            preResult += $"{val} ";
        });

        bst.InorderTraversal(val =>
        {
            inResult += $"{val} ";
        });

        bst.PostorderTraversal(val =>
        {
            postResult += $"{val} ";
        });

        bst.LevelOrderTraversal(val =>
        {
            levelResult += $"{val} ";
        });


        Assert.Equal(preAssert, preResult);
        Assert.Equal(inAssert, inResult);
        Assert.Equal(postAssert, postResult);
        Assert.Equal(levelAssert, levelResult);
    }

    [Fact]
    public void 实现二叉搜索树Test()
    {
        // List<int> data = Enumerable.Range(1, 10).ToList();
        var data = new List<int> { 7, 4, 9, 2, 5, 8, 11, 1, 3, 10, 12 };
        BST<int> bst = new BST<int>();

        foreach (var item in data)
        {
            bst.Add(item);
        }

        /*_output.WriteLine("------------Preorder Traversal------------");
        bst.PreorderTraversal(val =>
        {
            _output.WriteLine(val.ToString());
        });

        _output.WriteLine("------------Inorder Traversal------------");
        bst.InorderTraversal(val =>
        {
            _output.WriteLine(val.ToString());
        });

        _output.WriteLine("------------Postorder Traversal------------");
        bst.PostorderTraversal(val =>
        {
            _output.WriteLine(val.ToString());
        });

        _output.WriteLine("------------Level Order Traversal------------");
        bst.LevelOrderTraversal(val => 
        {
            _output.WriteLine(val.ToString());
        });*/

        _output.WriteLine(bst.ToString());

        Assert.Equal(4, bst.Height());
        Assert.Equal(4, bst.HeightByIterate());
    }

    [Fact]
    public void _226_翻转二叉树Test()
    {
        // List<int> data = Enumerable.Range(1, 10).ToList();
        var data = new List<int> { 4, 2, 7, 1, 3, 6, 9 };
        BST<int> bst = new BST<int>();

        foreach (var item in data)
        {
            bst.Add(item);
        }

        /*bst.LevelOrderTraversal(val =>
        {
            _output.WriteLine(val.ToString());
        });
        _output.WriteLine("------------------------------");
        _226_翻转二叉树.InvertTreePreorder(bst.Root());
        bst.LevelOrderTraversal(val =>
        {
            _output.WriteLine(val.ToString());
        });*/


        /*bst.LevelOrderTraversal(val =>
        {
            _output.WriteLine(val.ToString());
        });
        _output.WriteLine("------------------------------");
        _226_翻转二叉树.InvertTreeInorder(bst.Root());
        bst.LevelOrderTraversal(val =>
        {
            _output.WriteLine(val.ToString());
        });*/

        bst.LevelOrderTraversal(val =>
        {
            _output.WriteLine(val.ToString());
        });
        _output.WriteLine("------------------------------");
        _226_翻转二叉树.InvertTreeLevelOrder(bst.Root());
        bst.LevelOrderTraversal(val =>
        {
            _output.WriteLine(val.ToString());
        });
    }

    [Fact]
    public void _0_获取前驱节点Test()
    {
        var data = new List<int> { 8, 4, 13, 2, 6, 10, 1, 3, 5, 7, 9, 12, 11 };
        BST<int> bst = new BST<int>();
        foreach (var item in data)
        {
            bst.Add(item);
        }
        TreeNode<int> node = bst.GetNode(13);
        _output.WriteLine(bst.ToString());
        var pn = bst.Predecessor(node);
        Assert.Equal(12, pn.Value);
    }

    [Fact]
    public void _0_获取后继节点Test()
    {
        var data = new List<int> { 4, 1, 8, 2, 7, 10, 3, 5, 9, 11, 6 };
        BST<int> bst = new BST<int>();
        foreach (var item in data)
        {
            bst.Add(item);
        }
        TreeNode<int> node = bst.GetNode(6);
        _output.WriteLine(bst.ToString());
        var pn = bst.Successor(node);
        Assert.Equal(7, pn.Value);
    }

    [Fact]
    public void _0_求出二叉树Test()
    {
        // 前序序列: A,B,C,D,E,F,G,H,I,J
        // 中序序列: C,B,A,F,E,D,I,H,J,G
        // 后序序列: C,B,F,E,I,J,H,G,D,A

        //var preorder = "A,B,C,D,E,F,G,H,I,J";
        //var inorder = "C,B,A,F,E,D,I,H,J,G";
        //var postorder = "C,B,F,E,I,J,H,G,D,A";

        //var preorder = "1,2,3,4,5,6,7";
        //var inorder = "3,2,4,1,6,5,7";
        //var postorder = "3,4,2,6,7,5,1";

        var preorder = "A,B,D,C,E,G,H,F";
        var inorder = "D,B,A,G,E,H,C,F";
        var postorder = "D,B,G,H,E,F,C,A";

        //var postorderRes = _0_求出二叉树.GetPostorder(preorder, inorder);
        //Assert.Equal(postorderRes, postorder);

        var preorderRes = _0_求出二叉树.GetPreorder(inorder, postorder);
        Assert.Equal(preorderRes, preorder);
    }
}
