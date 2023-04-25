using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tiny.Toolkits
{
    /// <summary>
    /// <see cref="RelayCommandAsync{TParameter}"/>
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class RelayCommandAsync<TParameter> : ICommand, IRelayCommandAsync<TParameter>
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
        private readonly Func<TParameter, Task> executeCallback;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private readonly Func<TParameter, bool> canExecuteCallback = null;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool isExecuting;

        /// <summary>
        /// create a new command
        /// </summary>
        /// <param name="executeCallback"></param>
        /// <param name="canExecuteCallback"></param>
        public RelayCommandAsync(Func<TParameter, Task> executeCallback, Func<TParameter, bool> canExecuteCallback = null)
        {
            this.executeCallback = executeCallback;
            this.canExecuteCallback = canExecuteCallback;
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (isExecuting)
            {
                return false;
            }

            if (parameter is TParameter parameter1)
            {
                return CanExecute(parameter1);
            }

            return true;
        }

        async void ICommand.Execute(object parameter)
        {
            TParameter p = default;

            if (parameter is TParameter parameter1)
            {
                p = parameter1;
            }

            await ExecuteAsync(p);
        }

        /// <summary>
        /// can execute with <typeparamref name="TParameter"/> <paramref name="parameter"/>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(TParameter parameter)
        {
            return canExecuteCallback?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// execute command with <typeparamref name="TParameter"/> <paramref name="parameter"/> async
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Task ExecuteAsync(TParameter parameter)
        {
            if (executeCallback is null)
            {
                return Task.FromResult(false);
            }

            isExecuting = true;
            RaiseCanExecuteChanged();
            return executeCallback
                .Invoke(parameter)
                .ContinueWith(t =>
                {
                    RaiseCanExecuteChanged();
                    isExecuting = false; 
                    t.Wait();
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
        public static implicit operator RelayCommandAsync<TParameter>(Func<TParameter, Task> commandAction)
        {
            return new RelayCommandAsync<TParameter>(commandAction);
        }
    }
}
