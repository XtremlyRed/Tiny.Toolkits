

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

        internal static async Task<string> InnerMesagePopup(UIElement uIElement, string message, string title, string[] buttonContents)
        {

            return await await uIElement.Dispatcher.InvokeAsync(async () =>
            {
                PopupBridge popupBridge = PropertyAttache.GetProperty0(uIElement) as PopupBridge;

                if (popupBridge.IsLoaded == false)
                {
                    string containerName = PopupManager.GetContainerName(uIElement);

                    throw new Exception($"the popup:{containerName} is not loaded");
                }

                popupBridge.DisplayVisual();

                await popupBridge.messageSemaphoreSlim.WaitAsync();

                popupBridge.PopupAdornet?.SetMessage(message, title, buttonContents);

                string popupResult = await popupBridge.PopupAdornet?.WaitMessageResultAsync(waitTimeSpan, () =>
                {
                    popupBridge.CloseVisual();

                    popupBridge.messageCloseSemaphoreSlim.ReleaseWhenZero();
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
                PopupBridge popupBridge = PropertyAttache.GetProperty0(uIElement) as PopupBridge;

                if (popupBridge.IsLoaded == false)
                {
                    string containerName = PopupManager.GetContainerName(uIElement);

                    throw new Exception($"the popup:{containerName} is not loaded");
                }

                popupBridge.DisplayVisual();

                await popupBridge.contentSemaphoreSlim.WaitAsync();

                popupBridge.PopupAdornet?.SetContent(popupContent, parameters);

                object popupResult = await popupBridge.PopupAdornet?.WaitContentResultAsync(waitTimeSpan, () =>
                {
                    popupBridge.CloseVisual();

                    popupBridge.contentCloseSemaphoreSlim.ReleaseWhenZero();

                    popupBridge.contentSemaphoreSlim.ReleaseWhenZero();

                });

                await popupBridge.contentCloseSemaphoreSlim.WaitAsync();

                return popupResult;

            });

        }
    }
}
