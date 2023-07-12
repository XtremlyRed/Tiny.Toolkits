using System;
using System.Runtime.CompilerServices;
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
        public static Task GetAwaiter(this TimeSpan timeSpan)
        {
            return Task.Delay(timeSpan) ;
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