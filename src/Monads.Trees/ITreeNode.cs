using System;
using System.Collections.Generic;

namespace Monads.Trees
{
    public interface ITreeNode<out TItem> : IFunctor<TItem>, IEnumerable<ITreeNode<TItem>>
    {
        TItem Item { get; }

        new ITreeNode<TResult> Select<TResult>(Func<TItem, TResult> selector);
    }
}