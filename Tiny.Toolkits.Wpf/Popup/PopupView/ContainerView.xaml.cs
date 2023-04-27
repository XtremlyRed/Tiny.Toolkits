


using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tiny.Toolkits.Wpf.Popup.PopupView
{
    /// <summary>
    /// ContainerView.xaml 的交互逻辑
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerView : PopupViewBase
    {
        private string currentClickResult;
        private readonly object currentPopupResult;
        private readonly IPopupAware popupAware;
        private readonly Parameters parameters;
        private readonly Action popupContentCloseCallback;
        private readonly SemaphoreSlim messageSemaphoreSlim = new(0, 1);
        private readonly SemaphoreSlim contentSemaphoreSlim = new(0, 1);
        internal ContainerView()
        {
            InitializeComponent();
        }



        /// <summary> 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="buttonContents"></param>
        protected override void SetPopupMessageInfo(string message, string title, string[] buttonContents)
        {
            currentClickResult = null;
            TitleBox.Text = title;
            MessageBox.Text = message;

            ButtonBoxs.ItemsSource = buttonContents;

            if (buttonContents != null && buttonContents.Length > 0)
            {
                ButtonBoxs.Loaded += (s, e) =>
                {
                    Button bs = WpfAssist.FindVisualChildren<Button>(ButtonBoxs)?.FirstOrDefault(i => i.Content?.ToString() == buttonContents[0]);
                    if (bs is null)
                    {
                        return;
                    }
                    bs.Foreground = System.Windows.Media.Brushes.White;
                    bs.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 51, 119, 133));
                };
            }
        }

        /// <summary> 
        /// </summary>
        /// <returns></returns>
        protected override Panel GetPopupContentContainer()
        {
            return popupContainer;

        }

        /// <summary> 
        /// </summary>
        /// <returns></returns>
        protected override FrameworkElement GetPopupMessageContainer()
        {
            return messageContainer;
        }



        private void Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button brn)
            {
                return;
            }

            currentClickResult = brn.Content as string;


            base.SetCurrentClickContent(currentClickResult);
        }

        //internal async Task<object> WaitResultAsync(
        //  PopupType popupMessage,
        //    TimeSpan durationAnimation,
        //    Action animationCompleteCallback = null)
        //{

        //    if (popupMessage == PopupType.Message)
        //    {
        //        DisplayVisual(messageContainer, durationAnimation);
        //        await messageSemaphoreSlim.WaitAsync();
        //        RemoveVisual(messageContainer, durationAnimation, animationCompleteCallback);
        //        return currentClickResult;
        //    }

        //    DisplayVisual(popupContainer, durationAnimation);
        //    await contentSemaphoreSlim.WaitAsync();
        //    RemoveVisual(popupContainer, durationAnimation, () =>
        //    {
        //        popupContentCloseCallback?.Invoke();
        //        popupContainer?.Children?.Clear();
        //        animationCompleteCallback?.Invoke();
        //        popupAware?.OnPopupClosed();
        //    });

        //    return currentPopupResult;
        //}


        //private void RemoveVisual(FrameworkElement @object, TimeSpan durationAnimation, Action animationCompleteCallback = null)
        //{

        //    DoubleAnimation doubleAnimation = new();
        //    doubleAnimation.To = 0;
        //    doubleAnimation.Duration = durationAnimation;// TimeSpan.FromMilliseconds(200);
        //    Storyboard.SetTarget(doubleAnimation, @object);
        //    Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(nameof(FrameworkElement.Opacity)));

        //    Storyboard storyboard = new();
        //    storyboard.Children.Add(doubleAnimation);
        //    storyboard.Completed += (s, e) =>
        //    {
        //        @object.Visibility = Visibility.Collapsed;
        //        animationCompleteCallback?.Invoke();
        //    };
        //    storyboard.Begin();

        //}

        //private void DisplayVisual(FrameworkElement @object, TimeSpan durationAnimation)
        //{

        //    DoubleAnimation doubleAnimation = new();
        //    doubleAnimation.From = 0;
        //    doubleAnimation.To = 1;
        //    doubleAnimation.Duration = durationAnimation;
        //    Storyboard.SetTarget(doubleAnimation, @object);
        //    Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(nameof(FrameworkElement.Opacity)));

        //    Storyboard storyboard = new();
        //    storyboard.Children.Add(doubleAnimation);

        //    @object.Visibility = Visibility.Visible;

        //    storyboard.Begin();

        //}



        //internal void SetContent(FrameworkElement popupContent, Parameters parameters = null)
        //{
        //    popupContentCloseCallback = () =>
        //    {
        //        popupContent.DataContextChanged -= PopupContent_DataContextChanged;
        //        if (popupContent is IPopupAware popupAware)
        //        {
        //            popupAware.RequestCloseEvent -= PopupAware_RequestCloseEvent;
        //        }
        //        if (popupContent.DataContext is IPopupAware popupAware1)
        //        {
        //            popupAware1.RequestCloseEvent -= PopupAware_RequestCloseEvent;
        //        }
        //        popupContentCloseCallback = null;
        //    };
        //    this.parameters = parameters;
        //    popupContainer.Children.Add(popupContent);

        //    AwareCallback(popupContent);
        //    AwareCallback(popupContent.DataContext);

        //    popupContent.DataContextChanged += PopupContent_DataContextChanged;
        //}

        //private void PopupAware_RequestCloseEvent(object sender, object args)
        //{
        //    currentPopupResult = args;

        //    if (contentSemaphoreSlim.CurrentCount == 0)
        //    {
        //        contentSemaphoreSlim.Release();
        //    }
        //}


        //private void PopupContent_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (e.OldValue is IPopupAware popupAware)
        //    {
        //        popupAware.RequestCloseEvent -= PopupAware_RequestCloseEvent;
        //    }
        //    AwareCallback(e.NewValue);
        //}

        //private void AwareCallback(object @object)
        //{
        //    if (@object is not IPopupAware popupAware)
        //    {
        //        return;
        //    }
        //    this.popupAware = popupAware;
        //    this.popupAware.OnPopupOpened(parameters);
        //    popupAware.RequestCloseEvent += PopupAware_RequestCloseEvent;

        //}
    }
}
