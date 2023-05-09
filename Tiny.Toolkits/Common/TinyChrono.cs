 
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Tiny.Toolkits
{
    /// <summary>
    /// <para> class of  <see cref="TinyChrono"/></para>
    /// <para> a chrono helper class of the execute time</para>
    /// </summary>
    [DebuggerDisplay("{GetTimeSpan()}")]
    public sealed class TinyChrono : IDisposable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private long currentTickCount;

        /// <summary>
        /// carete a new chrono 
        /// </summary>
        public TinyChrono()
        {
            currentTickCount = Environment.TickCount;
        }

        /// <summary>
        /// dispose this chrono
        /// </summary>
        public void Dispose()
        {
            currentTickCount = 0;
        }


        /// <summary>
        /// create a new chrono and start
        /// </summary>
        /// <returns></returns>
        public static TinyChrono BeginTimer()
        {
            return new TinyChrono();
        }
                   

        /// <summary>
        /// stop this chrono and return execute use time
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetTimeSpan()
        {
            long interval = Environment.TickCount - currentTickCount;
            return new TimeSpan(interval * 10000);
        }

        /// <summary>
        ///  stop this chrono and return execute use time
        /// </summary>
        /// <returns></returns>
        public long GetTotalMilliseconds()
        {
            long interval = Environment.TickCount - currentTickCount;
            return interval;
        }


        /// <summary>
        /// reset chrono
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