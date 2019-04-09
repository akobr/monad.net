namespace Monads.Trees
{
    public interface IBinaryTreeNodeVisitor<TItem, out TResult>
    {
        TResult Visit(BinaryTreeNode<TItem> node);

        TResult Visit(BinaryTreeLeaf<TItem> node);
    }
}