

using System;
using System.Threading.Tasks;
using System.Windows;


namespace Tiny.Toolkits.Wpf
{
    /// <summary>
    /// a class of <see cref="IPopupManager"/>
    /// </summary>
    public interface IPopupManager
    {
        /// <summary>
        /// show message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/>,
        /// when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true
        /// </summary>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <returns></returns>
        Task ShowAsync(string message, string title, string[] buttonContents);

        /// <summary>
        /// comfirm message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/>
        /// when using, there must be a popup container with the <code><see cref="PopupManager.IsMainContainerProperty"/></code>  attribute set to true
        /// </summary>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <returns>the content of a clicked button</returns>
        Task<string> ComfirmAsync(string message, string title, string[] buttonContents);

        /// <summary>
        /// 
        /// when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true
        /// </summary>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <param name="clickChecker">for determining the click on the content of the clicked button (see parameter: <paramref name="buttonContents"/>).</param>
        /// <returns></returns>
        Task<bool> ComfirmAsync(string message, string title, string[] buttonContents, Func<string, bool> clickChecker);

        /// <summary>
        /// show message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/> from <paramref name="containerName"/>
        /// </summary>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <returns></returns>
        Task ShowAsync(string containerName, string message, string title, string[] buttonContents);

        /// <summary>
        /// comfirm message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/> from <paramref name="containerName"/>
        /// </summary>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <returns></returns>
        Task<string> ComfirmAsync(string containerName, string message, string title, string[] buttonContents);

        /// <summary>
        /// comfirm message with <paramref name="message"/>,<paramref name="title"/>,<paramref name="buttonContents"/> from <paramref name="containerName"/>
        /// </summary>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="message">the message content of the pop-up box</param>
        /// <param name="title">the title of the pop-up box</param>
        /// <param name="buttonContents">the button contents of the pop-up box</param>
        /// <param name="clickChecker">for determining the click on the content of the clicked button (see parameter: <paramref name="buttonContents"/>).</param>
        /// <returns></returns>
        Task<bool> ComfirmAsync(string containerName, string message, string title, string[] buttonContents, Func<string, bool> clickChecker);

        /// <summary>
        /// popup view with <paramref name="parameters"/> from  main container
        /// when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true
        /// </summary>
        /// <typeparam name="TView">view type</typeparam>
        /// <param name="view">view</param>
        /// <param name="parameters">parameters</param>
        /// <returns></returns>
        Task<object> PopupAsync<TView>(TView view, Parameters parameters = null) where TView : FrameworkElement;

        /// <summary>
        /// popup view with <paramref name="parameters"/> from  main container
        /// when using, there must be a popup container with the <see cref="PopupManager.IsMainContainerProperty"/> attribute set to true
        /// </summary>
        /// <typeparam name="TView">view type</typeparam>
        /// <param name="viewCreator">view creator</param>
        /// <param name="parameters">parameters</param>
        /// <returns></returns>
        Task<object> PopupAsync<TView>(Func<TView> viewCreator, Parameters parameters = null) where TView : FrameworkElement;

        /// <summary>
        /// popup view with <paramref name="parameters"/> from <paramref name="containerName"/>
        /// </summary>
        /// <typeparam name="TView">view type</typeparam>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="view">view</param>
        /// <param name="parameters">parameters</param>
        /// <returns></returns>
        Task<object> PopupAsync<TView>(string containerName, TView view, Parameters parameters = null) where TView : FrameworkElement;

        /// <summary>
        /// popup view with <paramref name="parameters"/> from <paramref name="containerName"/>
        /// </summary>
        /// <typeparam name="TView">view type</typeparam>
        /// <param name="containerName">popup <paramref name="containerName"/></param>
        /// <param name="viewCreator">view creator</param>
        /// <param name="parameters">parameters</param>
        /// <returns></returns>
        Task<object> PopupAsync<TView>(string containerName, Func<TView> viewCreator, Parameters parameters = null) where TView : FrameworkElement;
    }


    /// <summary>
    /// popup content aware to view close event
    /// </summary>
    public interface IPopupAware
    {
        /// <summary>
        /// on popup closed
        /// </summary>
        void OnPopupClosed();
        /// <summary>
        /// on popup opened
        /// </summary>
        /// <param name="parameters"></param>
        void OnPopupOpened(Parameters parameters);

        /// <summary>
        /// request close popup 
        /// </summary>
        event RequestCloseEventHandler RequestCloseEvent;
    }

    /// <summary>
    /// request close popup event
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="args">args</param>
    public delegate void RequestCloseEventHandler(object sender, object args);


}
