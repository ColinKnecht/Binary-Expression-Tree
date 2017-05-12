using System;

namespace BinaryTreeDemo
{
    public class BinaryNode<T>
    {
        public T item { get; set; }
        public BinaryNode<T> left { get; set; }
        public BinaryNode<T> right { get; set; }

        public BinaryNode()
        {
        }

        public BinaryNode(T element)
        {
            item = element;
        }

        public BinaryNode(T element, BinaryNode<T> leftNode, BinaryNode<T> rightNode)
        {
            item = element;
            left = leftNode;
            right = rightNode;
        }

        public bool isLeaf()
        {
            return (left == null && right == null);
        }

        public override String ToString()
        {
            return item.ToString();
        }
    }
}
