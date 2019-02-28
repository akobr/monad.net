namespace Monads.Trees
{
    public interface IBinaryTreeNodeVisitor<TItem, out TResult>
    {
        TResult Visit(IBinaryTreeNode<TItem> node);
    }
}