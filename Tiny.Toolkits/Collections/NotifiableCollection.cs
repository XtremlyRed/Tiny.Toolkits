using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace Tiny.Toolkits
{
    /// <summary>
    ///  <see cref="NotifiableCollection{Target}"/> class
    /// </summary>
    /// <typeparam name="Target"></typeparam>
    public class NotifiableCollection<Target> : ObservableCollection<Target>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly NotifyCollectionChangedAction changedAction = NotifyCollectionChangedAction.Reset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const string CountString = "Count";
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const string IndexerName = "Item[]";

        /// <summary>
        /// 
        /// </summary>
        public NotifiableCollection() : base()
        {

        }

        /// <summary>
        /// create a new  AsyncObservableCollection
        /// </summary>
        public NotifiableCollection(bool autoNotifyWhenCollectionChanged = true)
        {
            AutoNotify = autoNotifyWhenCollectionChanged;
        }


        /// <summary>
        /// create a new  AsyncObservableCollection by an exist collection
        /// </summary>
        /// <param name="collection">a exist collection</param>
        /// <param name="autoNotifyWhenCollectionChanged"></param>
        public NotifiableCollection(IEnumerable<Target> collection, bool autoNotifyWhenCollectionChanged = true)
        {
            AutoNotify = autoNotifyWhenCollectionChanged;
            AddRange(collection);
        }


        /// <summary>
        /// create a new  AsyncObservableCollection by an exist array
        /// </summary>
        /// <param name="autoNotifyWhenCollectionChanged"></param>
        /// <param name="array">a exist array</param>
        public NotifiableCollection(bool autoNotifyWhenCollectionChanged, params Target[] array)
        {
            AutoNotify = autoNotifyWhenCollectionChanged;
            AddRange(array);
        }


        /// <summary>
        /// add an exist collection into this Collection
        /// </summary>
        /// <param name="collection">an exist collection</param>
        /// <Exception cref="ArgumentNullException"></Exception>
        public void AddRange(IEnumerable<Target> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (Target item in collection)
            {
                base.Add(item);
            }
        }

        /// <summary>
        /// add an exist array into this Collection
        /// </summary>
        /// <param name="array">an exist array</param>
        /// <Exception cref="ArgumentNullException"></Exception>
        public void AddRange(params Target[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            foreach (Target item in array)
            {
                base.Add(item);
            }
        }

        /// <summary>
        /// auto notify ollection changed
        /// </summary>
        public bool AutoNotify { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public void NotifyChanged()
        {

            base.OnPropertyChanged(new PropertyChangedEventArgs(CountString));
            base.OnPropertyChanged(new PropertyChangedEventArgs(IndexerName));
            base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(changedAction));

        }

        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (AutoNotify == false)
            {
                return;
            }

            base.OnPropertyChanged(e);
        }

        /// <summary>
        /// OnCollectionChanged
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (AutoNotify == false)
            {
                return;
            }

            base.OnCollectionChanged(e);
        }
    }
}
