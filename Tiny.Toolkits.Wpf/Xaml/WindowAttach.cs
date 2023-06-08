using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
    public static class WindowAttach
    { 
        #region window move

        private static readonly List<int> registedWindow = new();
        /// <summary>
        /// password
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetEnableWindowMovable(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableWindowMovableProperty);
        }

        /// <summary>
        /// password
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetEnableWindowMovable(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableWindowMovableProperty, value);
        }

        /// <summary>
        /// password
        /// </summary>
        public static readonly DependencyProperty EnableWindowMovableProperty =
            DependencyProperty.RegisterAttached("EnableWindowMovable", typeof(bool),
            typeof(WindowAttach),
            new FrameworkPropertyMetadata(false, (s, e) =>
            {
                if (s is not FrameworkElement uielement)
                {
                    return;
                }

                if (uielement.IsLoaded)
                {
                    Register();
                    return;
                }
                RoutedEventHandler routedEventHandler = null;
                routedEventHandler = (s, e) =>
                {
                    uielement.Loaded -= routedEventHandler;
                    Register();
                };
                uielement.Loaded += routedEventHandler;
                 
                void Register()
                {
                    Window window = uielement.FindParent<Window>();
                    if (window is null)
                    {
                        return;
                    }

                    if (registedWindow.Contains(window.GetHashCode()))
                    {
                        return;
                    }

                    registedWindow.Add(window.GetHashCode());

                    System.Reflection.PropertyInfo property = uielement.GetType().GetProperty(nameof(Panel.Background));
                    if (property != null)
                    {
                        if (property.GetValue(uielement) is null)
                        {
                            try
                            {
                                property.SetValue(uielement, System.Windows.Media.Brushes.Transparent);
                            }
                            catch
                            {
                            }
                        }
                    }

                    uielement.PreviewMouseLeftButtonDown += (s, e) =>
                    {
                        if (e.MouseDevice.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                        {
                            try
                            {
                                window.DragMove();
                            }
                            catch
                            {
                            }
                        }
                    };
                }
            }));



        #endregion




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
            typeof(WindowAttach),
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
