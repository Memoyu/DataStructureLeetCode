
using System.Collections.Generic;
using System.Linq;
using Xunit;
using 二叉树.实现二叉搜索树;

namespace DataStructrue.Test;

public class _4_二叉树Test
{
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

        bst.PreorderTraversal();

        bst.InorderTraversal();

        bst.PostorderTraversal();

        bst.LevelOrderTraversal();
    }
}
