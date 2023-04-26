


using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

using Tiny.Toolkits.Popup.Assist;

namespace Tiny.Toolkits.Wpf.Popup.PopupView
{
    /// <summary>
    /// _________ContainerView.xaml 的交互逻辑
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class _________ContainerView : UserControl
    {
        private object currentClickResult, currentPopupResult;
        private IPopupAware popupAware;
        private Parameters parameters;
        private Action popupContentCloseCallback;
        private readonly SemaphoreSlim messageSemaphoreSlim = new(0, 1);
        private readonly SemaphoreSlim contentSemaphoreSlim = new(0, 1);
        internal _________ContainerView()
        {
            InitializeComponent();
        }



        internal void SetBtnContent(string message, string title, string[] contents)
        {
            currentClickResult = null;
            TitleBox.Text = title;
            MessageBox.Text = message;

            ButtonBoxs.ItemsSource = contents;
        }

        internal async Task<object> WaitResultAsync(
          PopupType popupMessage,
            TimeSpan durationAnimation,
            Action animationCompleteCallback = null)
        {

            if (popupMessage == PopupType.Message)
            {
                DisplayVisual(messageContainer, durationAnimation);
                await messageSemaphoreSlim.WaitAsync();
                RemoveVisual(messageContainer, durationAnimation, animationCompleteCallback);
                return currentClickResult;
            }

            DisplayVisual(popupContainer, durationAnimation);
            await contentSemaphoreSlim.WaitAsync();
            RemoveVisual(popupContainer, durationAnimation, () =>
            {
                popupContentCloseCallback?.Invoke();
                popupContainer?.Children?.Clear();
                animationCompleteCallback?.Invoke();
                popupAware?.OnPopupClosed();
            });

            return currentPopupResult;
        }


        private void RemoveVisual(FrameworkElement @object, TimeSpan durationAnimation, Action animationCompleteCallback = null)
        {

            DoubleAnimation doubleAnimation = new();
            doubleAnimation.To = 0;
            doubleAnimation.Duration = durationAnimation;// TimeSpan.FromMilliseconds(200);
            Storyboard.SetTarget(doubleAnimation, @object);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(nameof(FrameworkElement.Opacity)));

            Storyboard storyboard = new();
            storyboard.Children.Add(doubleAnimation);
            storyboard.Completed += (s, e) =>
            {
                @object.Visibility = Visibility.Collapsed;
                animationCompleteCallback?.Invoke();
            };
            storyboard.Begin();

        }

        private void DisplayVisual(FrameworkElement @object, TimeSpan durationAnimation)
        {

            DoubleAnimation doubleAnimation = new();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = durationAnimation;
            Storyboard.SetTarget(doubleAnimation, @object);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(nameof(FrameworkElement.Opacity)));

            Storyboard storyboard = new();
            storyboard.Children.Add(doubleAnimation);

            @object.Visibility = Visibility.Visible;

            storyboard.Begin();

        }



        private void Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button brn)
            {
                return;
            }

            currentClickResult = brn.Content as string;

            if (messageSemaphoreSlim.CurrentCount == 0)
            {
                messageSemaphoreSlim.Release(1);
            }
        }

        internal void SetContent(FrameworkElement popupContent, Parameters parameters = null)
        {
            popupContentCloseCallback = () =>
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
            this.parameters = parameters;
            popupContainer.Children.Add(popupContent);

            AwareCallback(popupContent);
            AwareCallback(popupContent.DataContext);

            popupContent.DataContextChanged += PopupContent_DataContextChanged;
        }

        private void PopupAware_RequestCloseEvent(object sender, object args)
        {
            currentPopupResult = args;

            if (contentSemaphoreSlim.CurrentCount == 0)
            {
                contentSemaphoreSlim.Release();
            }
        }


        private void PopupContent_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is IPopupAware popupAware)
            {
                popupAware.RequestCloseEvent -= PopupAware_RequestCloseEvent;
            }
            AwareCallback(e.NewValue);
        }

        private void AwareCallback(object @object)
        {
            if (@object is not IPopupAware popupAware)
            {
                return;
            }
            this.popupAware = popupAware;
            this.popupAware.OnPopupOpened(parameters);
            popupAware.RequestCloseEvent += PopupAware_RequestCloseEvent;

        }
    }
}
