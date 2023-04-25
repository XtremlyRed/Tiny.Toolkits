
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tiny.Toolkits
{
    /// <summary>
    /// simple mvvm ViewModelBase
    /// </summary>
    public abstract partial class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Property Changed Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        /// <summary>
        /// dispose viewModel
        /// </summary>
        ~ViewModelBase()
        {
            PropertyValueMapper?.Clear();
        }
    }
}