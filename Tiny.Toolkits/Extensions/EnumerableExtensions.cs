
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tiny.Toolkits
{
    /// <summary>
    /// Collection Extensions
    /// </summary>
    public static partial class EnumerableExtensions
    {
        private static class EmptyImpls<T>
        {
            public static readonly T[] Array = new T[0];
        }


        /// <summary>
        /// empty array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] EmptyArray<T>()
        {
            return EmptyImpls<T>.Array;
        }



        /// <summary>
        ///  collection is  null  or empty
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> coll)
        {
            if (coll is null)
            {
                return true;
            }

            if (coll is ICollection collection)
            {
                return collection.Count == 0;
            }

            if (coll is IReadOnlyCollection<TSource> readonlyList)
            {
                return readonlyList.Count == 0;
            }

            using IEnumerator<TSource> itor = coll.GetEnumerator();

            return itor.MoveNext();

        }


        /// <summary>
        ///  gets the index number of an element in the collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="collection"></param>
        /// <param name="source"></param> 
        /// <returns>index number</returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> collection, TSource source)
        {
            if (collection is null || source is null)
            {
                return -1;
            }
            int currentIndex = 0;
            EqualityComparer<TSource> @default = EqualityComparer<TSource>.Default;
            using IEnumerator<TSource> itor = collection.GetEnumerator();
            while (itor.MoveNext())
            {
                if (@default.Equals(itor.Current, source))
                {
                    return currentIndex;
                }
                currentIndex++;
            }
            return -1;
        }


        /// <summary>
        ///  gets the index number of an element in the collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param> 
        /// <returns>index number</returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            if (collection is null || predicate is null)
            {
                return -1;
            }

            int currentIndex = 0;

            using IEnumerator<TSource> itor = collection.GetEnumerator();

            while (itor.MoveNext())
            {
                if (predicate(itor.Current))
                {
                    return currentIndex;
                }

                currentIndex++;
            }

            return -1;
        }

        /// <summary>
        ///  gets the index number of an element in the collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param> 
        /// <returns>index number</returns>
        public static IEnumerable<int> IndexOfMany<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            if (collection is null || predicate is null)
            {
                yield break;
            }

            int currentIndex = 0;

            using IEnumerator<TSource> itor = collection.GetEnumerator();

            while (itor.MoveNext())
            {
                if (predicate(itor.Current))
                {
                    int current = currentIndex;
                    currentIndex++;
                    yield return current;
                }

                currentIndex++;
            }
        }

        /// <summary>
        /// forEach   collection 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="forEachBody">forEachBody</param>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void ForEach<TSource>(this IEnumerable<TSource> collection, Action<TSource> forEachBody)
        {
            if (collection is null || forEachBody is null)
            {
                return;
            }

            foreach (TSource item in collection)
            {
                forEachBody(item);
            }
        }

        /// <summary>
        /// loop collection{<typeparamref name="TSource"/>} by forEachBody and element RetryIndex
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="forEachBody">forEachBody</param>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void ForEach<TSource>(this IEnumerable<TSource> collection, Action<TSource, int> forEachBody)
        {
            if (collection is null || forEachBody is null)
            {
                return;
            }

            int index = 0;

            foreach (TSource item in collection)
            {
                forEachBody(item, index);
                index++;
            }
        }

        /// <summary>
        /// add items into collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="items">items</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void AddItems<TSource, TItem>(this ICollection<TSource> collection, IEnumerable<TItem> items) where TItem : TSource
        {
            if (collection is null || items is null)
            {
                return;
            }

            foreach (TSource item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// add items into collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="items">items coll</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void AddItems<TSource, TItem>(this ICollection<TSource> collection, params TItem[] items) where TItem : TSource
        {
            if (collection is null || items is null || items.Length == 0)
            {
                return;
            }

            foreach (TSource item in items)
            {
                collection.Add(item);
            }
        }


        /// <summary>
        /// concat items into collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="items">items coll</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static IEnumerable<TSource> Concat<TSource, TItem>(this IEnumerable<TSource> collection, params TItem[] items) where TItem : TSource
        {
            return collection is null || items is null || items.Length == 0
                ? collection
                : collection.Concat(items);
        }

        /// <summary>
        /// concat items into collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="source">source</param>
        /// <param name="items">items coll</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static IEnumerable<TSource> Concat<TSource, TItem>(this TSource source, params TItem[] items) where TItem : TSource
        {
            return source is null
                ? items is null || items.Length == 0 ? EmptyArray<TSource>() : items.Cast<TSource>()
                : items is null || items.Length == 0 ? (new[] { source }) : new[] { source }.Concat(items);
        }



#if !NET6_0_OR_GREATER

        /// <summary>
        /// Max items OF collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TComparable"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="maxComparer"></param> 
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TSource MaxBy<TSource, TComparable>(this IEnumerable<TSource> collection, Func<TSource, TComparable> maxComparer)
            where TComparable : IComparable<TComparable>
            where TSource : notnull
        {
            if (collection is null || maxComparer == null || collection.Any() == false)
            {
                return default;
            }

            TSource first = collection.First();
            TComparable firstCompa = maxComparer(first);

            foreach (TSource item in collection.Skip(1))
            {
                TComparable current = maxComparer(item);

                int com = current.CompareTo(firstCompa);
                if (com > 0)
                {
                    firstCompa = current;
                    first = item;
                }
            }

            return first;
        }



        /// <summary>
        /// Min items OF collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TComparable"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="minComparer"></param> 
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TSource MinBy<TSource, TComparable>(this IEnumerable<TSource> collection, Func<TSource, TComparable> minComparer)
            where TComparable : IComparable<TComparable>
            where TSource : notnull
        {
            if (collection is null || minComparer == null || collection.Any() == false)
            {
                return default;
            }


            TSource first = collection.First();
            TComparable firstCompa = minComparer(first);
            foreach (TSource item in collection.Skip(1))
            {
                TComparable current = minComparer(item);

                int com = current.CompareTo(firstCompa);
                if (com < 0)
                {
                    firstCompa = current;
                    first = item;
                }
            }

            return first;
        }




        /// <summary>
        /// segment a <typeparamref name="TSource"/> collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="targets">collection</param>
        /// <param name="segmentCapacity">the capacity of segment</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        /// <Exception cref="ArgumentOutOfRangeException"></Exception>
        public static IEnumerable<IEnumerable<TSource>> Chunk<TSource>(this IEnumerable<TSource> targets, int segmentCapacity)
        {

            if (targets is null || segmentCapacity < 1)
            {
                yield break;
            }

            int totalCount = targets.Count();

            int segmentCount = totalCount / segmentCapacity;

            int segmentCounter = segmentCount * segmentCapacity;

            int remainingCount = totalCount - segmentCounter;

            for (int i = 0; i < segmentCount; i++)
            {
                yield return targets.Skip(i * segmentCapacity).Take(segmentCapacity);
            }

            if (remainingCount > 0)
            {
                yield return targets.Skip(segmentCounter).Take(remainingCount);
            }
        }

#endif

        /// <summary>
        /// Disrupt the order of a  collection
        /// </summary> 
        /// <param name="target"></param>
        public static TSource Disorder<TSource>(this TSource target) where TSource : System.Collections.IList
        {
            if (target is null || target.Count == 0)
            {
                return target;
            }

            Random disorderRandom = new();

            int currentIndex, targetIndex;
            object tempValue;
            int maxIndex = target.Count - 1;

            for (int i = 0; i < target.Count; i++)
            {
                targetIndex = maxIndex - i;
                currentIndex = disorderRandom.Next(0, target.Count - i);
                tempValue = target[currentIndex];
                target[currentIndex] = target[targetIndex];
                target[targetIndex] = tempValue;
            }

            return target;
        }


        /// <summary>
        /// remove elements that meet the condition from the IEnumerable collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="filter">filter condition</param>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveAll<TSource>(this IEnumerable collection, Func<TSource, bool> filter)
        {
            if (collection is null || filter is null)
            {
                yield break;
            }

            foreach (TSource item in collection)
            {
                if (filter(item) == false)
                {
                    yield return item;
                }
            }
        }



        /// <summary>
        /// collection to  <see cref="ObservableCollection{Target}"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static ObservableCollection<TSource> ToObservableCollection<TSource>(this IEnumerable<TSource> collection)
        {
            return collection is null
                ? new ObservableCollection<TSource>()
                : new ObservableCollection<TSource>(collection);
        }


        /// <summary>
        /// source to array or self
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TSource[] ToArrayTryNonEnumerated<TSource>(this IEnumerable<TSource> source)
        {
            return source is null
                ? EmptyArray<TSource>()
                : source is TSource[] array
                ? array
                : source.ToArray();
        }

        /// <summary>
        /// source to <see cref="List{T}"/> or self
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IList<TSource> ToListTryNonEnumerated<TSource>(this IEnumerable<TSource> source)
        {
            return source is null
                ? EmptyArray<TSource>()
                : source is List<TSource> array
                ? array
                : source.ToList();
        }

        /// <summary>
        /// copy array
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TSource[] Copy<TSource>(this TSource[] source)
        {
            if (source == null)
            {
                return source;
            }
            if (source.Length == 0)
            {
                return EmptyArray<TSource>();
            }

            TSource[] copy = new TSource[source.Length];
            Array.ConstrainedCopy(source, 0, copy, 0, source.Length);
            return copy;
        }
    }
}