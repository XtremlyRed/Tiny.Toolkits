using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Tiny.Toolkits
{
    /// <summary>
    ///  a class of <see cref="PasswordAttach"/>
    /// </summary>
    public class PasswordAttach : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly ConcurrentDictionary<int, bool> bindingAssistCached = new();

        /// <summary>
        /// password
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        /// <summary>
        /// password
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        /// <summary>
        /// password
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string),
            typeof(PasswordAttach),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordChanged));

        //when the buffer changed, upate the passwordBox's password
        private static void OnPasswordChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is PasswordBox passwordBox)
            {
                if (bindingAssistCached.TryGetValue(passwordBox.GetHashCode(), out bool result) == false)
                {
                    passwordBox.Unloaded += PasswordBox_Unloaded;
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                    bindingAssistCached[passwordBox.GetHashCode()] = true;
                }

                string newValue = e.NewValue?.ToString() ?? string.Empty;
                string oldValue = passwordBox.Password;

                if (newValue == oldValue)
                {
                    return;
                }

                passwordBox.Password = newValue;
            }

            void PasswordBox_Unloaded(object sender, RoutedEventArgs e)
            {
                passwordBox.Unloaded -= PasswordBox_Unloaded;
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                bindingAssistCached.TryRemove(passwordBox.GetHashCode(), out bool _);
            }

            void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
            {
                SetPassword(passwordBox, passwordBox.Password);
            }
        }
    }
}
