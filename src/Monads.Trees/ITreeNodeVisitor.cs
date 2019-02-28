namespace Monads.Trees
{
    public interface ITreeNodeVisitor<TItem, out TResult>
    {
        TResult Visit(IBinaryTreeNode<TItem> node);
    }
}