using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Linq
{
    /// <summary>
    /// Collection Extensions
    /// </summary>
    public static class CollectionExtensions
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
                    yield return currentIndex;
                }

                currentIndex++;
            }
        }

        /// <summary>
        /// forEach   collection 
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="forEachBody">forEachBody</param>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void ForEach<Target>(this IEnumerable<Target> collection, Action<Target> forEachBody)
        {
            if (collection is null || forEachBody is null)
            {
                return;
            }

            foreach (Target item in collection)
            {
                forEachBody(item);
            }
        }

        /// <summary>
        /// loop collection{<typeparamref name="Target"/>} by forEachBody and element RetryIndex
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="forEachBody">forEachBody</param>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void ForEach<Target>(this IEnumerable<Target> collection, Action<Target, int> forEachBody)
        {
            if (collection is null || forEachBody is null)
            {
                return;
            }

            int index = 0;

            foreach (Target item in collection)
            {
                forEachBody(item, index);
                index++;
            }
        }

        /// <summary>
        /// add items into collection
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="items">items</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static ICollection<Target> AddItems<Target>(this ICollection<Target> collection, IEnumerable<Target> items)
        {
            if (collection is null || items is null)
            {
                return collection;
            }

            if (collection is Target[] targets)
            {
                Target[] array = items.AsArray();
                Array.Resize(ref targets, targets.Length + array.Length);
                Array.Copy(array, 0, targets, targets.Length, array.Length);
                return targets;
            }


            foreach (Target item in items)
            {
                collection.Add(item);
            }

            return collection;
        }

        /// <summary>
        /// add items into collection
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="items">items coll</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static ICollection<Target> AddItems<Target>(this ICollection<Target> collection, params Target[] items)
        {
            if (collection is null || items is null || items.Length == 0)
            {
                return collection;
            }

            if (collection is Target[] targets)
            {
                int index = targets.Length;
                Array.Resize(ref targets, targets.Length + items.Length);
                Array.Copy(items, 0, targets, index, items.Length);
                return targets;
            }

            foreach (Target item in items)
            {
                collection.Add(item);
            }

            return collection;
        }


#if !NET6_0_OR_GREATER

        /// <summary>
        /// Max items OF collection
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <typeparam name="TComparable"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="maxComparer"></param> 
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Target MaxBy<Target, TComparable>(this IEnumerable<Target> collection, Func<Target, TComparable> maxComparer)
            where TComparable : IComparable<TComparable>
            where Target : notnull
        {
            if (collection is null || maxComparer == null || collection.Any() == false)
            {
                return default;
            }

            Target first = collection.First();
            TComparable firstCompa = maxComparer(first);

            foreach (Target item in collection.Skip(1))
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
        /// <typeparam name="Target"></typeparam>
        /// <typeparam name="TComparable"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="minComparer"></param> 
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Target MinBy<Target, TComparable>(this IEnumerable<Target> collection, Func<Target, TComparable> minComparer)
            where TComparable : IComparable<TComparable>
            where Target : notnull
        {
            if (collection is null || minComparer == null || collection.Any() == false)
            {
                return default;
            }
             

            Target first = collection.First();
            TComparable firstCompa = minComparer(first);
            foreach (Target item in collection.Skip(1))
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
        /// segment a <typeparamref name="Target"/> collection
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="targets">collection</param>
        /// <param name="segmentCapacity">the capacity of segment</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        /// <Exception cref="ArgumentOutOfRangeException"></Exception>
        public static IEnumerable<IEnumerable<Target>> Chunk<Target>(this IEnumerable<Target> targets, int segmentCapacity)
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
        public static Target Disorder<Target>(this Target target) where Target : System.Collections.IList
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
        /// collection to  <see cref="ObservableCollection{Target}"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static ObservableCollection<Target> ToObservableCollection<Target>(this IEnumerable<Target> collection)
        {
            return collection is null
                ? new ObservableCollection<Target>()
                : new ObservableCollection<Target>(collection);
        }


        /// <summary>
        /// source to array or self
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[] AsArray<T>(this IEnumerable<T> source)
        {
            return source is null
                ? EmptyArray<T>()
                : source is T[] array
                ? array
                : source.ToArray();
        }

        /// <summary>
        /// source to <see cref="List{T}"/> or self
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IList<T> AsList<T>(this IEnumerable<T> source)
        {
            return source is null
                ? EmptyArray<T>()
                : source is List<T> array
                ? array
                : source.ToList();
        }

        /// <summary>
        /// copy array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] source)
        {
            if (source == null)
            {
                return source;
            }
            if (source.Length == 0)
            {
                return EmptyArray<T>();
            }

            T[] copy = new T[source.Length];
            Array.Copy(source, 0, copy, 0, source.Length);
            return copy;
        }
    }
}