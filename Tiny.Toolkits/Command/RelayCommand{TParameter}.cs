using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Tiny.Toolkits
{
    /// <summary>
    /// <see cref="IRelayCommand{TParameter}"/>
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public interface IRelayCommand<TParameter> : ICommand
    {
        /// <summary>
        /// can execute command
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool CanExecute(TParameter parameter);

        /// <summary>
        /// execute command
        /// </summary>
        /// <param name="parameter"></param>
        void Execute(TParameter parameter);
    }

    /// <summary>
    /// <see cref="IRelayCommandAsync{TParameter}"/>
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public interface IRelayCommandAsync<TParameter> : ICommand
    {
        /// <summary>
        /// can execute command
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool CanExecute(TParameter parameter);

        /// <summary>
        /// execute command async
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task ExecuteAsync(TParameter parameter);
    }

    /// <summary>
    /// RelayCommand
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class RelayCommand<TParameter> : ICommand, IRelayCommand<TParameter>
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
        private readonly Action<TParameter> executeCallback;

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
        public RelayCommand(Action<TParameter> executeCallback, Func<TParameter, bool> canExecuteCallback = null)
        {
            this.executeCallback = executeCallback;
            this.canExecuteCallback = canExecuteCallback;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return isExecuting
                ? false
                : parameter is TParameter parameter1
                ? CanExecute(parameter1)
                : true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            TParameter p = default;

            if (parameter is TParameter parameter2)
            {
                p = parameter2;
            }

            Execute(p);
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
        /// execute command with <typeparamref name="TParameter"/> <paramref name="parameter"/>
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(TParameter parameter)
        {
            if (executeCallback is null)
            {
                return;
            }

            try
            {
                isExecuting = true;
                RaiseCanExecuteChanged();
                executeCallback.Invoke(parameter);
            }
            finally
            {
                isExecuting = false;
                RaiseCanExecuteChanged();
            }
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
        public static implicit operator RelayCommand<TParameter>(Action<TParameter> commandAction)
        {
            return new RelayCommand<TParameter>(commandAction);
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
