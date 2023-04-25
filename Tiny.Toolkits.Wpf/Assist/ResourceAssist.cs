using System.Windows;

namespace Tiny.Toolkits.Wpf
{
    /// <summary>
    /// resource assist
    /// </summary>
    public static partial class AssistFactory
    {

        /// <summary>
        ///  Resource Key
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="key"> Resource Key</param>
        /// <returns></returns>
        public static Target GetResource<Target>(string key)
        {
            if (string.IsNullOrEmpty(key) || Application.Current is null)
            {
                return default(Target);
            }

            if (Application.Current?.TryFindResource(key) is Target resource)
            {
                return resource;
            }

            return default;
        }


        /// <summary>
        ///  GetResource
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="element"></param>
        /// <param name="key"> Resource Key </param>
        /// <returns></returns>
        public static Target GetResource<Target>(this DependencyObject element, string key)
        {
            if (string.IsNullOrEmpty(key) || Application.Current is null)
            {
                return default(Target);
            }

            if (Application.Current?.TryFindResource(key) is Target resource)
            {
                return resource;
            }

            return default;
        }
    }
}
