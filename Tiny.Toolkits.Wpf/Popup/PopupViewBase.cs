using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>
    /// The base class for all popup views.
    /// </summary>
    public abstract class PopupViewBase : UserControl
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private object currentPopupResult;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IPopupAware popupAware;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Parameters parameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Action popupContentCloseCallback;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly SemaphoreSlim messageSemaphoreSlim = new(0, 1);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly SemaphoreSlim contentSemaphoreSlim = new(0, 1);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private string[] buttonContents;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private string currentClickResult;

        /// <summary>
        /// Set pop-up information, title, and button content
        /// </summary>
        /// <param name="message">Popup message</param>
        /// <param name="title">Popup Title</param>
        /// <param name="buttonContents">Popup Button Contents</param>
        protected abstract void SetPopupMessageInfo(string message, string title, string[] buttonContents);

        /// <summary>
        /// Container panel for obtaining pop-up box content
        /// </summary>
        /// <returns></returns>
        protected abstract Panel GetPopupContentContainer();

        /// <summary>
        /// Obtain container elements for pop-up message boxes
        /// </summary>
        /// <returns></returns>
        protected abstract FrameworkElement GetPopupMessageContainer();


        internal void SetMessageInfo(string message, string title, string[] buttonContents)
        {
            this.buttonContents = buttonContents;
            SetPopupMessageInfo(message, title, buttonContents);
        }


        private FrameworkElement GetPopupMessageContainerElement()
        {
            FrameworkElement messageContainer = GetPopupMessageContainer();
            if (messageContainer == null)
            {
                throw new ArgumentNullException(nameof(messageContainer));
            }

            Panel.SetZIndex(messageContainer, int.MaxValue);
            return messageContainer;
        }


        private Panel GetPopupContentContainerElement()
        {
            Panel contentPanel = GetPopupContentContainer();
            if (contentPanel == null)
            {
                throw new ArgumentNullException(nameof(contentPanel));
            }

            Panel.SetZIndex(contentPanel, int.MaxValue - 1);

            return contentPanel;
        }


        internal async Task<string> WaitMessageResultAsync(TimeSpan durationAnimation, Action popupCloseCallback = null)
        {
            FrameworkElement messageContainer = GetPopupMessageContainerElement();

            DisplayVisual(messageContainer, durationAnimation);
            await messageSemaphoreSlim.WaitAsync();
            RemoveVisual(messageContainer, durationAnimation, popupCloseCallback);
            return currentClickResult;
        }


        /// <summary> 
        /// Set the content of the currently clicked button,
        /// which must be set through the parameter <c>buttonContents</c> of method <see cref="SetPopupMessageInfo"/>
        /// </summary>
        /// <param name="currentClickContent"></param>
        protected void SetCurrentClickContent(string currentClickContent)
        {
            if (currentClickContent is null)
            {
                throw new ArgumentNullException(nameof(currentClickContent));
            }

            if (buttonContents != null)
            {
                if (buttonContents.Contains(currentClickContent) == false)
                {
                    throw new InvalidOperationException($"invalid parameter :{currentClickContent}");
                }
            }

            currentClickResult = currentClickContent;

            if (messageSemaphoreSlim.CurrentCount == 0)
            {
                messageSemaphoreSlim.Release(1);
            }
        }

        internal async Task<object> WaitContentResultAsync(TimeSpan durationAnimation, Action popupCloseCallback = null)
        {
            Panel popupContainer = GetPopupContentContainerElement();

            DisplayVisual(popupContainer, durationAnimation);
            await contentSemaphoreSlim.WaitAsync();
            RemoveVisual(popupContainer, durationAnimation, () =>
            {
                popupContentCloseCallback?.Invoke();
                popupContainer?.Children?.Clear();
                popupCloseCallback?.Invoke();
                popupAware?.OnPopupClosed();
            });

            return currentPopupResult;
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

            Panel popupContainer = GetPopupContentContainerElement();

            popupContainer.Children.Clear();
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











        private void RemoveVisual(FrameworkElement @object, TimeSpan durationAnimation, Action popupCloseCallback = null)
        {
            DoubleAnimation doubleAnimation = new();
            doubleAnimation.To = 0;
            doubleAnimation.Duration = durationAnimation.Add(TimeSpan.FromMilliseconds(100));
            Storyboard.SetTarget(doubleAnimation, @object);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(nameof(FrameworkElement.Opacity)));

            Storyboard storyboard = new();
            storyboard.Children.Add(doubleAnimation);
            storyboard.Completed += (s, e) =>
            {
                @object.Visibility = Visibility.Collapsed;
                popupCloseCallback?.Invoke();
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

        internal void InitializeView()
        {
            FrameworkElement element = GetPopupMessageContainerElement();
            element.Visibility = Visibility.Collapsed;

            Panel element2 = GetPopupContentContainerElement();
            element2.Visibility = Visibility.Collapsed;
        }
    }
}
