using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tiny.Toolkits
{
    public static class FuncExtensions
    {


        public static Func<TInput, T> Then<TInput, TOutput, T>(this Func<TInput, TOutput> thisFunc, Func<TOutput, T> function)
        {

            if (thisFunc is null)
            {
                throw new ArgumentNullException(nameof(thisFunc));
            }

            return input => function(thisFunc(input));
        }


        public static Func<TInput, Task<T>> ThenAsync<TInput, TOutput, T>(this Func<TInput, Task<TOutput>> thisFunc, Func<TOutput, T> function, CancellationToken cancellationToken = default)
        {
            if (thisFunc is null)
            {
                throw new ArgumentNullException(nameof(thisFunc));
            }

            return async input =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                TOutput output = await thisFunc(input);

                return function(output);
            };
        }
    }
}
