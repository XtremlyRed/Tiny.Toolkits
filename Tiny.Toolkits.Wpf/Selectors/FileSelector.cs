 

using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Tiny.Toolkits.Wpf
{
    /// <summary>
    /// FileSelectionChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="fileNames"></param>
    public delegate void FileSelectionChanged(object sender, string[] fileNames);

    /// <summary>
    /// FileSelector
    /// </summary> 
    public class FileSelector : UserControl
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private readonly System.Windows.Forms.OpenFileDialog openFileDialog = new();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const FrameworkPropertyMetadataOptions defaultOptions = FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Inherits;

        static FileSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FileSelector),
                new FrameworkPropertyMetadata(typeof(UserControl)));
        }

        /// <summary>
        /// FileSelector
        /// </summary>
        public FileSelector()
        {
            Content = nameof(FileSelector);
            bool canPopup = false;
            Cursor = System.Windows.Input.Cursors.Hand; 

            VerticalContentAlignment = VerticalAlignment.Center;
            HorizontalContentAlignment = HorizontalAlignment.Center;

            BorderBrush = new SolidColorBrush(Colors.Black) { Opacity = 0.5 };
            BorderThickness = new Thickness(1);

            MouseLeftButtonDown += (s, e) => canPopup = true;
            MouseLeave += (s, e) => canPopup = false;
            MouseLeftButtonUp += (s, e) =>
            {
                if (canPopup == false)
                {
                    return;
                }

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string[] fileNames = null;

                    if (Multiselect)
                    {
                        FileNames = fileNames = openFileDialog.FileNames;
                    }
                    else
                    {
                        FileName = openFileDialog.FileName;
                        fileNames = new[] { openFileDialog.FileName };
                    }

                    FileSelectionChanged?.Invoke(this, fileNames);
                    FileSelectionChangedCommand?.Execute(fileNames);
                }
            };
        }

        /// <summary>
        /// FileSelectionChangedCommandProperty
        /// </summary>
        public static readonly DependencyProperty FileSelectionChangedCommandProperty =
        AssistFactory.PropertyRegister<FileSelector, IRelayCommand<string[]>>(i => i.FileSelectionChangedCommand, null, FrameworkPropertyMetadataOptions.Inherits, (s, e) => { });

        /// <summary>
        /// FileSelectionChangedCommand
        /// </summary>
        [Bindable(true), Category("ICommand")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public IRelayCommand<string[]> FileSelectionChangedCommand
        {
            get => (IRelayCommand<string[]>)GetValue(FileSelectionChangedCommandProperty);
            set => SetValue(FileSelectionChangedCommandProperty, value);
        }

        /// <summary>
        /// MultiselectProperty
        /// </summary>
        public static readonly DependencyProperty MultiselectProperty = AssistFactory.PropertyRegister<FileSelector, bool>(i => i.Multiselect, false, defaultOptions, (s, e) =>
        {
            s.openFileDialog.Multiselect = e.NewValue;
            if (e.NewValue)
            {
                s.FileName = null;
                return;
            }
            s.FileNames = null;
        });

        /// <summary>
        /// Multiselect
        /// </summary>
        [Bindable(true), Category("Multiselect")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public bool Multiselect
        {
            get => (bool)GetValue(MultiselectProperty);
            set => SetValue(MultiselectProperty, value);
        }

        /// <summary>
        /// TitleProperty
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            AssistFactory.PropertyRegister<FileSelector, string>(i => i.Title, "", defaultOptions, (s, e) =>
        {
            s.openFileDialog.Title = e.NewValue;
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
          AssistFactory.PropertyRegister<FileSelector, string>(i => i.FileName, "", defaultOptions, (s, e) =>
          {
              s.openFileDialog.FileName = e.NewValue;
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
        AssistFactory.PropertyRegister<FileSelector, string[]>(i => i.FileNames, null, defaultOptions, (s, e) => { });


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
          AssistFactory.PropertyRegister<FileSelector, string>(i => i.DefaultExt, "", defaultOptions, (s, e) =>
          {
              s.openFileDialog.DefaultExt = e.NewValue;
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
          AssistFactory.PropertyRegister<FileSelector, string>(i => i.Filter, "*.*", defaultOptions, (s, e) =>
          {
              s.openFileDialog.Filter = e.NewValue;
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
          AssistFactory.PropertyRegister<FileSelector, string>(i => i.InitialDirectory, null, defaultOptions, (s, e) =>
          {
              s.openFileDialog.InitialDirectory = e.NewValue;
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
          AssistFactory.PropertyRegister<FileSelector, int>(i => i.FilterIndex, default, defaultOptions, (s, e) =>
          {
              s.openFileDialog.FilterIndex = e.NewValue;
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
        /// FileSelectionChanged
        /// </summary>
        public event FileSelectionChanged FileSelectionChanged;

        /// <summary>
        /// CornerRadiusProperty
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            AssistFactory.PropertyRegister<FileSelector, CornerRadius>(i => i.CornerRadius, new CornerRadius(0));

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
