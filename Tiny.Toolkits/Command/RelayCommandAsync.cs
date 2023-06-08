using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tiny.Toolkits
{
    /// <summary>
    /// <see cref="IRelayCommandAsync"/>
    /// </summary>
    public interface IRelayCommandAsync : ICommand
    {
        /// <summary>
        /// can execute
        /// </summary>
        /// <returns></returns>
        bool CanExecute();

        /// <summary>
        /// execute command async
        /// </summary>
        /// <returns></returns>
        Task ExecuteAsync();
    }


    /// <summary>
    /// <see cref="RelayCommandAsync"/>
    /// </summary>
    public class RelayCommandAsync : IRelayCommandAsync
    {
        /// <summary>
        /// can execute changed event
        /// </summary>
        public event EventHandler CanExecuteChanged;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private readonly Func<Task> executeCallback;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private readonly Func<bool> canExecuteCallback = null;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool isExecuting;

        /// <summary>
        /// create a new command
        /// </summary>
        /// <param name="executeCallback"></param>
        /// <param name="canExecuteCallback"></param>
        public RelayCommandAsync(Func<Task> executeCallback, Func<bool> canExecuteCallback = null)
        {
            this.executeCallback = executeCallback;
            this.canExecuteCallback = canExecuteCallback;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return !isExecuting && CanExecute();
        }

        async void ICommand.Execute(object parameter)
        {
            await ExecuteAsync();
        }

        /// <summary>
        /// can execute
        /// </summary>
        /// <returns></returns>
        public bool CanExecute()
        {
            return canExecuteCallback?.Invoke() ?? true;
        }

        /// <summary>
        /// execute command async
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteAsync()
        {
            if (executeCallback is null)
            {
                await Task.FromResult(false);
            }

            isExecuting = true;
            RaiseCanExecuteChanged();
            await executeCallback
                   .Invoke()
                   .ContinueWith(y =>
                   {
                       try
                       {
                           y.Wait();
                       }
                       finally
                       {
                           isExecuting = false;
                           RaiseCanExecuteChanged();
                       }
                   });

        }

        /// <summary>
        /// raise can execute changed
        /// </summary>
        public virtual void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandAction"></param>
        public static implicit operator RelayCommandAsync(Func<Task> commandAction)
        {
            return new RelayCommandAsync(commandAction);
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
