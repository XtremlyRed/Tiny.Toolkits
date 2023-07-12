using System;
using System.ComponentModel;
using System.Diagnostics;
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
    /// RelayCommand
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class RelayCommand<TParameter> : CommandBase, ICommand, IRelayCommand<TParameter>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Action<TParameter> execute;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Func<TParameter, bool> canExecute = null;


        /// <summary>
        /// create a new command
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<TParameter> execute, Func<TParameter, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ??= i => true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            if (IsExecuting || parameter is not TParameter parameter1)
            {
                return false;
            }

            return CanExecute(parameter1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            if(parameter is TParameter parameter2)
            {
                Execute(parameter2);
            } 
        }

        /// <summary>
        /// can execute with <typeparamref name="TParameter"/> <paramref name="parameter"/>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(TParameter parameter)
        {
            return canExecute.Invoke(parameter);
        }

        /// <summary>
        /// execute command with <typeparamref name="TParameter"/> <paramref name="parameter"/>
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(TParameter parameter)
        {
            try
            {
                IsExecuting = true;
                RaiseCanExecuteChanged();
                execute.Invoke(parameter);
            }
            finally
            {
                IsExecuting = false;
                RaiseCanExecuteChanged();
            }
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
