using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using static System.Runtime.CompilerServices.ConfiguredTaskAwaitable;

namespace Tiny.Toolkits
{
    /// <summary>
    /// Task Extensions
    /// </summary>
    public static partial class Extensions
    {

        /// <summary>
        /// Delay 
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static ConfiguredTaskAwaiter GetAwaiter(this TimeSpan timeSpan)
        {
            return Task.Delay(timeSpan).ConfigureAwait(false).GetAwaiter();
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
          
    }
}