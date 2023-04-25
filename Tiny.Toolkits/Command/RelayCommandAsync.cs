using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
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
    public class RelayCommandAsync : ICommand, IRelayCommandAsync
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private readonly SynchronizationContext synchronizationContext = SynchronizationContext.Current;
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
            return isExecuting ? false : CanExecute();
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
        public Task ExecuteAsync()
        {
            if (executeCallback is null)
            {
                return Task.FromResult(false);
            }

            isExecuting = true;
            RaiseCanExecuteChanged();
            return executeCallback
                   .Invoke()
                   .ContinueWith(y =>
                   {
                       isExecuting = false;
                       RaiseCanExecuteChanged();
                       y.Wait();
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
    }
}
