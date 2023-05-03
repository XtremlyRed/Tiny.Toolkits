using System.Windows.Controls;

namespace Tiny.Toolkits.Wpf.Popup.PopupView
{
    /// <summary>
    /// TipView.xaml 的交互逻辑
    /// </summary>
    public partial class TipView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public TipView()
        {
            InitializeComponent();
        }

        internal void SetContent(string title, string message)
        {
            TitleBox.Text = title;
            MessageBox.Text = message;
        }
    }
}
