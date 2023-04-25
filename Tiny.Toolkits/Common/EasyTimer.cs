using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace Tiny.Toolkits
{
    /// <summary>
    /// <para> class of  <see cref="EasyTimer"/></para>
    /// <para> a timer helper class of the execute time</para>
    /// </summary>
    [DebuggerDisplay("{GetTimeSpan()}")]
    public sealed class EasyTimer : IDisposable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private long currentTickCount;

        /// <summary>
        /// carete a new timer
        /// </summary>
        public EasyTimer()
        {
            currentTickCount = Environment.TickCount;
        }

        /// <summary>
        /// dispose this timer
        /// </summary>
        public void Dispose()
        {
            currentTickCount = 0;
        }


        /// <summary>
        /// create a new time and start timer
        /// </summary>
        /// <returns></returns>
        public static EasyTimer BeginTimer()
        {
            return new EasyTimer();
        }


        /// <summary>
        /// stop this timer and return  execute  use time
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetTimeSpan()
        {
            long interval = Environment.TickCount - currentTickCount;
            return new TimeSpan(interval * 10000);
        }

        /// <summary>
        ///  stop this timer and return  execute  use time
        /// </summary>
        /// <returns></returns>
        public long GetTotalMilliseconds()
        {
            long interval = Environment.TickCount - currentTickCount;
            return interval;
        }


        /// <summary>
        /// reset timer
        /// </summary>
        public void ResetTimer()
        {
            currentTickCount = Environment.TickCount;
        }


        #region hide base function

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        ///  Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }


        #endregion


    }
}