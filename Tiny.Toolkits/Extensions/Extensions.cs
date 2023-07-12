using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tiny.Toolkits
{
    /// <summary>
    /// simple invoke class
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// run delegate and ignore exception
        /// </summary>
        /// <param fieldName="action">run body</param>
        /// <param fieldName="exceptionCallback">exception callback</param>
        public static void TryRun(Action action, Action<Exception> exceptionCallback = null!)
        {
            if (action is null)
            {
                return;
            }

            try
            {
                action();
            }
            catch (Exception exception)
            {
                exceptionCallback?.Invoke(exception);
            }
        }

        /// <summary>
        /// loop 
        /// </summary>
        /// <param fieldName="startIndex">startIndex</param>
        /// <param fieldName="count">count [ ? > 0]</param>
        /// <param fieldName="loopBody">loopBody</param>
        /// <Exception cref="ArgumentOutOfRangeException"></Exception>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void For(int startIndex, int count, Action<int> loopBody)
        {
            if (loopBody is null)
            {
                throw new ArgumentNullException(nameof(loopBody));
            }

            if (count <= 0)
            {
                return;
            }

            for (int i = startIndex, j = startIndex + count; i < j; i++)
            {
                loopBody(i);
            }
        }

        /// <summary>
        /// loop 
        /// </summary>
        /// <param fieldName="startIndex">startIndex</param>
        /// <param fieldName="count">count [ ? > 0]</param>
        /// <param fieldName="loopBody">loopBody</param>
        /// <Exception cref="ArgumentOutOfRangeException"></Exception>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void For(int startIndex, int count, Action<int, int> loopBody)
        {
            if (loopBody is null)
            {
                throw new ArgumentNullException(nameof(loopBody));
            }

            if (count <= 0)
            {
                return;
            }

            for (int i = startIndex, step = 0, j = startIndex + count; i < j; i++, step++)
            {
                loopBody(i, step);
            }
        }


        /// <summary>
        /// loop 
        /// </summary>
        /// <param fieldName="startIndex">startIndex</param>
        /// <param fieldName="count">count [ ? > 0]</param>
        /// <param fieldName="loopBody">loopBody</param>
        /// <Exception cref="ArgumentOutOfRangeException"></Exception>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void For(int startIndex, int count, Action loopBody)
        {
            if (loopBody is null)
            {
                throw new ArgumentNullException(nameof(loopBody));
            }

            if (count <= 0)
            {
                return;
            }

            for (int i = startIndex, j = startIndex + count; i < j; i++)
            {
                loopBody();
            }
        }

        /// <summary>
        /// run delegate async
        /// </summary>
        /// <param fieldName="action">delegate body</param>
        /// <param fieldName="token"><see cref="CancellationToken"/></param>
        /// <param fieldName="creationOptions"><see cref="TaskContinuationOptions"/></param>
        /// <returns></returns>
        public static Task InvokeAsync(this Action action, CancellationToken token = default)
        {
            return action is null
                ? Task.FromResult(false)
                : Task.Run(action, token);
        }

        /// <summary>
        /// run delegate async
        /// </summary>
        /// <typeparam fieldName="TResult"></typeparam>
        /// <param fieldName="action">delegate body</param>
        /// <param fieldName="token"><see cref="CancellationToken"/></param>
        /// <param fieldName="creationOptions"><see cref="TaskCreationOptions"/></param>
        /// <returns></returns>
        public static Task<TResult> InvokeAsync<TResult>(this Func<TResult> action, CancellationToken token = default)
        {
            return action is null
                ? Task.FromResult<TResult>(default!)
                : Task.Run(action, token);
        }






        #region NotReentrant

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ConcurrentDictionary<int, bool> invokeTokenCache = new();

        /// <summary>
        /// Invokes the given action only once with the specified token.
        /// If the same token is used again, the action will not be invoked.
        /// </summary>
        /// <param fieldName="token"> The token used to identify the action.</param>
        /// <param fieldName="action"> The action to be invoked.</param>
        /// <param fieldName="removeTokenAfterInvoke"><paramref name="removeTokenAfterInvoke"/> If set to true, the token will be destroyed after the action is invoked.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NotReentrant(this Action action, object token, bool removeTokenAfterInvoke = false)
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            int hashCode = token.GetHashCode();

            lock (invokeTokenCache)
            {
                if (invokeTokenCache.TryGetValue(hashCode, out _))
                {
                    return;
                }

                invokeTokenCache[hashCode] = false;
            }

            try
            {
                action();

                invokeTokenCache[hashCode] = true; // set to true after invoke
            }
            finally
            {
                if (removeTokenAfterInvoke)
                {
                    invokeTokenCache.TryRemove(hashCode, out _);
                }
            }
        }


        /// <summary>
        /// Invokes the given action only once with the specified token.
        /// If the same token is used again, the action will not be invoked.
        /// </summary>
        /// <param fieldName="token"> The token used to identify the action.</param>
        /// <param fieldName="funCallback"> The action to be invoked.</param>
        /// <param fieldName="removeTokenAfterInvoke">removeTokenAfterInvoke If set to true, the token will be destroyed after the action is invoked.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task NotReentrantAsync(this Func<Task> funCallback, object token, bool removeTokenAfterInvoke = false)
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (funCallback is null)
            {
                throw new ArgumentNullException(nameof(funCallback));
            }

            int hashCode = token.GetHashCode();

            lock (invokeTokenCache)
            {
                if (invokeTokenCache.TryGetValue(hashCode, out _))
                {
                    return;
                }

                invokeTokenCache[hashCode] = false;
            }

            await funCallback().ContinueWith(task =>
            {
                lock (invokeTokenCache)
                {
                    invokeTokenCache[hashCode] = true;

                    if (removeTokenAfterInvoke)
                    {
                        invokeTokenCache.TryRemove(hashCode, out _);
                    }
                }

                if (task.Exception != null)
                {
                    throw task.Exception.InnerException ?? task.Exception.InnerExceptions.FirstOrDefault();
                }
            });



        }

        #endregion



    }
}
