using System;

namespace Monads
{
    public interface IFunctor<out TContext>
    {
        IFunctor<TResult> Select<TResult>(Func<TContext, TResult> selector);
    }
}