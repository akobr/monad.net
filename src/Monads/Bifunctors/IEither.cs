using System;

namespace Monads
{
    public interface IEither<out TLeft, out TRight>
    {
        TResult Match<TResult>(Func<TLeft, TResult> onLeft, Func<TRight, TResult> onRight);
    }
}