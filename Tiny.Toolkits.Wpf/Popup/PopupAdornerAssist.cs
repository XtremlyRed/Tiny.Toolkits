using System;
using System.Windows;

namespace Tiny.Toolkits.Popup.Assist
{
    internal static class PopupAdornerAssist
    {
        internal static void  SetToast(this PopupAdorner popupAdorner, int toastIndex, FrameworkElement popupContent)
        {
            popupAdorner.toastContainer.Children.Add(popupContent);
        }

        internal static Action SetContent(this PopupAdorner popupAdorner, int contentIndex, FrameworkElement popupContent, Parameters parameters = null)
        {

            Action popupContentCloseCallback = () =>
            {
                popupContent.DataContextChanged -= PopupContent_DataContextChanged;
                if (popupContent is IPopupAware popupAware)
                {
                    popupAware.RequestCloseEvent -= PopupAware_RequestCloseEvent;
                }
                if (popupContent.DataContext is IPopupAware popupAware1)
                {
                    popupAware1.RequestCloseEvent -= PopupAware_RequestCloseEvent;
                }
                popupContentCloseCallback = null;
            };

            popupAdorner.contentContainer.Children.Clear();
            popupAdorner.contentContainer.Children.Add(popupContent);

            AwareCallback(popupContent);
            AwareCallback(popupContent.DataContext);

            popupContent.DataContextChanged += PopupContent_DataContextChanged;


            return popupContentCloseCallback;

            void PopupAware_RequestCloseEvent(object sender, object args)
            {
                popupAdorner.contentResult = args;

                if (popupAdorner.InteropsemaphoreSlims[contentIndex].CurrentCount == 0)
                {
                    popupAdorner.InteropsemaphoreSlims[contentIndex].Release();
                }
            }
            void PopupContent_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (e.OldValue is IPopupAware popupAware)
                {
                    popupAware.RequestCloseEvent -= PopupAware_RequestCloseEvent;
                }
                AwareCallback(e.NewValue);
            }

            void AwareCallback(object @object)
            {
                if (@object is not IPopupAware popupAware)
                {
                    return;
                }

                popupAware.OnPopupOpened(parameters);
                popupAware.RequestCloseEvent += PopupAware_RequestCloseEvent;

            }
        }
         
        public static void ShowContainer(this PopupAdorner popupAdorner, FrameworkElement visual, int index, TimeSpan durationAnimation)
        {
            if (popupAdorner.shown[index])
            {
                return;
            }
            popupAdorner.shown[index] = true;

            DisplayVisual(visual, durationAnimation);
        }
         
        public static void HideContainer(this PopupAdorner popupAdorner, FrameworkElement visual, int index, TimeSpan durationAnimation, Action action = null)
        { 
            if (index == PopupManagerAssist.MessageIndex)
            {
                popupAdorner.messageCounter--;

                if (popupAdorner.shown[index] == false)
                {
                    return;
                }

                if (popupAdorner.messageCounter != 0)
                {
                    action?.Invoke();
                    return;
                }

                popupAdorner.shown[index] = false;

            }
            else if (index == PopupManagerAssist.ContentIndex)
            {
                popupAdorner.contentCounter--;

                if (popupAdorner.shown[index] == false)
                {
                    return;
                }

                if (popupAdorner.contentCounter != 0)
                {
                    action?.Invoke();
                    return;
                }
                popupAdorner.shown[index] = false;

            }
            else if (index == PopupManagerAssist.ToastIndex)
            {
                popupAdorner.toastCounter--;

                if (popupAdorner.shown[index] == false || popupAdorner.toastCounter != 0)
                {
                    return;
                }
              
                popupAdorner.shown[index] = false;
                action?.Invoke();
            }


            RemoveVisual(visual, durationAnimation, action);
        }

        private static void DisplayVisual(FrameworkElement @object, TimeSpan durationAnimation)
        {

            IAnimationPlayer opacityPlayer = @object.WithDoubleAnimation()
                .Property(i => i.Opacity)
                .From(0.001)
                .To(1)
                .Duration(durationAnimation)
                .BuildAnimation();

            IAnimationPlayer visibilityPlayer = @object.WithObjectKeyFrameAnimation()
                .Property(i => i.Visibility)
                .Add(Visibility.Visible, TimeSpan.FromMilliseconds(01))
                .BuildAnimation();

            AnimationAssist.PlayAnimations(opacityPlayer, visibilityPlayer);

        }

        private static void RemoveVisual(FrameworkElement @object, TimeSpan durationAnimation, Action popupCloseCallback = null)
        {
            TimeSpan duration = durationAnimation.Add(TimeSpan.FromMilliseconds(100));


            IAnimationPlayer opacityPlayer = @object.WithDoubleAnimation()
                .Property(i => i.Opacity)
                .From(1)
                .To(0)
                .Duration(duration)
                .BuildAnimation();

            IAnimationPlayer visibilityPlayer = @object.WithObjectKeyFrameAnimation()
                .Property(i => i.Visibility)
                .BeginTime(duration)
                .Add(Visibility.Collapsed, TimeSpan.FromMilliseconds(10))
                .BuildAnimation();


            new[] { opacityPlayer, visibilityPlayer }.PlayAnimations(() => popupCloseCallback?.Invoke());


        }
    }
}
