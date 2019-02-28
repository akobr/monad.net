using System;

namespace Monads
{
    public class Maybe<TValue> : IFunctor<TValue>
    {
        private readonly bool hasValue;
        private readonly TValue value;

        public Maybe()
        {
            // no operation
        }

        public Maybe(TValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            hasValue = true;
            this.value = value;
        }

        public TResult Match<TResult>(TResult nothing, Func<TValue, TResult> just)
        {
            if (nothing == null)
            {
                throw new ArgumentNullException(nameof(nothing));
            }

            if (just == null)
            {
                throw new ArgumentNullException(nameof(just));
            }

            return hasValue ? just(value) : nothing;
        }

        public Maybe<TResult> Select<TResult>(Func<TValue, TResult> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return hasValue
                ? new Maybe<TResult>(selector(value))
                : new Maybe<TResult>();
        }

        IFunctor<TResult> IFunctor<TValue>.Select<TResult>(Func<TValue, TResult> selector)
        {
            return Select(selector);
        }

        public Maybe<TResult> SelectMany<TResult>(Func<TValue, Maybe<TResult>> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return hasValue
                ? selector(value)
                : new Maybe<TResult>();
        }

        public TValue GetValue(TValue fallbackValue)
        {
            if (fallbackValue == null)
            {
                throw new ArgumentNullException(nameof(fallbackValue));
            }

            return hasValue ? value : fallbackValue;
        }

        public TValue GetValue(Func<TValue> fallback)
        {
            if (fallback == null)
            {
                throw new ArgumentNullException(nameof(fallback));
            }

            return hasValue ? value : fallback();
        }

        public override bool Equals(object obj)
        {
            if (obj is Maybe<TValue> other)
            {
                return Equals(value, other.value);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return hasValue ? value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return hasValue ? value.ToString() : Constants.NULL;
        }
    }
}
