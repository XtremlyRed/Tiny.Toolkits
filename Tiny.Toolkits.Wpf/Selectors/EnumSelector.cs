using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;


namespace Tiny.Toolkits
{
    /// <summary>
    /// An extended combobox that is enumerating Enum values. 
    ///  <para>Use the <see cref="DescriptionAttribute" /> to display entries.</para>
    /// <para>Use the <see cref="BrowsableAttribute" /> to hide specific entries.</para>
    /// </summary> 
    public class EnumSelector : ComboBox
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly IDictionary<Type, ICollection<EnumInfo>> EnumInfos = new ConcurrentDictionary<Type, ICollection<EnumInfo>>();

        static EnumSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumSelector), new FrameworkPropertyMetadata(typeof(ComboBox)));
        }

        private enum EmptyEnumMode { None }

        [DebuggerDisplay("{Value}")]
        [DebuggerNonUserCode]
        private struct EnumInfo
        {
            public object Value;
            public int HashCode;
            public string Name;
            public string DisplayName;
        }

        /// <summary>
        /// create a new <see cref="EnumSelector"/>
        /// </summary>
        public EnumSelector()
        {
            Loaded += (s, e) => IsEditable = false;
        }



        /// <summary>
        /// enum type
        /// </summary>
        public static DependencyProperty EnumTypeProperty =
            DependencyProperty.Register(nameof(EnumType), typeof(Type), typeof(EnumSelector), new FrameworkPropertyMetadata(null, (s, e) =>
            {
                if (s is EnumSelector @enum)
                {
                    if (e.NewValue is Type type && type.IsEnum && EnumInfos.TryGetValue(type, out _) == false)
                    {
                        EnumInfos[type] = type.GetFields()
                        .Where(i => i.IsStatic)
                        .Where(i => i.GetAttribute<BrowsableAttribute>()?.Browsable != false)
                        .Select(i => new EnumInfo
                        {
                            Value = i.GetValue(null),
                            HashCode = i.GetValue(null).GetHashCode(),
                            Name = i.Name,
                            DisplayName = i.GetCustomAttribute<DescriptionAttribute>()?.Description ?? i.Name
                        }).ToArray();
                    }

                    @enum.UpdateVisual();
                }
            }));

        /// <summary>
        /// enum type must be <see cref="Enum"/> type
        /// </summary>
        public Type EnumType
        {
            get => (Type)GetValue(EnumTypeProperty);
            set => SetValue(EnumTypeProperty, value);
        }

        /// <summary>
        /// enum type must be <see cref="Enum"/> type
        /// </summary>
        public static DependencyProperty EnumValueProperty =
            DependencyProperty.Register(nameof(EnumValue), typeof(object), typeof(EnumSelector), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (s, e) =>
            {
                if (s is EnumSelector @enum)
                {
                    if (e.OldValue is null || (e.NewValue != null && e.OldValue != null && e.OldValue.GetHashCode() != e.NewValue.GetHashCode()))
                    {
                        @enum.UpdateVisual(false);
                    }
                }
            }));

        /// <summary>
        /// selected enum value ,can be null
        /// </summary>
        public object EnumValue
        {
            get => GetValue(EnumValueProperty);
            set => SetValue(EnumValueProperty, value);
        }

        /// <summary>
        /// has default empty value
        /// </summary>
        public static DependencyProperty HasEmptyValueProperty =
              DependencyProperty.Register(nameof(HasEmptyValue), typeof(bool), typeof(EnumSelector), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (s, e) =>
              {
                  if (s is EnumSelector @enum)
                  {
                      @enum.UpdateVisual();
                  }
              }));

        /// <summary>
        ///  has default empty value
        /// </summary>
        public bool HasEmptyValue
        {
            get => (bool)GetValue(HasEmptyValueProperty);
            set => SetValue(HasEmptyValueProperty, value);
        }

        /// <summary>
        /// default empty value
        /// </summary>
        public static DependencyProperty EmptyValueProperty =
           DependencyProperty.Register(nameof(EmptyValue), typeof(object), typeof(EnumSelector), new FrameworkPropertyMetadata("None", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (s, e) =>
           {
               if (s is EnumSelector @enum)
               {
                   @enum.UpdateVisual();
               }
           }));

        /// <summary>
        /// default empty value
        /// </summary>
        public object EmptyValue
        {
            get => GetValue(EmptyValueProperty);
            set => SetValue(EmptyValueProperty, value);
        }

        /// <summary>
        /// ignore values
        /// </summary>
        public static DependencyProperty IgnoreValuesProperty =
            DependencyProperty.Register(nameof(IgnoreValues), typeof(IEnumerable), typeof(EnumSelector), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (s, e) =>
            {
                if (s is EnumSelector @enum)
                {
                    @enum.UpdateVisual();
                }
            }));

        /// <summary>
        /// ignore values
        /// </summary>
        public IEnumerable IgnoreValues
        {
            get => (IEnumerable)GetValue(IgnoreValuesProperty);
            set => SetValue(IgnoreValuesProperty, value);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<EnumInfo> ValidEnumValues;



        private void UpdateVisual(bool effectVisual = true)
        {
            if (EnumType is null || EnumInfos.TryGetValue(EnumType, out ICollection<EnumInfo> enumInfos) == false)
            {
                return;
            }


            if (effectVisual == true)
            {
                List<EnumInfo> validInfos = enumInfos.ToList();

                if (HasEmptyValue)
                {
                    validInfos.Insert(0, new EnumInfo()
                    {
                        DisplayName = EmptyValue as string,
                        Name = EmptyValue as string,
                        Value = null,
                    });
                }

                if (IgnoreValues != null)
                {
                    int[] ignoreValues = IgnoreValues.Cast<object>().Where(i => i != null).Select(i => i.GetHashCode()).ToArray();
                    if (ignoreValues.Length > 0)
                    {
                        validInfos = validInfos.Where(i => ignoreValues.Contains(i.HashCode) == false).ToList();
                    }
                }

                ValidEnumValues = validInfos;

                ItemsSource = ValidEnumValues.Select(i => i.DisplayName).ToArray();
            }

            if (EnumValue is null)
            {
                SelectedIndex = 0;
                return;
            }

            int hashCode = EnumValue.GetHashCode();
            int index = TinyTools.IndexOf(ValidEnumValues, i => i.HashCode == hashCode);

            if ((EnumValue != null && SelectedIndex == -1) || index != SelectedIndex)
            {
                SelectedIndex = index;
            }
        }

        /// <summary>
        /// Responds to a <see cref="EnumSelector"/> selection change by raising a <see cref="System.Windows.Controls.Primitives.Selector.SelectionChanged"/> event.
        /// </summary>
        /// <param name="e">Provides data for <see cref="SelectionChangedEventArgs"/>.</param>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            object updateValue = null;

            if (SelectedIndex >= 0 && SelectedIndex < ValidEnumValues.Count)
            {
                updateValue = ValidEnumValues[SelectedIndex].Value;
            }

            SetCurrentValue(EnumValueProperty, updateValue);
        }
    }
}
