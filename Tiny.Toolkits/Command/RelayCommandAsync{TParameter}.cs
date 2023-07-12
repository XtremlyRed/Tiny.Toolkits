using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tiny.Toolkits
{

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
    /// <see cref="RelayCommandAsync{TParameter}"/>
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class RelayCommandAsync<TParameter> : CommandBase, ICommand, IRelayCommandAsync<TParameter>
    {


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Func<TParameter, Task> execute;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Func<TParameter, bool> canExecute = null;


        /// <summary>
        /// create a new command
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommandAsync(Func<TParameter, Task> execute, Func<TParameter, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ??= i => true;
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (IsExecuting || parameter is not TParameter parameter1)
            {
                return false;
            }

            return CanExecute(parameter1);
        }

        async void ICommand.Execute(object parameter)
        {
            if (parameter is TParameter parameter1)
            {
                await ExecuteAsync(parameter1);
            }
        }

        /// <summary>
        /// can execute with <typeparamref name="TParameter"/> <paramref name="parameter"/>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(TParameter parameter)
        {
            return canExecute(parameter);
        }

        /// <summary>
        /// execute command with <typeparamref name="TParameter"/> <paramref name="parameter"/> async
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(TParameter parameter)
        {
            IsExecuting = true;
            RaiseCanExecuteChanged();
            await execute(parameter)
                .ContinueWith(executeTask =>
                {
                    IsExecuting = false;
                    RaiseCanExecuteChanged();

                    if (executeTask.Exception != null)
                    {
                        throw executeTask.Exception.InnerException ?? executeTask.Exception.InnerExceptions.FirstOrDefault();
                    }
                });

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandAction"></param>
        public static implicit operator RelayCommandAsync<TParameter>(Func<TParameter, Task> commandAction)
        {
            return new RelayCommandAsync<TParameter>(commandAction);
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
