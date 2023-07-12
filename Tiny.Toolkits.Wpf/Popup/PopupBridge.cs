using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
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
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal SemaphoreSlim visualSemaphoreSlim;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal SemaphoreSlim visualAnimationSemaphoreSlim;
        public AdornerLayer AdornerLayer { get; set; }

        public PopupAdorner PopupAdornet { get; set; }

        public bool IsLoaded { get; internal set; }

        private bool IsPopup;

        private int popupIndex = 0;

        public async Task DisplayVisualAsync()
        {

            await visualSemaphoreSlim.WaitAsync();

            Interlocked.Increment(ref popupIndex);

            if (IsPopup == false)
            {
                IsPopup = true;

                PopupAdornet.Opacity = 0.001;
                AdornerLayer.Add(PopupAdornet);

                PopupAdornet.WithDoubleAnimation()
                    .Property(x => x.Opacity)
                    .To(1)
                    .Duration(150)
                    .Complete(() => visualAnimationSemaphoreSlim.ReleaseWhenZero())
                    .BuildAnimation()
                    .Play();

                await visualAnimationSemaphoreSlim.WaitAsync();
            }

            visualSemaphoreSlim.Release(1);

        }

        public async Task CloseVisualAsync(Action closeCallback = null)
        {

            await visualSemaphoreSlim.WaitAsync();

            Interlocked.Decrement(ref popupIndex);

            if (popupIndex == 0 && IsPopup == true)
            {
                IsPopup = false;

                PopupAdornet.Opacity = 1;

                PopupAdornet.WithDoubleAnimation()
                    .Property(x => x.Opacity)
                    .To(0)
                    .Duration(150)
                    .Complete(() =>
                    {
                        AdornerLayer.Remove(PopupAdornet);
                        visualAnimationSemaphoreSlim.ReleaseWhenZero();
                        closeCallback?.Invoke();
                    })
                    .BuildAnimation()
                    .Play();

                await visualAnimationSemaphoreSlim.WaitAsync();
            }
            else
            {
                closeCallback?.Invoke();
            }

            visualSemaphoreSlim.ReleaseWhenZero();

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

            visualSemaphoreSlim?.Dispose();
            visualSemaphoreSlim = null;

            visualAnimationSemaphoreSlim?.Dispose();
            visualAnimationSemaphoreSlim = null;
        }

        internal void Init()
        {
            visualAnimationSemaphoreSlim = new SemaphoreSlim(0, 1);
            visualSemaphoreSlim = new(1, 1);
            messageSemaphoreSlim = new(1, 1);
            contentSemaphoreSlim = new(1, 1);
            messageCloseSemaphoreSlim = new(0, 1);
            contentCloseSemaphoreSlim = new(0, 1);
        }
    }

    internal static class extensions
    {
        /// <summary>
        /// release a <see cref="SemaphoreSlim"/> when <see cref="SemaphoreSlim.CurrentCount"/> == 0
        /// </summary>
        /// <param fieldName="semaphoreSlim"></param>
        /// <param fieldName="releaseCount"></param>
        public static void ReleaseWhenZero(this SemaphoreSlim semaphoreSlim, int releaseCount = 1)
        {
            if (semaphoreSlim is null || releaseCount < 1 || semaphoreSlim.CurrentCount != 0)
            {
                return;
            }
 
            semaphoreSlim.Release(releaseCount);

        }
    }
}
