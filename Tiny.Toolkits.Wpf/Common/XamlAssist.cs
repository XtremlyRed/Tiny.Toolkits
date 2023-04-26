using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace Tiny.Toolkits
{

    /// <summary>
    /// xaml attache 
    /// </summary>
    public static class XamlAttache
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly ConcurrentDictionary<object, bool> bindingAssistCached = new();

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
            typeof(XamlAttache),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordChanged));

        //when the buffer changed, upate the passwordBox's password
        private static void OnPasswordChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is PasswordBox passwordBox)
            {
                if (bindingAssistCached.TryGetValue(passwordBox, out bool result) == false)
                {
                    passwordBox.Unloaded += PasswordBox_Unloaded;
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                    bindingAssistCached[passwordBox] = true;
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
                bindingAssistCached.TryRemove(passwordBox, out bool _);
            }

            void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
            {
                SetPassword(passwordBox, passwordBox.Password);
            }
        }


        #region window Blur


        /// <summary>
        /// password
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetEnableWindowBlur(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableWindowBlurProperty);
        }

        /// <summary>
        /// password
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetEnableWindowBlur(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableWindowBlurProperty, value);
        }

        /// <summary>
        /// password
        /// </summary>
        public static readonly DependencyProperty EnableWindowBlurProperty =
            DependencyProperty.RegisterAttached("EnableWindowBlur", typeof(bool),
            typeof(XamlAttache),
            new FrameworkPropertyMetadata(false, (s, e) =>
            {
                if (s is Window window)
                {
                    window.WindowStyle = WindowStyle.None;
                    window.AllowsTransparency = true;
                    if (window.IsLoaded)
                    {
                        window.EnableBlur((bool)e.NewValue);
                    }
                    else
                    {
                        window.Loaded += (s, ee) =>
                        {
                            window.EnableBlur((bool)e.NewValue);
                        };
                    }
                }
            }));

        private static readonly ConcurrentDictionary<int, bool> keyValuePairs = new();

        /// <summary>
        /// set window blur
        /// </summary>
        /// <param name="window"></param>
        /// <param name="enable"></param>
        public static void EnableBlur(this Window window, bool enable)
        {
            if (enable == false || (keyValuePairs.TryGetValue(window.GetHashCode(), out bool v) && v))
            {
                return;
            }

            keyValuePairs[window.GetHashCode()] = true;
            WindowInteropHelper windowHelper = new(window);

            AccentPolicy accent = new()
            {
                AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND,
                //GradientColor = (int) ((_blurOpacity << 24) | (_blurBackgroundColor & 0xFFFFFF))
            };

            int accentStructSize = Marshal.SizeOf(accent);

            IntPtr accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            WindowCompositionAttributeData data = new()
            {
                Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);


        private enum AccentState
        {
            ACCENT_DISABLED = 1,
            ACCENT_ENABLE_GRADIENT = 0,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_INVALID_STATE = 4,
            ACCENT_ENABLE_ACRYLICBLURBEHIND = 5
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        private enum WindowCompositionAttribute
        {
            // ...
            WCA_ACCENT_POLICY = 19
            // ...
        }


        #endregion
    }
}
