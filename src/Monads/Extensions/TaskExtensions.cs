using System;
using System.Threading.Tasks;

namespace Monads
{
    public static class TaskExtensions
    {
        public static async Task<TResult> Select<TValue, TResult>(
            this Task<TValue> task,
            Func<TValue, TResult> selector)
        {
            TValue x = await task;
            return selector(x);
        }

        public static async Task<TResult> SelectMany<TFirst, TSecond, TResult>(
            this Task<TFirst> task,
            Func<TFirst, Task<TSecond>> selector,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            TFirst firstValue = await task;
            TSecond secondValue = await selector(firstValue);
            return resultSelector(firstValue, secondValue);
        }

#if MATH_NAMING
        public static Task<TResult> Map<TValue, TResult>(
            this Task<TValue> task,
            Func<TValue, TResult> selector)
        {
            return Select(task, selector);
        }
#endif
    }
}
