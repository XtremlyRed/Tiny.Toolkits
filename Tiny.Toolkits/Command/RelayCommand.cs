using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tiny.Toolkits
{

    /// <summary>
    /// <see cref="IRelayCommand"/>
    /// </summary> 
    public interface IRelayCommand : ICommand
    {
        /// <summary>
        /// can execute
        /// </summary>
        /// <returns></returns>
        bool CanExecute();
        /// <summary>
        /// execute command
        /// </summary> 
        void Execute();
    }

    /// <summary>
    /// RelayCommand
    /// </summary>
    public class RelayCommand : CommandBase, IRelayCommand, ICommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Func<bool> canExecute;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Action execute;

        /// <summary>
        /// create a new command  
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ??= () => true;
        }


        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }
        /// <summary>
        ///  can cexcute command
        /// </summary>
        /// <returns></returns>
        public bool CanExecute()
        {
            return base.IsExecuting ? false : canExecute();
        }
        /// <summary>
        /// execute sync command
        /// </summary>
        public void Execute()
        {
            try
            {
                base.IsExecuting = true;

                RaiseCanExecuteChanged();
                execute.Invoke();
            }
            finally
            {
                IsExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// create relaycommand from  <see cref="Action"/> <paramref name="commandAction"/>
        /// </summary>
        /// <param name="commandAction"></param>
        public static implicit operator RelayCommand(Action commandAction)
        {
            return new RelayCommand(commandAction);
        }

        /// <summary>
        ///  binding command
        /// </summary>
        /// <param name="commandAction"></param>
        /// <param name="canExecuteAction"></param>
        /// <returns></returns>
        public static RelayCommand Bind(Action commandAction, Func<bool> canExecuteAction = null)
        {
            return new RelayCommand(commandAction, canExecuteAction);
        }



        /// <summary>
        /// binding command
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="commandAction"></param>
        /// <param name="canExecuteAction"></param>
        /// <returns></returns>
        public static RelayCommand<Target> Bind<Target>(Action<Target> commandAction, Func<Target, bool> canExecuteAction = null)
        {
            return new RelayCommand<Target>(commandAction, canExecuteAction);
        }



        /// <summary>
        /// binding command
        /// </summary> 
        /// <param name="commandAction"></param>
        /// <param name="canExecuteAction"></param>
        /// <returns></returns>
        public static RelayCommandAsync Bind(Func<Task> commandAction, Func<bool> canExecuteAction = null)
        {
            return new RelayCommandAsync(commandAction, canExecuteAction);
        }



        /// <summary>
        /// binding command
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="commandAction"></param>
        /// <param name="canExecuteAction"></param>
        /// <returns></returns>
        public static RelayCommandAsync<Target> Bind<Target>(Func<Target, Task> commandAction, Func<Target, bool> canExecuteAction = null)
        {
            return new RelayCommandAsync<Target>(commandAction, canExecuteAction);
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
