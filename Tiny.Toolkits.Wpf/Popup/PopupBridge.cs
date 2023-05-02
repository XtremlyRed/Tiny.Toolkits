using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
namespace Tiny.Toolkits.Popup.Assist
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class PopupBridge
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal SemaphoreSlim messageSemaphoreSlim;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal SemaphoreSlim contentSemaphoreSlim;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal SemaphoreSlim messageCloseSemaphoreSlim;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal SemaphoreSlim contentCloseSemaphoreSlim;

        public AdornerLayer AdornerLayer { get; set; }

        public PopupAdorner PopupAdornet { get; set; }

        public bool IsLoaded { get; internal set; }

        private bool IsPopup;

        private int popupIndex = 0;

        public void DisplayVisual()
        {
            lock (this)
            {
                if (IsPopup == false)
                {
                    AdornerLayer.Add(PopupAdornet);
                    IsPopup = true;
                }

                Interlocked.Increment(ref popupIndex);
            }
        }

        public void CloseVisual()
        {
            lock (this)
            {
                int index = Interlocked.Decrement(ref popupIndex);

                if (popupIndex == 0)
                {
                    AdornerLayer.Remove(PopupAdornet);
                    IsPopup = false;
                }
            }
        }

        internal void Release()
        {
            popupIndex = 0;
            IsPopup = false;
            AdornerLayer = null;
            PopupAdornet = null;

            messageSemaphoreSlim?.Dispose();
            messageSemaphoreSlim = null;

            contentSemaphoreSlim?.Dispose();
            contentSemaphoreSlim = null;

            messageCloseSemaphoreSlim?.Dispose();
            messageCloseSemaphoreSlim = null;

            contentCloseSemaphoreSlim?.Dispose();
            contentCloseSemaphoreSlim = null;
        }

        internal void Init()
        {
            messageSemaphoreSlim = new(1, 1);
            contentSemaphoreSlim = new(1, 1);
            messageCloseSemaphoreSlim = new(0, 1);
            contentCloseSemaphoreSlim = new(0, 1);
        }
    }
}
