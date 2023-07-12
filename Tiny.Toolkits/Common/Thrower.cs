using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Tiny.Toolkits
{
    /// <summary>
    /// exception thrower
    /// </summary>
    public static class Thrower
    {
        private const string positionInfo = "{0}, On line {1} of file {2}";

        /// <summary>
        /// throw <paramref name="message"/>  <see cref="Exception"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <exception cref="Exception"></exception>
        public static void Throw(string message, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            throw new Exception(string.Format(positionInfo, message, lineNumber, Path.GetFileName(filePath)));
        }

        /// <summary>
        /// throw <paramref name="argumentName"/> <see langword="null"/>  <see cref="Exception"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="argumentName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IsArgumentNull<T>(this T value, string argumentName, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) where T : class
        {
            const string argumentNullMessage = "{0} is null";
            if (value is null)
            {
                string message = string.Format(argumentNullMessage, argumentName ?? "value");

                throw new ArgumentNullException(argumentName, string.Format(positionInfo, message, lineNumber, Path.GetFileName(filePath)));
            }
        }
        /// <summary>
        /// throw <paramref name="message"/> <see cref="Exception"/> when <paramref name="condition"/> is true
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <exception cref="Exception"></exception>
        public static void IfTrue(bool condition, string message, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (condition)
            {
                throw new Exception(string.Format(positionInfo, message, lineNumber, Path.GetFileName(filePath)));
            }
        }

        /// <summary>
        /// throw <paramref name="message"/> <see cref="Exception"/> when <paramref name="condition"/> is false
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <exception cref="Exception"></exception>
        public static void IfFalse(bool condition, string message, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (condition == false)
            {
                throw new Exception(string.Format(positionInfo, message, lineNumber, Path.GetFileName(filePath)));
            }
        }

        /// <summary>
        /// throw <paramref name="valueName"/> is <see langword="null"/>  <see cref="Exception"/> when <paramref name="value"/> is false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="valueName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <exception cref="Exception"></exception>
        public static void IsNull<T>(this T value, string valueName, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) where T : class
        {
            const string defaultMessage = "{0} is null";
            if (value is null)
            {
                string message = string.Format(defaultMessage, valueName ?? "value");

                throw new Exception(string.Format(positionInfo, message, lineNumber, Path.GetFileName(filePath)));
            }
        }
    }
}
