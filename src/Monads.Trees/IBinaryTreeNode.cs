namespace Monads.Trees
{
    public interface IBinaryTreeNode<TItem>
    {
        TResult Accept<TResult>(IBinaryTreeNodeVisitor<TItem, TResult> visitor);
    }
}