using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace Tiny.Toolkits
{

    /// <summary>
    /// target type converter
    /// </summary>
    /// <typeparam name="From"></typeparam>
    /// <typeparam name="To"></typeparam>
    public class TypeConvertFactory<From, To> : TypeConverter
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly Type from = typeof(From);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly Type to = typeof(To);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly Func<From, To> labmbdaFromConverter;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly Func<To, From> labmbdaToConverter;

        /// <summary>
        /// create a new <see cref="TypeConvertFactory{From, To}"/>
        /// </summary>
        /// <param name="labmbdaFromConverter"></param>
        /// <param name="labmbdaToConverter"></param>
        public TypeConvertFactory(Func<From, To> labmbdaFromConverter, Func<To, From> labmbdaToConverter)
        {
            this.labmbdaFromConverter = labmbdaFromConverter;
            this.labmbdaToConverter = labmbdaToConverter;
        }

        /// <summary>
        /// can convert from
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == from)
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// convert from
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is From fromValue)
            {
                return labmbdaFromConverter(fromValue);
            }
            return base.ConvertFrom(context, culture, value);
        }


        /// <summary>
        /// can convert to
        /// </summary>
        /// <param name="context"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == to)
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// convert to
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>          
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == to && value is To toValue)
            {
                return labmbdaToConverter(toValue);
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
