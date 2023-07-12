using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
    public class RelayCommandAsync : CommandBase, IRelayCommandAsync
    { 
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Func<Task> execute;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Func<bool> canExecute = null;


        /// <summary>
        /// create a new command
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommandAsync(Func<Task> execute, Func<bool> canExecute = null)
        {
            this.execute = execute ?? throw new Exception(nameof(execute));
            this.canExecute = canExecute ??= () => true;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
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
            return IsExecuting ? false : canExecute();
        }

        /// <summary>
        /// execute command async
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteAsync()
        {
            IsExecuting = true;
            RaiseCanExecuteChanged();
            await execute()
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
