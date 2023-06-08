using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Tiny.Toolkits
{
    /// <summary>
    /// ToastView.xaml 的交互逻辑
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ToastView : PopupToastViewBase
    {
        /// <summary>
        /// 
        /// </summary>
        public ToastView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// set toast message info
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="objects"></param>
        protected override void SetToastInfo(string title, string message, params object[] @objects)
        {
            TitleBox.Text = title;
            MessageBox.Text = message;
        }

        void ClosePopupClick(object sender, MouseButtonEventArgs e) 
        {
            base.CloseToast();
        }
    }
}
