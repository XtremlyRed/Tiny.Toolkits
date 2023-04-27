

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

using BF = System.Reflection.BindingFlags;
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
                string popupResult = await popupAdornet.WaitMessageResultAsync(waitTimeSpan, () =>
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
                object popupResult = await popupAdornet.WaitContentResultAsync(waitTimeSpan, () =>
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
    internal class PopupAdorner : Adorner
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool isLoad;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly PopupViewBase popupView;
        public PopupAdorner(Type messageContainerType, UIElement adornedElement) : base(adornedElement)
        {
            System.Reflection.ConstructorInfo[] cs = messageContainerType.GetConstructors(BF.Instance | BF.Public | BF.NonPublic);

            popupView = cs.FirstOrDefault()?.Invoke(null) as PopupViewBase;

            popupView.InitializeView();
        }

        protected override int VisualChildrenCount => popupView != null ? 1 : 0;

        public void SetMaskBrush(Brush brush)
        {
            if (popupView != null)
            {
                popupView.Background = brush;
            }
        }

        public void SetMessage(string message, string title, string[] btnContents)
        {
            popupView.SetMessageInfo(message, title, btnContents);
        }


        public async Task<string> WaitMessageResultAsync(
            TimeSpan durationAnimation,
            Action popupCloseCallback = null)
        {

            if (isLoad == false)
            {
                AddVisualChild(popupView);
                isLoad = true;
            }

            PopupManagerAssist.displayed[0] = true;

            string result = await popupView.WaitMessageResultAsync(durationAnimation, popupCloseCallback);

            PopupManagerAssist.displayed[0] = false;

            return result;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            popupView?.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return
                index == 0 && popupView != null
                ? popupView
                : base.GetVisualChild(index);
        }

        internal void SetContent(FrameworkElement popupContent, Parameters parameters = null)
        {
            popupView.SetContent(popupContent, parameters);
        }

        internal async Task<object> WaitContentResultAsync(
            TimeSpan durationAnimation,
            Action popupCloseCallback = null)
        {
            if (isLoad == false)
            {
                AddVisualChild(popupView);
                isLoad = true;
            }

            PopupManagerAssist.displayed[1] = true;

            object result = await popupView.WaitContentResultAsync(durationAnimation, popupCloseCallback);

            PopupManagerAssist.displayed[1] = false;

            return result;
        }
    }
}
