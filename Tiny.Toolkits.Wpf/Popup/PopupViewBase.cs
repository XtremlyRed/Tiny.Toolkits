﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Tiny.Toolkits.Wpf.Popup.PopupView;

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
        protected abstract Grid GetPopupContentContainer();

        /// <summary>
        /// Obtain container elements for pop-up message boxes
        /// </summary>
        /// <returns></returns>
        protected abstract FrameworkElement GetPopupMessageContainer();


        ///// <summary>
        ///// get side information popup boxes
        ///// </summary>
        ///// <returns></returns>
        //protected abstract StackPanel GetTipMessageContainer();


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


        //private StackPanel GetPopupTipContainerElement()
        //{
        //    StackPanel contentPanel = GetTipMessageContainer();
        //    if (contentPanel == null)
        //    {
        //        throw new ArgumentNullException(nameof(contentPanel));
        //    } 
        //    contentPanel.HorizontalAlignment = HorizontalAlignment.Right;
        //    contentPanel.VerticalAlignment = VerticalAlignment.Top; 
        //    Panel.SetZIndex(contentPanel, int.MaxValue - 2); 
        //    return contentPanel; 
        //}


        internal void SetTipContent(string message, string title, TimeSpan durationAnimation, TimeSpan displayTimeSpan)
        {
            //StackPanel messageContainer = GetPopupTipContainerElement();
            //messageContainer.Visibility = Visibility.Visible; 
            //TipView tip = new();
            //tip.SetContent(title, message);
            //messageContainer.Children.Add(tip); 
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

            AnimationAssist.PlayAnimations(new[] { opacityPlayer, visibilityPlayer }, () => popupCloseCallback?.Invoke());


        }


        private void DisplayVisual(FrameworkElement @object, TimeSpan durationAnimation)
        {

            IAnimationPlayer opacityPlayer = @object.WithDoubleAnimation()
                .Property(i => i.Opacity)
                .From(0.001)
                .To(1)
                .Duration(durationAnimation)
                .BuildAnimation();

            IAnimationPlayer visibilityPlayer = @object.WithObjectKeyFrameAnimation()
                .Property(i => i.Visibility)
                .Add(Visibility.Visible, TimeSpan.FromMilliseconds(0))
                .BuildAnimation();

            AnimationAssist.PlayAnimations(opacityPlayer, visibilityPlayer);

        }

        internal void InitializeView()
        {
            FrameworkElement element = GetPopupMessageContainerElement();
            element.Visibility = Visibility.Collapsed;

            Panel element2 = GetPopupContentContainerElement();
            element2.Visibility = Visibility.Collapsed;
        }


        internal void InnerContainerSizeChanged(Size size)
        {
            ContainerSizeChanged(size);
        }

        /// <summary>
        /// when container size changed 
        /// </summary>
        /// <param name="size">current size</param>
        protected virtual void ContainerSizeChanged(Size size)
        {

        }
    }
}
