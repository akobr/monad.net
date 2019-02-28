using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Monads.Trees
{
    public class TreeNode<TItem> : ITreeNode<TItem>
    {
        private readonly IEnumerable<ITreeNode<TItem>> children;

        public TreeNode(TItem item, IEnumerable<ITreeNode<TItem>> children)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Item = item;
            this.children = children ?? throw new ArgumentNullException(nameof(children));
        }

        public TItem Item { get; }

        public ITreeNode<TResult> Select<TResult>(Func<TItem, TResult> selector)
        {
            return new TreeNode<TResult>(
                selector(Item),
                children.Select(child => child.Select(selector)));
        }

        IFunctor<TResult> IFunctor<TItem>.Select<TResult>(Func<TItem, TResult> selector)
        {
            return Select(selector);
        }

        public IEnumerator<ITreeNode<TItem>> GetEnumerator()
        {
            return children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return children.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (obj is TreeNode<TItem> other)
            {
                return Equals(Item, other.Item)
                       && this.SequenceEqual(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode() ^ children.GetHashCode();
        }
    }
}
