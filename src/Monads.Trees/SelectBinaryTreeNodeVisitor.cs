using System;

namespace Monads.Trees
{
    public class SelectBinaryTreeNodeVisitor<TItem, TResult> : IBinaryTreeNodeVisitor<TItem, IBinaryTreeNode<TResult>>
    {
        private readonly Func<TItem, TResult> selector;

        public SelectBinaryTreeNodeVisitor(Func<TItem, TResult> selector)
        {
            this.selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        public IBinaryTreeNode<TResult> Visit(BinaryTreeLeaf<TItem> leaf)
        {
            TResult mappedItem = selector(leaf.Item);
            return BinaryTree.Leaf(mappedItem);
        }

        public IBinaryTreeNode<TResult> Visit(BinaryTreeNode<TItem> node)
        {
            TResult mappedItem = selector(node.Item);
            IBinaryTreeNode<TResult> mappedLeft = node.Left.Accept(this);
            IBinaryTreeNode<TResult> mappedRight = node.Right.Accept(this);
            return BinaryTree.Node(mappedItem, mappedLeft, mappedRight);
        }
    }
}
