using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Tiny.Toolkits
{

    /// <summary>
    /// compare mode
    /// </summary>
    public enum CompareMode
    {
        /// <summary>
        /// equal
        /// </summary>
        Equal,
        /// <summary>
        /// not equal
        /// </summary>
        NotEqual,
        /// <summary>
        /// greater than
        /// </summary>
        GreaterThan,
        /// <summary>
        /// greater than or equal
        /// </summary>
        GreaterThanOrEqual,
        /// <summary>
        /// less than
        /// </summary>
        LessThan,
        /// <summary>
        /// less than or equal
        /// </summary>
        LessThanOrEqual,
    }

    /// <summary>
    /// match item
    /// </summary>
    [MarkupExtensionReturnType(typeof(MatchItemExtension))]
    [ContentProperty(nameof(Value))]
    public class MatchItemExtension : MarkupExtension
    {

        /// <summary>
        /// value 
        /// </summary>
        [ConstructorArgument(nameof(Value))]
        public object Value { get; set; }

        /// <summary>
        /// compare value
        /// </summary>
        [ConstructorArgument(nameof(CompareValue))]
        public IComparable CompareValue { get; set; }

        /// <summary>
        /// compare mode
        /// </summary>
        [ConstructorArgument(nameof(CompareMode))]
        public CompareMode CompareMode { get; set; }

        /// <summary>
        /// provide value
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }

    /// <summary>
    /// match binding extension 
    /// </summary>
    [MarkupExtensionReturnType(typeof(object))]
    [ContentProperty(nameof(Items))]
    public class MatchBindingExtension : Binding
    {

        /// <summary>
        /// create match binding extension
        /// </summary>
        public MatchBindingExtension()
        {
            Converter = new MatchBindingConverter(this);
        }

        /// <summary>
        /// match items
        /// </summary>
        public Collection<MatchItemExtension> Items { get; } = new Collection<MatchItemExtension>();

        private class MatchBindingConverter : IValueConverter
        {
            private readonly MatchBindingExtension matchBindingExtension;
            public MatchBindingConverter(MatchBindingExtension matchBindingExtension)
            {
                this.matchBindingExtension = matchBindingExtension;
            }
           
            public object Convert(object values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values is IComparable value)
                {
                    foreach (MatchItemExtension item in matchBindingExtension.Items)
                    {
                        if (Match(value, item.CompareValue, item.CompareMode))
                        {
                            return item.Value;
                        }
                    }
                }

                return Binding.DoNothing;

                static bool Match(IComparable value, IComparable comparer, CompareMode compareMode)
                {
                    switch (compareMode)
                    {
                        case CompareMode.Equal:
                            return value.CompareTo(comparer) == 0;
                        case CompareMode.NotEqual:
                            return value.CompareTo(comparer) != 0;
                        case CompareMode.GreaterThan:
                            return value.CompareTo(comparer) > 0;
                        case CompareMode.GreaterThanOrEqual:
                            return value.CompareTo(comparer) >= 0;
                        case CompareMode.LessThan:
                            return value.CompareTo(comparer) < 0;
                        case CompareMode.LessThanOrEqual:
                            return value.CompareTo(comparer) <= 0;
                        default:
                            return true;
                    }
                }
            }

            public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
