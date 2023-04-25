using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Threading.Tasks
{
    /// <summary>
    /// Task Extensions
    /// </summary>
    public static class TaskExtensions
    {

        /// <summary>
        /// ConfiguredTaskAwaitable  No Awaiter
        /// </summary>
        /// <param name="criticalNotifyCompletion"></param>
        public static void NoAwaiter(this ICriticalNotifyCompletion criticalNotifyCompletion)
        {
        }

        /// <summary>
        /// ConfiguredTaskAwaitable  No Awaiter
        /// </summary>
        /// <param name="notifyCompletion"></param>
        public static void NoAwaiter(this INotifyCompletion notifyCompletion)
        {
        }
        /// <summary>
        /// ConfiguredTaskAwaitable  No Awaiter
        /// </summary>
        /// <param name="configuredTaskAwaitable"></param>
        public static void NoAwaiter(this ConfiguredTaskAwaitable configuredTaskAwaitable)
        {
        }
        /// <summary>
        /// ConfiguredTaskAwaitable  No Awaiter
        /// </summary>
        /// <param name="configuredTaskAwaitable"></param>
        public static void NoAwaiter<TType>(this ConfiguredTaskAwaitable<TType> configuredTaskAwaitable)
        {
        }
        /// <summary>
        /// task  No Awaiter
        /// </summary>
        /// <param name="task"></param>
        public static void NoAwaiter(this Task task)
        {
        }
        /// <summary>
        /// task  No Awaiter
        /// </summary>
        /// <param name="task"></param>
        public static void NoAwaiter<TType>(this Task<TType> task)
        {
        }


        /// <summary>
        /// task  No Awaiter
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="millisecondsTimeout"></param>
        public static void WaitComplete(this Task task, CancellationToken cancellationToken = default, int millisecondsTimeout = -1)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            if (task.IsCompleted)
            {
                return;
            }

            bool waitResult = task.Wait(millisecondsTimeout, cancellationToken);

            if (waitResult == false)
            {
                throw new TimeoutException();
            }
        }


        /// <summary>
        /// task  No Awaiter
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="millisecondsTimeout"></param>
        public static TType WaitComplete<TType>(this Task<TType> task, CancellationToken cancellationToken = default, int millisecondsTimeout = -1)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            if (task.IsCompleted)
            {
                return task.Result;
            }

            bool waitResult = task.Wait(millisecondsTimeout, cancellationToken);

            return waitResult == false ? throw new TimeoutException() : task.Result;
        }



        /// <summary>
        /// foreach async
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="loopBody">loopBody</param>
        /// <param name="token"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Task ForEachAsync<TType>(this IEnumerable<TType> collection, Action<TType> loopBody, CancellationToken token = default)
        {
            return loopBody is null
                ? throw new ArgumentNullException(nameof(loopBody))
                : collection is null
                ? throw new ArgumentNullException(nameof(collection))
                : Task.Factory.StartNew(() =>
                {
                    foreach (TType item in collection)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                        loopBody(item);
                    }
                }, token, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }


        /// <summary>
        /// foreach async
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="loopBody">loopBody</param>
        /// <param name="token"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Task ForEachAsync<TType>(this IEnumerable<TType> collection, Action<TType, int> loopBody, CancellationToken token = default)
        {
            return loopBody is null
                ? throw new ArgumentNullException(nameof(loopBody))
                : collection is null
                ? throw new ArgumentNullException(nameof(collection))
                : Task.Factory.StartNew(() =>
                {
                    int index = 0;
                    foreach (TType item in collection)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                        loopBody(item, index);
                        index++;
                    }
                }, token, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }
    }
}