using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;




namespace Tiny.Toolkits
{
    /// <summary>
    /// FileNameSelectionChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="fileName"></param>
    public delegate void FileNameSelectionChanged(object sender, string fileName);


    /// <summary>
    /// FileNameSelector
    /// </summary> 
    public class FileNameSelector : UserControl
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] 
        private readonly System.Windows.Forms.SaveFileDialog saveFileDialog = new();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] 
        private const FrameworkPropertyMetadataOptions defaultOptions = FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Inherits;

        static FileNameSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FileNameSelector),
                new FrameworkPropertyMetadata(typeof(UserControl)));
        }

        /// <summary>
        /// FileNameSelector
        /// </summary>
        public FileNameSelector()
        {
            bool canPopup = false;
            Content = nameof(FileNameSelector);
            Cursor = System.Windows.Input.Cursors.Hand;
            VerticalContentAlignment = VerticalAlignment.Center;
            HorizontalContentAlignment = HorizontalAlignment.Center;

            BorderBrush = new SolidColorBrush(Colors.Black) { Opacity = 0.5 };
            BorderThickness = new Thickness(1);

            MouseLeftButtonDown += (s, e) =>
            {
                canPopup = true;
            };
            MouseLeave += (s, e) =>
            {
                canPopup = false;
            };
            MouseLeftButtonUp += (s, e) =>
            {
                if (canPopup == false)
                {
                    return;
                }

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = FileName = saveFileDialog.FileName;

                    FileNameSelectionChanged?.Invoke(this, fileName);

                    FileNameSelectionChangedCommand?.Execute(fileName);
                }
            };
        }

        /// <summary>
        /// FileNameSelectionChanged
        /// </summary>
        public event FileNameSelectionChanged FileNameSelectionChanged;

        /// <summary>
        /// FileNameSelectionChangedCommandProperty
        /// </summary>
        public static readonly DependencyProperty FileNameSelectionChangedCommandProperty =
                 WpfAssist.PropertyRegister<FileNameSelector, IRelayCommand<string>>(i => i.FileNameSelectionChangedCommand, null, FrameworkPropertyMetadataOptions.Inherits, (s, e) => { });

        /// <summary>
        /// FileNameSelectionChangedCommand
        /// </summary>
        [Bindable(true), Category("ICommand")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public IRelayCommand<string> FileNameSelectionChangedCommand
        {
            get => (IRelayCommand<string>)GetValue(FileNameSelectionChangedCommandProperty);
            set => SetValue(FileNameSelectionChangedCommandProperty, value);
        }




        /// <summary>
        /// TitleProperty
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            WpfAssist.PropertyRegister<FileNameSelector, string>(i => i.Title, "", defaultOptions, (s, e) =>
            {
                s.saveFileDialog.Title = e.NewValue;
            });

        /// <summary>
        /// Title
        /// </summary>
        [Bindable(true), Category("Title")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// FileNameProperty
        /// </summary>
        public static readonly DependencyProperty FileNameProperty =
          WpfAssist.PropertyRegister<FileNameSelector, string>(i => i.FileName, "", defaultOptions, (s, e) =>
          {
              s.saveFileDialog.FileName = e.NewValue;
          });

        /// <summary>
        /// FileName
        /// </summary>
        [Bindable(true), Category("FileName")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public string FileName
        {
            get => (string)GetValue(FileNameProperty);
            set => SetValue(FileNameProperty, value);
        }


        /// <summary>
        /// FileNamesProperty
        /// </summary>
        public static readonly DependencyProperty FileNamesProperty =
        WpfAssist.PropertyRegister<FileNameSelector, string[]>(i => i.FileNames, null, defaultOptions, (s, e) => { });

        /// <summary>
        /// FileNames
        /// </summary>
        [Bindable(true), Category("FileNames")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public string[] FileNames
        {
            get => (string[])GetValue(FileNamesProperty);
            set => SetValue(FileNamesProperty, value);
        }


        /// <summary>
        /// DefaultExtProperty
        /// </summary>
        public static readonly DependencyProperty DefaultExtProperty =
          WpfAssist.PropertyRegister<FileNameSelector, string>(i => i.DefaultExt, "", defaultOptions, (s, e) =>
          {
              s.saveFileDialog.DefaultExt = e.NewValue;
          });

        /// <summary>
        /// DefaultExt
        /// </summary>
        [Bindable(true), Category("DefaultExt")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public string DefaultExt
        {
            get => (string)GetValue(DefaultExtProperty);
            set => SetValue(DefaultExtProperty, value);
        }
        /// <summary>
        /// FilterProperty
        /// </summary>
        public static readonly DependencyProperty FilterProperty =
          WpfAssist.PropertyRegister<FileNameSelector, string>(i => i.Filter, "", defaultOptions, (s, e) =>
          {
              s.saveFileDialog.Filter = e.NewValue;
          });
        /// <summary>
        /// Filter
        /// </summary>
        [Bindable(true), Category("Filter")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public string Filter
        {
            get => (string)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }

        /// <summary>
        /// InitialDirectoryProperty
        /// </summary>
        public static readonly DependencyProperty InitialDirectoryProperty =
          WpfAssist.PropertyRegister<FileNameSelector, string>(i => i.InitialDirectory, null, defaultOptions, (s, e) =>
          {
              s.saveFileDialog.InitialDirectory = e.NewValue;
          });

        /// <summary>
        /// InitialDirectory
        /// </summary>
        [Bindable(true), Category("InitialDirectory")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public string InitialDirectory
        {
            get => (string)GetValue(InitialDirectoryProperty);
            set => SetValue(InitialDirectoryProperty, value);
        }

        /// <summary>
        /// FilterIndexProperty
        /// </summary>
        public static readonly DependencyProperty FilterIndexProperty =
          WpfAssist.PropertyRegister<FileNameSelector, int>(i => i.FilterIndex, default, defaultOptions, (s, e) =>
          {
              s.saveFileDialog.FilterIndex = e.NewValue;
          });

        /// <summary>
        /// FilterIndex
        /// </summary>
        [Bindable(true), Category("FilterIndex")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public int FilterIndex
        {
            get => (int)GetValue(FilterIndexProperty);
            set => SetValue(FilterIndexProperty, value);
        }


        /// <summary>
        /// CornerRadiusProperty
        /// </summary> 
        public static readonly DependencyProperty CornerRadiusProperty = WpfAssist.PropertyRegister<FileNameSelector, CornerRadius>(i => i.CornerRadius, new CornerRadius(0));

        /// <summary>
        /// CornerRadius
        /// </summary>
        [Bindable(true), Category("CornerRadius")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
