

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace Tiny.Toolkits.Popup.Assist
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class PopupManagerAssist
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly TimeSpan waitTimeSpan = TimeSpan.FromMilliseconds(300);

        internal static async Task<string> InnerMessagePopup(UIElement uIElement, string message, string title, string[] buttonContents)
        {

            return await await uIElement.Dispatcher.InvokeAsync(async () =>
            {
                PopupBridge popupBridge = await PopupInitializeAsync(uIElement);

                await popupBridge.messageSemaphoreSlim.WaitAsync();

                popupBridge.PopupAdornet?.SetMessage(message, title, buttonContents);

                string popupResult = await popupBridge.PopupAdornet?.WaitMessageResultAsync(waitTimeSpan, async () =>
                {
                    await popupBridge.CloseVisualAsync(() => popupBridge.messageCloseSemaphoreSlim.ReleaseWhenZero());

                    popupBridge.messageSemaphoreSlim.ReleaseWhenZero();
                });

                await popupBridge.messageCloseSemaphoreSlim.WaitAsync();

                return popupResult;

            });

        }



        internal static async Task<object> InnerContentPopup(UIElement uIElement, FrameworkElement popupContent, Parameters parameters = null)
        {
            return await await uIElement.Dispatcher.InvokeAsync(async () =>
            {
                PopupBridge popupBridge = await PopupInitializeAsync(uIElement);

                await popupBridge.contentSemaphoreSlim.WaitAsync();

                popupBridge.PopupAdornet?.SetContent(popupContent, parameters);

                object popupResult = await popupBridge.PopupAdornet?.WaitContentResultAsync(waitTimeSpan, async () =>
                {
                    await popupBridge.CloseVisualAsync(() => popupBridge.contentCloseSemaphoreSlim.ReleaseWhenZero());

                    popupBridge.contentSemaphoreSlim.ReleaseWhenZero();

                });

                await popupBridge.contentCloseSemaphoreSlim.WaitAsync();

                return popupResult;

            });

        }

        private static async Task<PopupBridge> PopupInitializeAsync(UIElement uIElement)
        {
            PopupBridge popupBridge = PropertyAttache.GetProperty0(uIElement) as PopupBridge;

            if (popupBridge.IsLoaded == false)
            {
                string containerName = PopupManager.GetContainerName(uIElement);

                throw new Exception($"the popup:{containerName} not loaded");
            }

            await popupBridge.DisplayVisualAsync();

            return popupBridge;
        }



        internal static async Task<int> InnerTipPopup(UIElement uieleMent, string message, string title, int displayTimeSpan_Ms)
        {
            return await await uieleMent.Dispatcher.InvokeAsync(async () =>
            {
                PopupBridge popupBridge = await PopupInitializeAsync(uieleMent);

                TimeSpan timeSpan = displayTimeSpan_Ms < 0 ? TimeSpan.Zero : TimeSpan.FromMilliseconds(displayTimeSpan_Ms);

                popupBridge.PopupAdornet?.SetTipContent(message, title, waitTimeSpan, timeSpan);

                return 1;

            });
        }
    }
}
