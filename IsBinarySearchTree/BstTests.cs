using System;
using Xunit;
using Xunit.Abstractions;

namespace IsBinarySearchTree
{
    public class BstTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public BstTests(ITestOutputHelper outputHelper)
        {
            _testOutputHelper = outputHelper;
        }
        [Fact]
        public void Test1()
        {
            var input = new Node()
            {
                Data = 4,
                Left = new Node()
                {
                    Data = 2,
                    Right = new Node()
                    {
                        Data = 3
                    },
                    Left = new Node()
                    {
                        Data = 1
                    }
                },
                Right = new Node()
                {
                    Data = 6,
                    Left = new Node()
                    {
                        Data = 5
                    },
                    Right = new Node()
                    {
                        Data = 7
                    }
                }
            };

            var bstResolver = new BstResolver();
            var result = bstResolver.IsBst(input);
            Assert.True(result);
            //_testOutputHelper.WriteLine(result.ToString());
        }
    }

    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set; }
    }

    public class BstResolver
    {
        public bool IsBst(Node node)
        {
            if (node.Left == null && node.Right == null)
                return true;
            if (node.Left?.Data >= node.Data)
                return false;
            if (node.Right?.Data <= node.Data)
                return false;

            return IsBst(node.Left) && IsBst(node.Right);
        }
    }

    //TODO: That's a right solution!!!

    //boolean checkBST(Node node)
    //{
    //    return isValid(node, Integer.MIN_VALUE,
    //     Integer.MAX_VALUE);
    //}

    //boolean isValid(Node node, int MIN, int MAX)
    //{
    //    if (node == null)
    //        return true;

    //    if (node.data > MIN && node.data < MAX && isValid(node.left, MIN, node.data) && isValid(node.right, node.data, MAX))
    //        return true;
    //    else
    //        return false;
    //}

}
