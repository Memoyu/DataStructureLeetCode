
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
        List<int> data = Enumerable.Range(1, 10).ToList();

        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        foreach (var item in data)
        {
            bst.Add(item);
        }
    }
}
