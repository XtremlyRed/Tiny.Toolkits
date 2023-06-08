using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Tiny.Toolkits
{
    /// <summary>
    /// create a new class of <see cref="ConditionBindingExtension"/>
    /// </summary>
    [MarkupExtensionReturnType(typeof(object))]
    public class ConditionBindingExtension : MultiBinding
    {
        private int inputBindingIndex = -1;
        private int falseBindingIndex = -1;
        private int trueBindingIndex = -1;
        public ConditionBindingExtension()
        {
            Converter = new ConditionBindingConverter(this);
        }

        /// <summary>
        ///  <see langword="true"/>  value
        /// </summary>
        [ConstructorArgument(nameof(True))]
        public object True { get; set; }

        /// <summary>
        /// <see langword="false"/>  value
        /// </summary>
        [ConstructorArgument(nameof(False))]
        public object False { get; set; }

        /// <summary>
        ///  <see langword="true"/>  <see cref="Binding"/>
        /// </summary>
        [ConstructorArgument(nameof(TrueBinding))]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Binding TrueBinding
        {
            set => SetBinding(value, ref trueBindingIndex);
        }

        /// <summary> 
        /// 
        ///  <see langword="false"/>  <see cref="Binding"/>
        /// </summary>
        [ConstructorArgument(nameof(FalseBinding))]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Binding FalseBinding
        {
            set => SetBinding(value, ref falseBindingIndex);
        }


        /// <summary>
        ///  input  <see cref="Binding"/>  must be <see cref="bool"/> value
        /// </summary>
        [ConstructorArgument(nameof(InputCondition))]
        public Binding InputCondition
        {
            set => SetBinding(value, ref inputBindingIndex);
        }

        private void SetBinding<T>(T value, ref int index)
        {
            if (value is BindingBase binding)
            {
                if (index == -1)
                {
                    Bindings.Add(binding);
                    index = Bindings.Count - 1;
                    return;
                }

                Bindings[index] = binding;
            }
        }

        private class ConditionBindingConverter : IMultiValueConverter
        {
            private readonly ConditionBindingExtension binding;

            public ConditionBindingConverter(ConditionBindingExtension binding)
            {
                this.binding = binding;
            }

            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                object @true = binding.trueBindingIndex >= 0 ? values[binding.trueBindingIndex] : binding.True;
                object @false = binding.falseBindingIndex >= 0 ? values[binding.falseBindingIndex] : binding.False;
                object input = binding.inputBindingIndex >= 0 ? values[binding.inputBindingIndex] : null;

                if (input is not bool boolValue)
                {
                    throw new ArgumentException(string.Format("invalid data type cannot be compared ,must be {0}", typeof(bool)));
                }

                if (string.IsNullOrEmpty(binding.StringFormat))
                {
                    return boolValue ? @true : @false;
                }
                return string.Format(binding.StringFormat, boolValue ? @true : @false);
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
