

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

using Tiny.Toolkits.Wpf.Popup.PopupView;

namespace Tiny.Toolkits.Popup.Assist
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class PopupManagerAssist
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal static readonly bool[] displayed = new[] { false, false };
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly SemaphoreSlim messageSemaphoreSlim = new(1, 1);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly SemaphoreSlim contentSemaphoreSlim = new(1, 1);

        internal static async Task<string> InnerMesagePopup(UIElement uIElement, string message, string title, string[] buttonContents)
        {
            await messageSemaphoreSlim.WaitAsync();
            TimeSpan waitTimeSpan = TimeSpan.FromMilliseconds(300);

            string returnResult = await await uIElement.Dispatcher.InvokeAsync(async () =>
            {
                AdornerLayer adornerLayer = PropertyAttache.GetProperty0(uIElement) as AdornerLayer;

                PopupAdorner popupAdornet = PropertyAttache.GetProperty1(uIElement) as PopupAdorner;

                popupAdornet?.SetMessage(message, title, buttonContents);

                if (displayed.Aggregate(false, (s, e) => s || e) == false)
                {
                    adornerLayer.Add(popupAdornet);
                }
                string popupResult = await popupAdornet.WaitMessageResultAsync(PopupType.Message, waitTimeSpan, () =>
                {
                    if (displayed.Aggregate(false, (s, e) => s || e) == false)
                    {
                        adornerLayer.Remove(popupAdornet);
                    }
                });

                return popupResult;


            });

            await Task.Delay(waitTimeSpan.Add(TimeSpan.FromMilliseconds(50)));

            if (messageSemaphoreSlim.CurrentCount == 0)
            {
                messageSemaphoreSlim.Release();
            }

            return returnResult;
        }


        internal static async Task<object> InnerContentPopup(UIElement uIElement, FrameworkElement popupContent, Parameters parameters = null)
        {
            await contentSemaphoreSlim.WaitAsync();
            TimeSpan waitTimeSpan = TimeSpan.FromMilliseconds(300);

            object returnResult = await await uIElement.Dispatcher.InvokeAsync(async () =>
            {
                AdornerLayer adornerLayer = PropertyAttache.GetProperty0(uIElement) as AdornerLayer;

                PopupAdorner popupAdornet = PropertyAttache.GetProperty1(uIElement) as PopupAdorner;

                popupAdornet?.SetContent(popupContent, parameters);

                if (displayed.Aggregate(false, (s, e) => s || e) == false)
                {
                    adornerLayer.Add(popupAdornet);
                }
                object popupResult = await popupAdornet.WaitContentResultAsync(PopupType.Content, waitTimeSpan, () =>
                {
                    if (displayed.Aggregate(false, (s, e) => s || e) == false)
                    {
                        adornerLayer.Remove(popupAdornet);
                    }
                });

                return popupResult;

            });

            await Task.Delay(waitTimeSpan.Add(TimeSpan.FromMilliseconds(50)));

            if (contentSemaphoreSlim.CurrentCount == 0)
            {
                contentSemaphoreSlim.Release();
            }

            return returnResult;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal enum PopupType
    {
        Message,
        Content
    }


    [EditorBrowsable(EditorBrowsableState.Never)]

    internal class PopupAdorner : Adorner
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool isLoad;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly _________ContainerView containerView;
        public PopupAdorner(UIElement adornedElement) : base(adornedElement)
        {
            containerView = new _________ContainerView();
        }

        protected override int VisualChildrenCount => containerView != null ? 1 : 0;

        public void SetMaskBrush(Brush brush)
        {
            if (containerView != null)
            {
                containerView.Background = brush;
            }
        }

        public void SetMessage(string message, string title, string[] btnContents)
        {
            containerView.SetBtnContent(message, title, btnContents);
        }


        public async Task<string> WaitMessageResultAsync(
            PopupType popupType,
            TimeSpan durationAnimation,
            Action animationCompleteCallback = null)
        {

            if (isLoad == false)
            {
                AddVisualChild(containerView);
                isLoad = true;
            }

            PopupManagerAssist.displayed[popupType == PopupType.Message ? 0 : 1] = true;

            object result = await containerView.WaitResultAsync(popupType, durationAnimation, animationCompleteCallback);

            PopupManagerAssist.displayed[popupType == PopupType.Message ? 0 : 1] = false;

            return result as string;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            containerView?.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return
                index == 0 && containerView != null
                ? containerView
                : base.GetVisualChild(index);
        }

        internal void SetContent(FrameworkElement popupContent, Parameters parameters = null)
        {
            containerView.SetContent(popupContent, parameters);
        }

        internal async Task<object> WaitContentResultAsync(PopupType popupType, TimeSpan durationAnimation, Action animationCompleteCallback = null)
        {
            if (isLoad == false)
            {
                AddVisualChild(containerView);
                isLoad = true;
            }

            PopupManagerAssist.displayed[popupType == PopupType.Message ? 0 : 1] = true;

            object result = await containerView.WaitResultAsync(popupType, durationAnimation, animationCompleteCallback);

            PopupManagerAssist.displayed[popupType == PopupType.Message ? 0 : 1] = false;

            return result;
        }
    }
}
