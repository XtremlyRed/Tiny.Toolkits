using System;
using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel;
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
        public static Task InvokeAsync(this Action action, CancellationToken token = default, TaskCreationOptions creationOptions = TaskCreationOptions.DenyChildAttach)
        {
            return action is null
                ? Task.FromResult(false)
                : Task.Factory.StartNew(action, token, creationOptions, TaskScheduler.Default);
        }

        /// <summary>
        /// run delegate async
        /// </summary>
        /// <typeparam fieldName="TResult"></typeparam>
        /// <param fieldName="action">delegate body</param>
        /// <param fieldName="token"><see cref="CancellationToken"/></param>
        /// <param fieldName="creationOptions"><see cref="TaskCreationOptions"/></param>
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
        /// <param fieldName="obj"></param>
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
        /// <typeparam fieldName="To"></typeparam>
        /// <param fieldName="value">object value</param>
        /// <param fieldName="outValue">target value</param>
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ConcurrentDictionary<Type, TypeConverter> typeConverters = new();
         
        /// <summary>
        /// cast object value to target Type
        /// </summary>
        /// <typeparam fieldName="To"></typeparam>
        /// <param fieldName="value">object value</param> 
        /// <returns>cast success</returns>
        public static To To<To>(this object value, TypeConverter converter = null)
        {
            if (value is null)
            {
                return default!;
            }

            if (value is To target)
            {
                return target;
            }

            Type targetType = typeof(To);
            Type currentType = value.GetType();

            converter ??= typeConverters.GetOrAdd(targetType, static i => TypeDescriptor.GetConverter(i));

            if (converter.CanConvertFrom(currentType))
            {
                object convertValue = converter.ConvertFrom(value);

                if (convertValue is To targetValue)
                {
                    return targetValue;
                }
            }

            throw new System.InvalidCastException($"Can not convert {currentType} to {targetType},Please pass in a valid type converter");

        }



        /// <summary>
        /// cast object value to target Type
        /// </summary>
        /// <typeparam fieldName="To"></typeparam>
        /// <param fieldName="value">object value</param> 
        /// <returns>cast success</returns>
        public static To To<From, To>(this From value, Func<From, To> lambdaConverter)
        {
            if (value is null)
            {
                return default!;
            }

            if (value is To target)
            {
                return target;
            }

            Type targetType = typeof(To);
            Type currentType = value.GetType();

            TypeConverter converter = typeConverters.GetOrAdd(targetType, i =>
            {
                TypeConverter cvt = TypeDescriptor.GetConverter(i);

                if ((cvt is null || cvt.CanConvertFrom(currentType) == false) && lambdaConverter != null)
                {
                    cvt = new CommonTypeConverter<From, To>(lambdaConverter);
                }

                return cvt;
            });

            object convertValue = converter.ConvertFrom(value);

            if (convertValue is To targetValue)
            {
                return targetValue;
            }

            if (lambdaConverter is null)
            {
                throw new System.InvalidCastException($"Can not convert {currentType} to {targetType},Please pass in a valid lambda converter");
            }

            return lambdaConverter(value);
        }


        #region InvokeOnce

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
        public static void InvokeOnce(this Action action, object token, bool removeTokenAfterInvoke = false)
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

                if (removeTokenAfterInvoke == false)
                {
                    invokeTokenCache[hashCode] = true;
                }
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
        public static async Task InvokeOnceAsync(this Func<Task> funCallback, object token, bool removeTokenAfterInvoke = false)
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

            try
            {
                await funCallback();

                if (removeTokenAfterInvoke == false)
                {
                    invokeTokenCache[hashCode] = true;
                }
            }
            finally
            {
                if (removeTokenAfterInvoke)
                {
                    invokeTokenCache.TryRemove(hashCode, out _);
                }
            }
        }

        #endregion



        /// <summary>
        /// release a <see cref="SemaphoreSlim"/> when <see cref="SemaphoreSlim.CurrentCount"/> == 0
        /// </summary>
        /// <param fieldName="semaphoreSlim"></param>
        /// <param fieldName="releaseCount"></param>
        public static void ReleaseWhenZero(this SemaphoreSlim semaphoreSlim, int releaseCount = 1)
        {
            if (semaphoreSlim is null)
            {
                return;
            }


            if (releaseCount < 1)
            {
                return;
            }

            if (semaphoreSlim.CurrentCount == 0)
            {
                semaphoreSlim.Release(releaseCount);
            }
        }
    }
}
