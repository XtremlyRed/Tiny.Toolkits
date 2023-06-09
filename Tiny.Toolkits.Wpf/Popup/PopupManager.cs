﻿


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

using Tiny.Toolkits.Popup.Assist;

namespace Tiny.Toolkits
{
    /// <summary>
    /// a class of <see cref="PopupManager"/>
    /// </summary>
    public class PopupManager : IPopupManager
    {

        /// <summary>
        /// all elements that can be popup container
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly List<UIElement> uiElements = new();


        /// <summary>
        ///  display tips with <paramref name="message"/>,<paramref name="title"/>, in container right
        /// </summary>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>    
        /// <param name="parameters"></param>
        /// <param name="displayTime_Ms"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ToastAsync(string title,string message,  int displayTime_Ms = -1, params object[] parameters)
        {
            PopupContainerCheck();
            UIElement uieleMent = await uiElements[0].Dispatcher.InvokeAsync(() => uiElements.FirstOrDefault(i => GetIsMainContainer(i) && GetContainerName(i) != null));

            if (uieleMent is null)
            {
                throw new Exception("PopupManager: the main container was not found or the main container name is empty");
            }

            await PopupManagerAssist.InnerTipPopup(uieleMent,title, message,  displayTime_Ms, parameters);
        }


        /// <summary>
        ///  display tips with <paramref name="message"/>,<paramref name="title"/>, in container right
        /// </summary>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>    
        /// <param name="parameters"></param>
        /// <param name="displayTime_Ms"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ToastAsync(string containerName, string title,string message,  int displayTime_Ms = -1, params object[] parameters)
        {
            PopupContainerCheck();
            UIElement uieleMent = await uiElements[0].Dispatcher.InvokeAsync(() => uiElements.FirstOrDefault(i => GetContainerName(i) == containerName));
            if (uieleMent is null)
            {
                throw new Exception($"PopupManager: No popup container named:{containerName}");
            }

            await PopupManagerAssist.InnerTipPopup(uieleMent,title, message,  displayTime_Ms, parameters);
        }



        /// <summary>
        /// show message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/>,
        /// when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true
        /// </summary>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <returns></returns>
        public async Task ShowAsync(string message, string title, string[] buttonContents)
        {
            PopupContainerCheck();
            UIElement uieleMent = await uiElements[0].Dispatcher.InvokeAsync(() => uiElements.FirstOrDefault(i => GetIsMainContainer(i) && GetContainerName(i) != null));

            _ = uieleMent is null
              ? throw new Exception("PopupManager: the main container was not found or the main container name is empty")
              : await PopupManagerAssist.InnerMessagePopup(uieleMent, message, title, buttonContents);
        }
        /// <summary>
        /// comfirm message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/>
        /// when using, there must be a popup container with the <code><see cref="PopupManager.IsMainContainerProperty"/></code>  attribute set to true
        /// </summary>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <returns>the content of a clicked button</returns>
        public async Task<string> ComfirmAsync(string message, string title, string[] buttonContents)
        {
            PopupContainerCheck();
            UIElement uieleMent = await uiElements[0].Dispatcher.InvokeAsync(() => uiElements.FirstOrDefault(i => GetIsMainContainer(i) && GetContainerName(i) != null));

            return uieleMent is null
                ? throw new Exception("PopupManager: the main container was not found or the main container name is empty")
                : await PopupManagerAssist.InnerMessagePopup(uieleMent, message, title, buttonContents);
        }

        /// <summary>
        /// 
        /// when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true
        /// </summary>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <param name="clickChecker">for determining the click on the content of the clicked button (see parameter: <paramref name="buttonContents"/>).</param>
        /// <returns></returns>
        public async Task<bool> ComfirmAsync(string message, string title, string[] buttonContents, Func<string, bool> clickChecker)
        {
            PopupContainerCheck();
            string result = await ComfirmAsync(message, title, buttonContents);
            return clickChecker(result);
        }


        /// <summary>
        /// show message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/> from <paramref name="containerName"/>
        /// </summary>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <returns></returns>
        public async Task ShowAsync(string containerName, string message, string title, string[] buttonContents)
        {
            PopupContainerCheck();
            UIElement uieleMent = await uiElements[0].Dispatcher.InvokeAsync(() => uiElements.FirstOrDefault(i => GetContainerName(i) == containerName));
            _ = uieleMent is null
                  ? throw new Exception($"PopupManager: No popup container named:{containerName}")
                  : await PopupManagerAssist.InnerMessagePopup(uieleMent, message, title, buttonContents);
        }


        /// <summary>
        /// comfirm message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/> from <paramref name="containerName"/>
        /// </summary>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <returns></returns>
        public async Task<string> ComfirmAsync(string containerName, string message, string title, string[] buttonContents)
        {
            PopupContainerCheck();
            UIElement uieleMent = await uiElements[0].Dispatcher.InvokeAsync(() => uiElements.FirstOrDefault(i => GetContainerName(i) == containerName));
            return uieleMent is null
                   ? throw new Exception($"PopupManager: No popup container named:{containerName}")
                   : await PopupManagerAssist.InnerMessagePopup(uieleMent, message, title, buttonContents);
        }
        /// <summary>
        /// comfirm message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/> from <paramref name="containerName"/>
        /// </summary>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <param name="clickChecker">for determining the click on the content of the clicked button (see parameter: <paramref name="buttonContents"/>).</param>
        /// <returns></returns>
        public async Task<bool> ComfirmAsync(string containerName, string message, string title, string[] buttonContents, Func<string, bool> clickChecker)
        {
            PopupContainerCheck();
            string result = await ComfirmAsync(containerName, message, title, buttonContents);
            return clickChecker(result);
        }

        /// <summary>
        /// <para> popup view with <paramref name="parameters"/> from  main container</para>
        /// <para> when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true</para>
        /// <para> The <paramref name="view"/> type or the view model type bound to it must inherit from <see cref="IPopupAware"/> to obtain support for closing popup</para>
        /// </summary>
        /// <typeparam name="TView">view type</typeparam>
        /// <param name="view">view</param>
        /// <param name="parameters">parameters</param>
        /// <returns></returns>
        public async Task<object> PopupAsync<TView>(TView view, Parameters parameters = null) where TView : FrameworkElement
        {
            PopupContainerCheck();

            return view is null
                ? throw new ArgumentException("invalid visual")
                : (await uiElements[0].Dispatcher.InvokeAsync(() => uiElements.FirstOrDefault(i => GetIsMainContainer(i) && GetContainerName(i) != null))) is not UIElement uieleMent
                ? throw new Exception("PopupManager: the main container was not found or the main container name is empty")
                : await PopupManagerAssist.InnerContentPopup(uieleMent, view, parameters);
        }
        /// <summary> 
        /// <para> popup view with <paramref name="parameters"/> from  main container</para>
        /// <para> when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true</para>
        /// <para> The <typeparamref name="TView"/> type or the view model type bound to it must inherit from <see cref="IPopupAware"/> to obtain support for closing popup</para>
        /// </summary>
        /// <typeparam name="TView">view type</typeparam>
        /// <param name="viewCreator">view creator</param>
        /// <param name="parameters">parameters</param>
        /// <returns></returns>
        public async Task<object> PopupAsync<TView>(Func<TView> viewCreator, Parameters parameters = null) where TView : FrameworkElement
        {
            PopupContainerCheck();

            return viewCreator is null
                ? throw new ArgumentNullException(nameof(viewCreator))
                : (await uiElements[0].Dispatcher.InvokeAsync(() => viewCreator())) is not TView view
                ? throw new ArgumentException("invalid visual")
                : await PopupAsync(view, parameters);

        }

        /// <summary>
        /// popup view with <paramref name="parameters"/> from <paramref name="containerName"/> 
        /// <para> when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true</para>
        /// <para> The <paramref name="view"/> type or the view model type bound to it must inherit from <see cref="IPopupAware"/> to obtain support for closing popup</para>
        /// </summary>
        /// <typeparam name="TView">view type</typeparam>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="view">view</param>
        /// <param name="parameters">parameters</param>
        /// <returns></returns>
        public async Task<object> PopupAsync<TView>(string containerName, TView view, Parameters parameters = null) where TView : FrameworkElement
        {
            PopupContainerCheck();

            return view is null
                ? throw new ArgumentException("invalid visual")
                : (await uiElements[0].Dispatcher.InvokeAsync(() => uiElements.FirstOrDefault(i => GetContainerName(i) == containerName))) is not UIElement uieleMent
                ? throw new Exception("PopupManager: No popup main container found.")
                : await PopupManagerAssist.InnerContentPopup(uieleMent, view, parameters);


        }
        /// <summary>
        /// popup view with <paramref name="parameters"/> from <paramref name="containerName"/> 
        /// <para> when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true</para>
        /// <para> The <typeparamref name="TView"/>  type or the view model type bound to it must inherit from <see cref="IPopupAware"/> to obtain support for closing popup</para>
        /// </summary>
        /// <typeparam name="TView">view type</typeparam>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="viewCreator">view creator</param>
        /// <param name="parameters">parameters</param>
        /// <returns></returns>
        public async Task<object> PopupAsync<TView>(string containerName, Func<TView> viewCreator, Parameters parameters = null) where TView : FrameworkElement
        {
            PopupContainerCheck();

            return viewCreator is null
                ? throw new ArgumentNullException(nameof(viewCreator))
                : (await uiElements[0].Dispatcher.InvokeAsync(() => viewCreator())) is not TView view
                ? throw new ArgumentException("invalid visual")
                : await PopupAsync(containerName, view, parameters);
        }




        private void PopupContainerCheck()
        {
            if (uiElements.Count == 0)
            {
                throw new Exception("PopupManager: No popup container found.");
            }
        }

        #region  popup container name

        /// <summary>
        /// get popup container name
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetContainerName(DependencyObject element)
        {
            return element.GetValue(ContainerNameProperty) as string;
        }

        /// <summary>
        /// set popup container name
        /// </summary>
        /// <param name="element"></param>
        /// <param name="popupContainerName"></param>
        public static void SetContainerName(DependencyObject element, string popupContainerName)
        {
            element.SetValue(ContainerNameProperty, popupContainerName);
        }

        /// <summary>
        /// popup container name
        /// </summary>
        public static readonly DependencyProperty ContainerNameProperty =
            DependencyProperty.RegisterAttached("ContainerName", typeof(string), typeof(PopupManager),
                new FrameworkPropertyMetadata(Guid.NewGuid().ToString(), (s, e) =>
                {
                    if (s is FrameworkElement element)
                    {
                        if (element.IsLoaded)
                        {
                            CreateAdorner(element, e.NewValue as string);
                        }
                        element.Loaded += Element_Loaded;
                        element.Unloaded += Element_Unloaded;
                    }

                    static void Element_Unloaded(object sender, RoutedEventArgs e)
                    {
                        if (sender is FrameworkElement element)
                        {
                            if (uiElements.Contains(element))
                            {
                                if (GetPopupAdornerContainer(element) is PopupAdorner popupBridge)
                                {
                                    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(element);
                                    adornerLayer?.Remove(popupBridge);
                                }

                                uiElements.Remove(element);

                            }
                        }
                    }

                    static void Element_Loaded(object sender, RoutedEventArgs e)
                    {
                        if (sender is FrameworkElement element)
                        {
                            if (uiElements.Contains(element))
                            {
                                return;
                            }
                            CreateAdorner(element, GetContainerName(element));
                        }
                    }

                    static void CreateAdorner(FrameworkElement element, string name)
                    {
                        uiElements.Add(element);

                        AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(element);
                        if (adornerLayer == null)
                        {
                            return;
                        }

                        Type toastContainerType = GetToastContainerType(element);
                        Type messageContainerType = GetMessageContainerType(element);
                        Brush maskBrush = GetMaskBrush(element);

                        PopupAdorner popupAdorner = new(messageContainerType, toastContainerType, element, maskBrush);

                        adornerLayer.Add(popupAdorner);

                        SetPopupAdornerContainer(element, popupAdorner);

                    }
                }));

        #endregion

        #region MaskBrush

        /// <summary>
        /// get mask maskBrush of popup container
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Brush GetMaskBrush(DependencyObject element)
        {
            return (Brush)element.GetValue(MaskBrushProperty);
        }

        /// <summary>
        /// set mask maskBrush of popup container
        /// </summary>
        /// <param name="element"></param>
        /// <param name="maskBrush"></param>
        public static void SetMaskBrush(DependencyObject element, Brush maskBrush)
        {
            element.SetValue(MaskBrushProperty, maskBrush);
        }

        /// <summary>
        /// mask maskBrush of popup container
        /// </summary>
        public static readonly DependencyProperty MaskBrushProperty =
            DependencyProperty.RegisterAttached("MaskBrush", typeof(Brush), typeof(PopupManager),
                new PropertyMetadata(new BrushConverter().ConvertFromString("#50000000")));


        #endregion

        #region IsMainContainer

        /// <summary>
        /// get popup container is main container
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetIsMainContainer(DependencyObject element)
        {
            return (bool)element.GetValue(IsMainContainerProperty);
        }

        /// <summary>
        /// set popup container is main container
        /// </summary>
        /// <param name="element"></param>
        /// <param name="isMainContainer"></param>
        public static void SetIsMainContainer(DependencyObject element, bool isMainContainer)
        {
            element.SetValue(IsMainContainerProperty, isMainContainer);
        }

        /// <summary>
        /// is main container
        /// </summary>
        public static readonly DependencyProperty IsMainContainerProperty =
            DependencyProperty.RegisterAttached("IsMainContainer", typeof(bool), typeof(PopupManager),
                new PropertyMetadata(false));



        #endregion


        #region MessageContainerType

        /// <summary>
        /// get message container type
        /// This type must inherit <see cref="Tiny.Toolkits.PopupMessageViewBase"/>
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Type GetMessageContainerType(DependencyObject element)
        {
            return (Type)element.GetValue(MessageContainerTypeProperty);
        }

        /// <summary>
        /// set message container type 
        /// This type must inherit <see cref="Tiny.Toolkits.PopupMessageViewBase"/>
        /// and must contain an parameterless constructor
        /// </summary>
        /// <param name="element"></param>
        /// <param name="messageContainerType"></param>
        public static void SetMessageContainerType(DependencyObject element, Type messageContainerType)
        {
            if (messageContainerType is null)
            {
                throw new Exception("invalid message Container Type");
            }

            Type baseType = typeof(Tiny.Toolkits.PopupMessageViewBase);
            if (baseType.IsAssignableFrom(messageContainerType) == false)
            {
                throw new Exception($"PopupManager: {messageContainerType.FullName} must inherit {baseType.FullName}");
            }

            element.SetValue(MessageContainerTypeProperty, messageContainerType);
        }


        /// <summary>
        /// message container type
        /// This type must inherit <see cref="Tiny.Toolkits.PopupMessageViewBase"/>
        /// </summary>
        public static readonly DependencyProperty MessageContainerTypeProperty =
            DependencyProperty.RegisterAttached("MessageContainerType", typeof(Type), typeof(PopupManager),
                new PropertyMetadata(typeof(MessageView)));


        #endregion


        #region ToastContainerType

        /// <summary>
        /// get toast container type
        /// This type must inherit <see cref="Tiny.Toolkits.PopupToastViewBase"/>
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Type GetToastContainerType(DependencyObject element)
        {
            return (Type)element.GetValue(ToastContainerTypeProperty);
        }

        /// <summary>
        /// set toast container type 
        /// This type must inherit <see cref="Tiny.Toolkits.PopupToastViewBase"/>
        /// and must contain an parameterless constructor
        /// </summary>
        /// <param name="element"></param>
        /// <param name="toastContainerType"></param>
        public static void SetToastContainerType(DependencyObject element, Type toastContainerType)
        {
            if (toastContainerType is null)
            {
                throw new Exception("invalid message Container Type");
            }

            Type baseType = typeof(Tiny.Toolkits.PopupToastViewBase);
            if (baseType.IsAssignableFrom(toastContainerType) == false)
            {
                throw new Exception($"PopupManager: {toastContainerType.FullName} must inherit {baseType.FullName}");
            }

            element.SetValue(ToastContainerTypeProperty, toastContainerType);
        }


        /// <summary>
        /// toast container type
        /// This type must inherit <see cref="Tiny.Toolkits.PopupToastViewBase"/>
        /// </summary>
        public static readonly DependencyProperty ToastContainerTypeProperty =
            DependencyProperty.RegisterAttached("ToastContainerType", typeof(Type), typeof(PopupManager),
                new PropertyMetadata(typeof(ToastView)));


        #endregion


        #region hide base function

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        ///  Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }


        #endregion



        #region MaskBrush

        /// <summary>
        /// get mask maskBrush of popup container
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        internal static PopupAdorner GetPopupAdornerContainer(DependencyObject element)
        {
            return (PopupAdorner)element.GetValue(PopupAdornerContainerProperty);
        }

        /// <summary>
        /// set mask maskBrush of popup container
        /// </summary>
        /// <param name="element"></param>
        /// <param name="grid"></param>
        internal static void SetPopupAdornerContainer(DependencyObject element, PopupAdorner grid)
        {
            element.SetValue(PopupAdornerContainerProperty, grid);
        }

        /// <summary>
        /// mask maskBrush of popup container
        /// </summary>
        internal static readonly DependencyProperty PopupAdornerContainerProperty =
            DependencyProperty.RegisterAttached("PopupAdornerContainer", typeof(PopupAdorner), typeof(PopupManager),
                new PropertyMetadata(null));


        #endregion


    }
}
