using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace Tiny.Toolkits
{
    /// <summary>
    /// switch
    /// </summary>
    public static class Switch
    {
        /// <summary>
        /// if the <paramref name="condition"/> is true and the current state is not completed, set <paramref name="invoker"/> result tothe <see cref="Switch{T}"/> and set the state to completed
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="condition"></param>
        /// <param name="invoker"></param>
        /// <returns></returns>
        public static Switch<Target> Case<Target>(bool condition, Func<Target> invoker)
        {
            return new Switch<Target>().Case(condition, invoker);
        }

        /// <summary>
        ///  if the <paramref name="condition"/> is true and the current state is not completed, set <paramref name="value"/> to the <see cref="Switch{T}"/> and set the state to completed
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="condition"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Switch<Target> Case<Target>(bool condition, Target value)
        {
            return new Switch<Target>().Case(condition, value);
        }

        /// <summary>
        /// if the <paramref name="condition"/> is true and the current state is not completed, set <paramref name="invoker"/> result to the <see cref="Switch{T}"/> and set the state to completed
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="condition"></param>
        /// <param name="invoker"></param>
        /// <returns></returns>
        public static Switch<Target> Case<Target>(Func<bool> condition, Func<Target> invoker)
        {
            return new Switch<Target>().Case(condition, invoker);
        }

        /// <summary>
        ///  if the <paramref name="condition"/> is true and the current state is not completed, set <paramref name="value"/> to the <see cref="Switch{T}"/> and set the state to completed
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="condition"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Switch<Target> Case<Target>(Func<bool> condition, Target value)
        {
            return new Switch<Target>().Case(condition, value);
        }
    }

    /// <summary>
    /// switch
    /// </summary>
    /// <typeparam name="T"></typeparam> 
    [DebuggerDisplay("{Value}")]
    public class Switch<T>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)][EditorBrowsable(EditorBrowsableState.Never)] private long isComplete;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)][EditorBrowsable(EditorBrowsableState.Never)] private long isDefaultComplete;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)][EditorBrowsable(EditorBrowsableState.Never)] private T currentValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)][EditorBrowsable(EditorBrowsableState.Never)] private T defaultValue;

        /// <summary>
        /// switch is completed
        /// </summary> 
        public bool IsCompleted => Interlocked.Read(ref isComplete) > 0;

        /// <summary>
        /// switch value
        /// </summary> 
        public T Value => Return();

        /// <summary>
        /// if the <paramref name="condition"/> is true and the current state is not completed, set <paramref name="invoker"/> result tothe <see cref="Switch{T}"/> and set the state to completed
        /// </summary>
        /// <param name="condition">condition</param>
        /// <param name="invoker">invoker</param>
        /// <returns></returns>
        public Switch<T> Case(bool condition, Func<T> invoker)
        {
            if (invoker is null)
            {
                throw new ArgumentNullException(nameof(invoker));
            }

            if (Interlocked.Read(ref isComplete) > 0 || condition == false)
            {
                return this;
            }

            Interlocked.Increment(ref isComplete);
            currentValue = invoker();
            return this;
        }

        /// <summary>
        /// if the <paramref name="condition"/> is true and the current state is not completed, set <paramref name="value"/> to the <see cref="Switch{T}"/> and set the state to completed
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Switch<T> Case(bool condition, T value)
        {
            if (Interlocked.Read(ref isComplete) > 0 || condition == false)
            {
                return this;
            }
            Interlocked.Increment(ref isComplete);
            currentValue = value;
            return this;
        }

        /// <summary>
        ///  if the <paramref name="condition"/> is true and the current state is not completed, set <paramref name="invoker"/> result to the <see cref="Switch{T}"/> and set the state to completed
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="invoker"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Switch<T> Case(Func<bool> condition, Func<T> invoker)
        {
            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (invoker is null)
            {
                throw new ArgumentNullException(nameof(invoker));
            }

            if (Interlocked.Read(ref isComplete) > 0 || condition() == false)
            {
                return this;
            }

            Interlocked.Increment(ref isComplete);
            currentValue = invoker();
            return this;

        }


        /// <summary>
        ///  if the <paramref name="condition"/> is true and the current state is not completed, set <paramref name="value"/> to the <see cref="Switch{T}"/> and set the state to completed
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Switch<T> Case(Func<bool> condition, T value)
        {
            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (Interlocked.Read(ref isComplete) > 0 || condition() == false)
            {
                return this;
            }

            Interlocked.Increment(ref isComplete);
            currentValue = value;
            return this;

        }

        /// <summary>
        /// default value
        /// </summary>
        /// <returns></returns>
        public Switch<T> Default(T value)
        {
            Interlocked.Increment(ref isDefaultComplete);
            defaultValue = value;
            return this;
        }


        /// <summary>
        /// get switch value
        /// </summary>
        /// <returns></returns>
        public T Return()
        {
            return Interlocked.Read(ref isComplete) > 0
                   ? currentValue
                   : Interlocked.Read(ref isDefaultComplete) > 0
                   ? defaultValue
                   : default;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="switch"></param>
        public static implicit operator T(Switch<T> @switch)
        {
            return @switch.Return();
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