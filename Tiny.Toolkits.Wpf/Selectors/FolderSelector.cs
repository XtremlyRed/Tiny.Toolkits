 

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tiny.Toolkits.Wpf
{

    /// <summary>
    /// FolderSelectionChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="folderPath"></param>
    public delegate void FolderSelectionChanged(object sender, string folderPath);


    /// <summary>
    /// FolderSelector
    /// </summary> 
    public class FolderSelector : UserControl
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private readonly System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private const FrameworkPropertyMetadataOptions defaultOptions = FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Inherits;


        static FolderSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FolderSelector),
                new FrameworkPropertyMetadata(typeof(UserControl)));
        }


        /// <summary>
        /// FolderSelector
        /// </summary>
        public FolderSelector()
        {
            Content = nameof(FolderSelector);
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

                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string sp = SelectedPath = folderBrowserDialog.SelectedPath;

                    FolderSelectionChanged?.Invoke(this, sp);

                    FolderSelectionChangedCommand?.Execute(sp);
                }
            };
        }

        /// <summary>
        /// FolderSelectionChanged
        /// </summary>
        public event FolderSelectionChanged FolderSelectionChanged;


        /// <summary>
        /// FolderSelectionChangedCommandProperty
        /// </summary>
        public static readonly DependencyProperty FolderSelectionChangedCommandProperty =
                AssistFactory.PropertyRegister<FolderSelector, IRelayCommand<string>>(i => i.FolderSelectionChangedCommand, null, FrameworkPropertyMetadataOptions.Inherits, (s, e) => { });


        /// <summary>
        /// FolderSelectionChangedCommand
        /// </summary>
        [Bindable(true), Category("ICommand")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public IRelayCommand<string> FolderSelectionChangedCommand
        {
            get => (IRelayCommand<string>)GetValue(FolderSelectionChangedCommandProperty);
            set => SetValue(FolderSelectionChangedCommandProperty, value);
        }

        /// <summary>
        /// DescriptionProperty
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty =
          AssistFactory.PropertyRegister<FolderSelector, string>(i => i.Description, "", defaultOptions, (s, e) =>
          {
              s.folderBrowserDialog.Description = e.NewValue;
          });

        /// <summary>
        /// Description
        /// </summary>
        [Bindable(true), Category("Description")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }


        /// <summary>
        /// ShowNewFolderButtonProperty
        /// </summary>
        public static readonly DependencyProperty ShowNewFolderButtonProperty =
          AssistFactory.PropertyRegister<FolderSelector, bool>(i => i.ShowNewFolderButton, false, defaultOptions, (s, e) =>
          {
              s.folderBrowserDialog.ShowNewFolderButton = e.NewValue;
          });

        /// <summary>
        /// ShowNewFolderButton
        /// </summary>
        [Bindable(true), Category("ShowNewFolderButton")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public bool ShowNewFolderButton
        {
            get => (bool)GetValue(ShowNewFolderButtonProperty);
            set => SetValue(ShowNewFolderButtonProperty, value);
        }

        /// <summary>
        /// SelectedPathProperty
        /// </summary>
        public static readonly DependencyProperty SelectedPathProperty =
       AssistFactory.PropertyRegister<FolderSelector, string>(i => i.SelectedPath, "", defaultOptions, (s, e) =>
       {
           s.folderBrowserDialog.SelectedPath = e.NewValue;
       });

        /// <summary>
        /// SelectedPath
        /// </summary>
        [Bindable(true), Category("SelectedPath")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public string SelectedPath
        {
            get => (string)GetValue(SelectedPathProperty);
            set => SetValue(SelectedPathProperty, value);
        }

        /// <summary>
        /// RootFolderProperty
        /// </summary>
        public static readonly DependencyProperty RootFolderProperty =
            AssistFactory.PropertyRegister<FolderSelector, Environment.SpecialFolder>(i => i.RootFolder, Environment.SpecialFolder.Desktop, defaultOptions, (s, e) =>
            {
                s.folderBrowserDialog.RootFolder = e.NewValue;
            });

        /// <summary>
        /// RootFolder
        /// </summary>
        [Bindable(true), Category("SelectedPath")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter()]
        public Environment.SpecialFolder RootFolder
        {
            get => (Environment.SpecialFolder)GetValue(RootFolderProperty);
            set => SetValue(RootFolderProperty, value);
        }


        /// <summary>
        /// UseDescriptionForTitleProperty
        /// </summary>
        public static readonly DependencyProperty UseDescriptionForTitleProperty =
          AssistFactory.PropertyRegister<FolderSelector, bool>(i => i.UseDescriptionForTitle, false, defaultOptions, (s, e) =>
          {
              s.folderBrowserDialog.ShowNewFolderButton = e.NewValue;
          });

        /// <summary>
        /// UseDescriptionForTitle
        /// </summary>
        [Bindable(true), Category("ShowNewFolderButton")]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public bool UseDescriptionForTitle
        {
            get => (bool)GetValue(UseDescriptionForTitleProperty);
            set => SetValue(UseDescriptionForTitleProperty, value);
        }


        /// <summary>
        /// Reset
        /// </summary>
        public void Reset()
        {
            folderBrowserDialog.Reset();
        }

        /// <summary>
        /// CornerRadiusProperty
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            AssistFactory.PropertyRegister<FolderSelector, CornerRadius>(i => i.CornerRadius, new CornerRadius(0));

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
