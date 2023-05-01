﻿using System.ComponentModel;
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

        private string[] buttonContents;

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
            TitleBox.Text = title;
            MessageBox.Text = message;

            ButtonBoxs.ItemsSource = this.buttonContents = buttonContents;
             
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {

            if (sender is not Button btn)
            {
                return;
            }

            if (btn.Content as string == buttonContents[0])
            {
                btn.Foreground = System.Windows.Media.Brushes.White;
                btn.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 51, 119, 133));
                btn.Focus();
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

            string currentClickResult = brn.Content as string;

            base.SetCurrentClickContent(currentClickResult);
        }
    }
}
