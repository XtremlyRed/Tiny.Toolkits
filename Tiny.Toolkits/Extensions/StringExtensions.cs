 
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;

namespace Tiny.Toolkits
{
    /// <summary>
    /// simple string  extension
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// <c>@string</c> IsNullOrWhiteSpace
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string @string)
        {
            return string.IsNullOrWhiteSpace(@string);
        }

        /// <summary>
        /// <c>@string</c> IsNullOrEmpty
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string);
        }

        /// <summary>
        /// Compare two strings for equality
        /// </summary>
        /// <param name="originString">string</param>
        /// <param name="childString">other string</param>
        /// <param name="stringComparison"><see cref="StringComparison"/></param>
        /// <returns></returns>
        public static bool Contains(this string originString, string childString, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (originString is null || childString is null)
            {
                return false;
            }
            bool result = originString.IndexOf(childString, stringComparison) >= 0;

            return result;
        }


        /// <summary>
        /// Compare two strings for equality
        /// </summary>
        /// <param name="originString">string</param>
        /// <param name="compareString">other string</param>
        /// <param name="stringComparison"><see cref="StringComparison"/></param>
        /// <returns></returns>
        public static bool Compare(this string originString, string compareString, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return originString is not null && compareString is not null && string.Compare(originString, compareString, stringComparison) == 0;
        }

        /// <summary>
        ///  Join a <typeparamref name="TTarget"/> collection
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="targets">collection</param>
        /// <param name="joinString">join char</param>
        /// <param name="selector">value selecor</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static string Join<TTarget>(this IEnumerable<TTarget> targets, string joinString, Func<TTarget, string> selector)
        {
            return targets is null
                ? throw new ArgumentNullException(nameof(targets))
                : selector is null
                ? throw new ArgumentNullException(nameof(selector))
                : string.Join(joinString ?? ",", targets.Select(i => selector(i)));
        }

        /// <summary>
        ///  Join a  <typeparamref name="TTarget"/> collection
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="targets">collection</param>
        /// <param name="joinString">join char</param> 
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static string Join<TTarget>(this IEnumerable<TTarget> targets, string joinString = ",")
        {
            return targets is null
                ? throw new ArgumentNullException(nameof(targets))
                : string.Join(joinString ?? ",", targets);
        }

        /// <summary>
        /// create <see cref="System.Text.StringBuilder"/> from <typeparamref name="Target"/> Collection
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="collection">collection</param>
        /// <param name="action">builder function</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static StringBuilder StringBuilder<Target>(this IEnumerable<Target> collection, Action<StringBuilder, Target> action)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            StringBuilder stringBuilder = new();

            foreach (Target item in collection)
            {
                action(stringBuilder, item);
            }

            return stringBuilder;
        }
    }
}