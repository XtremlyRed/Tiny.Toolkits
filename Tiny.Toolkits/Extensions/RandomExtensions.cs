using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Globalization;
namespace Tiny.Toolkits
{
    /// <summary>
    /// random extensions
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// default randomer
        /// </summary>
        private static readonly Random random1 = new();

        /// <summary>
        /// use <see cref="Random"/> to generate an index at random and return the corresponding value of the index
        /// <para>if the <c><paramref name="randomer"/></c> is null, use the built-in random</para>
        /// </summary>
        /// <typeparam name="Target"></typeparam> 
        /// <param name="collection"></param>
        /// <param name="randomer"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        /// <Exception cref="ArgumentOutOfRangeException"></Exception>
        public static Target InRandom<Target>(this IList<Target> collection, Random randomer = null!)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (collection.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ICollection.Count));
            }

            int index = (randomer ?? random1).Next(0, collection.Count);

            return collection[index];
        }
    }
}