using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Tiny.Toolkits
{
    /// <summary>
    /// MessageView.xaml 的交互逻辑
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MessageView : PopupMessageViewBase
    {

        private string[] buttonContents;
        private bool isLoaded = false;
        internal MessageView()
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
            isLoaded = true;
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn || isLoaded == false)
            {
                return;
            }

            isLoaded = false;

            if ((btn.Content as string) == buttonContents[0])
            {
                btn.Foreground = System.Windows.Media.Brushes.White;
                btn.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 51, 119, 133));
                btn.Focus();
            }
        }

        private void Btn_Container_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is UniformGrid uniformGrid && buttonContents != null)
            {
                if (buttonContents.Length > 2)
                {
                    uniformGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
                    return;
                }

                uniformGrid.HorizontalAlignment = HorizontalAlignment.Right;
            }
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
