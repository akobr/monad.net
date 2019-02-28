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
