using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tiny.Toolkits
{
    /// <summary>
    /// a class of <see cref="Parameters"/>
    /// </summary>
    public class Parameters : IDisposable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        private readonly Dictionary<string, object> parametersMapper = new();

        /// <summary>
        /// dispose 
        /// </summary>
        public void Dispose()
        {
            parametersMapper?.Clear();
        }

        /// <summary>
        /// set value into <see cref="Parameters"/>
        /// </summary>
        /// <param name="parameterKey">parameterKey</param>
        /// <param name="parameterValue">parameterValue</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Parameters SetValues(string parameterKey, string parameterValue)
        {
            if (string.IsNullOrWhiteSpace(parameterKey))
            {
                throw new ArgumentException($"invalid {nameof(parameterKey)}");
            }

            parametersMapper[parameterKey] = parameterValue;

            return this;
        }

        /// <summary>
        /// get value from <see cref="Parameters"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="parameterKey">parameterKey</param>
        /// <param name="parameterValue">parameterValue</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Parameters GetValue<Target>(string parameterKey, out Target parameterValue)
        {
            if (string.IsNullOrWhiteSpace(parameterKey))
            {
                throw new ArgumentException($"invalid {nameof(parameterKey)}");
            }

            if (parametersMapper.TryGetValue(parameterKey, out object value))
            {
                if (value is Target target)
                {
                    parameterValue = target;
                    return this;
                }
            }
            parameterValue = default;
            return this;
        }

        /// <summary>
        /// try get value from <see cref="Parameters"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="parameterKey">parameterKey</param>
        /// <param name="parameterValue">parameterValue</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool TryGetValue<Target>(string parameterKey, out Target parameterValue)
        {
            if (string.IsNullOrWhiteSpace(parameterKey))
            {
                throw new ArgumentException($"invalid {nameof(parameterKey)}");
            }

            if (parametersMapper.TryGetValue(parameterKey, out object value))
            {
                if (value is Target target)
                {
                    parameterValue = target;
                    return true;
                }
            }
            parameterValue = default;
            return false;
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
