
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using 二叉树;
using 二叉树.实现二叉搜索树;

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
}
