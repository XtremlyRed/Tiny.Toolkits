

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

using BF = System.Reflection.BindingFlags;
namespace Tiny.Toolkits.Popup.Assist
{
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



        public async Task<string> WaitMessageResultAsync(TimeSpan durationAnimation, Action popupCloseCallback = null)
        {

            AddChild();

            string result = await popupView.WaitMessageResultAsync(durationAnimation, popupCloseCallback);

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

        internal void SetTipContent(string message,string title,  TimeSpan durationAnimation, TimeSpan displayTimeSpan)
        {
            popupView.SetTipContent( message,title, durationAnimation, displayTimeSpan);
        }


        internal async Task<object> WaitContentResultAsync(TimeSpan durationAnimation, Action popupCloseCallback = null)
        {

            AddChild();

            object result = await popupView.WaitContentResultAsync(durationAnimation, popupCloseCallback);

            return result;
        }


        internal void ContainerSizeChanged(object sender, SizeChangedEventArgs e)
        {
            popupView.InnerContainerSizeChanged(e.NewSize);
        }

        internal void InitSize(Size renderSize)
        {
            popupView.InnerContainerSizeChanged(renderSize);
        }

        private void AddChild()
        {
            if (isLoad == false)
            {
                AddVisualChild(popupView);
                isLoad = true;
            }

        }

    }
}
