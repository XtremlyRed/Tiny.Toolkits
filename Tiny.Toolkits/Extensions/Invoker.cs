using System;
using System.Collections;
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
    public static class Invoker
    {
        /// <summary>
        /// run delegate and ignore exception
        /// </summary>
        /// <param name="action">run body</param>
        /// <param name="exceptionCallback">exception callback</param>
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
        /// <param name="startIndex">startIndex</param>
        /// <param name="count">count [ ? > 0]</param>
        /// <param name="loopBody">loopBody</param>
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
        /// <param name="startIndex">startIndex</param>
        /// <param name="count">count [ ? > 0]</param>
        /// <param name="loopBody">loopBody</param>
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
        /// <param name="startIndex">startIndex</param>
        /// <param name="count">count [ ? > 0]</param>
        /// <param name="loopBody">loopBody</param>
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
        /// loop  
        /// </summary>
        /// <param name="loopCondition">condition</param>
        /// <param name="loopBody">loopBody</param> 
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void While(Func<bool> loopCondition, Action loopBody)
        {
            if (loopCondition is null)
            {
                throw new ArgumentNullException(nameof(loopCondition));
            }
            if (loopBody is null)
            {
                throw new ArgumentNullException(nameof(loopBody));
            }

            while (loopCondition.Invoke())
            {
                loopBody();
            }
        }

        /// <summary>
        /// run delegate async
        /// </summary>
        /// <param name="action">delegate body</param>
        /// <param name="token"><see cref="CancellationToken"/></param>
        /// <param name="creationOptions"><see cref="TaskContinuationOptions"/></param>
        /// <returns></returns>
        public static Task InvokeAsync(this Action action, CancellationToken token = default, TaskCreationOptions creationOptions = TaskCreationOptions.DenyChildAttach)
        {
            return action is null
                ? Task.FromResult(false)
                : Task.Factory.StartNew(action, token, creationOptions, TaskScheduler.Default);
        }

        /// <summary>
        /// run delegate async
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action">delegate body</param>
        /// <param name="token"><see cref="CancellationToken"/></param>
        /// <param name="creationOptions"><see cref="TaskCreationOptions"/></param>
        /// <returns></returns>
        public static Task<TResult> InvokeAsync<TResult>(this Func<TResult> action, CancellationToken token = default, TaskCreationOptions creationOptions = TaskCreationOptions.DenyChildAttach)
        {
            return action is null
                ? Task.FromResult<TResult>(default!)
                : Task.Factory.StartNew(action, token, creationOptions, TaskScheduler.Default);
        }

        /// <summary>
        /// If the <see cref="IDisposable"/> is inherited, execute
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object TryDispose(object obj)
        {

            if (obj is IEnumerable and)
            {
                foreach (IDisposable item in and.OfType<IDisposable>())
                {
                    item?.Dispose();
                }
                return obj;
            }

            if (obj is IDisposable and1)
            {
                and1?.Dispose();
            }

            return obj;
        }

        /// <summary>
        /// cast object value to target Type
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="value">object value</param>
        /// <param name="outValue">target value</param>
        /// <returns>cast success</returns>
        public static bool TryCast<Target>(object value, out Target outValue)
        {
            if (value != null)
            {
                try
                {
                    if (value is Target target)
                    {
                        outValue = target;
                        return true;
                    }
                    outValue = (Target)Convert.ChangeType(value, typeof(Target));
                    return true;
                }
                catch
                {
                }
            }
            outValue = default!;
            return false;
        }

        /// <summary>
        /// cast object value to target Type
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="value">object value</param> 
        /// <returns>cast success</returns>
        public static Target CastTo<Target>(object value)
        {
            if (value is null)
            {
                return default!;
            }

            try
            {
                return value is Target target ? target : (Target)Convert.ChangeType(value, typeof(Target));
            }
            catch
            {
                return default!;
            }
        }





        #region InvokeOnce

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ConcurrentDictionary<int, bool> invokeTokenCache = new();

        /// <summary>
        /// Invokes the given action only once with the specified token.
        /// If the same token is used again, the action will not be invoked.
        /// </summary>
        /// <param name="token"> The token used to identify the action.</param>
        /// <param name="action"> The action to be invoked.</param>
        /// <param name="destroyTokenAfterInvoke">destroyTokenAfterInvoke If set to true, the token will be destroyed after the action is invoked.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void InvokeOnce(this Action action, object token, bool destroyTokenAfterInvoke = false)
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            lock (invokeTokenCache)
            {
                if (invokeTokenCache.TryGetValue(token.GetHashCode(), out _))
                {
                    return;
                }

                invokeTokenCache[token.GetHashCode()] = false;
            }

            try
            {
                action();

                if (destroyTokenAfterInvoke == false)
                {
                    invokeTokenCache[token.GetHashCode()] = true;
                }
            }
            finally
            {
                if (destroyTokenAfterInvoke)
                {
                    invokeTokenCache.TryRemove(token.GetHashCode(), out _);
                }
            }
        }


        /// <summary>
        /// Invokes the given action only once with the specified token.
        /// If the same token is used again, the action will not be invoked.
        /// </summary>
        /// <param name="token"> The token used to identify the action.</param>
        /// <param name="funCallback"> The action to be invoked.</param>
        /// <param name="destroyTokenAfterInvoke">destroyTokenAfterInvoke If set to true, the token will be destroyed after the action is invoked.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task InvokeOnce(this Func<Task> funCallback, object token, bool destroyTokenAfterInvoke = false)
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (funCallback is null)
            {
                throw new ArgumentNullException(nameof(funCallback));
            }

            lock (invokeTokenCache)
            {
                if (invokeTokenCache.TryGetValue(token.GetHashCode(), out _))
                {
                    return;
                }

                invokeTokenCache[token.GetHashCode()] = false;
            }

            try
            {
                await funCallback();

                if (destroyTokenAfterInvoke == false)
                {
                    invokeTokenCache[token.GetHashCode()] = true;
                }
            }
            finally
            {
                if (destroyTokenAfterInvoke)
                {
                    invokeTokenCache.TryRemove(token.GetHashCode(), out _);
                }
            }
        }

        #endregion
    }
}
