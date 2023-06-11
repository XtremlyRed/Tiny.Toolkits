using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Tiny.Toolkits
{
   
    public class CommonTypeConverter<From, To> : TypeConverter
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly Type from = typeof(From);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly Type to = typeof(To);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly Func<From, To> labmbdaConverter;

        public CommonTypeConverter(Func<From, To> labmbdaConverter)
        {
            this.labmbdaConverter = labmbdaConverter;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == from)
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is From fromValue)
            {
                return labmbdaConverter(fromValue);
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
