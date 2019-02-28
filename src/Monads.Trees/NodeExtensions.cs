using System;

namespace Monads
{
    public static class NodeExtensions
    {
#if MATH_NAMING
        public static ITreeNode<TResult> Map<TValue, TResult>(
            this ITreeNode<TValue> node,
            Func<TValue, TResult> selector)
        {
            return node.Select(selector);
        }
#endif
    }
}
