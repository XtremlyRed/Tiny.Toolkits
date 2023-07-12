using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace Tiny.Toolkits
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class CommandBase : INotifyPropertyChanged
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly PropertyChangedEventArgs IsExecutingProperty = new(nameof(IsExecuting));
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool isExecuting;
        public bool IsExecuting
        {
            get => isExecuting; protected set
            {
                if (isExecuting != value)
                {
                    isExecuting = value;
                    PropertyChanged?.Invoke(this, IsExecutingProperty);
                }
            }
        }

        /// <summary>
        /// raise can execute changed
        /// </summary>
        public virtual void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                synchronizationContext.Post(_ => CanExecuteChanged.Invoke(this, EventArgs.Empty), this);
            }
        }


        /// <summary>
        /// can execute changed event
        /// </summary>
        public event EventHandler CanExecuteChanged;


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


        /// <summary>
        /// property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        ///                      
        /// <summary>
        /// raise property changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion

}
