using System;

namespace Monads
{
    public class Maybe<TItem>
    {
        private readonly bool hasItem;
        private readonly TItem item;

        public Maybe()
        {
            // no operation
        }

        public Maybe(TItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            hasItem = true;
            this.item = item;
        }

        public TResult Match<TResult>(TResult nothing, Func<TItem, TResult> just)
        {
            if (nothing == null)
            {
                throw new ArgumentNullException(nameof(nothing));
            }

            if (just == null)
            {
                throw new ArgumentNullException(nameof(just));
            }

            return hasItem ? just(item) : nothing;
        }

        public Maybe<TResult> Select<TResult>(Func<TItem, TResult> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return hasItem
                ? new Maybe<TResult>(selector(item))
                : new Maybe<TResult>();
        }

        public Maybe<TResult> SelectMany<TResult>(Func<TItem, Maybe<TResult>> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return hasItem
                ? selector(item)
                : new Maybe<TResult>();
        }

        public override bool Equals(object obj)
        {
            if (obj is Maybe<TItem> other)
            {
                return Equals(item, other.item);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return hasItem ? item.GetHashCode() : 0;
        }
    }
}
