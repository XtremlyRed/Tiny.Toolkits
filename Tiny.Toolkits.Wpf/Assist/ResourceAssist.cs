using System.Windows;

namespace Tiny.Toolkits
{
    /// <summary>
    /// resource assist
    /// </summary>
    public static partial class WpfAssist
    {

        /// <summary>
        ///  Resource Key
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="key"> Resource Key</param>
        /// <returns></returns>
        public static Target GetResource<Target>(string key)
        {
            return string.IsNullOrEmpty(key) || Application.Current is null
                ? default(Target)
                : Application.Current?.TryFindResource(key) is Target resource ? resource : default;
        }


        /// <summary>
        ///  GetResource
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="_"></param>
        /// <param name="key"> Resource Key </param>
        /// <returns></returns>
        public static Target GetResource<Target>(this DependencyObject _, string key)
        {
            return string.IsNullOrEmpty(key) || Application.Current is null
                ? default(Target)
                : Application.Current?.TryFindResource(key) is Target resource ? resource : default;
        }
    }
}
