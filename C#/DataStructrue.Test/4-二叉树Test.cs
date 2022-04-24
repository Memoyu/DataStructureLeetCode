
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using 二叉树;
using 二叉树.实现二叉搜索树;
using static 二叉树.实现二叉搜索树.BinarySearchTree<int>;

namespace DataStructrue.Test;

public class _4_二叉树Test
{
    private readonly ITestOutputHelper _output;
    public _4_二叉树Test(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void 实现二叉搜索树Test()
    {
        // List<int> data = Enumerable.Range(1, 10).ToList();
        var data = new List<int> { 7, 4, 9, 2, 5, 8, 11, 1, 3, 10, 12 };
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

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
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

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
        BinarySearchTree<int> bst = new BinarySearchTree<int>();
        foreach (var item in data)
        {
            bst.Add(item);
        }
        Node<int> node = null;
        bst.PreorderTraversalNode(bst.Root(), n =>
        {
            if (n.Value == 8) node = n;
        });
        _output.WriteLine(bst.ToString());
        var pn = bst.Predecessor(node);
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
