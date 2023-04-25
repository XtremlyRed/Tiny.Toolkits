using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;


namespace Tiny.Toolkits.Wpf
{
    /// <summary>
    /// An extended combobox that is enumerating Enum values. 
    ///  <para>Use the <see cref="DescriptionAttribute" /> to display entries.</para>
    /// <para>Use the <see cref="BrowsableAttribute" /> to hide specific entries.</para>
    /// </summary>

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EnumSelector : ComboBox
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool isTriggerSelectedChengedEvent = true;
        static EnumSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumSelector),
                new FrameworkPropertyMetadata(typeof(ComboBox)));
        }
        /// <summary>
        /// IsEditable
        /// </summary>
        public new bool IsEditable { get => false; set => base.IsEditable = false; }

        #region Type property

        /// <summary>
        /// CornerRadiusProperty
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            AssistFactory.PropertyRegister<EnumSelector, CornerRadius>(i => i.CornerRadius, new CornerRadius(0));

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

        /// <summary>
        /// IgnoreItemsProperty
        /// </summary>
        public static DependencyProperty IgnoreItemsProperty =
            AssistFactory.PropertyRegister<EnumSelector, IEnumerable>(i => i.IgnoreItems, (s, e) =>
        {
            s.SetType(s.EnumType, e.NewValue);
        });

        /// <summary>
        /// IgnoreItems
        /// </summary>
        [Bindable(true)]
        [Category("EnumMode")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizability(LocalizationCategory.NeverLocalize)]
        public IEnumerable IgnoreItems
        {
            get => (IEnumerable)GetValue(IgnoreItemsProperty);
            set => SetValue(IgnoreItemsProperty, value);
        }

        /// <summary>
        /// EnumTypeProperty
        /// </summary>
        public static DependencyProperty EnumTypeProperty =
            AssistFactory.PropertyRegister<EnumSelector, Type>(i => i.EnumType, (s, e) =>
        {
            s.SetType(e.NewValue, s.IgnoreItems);
        });

        /// <summary>
        /// EnumType
        /// </summary>
        [Bindable(true)]
        [Category("EnumMode")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizability(LocalizationCategory.NeverLocalize)]
        public Type EnumType
        {
            get => (Type)GetValue(EnumTypeProperty);
            set => SetValue(EnumTypeProperty, value);
        }

        /// <summary>
        /// EnumValueProperty
        /// </summary>
        public static DependencyProperty EnumValueProperty =
            AssistFactory.PropertyRegister<EnumSelector, object>(i => i.EnumValue, default, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Inherits, System.Windows.Data.UpdateSourceTrigger.PropertyChanged, (s, e) =>
        {
            s.SetEnumValue(e.NewValue);
        });

        /// <summary>
        /// EnumValue
        /// </summary>
        [Bindable(true)]
        [Category("EnumMode")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizability(LocalizationCategory.NeverLocalize)]
        public object EnumValue
        {
            get => GetValue(EnumValueProperty);
            set => SetValue(EnumValueProperty, value);
        }

        #endregion

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Dictionary<Type, Dictionary<string, object>> EnumMapper = new();


        private void SetType(Type enumType, IEnumerable removeArray = null)
        {
            try
            {
                if (EnumMapper.TryGetValue(enumType, out Dictionary<string, object> enumTypeMapper) == false)
                {
                    List<FieldInfo> list = enumType.GetFields().Where(i => i.IsStatic && !i.IsSpecialName).ToList();

                    EnumMapper[enumType] = enumTypeMapper = new Dictionary<string, object>();

                    foreach (FieldInfo fieldInfo in list)
                    {
                        object[] attributes = fieldInfo.GetCustomAttributes(false);

                        BrowsableAttribute browsable = attributes.OfType<BrowsableAttribute>().FirstOrDefault();

                        if (browsable != null && browsable.Browsable == false)
                        {
                            continue;
                        }

                        string displayName = attributes.OfType<DescriptionAttribute>().FirstOrDefault()?.Description;

                        if (string.IsNullOrWhiteSpace(displayName))
                        {
                            displayName = fieldInfo.Name;
                        }

                        enumTypeMapper[displayName] = fieldInfo.GetValue(null);
                    }
                }

                object[] removeArray2 = removeArray?.Cast<object>().Where(i => i != null).ToArray();

                string[] keys = enumTypeMapper.Keys.ToArray();

                if (removeArray2 != null && removeArray2.Length > 0)
                {
                    keys = enumTypeMapper.Where(i => removeArray2.Contains(i.Value) == false).Select(i => i.Key).ToArray();
                }

                ItemsSource = keys.ToArray();

                if (EnumValue != null && SelectedItem is null)
                {
                    SetEnumValue(EnumValue);
                }
            }
            catch
            {
                // ignore
            }
        }

        private void SetEnumValue(object enumValue)
        {

            if (enumValue is null || EnumType is null)
            {
                return;
            }

            base.IsEditable = false;

            Dictionary<string, object> enumTyper = EnumMapper[EnumType];

            KeyValuePair<string, object> existResult = enumTyper.FirstOrDefault(i => i.Value.GetHashCode() == enumValue.GetHashCode());

            if (existResult.Key is null || existResult.Value is null)
            {
                return;
            }

            if ((SelectedItem as string) == existResult.Key)
            {
                return;
            }

            try
            {
                isTriggerSelectedChengedEvent = false;

                SelectedItem = existResult.Key;
            }
            finally
            {
                isTriggerSelectedChengedEvent = true;
            }
        }

        /// <summary>
        /// OnSelectionChanged
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            if (ItemsSource is not string[] s || SelectedIndex < 0 || SelectedIndex >= s.Length)
            {
                return;
            }

            string key = SelectedItem as string;

            Dictionary<string, object> enumTyper = EnumMapper[EnumType];

            if (enumTyper.TryGetValue(key, out object value))
            {
                SetCurrentValue(EnumValueProperty, value);
            }
        }
    }
}
