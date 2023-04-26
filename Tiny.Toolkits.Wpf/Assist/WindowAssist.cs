using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Tiny.Toolkits
{
    /// <summary>
    /// window assist
    /// </summary>
    public static partial class WpfAssist
    {

        #region Win32 API functions

        //private const int SW_SHOW_NORMAL = 1;
        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);
        #endregion

        /// <summary>
        /// get window handle
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IntPtr GetHandle(this Window @this)
        {
            return new WindowInteropHelper(@this).Handle;
        }

        /// <summary>
        /// activate window
        /// </summary>
        /// <param name="thisWindow"></param>
        /// <returns></returns>
        public static bool ActivateWindow(this Window thisWindow)
        {
            if (thisWindow is null)
            {
                return false;
            }
            PresentationSource hwndSource1 = PresentationSource.FromVisual(thisWindow);
            if (hwndSource1 is HwndSource hwndSource)
            {
                if (thisWindow.Visibility != Visibility.Visible)
                {
                    thisWindow.Visibility = Visibility.Visible;
                }

                IntPtr @this = hwndSource.Handle;

                if (IsIconic(@this))
                {
                    ShowWindowAsync(@this, SW_RESTORE);
                }
                //ShowWindowAsync(@this, IsIconic(@this) ? SW_RESTORE : SW_SHOW_NORMAL);
                SetForegroundWindow(@this);
                FlashWindow(@this, true);

                return true;
            }
            return false;


        }
        /// <summary>
        /// show and activate
        /// </summary>
        /// <param name="window"></param>
        public static void ShowAndActivate(this Window window)
        {

            if (window.Dispatcher?.CheckAccess() ?? true)
            {
                Action();
            }
            else
            {
                window.Dispatcher.Invoke(Action);
            }

            void Action()
            {
                window.Show();
                window.ActivateWindow();
            }
        }
    }
}
