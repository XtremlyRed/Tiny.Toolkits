
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Tiny.Toolkits
{
    /// <summary>
    /// simple mvvm BindableBase
    /// </summary>
    public abstract partial class BindableBase : INotifyPropertyChanged, INotifyPropertyChanging
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ConcurrentDictionary<string, PropertyChangedEventArgs> propertyChangedEventArgsCache = new();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ConcurrentDictionary<string, PropertyChangingEventArgs> propertyChangingEventArgsCache = new();

        /// <summary>
        /// Property Changed Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Property Changing Event
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Raise Property Changed
        /// </summary>
        /// <param name="propertyName">propertyName</param>
        /// <Exception cref="ArgumentNullException"></Exception>
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName is null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            PropertyChanged?.Invoke(this, propertyChangedEventArgsCache.GetOrAdd(propertyName, i => new PropertyChangedEventArgs(i)));
        }

        /// <summary>
        /// Raise Property Changing
        /// </summary>
        /// <param name="propertyName">propertyName</param>
        /// <Exception cref="ArgumentNullException"></Exception>
        protected virtual void RaisePropertyChanging([CallerMemberName] string propertyName = null)
        {
            if (propertyName is null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            PropertyChanging?.Invoke(this, propertyChangingEventArgsCache.GetOrAdd(propertyName, i => new PropertyChangingEventArgs(i)));

        }

        /// <summary>
        /// Raise Property List Changed
        /// </summary>
        /// <param name="propertyNames">property Names</param>
        public virtual void RaisePropertyChanged(params string[] propertyNames)
        {
            if (propertyNames == null || propertyNames.Length == 0)
            {
                return;
            }

            PropertyChangedEventHandler propertyChanged = PropertyChanged;

            foreach (string propertyName in propertyNames)
            {
                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    continue;
                }

                PropertyChanged?.Invoke(this, propertyChangedEventArgsCache.GetOrAdd(propertyName, i => new PropertyChangedEventArgs(i)));
                 
            }
        }


        /// <summary>
        /// dispose viewModel
        /// </summary>
        ~BindableBase()
        {
            PropertyValueMapper?.Clear();
            PropertyValueMapper = null;

            propertyChangedEventArgsCache?.Clear();
            propertyChangedEventArgsCache = null;

            propertyChangingEventArgsCache?.Clear();
            propertyChangingEventArgsCache = null;
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