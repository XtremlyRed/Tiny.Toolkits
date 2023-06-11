using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace Tiny.Toolkits
{


    /// <summary>
    /// value converter
    /// </summary>
    /// <typeparam name="TValue">object type</typeparam>
    /// <typeparam name="TParameter">parameter type</typeparam> 
    public interface IValueConverter<TValue, TParameter>
    {
        object Convert(TValue value, TParameter parameter);

        TValue ConvertBack(object value, TParameter parameter);
    }

    /// <summary>
    /// value converter
    /// </summary>
    /// <typeparam name="TValue">object type</typeparam>  
    public interface IValueConverter<TValue>
    {
        object Convert(TValue value);

        TValue ConvertBack(object value);
    }

    public static class ValueConverter
    {
        public static IValueConverter<TValue, TParameter> Create<TValue, TParameter>(
            Func<TValue, Type, TParameter, CultureInfo, object> converter,
             Func<object, Type, TParameter, CultureInfo, TValue> inverseConverter = null)
        {
            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            return new _ValueConverter<TValue, TParameter>(converter, inverseConverter);
        }



        public static IValueConverter<TValue, TParameter> Create<TValue, TParameter, TReturn>(
          Func<TValue, TParameter, object> converter,
           Func<object, TParameter, TValue> inverseConverter = null)
        {
            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            object invoker(TValue value, Type type, TParameter parameter, CultureInfo cultureInfo)
            {
                return converter.Invoke(value, parameter);
            }

            TValue inverseInvoker(object value, Type type, TParameter parameter, CultureInfo cultureInfo)
            {
                return inverseConverter.Invoke(value, parameter);
            }


            return new _ValueConverter<TValue, TParameter>(invoker, inverseConverter is null ? null : inverseInvoker);
        }



        public static IValueConverter<TValue> Create<TValue>(Func<TValue, Type, object, CultureInfo, object> converter, Func<object, Type, object, CultureInfo, TValue> inverseConverter = null)
        {
            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            return new _ValueConverter<TValue>(converter, inverseConverter);
        }



        public static IValueConverter<TValue> Create<TValue>(Func<TValue, object> converter, Func<object, TValue> inverseConverter = null)
        {
            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            object invoker(TValue value, Type type, object parameter, CultureInfo cultureInfo)
            {
                return converter.Invoke(value);
            }

            TValue inverseInvoker(object value, Type type, object parameter, CultureInfo cultureInfo)
            {
                return inverseConverter.Invoke(value);
            }


            return new _ValueConverter<TValue>(invoker, inverseConverter is null ? null : inverseInvoker);
        }

        #region Impl

        internal record _ValueConverter<TValue>
         (Func<TValue, Type, object, CultureInfo, object> converter,
        Func<object, Type, object, CultureInfo, TValue> inverseConverter = null)
       : ValueConverterBase<TValue, object, object>, IValueConverter<TValue>
        {

            object IValueConverter<TValue>.Convert(TValue value)
            {
                return converter.Invoke(value, value.GetType(), null, CultureInfo.CurrentCulture);
            }


            TValue IValueConverter<TValue>.ConvertBack(object value)
            {
                if (inverseConverter is null)
                {
                    throw new NotImplementedException();
                }

                return inverseConverter.Invoke(value, value.GetType(), null, CultureInfo.CurrentCulture);
            }



            protected sealed override object Convert(TValue value, Type targetType, object parameter, CultureInfo culture)
            {
                return converter.Invoke(value, targetType, parameter, culture);
            }


            protected sealed override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (inverseConverter is null)
                {
                    throw new NotImplementedException();
                }

                return inverseConverter.Invoke(value, targetType, parameter, culture);
            }
        }

        internal record _ValueConverter<TValue, TParameter>
              (Func<TValue, Type, TParameter, CultureInfo, object> converter,
             Func<object, Type, TParameter, CultureInfo, TValue> inverseConverter = null)
            : ValueConverterBase<TValue, TParameter, object>, IValueConverter<TValue, TParameter>
        {

            object IValueConverter<TValue, TParameter>.Convert(TValue value, TParameter parameter)
            {
                return converter.Invoke(value, value.GetType(), parameter, CultureInfo.CurrentCulture);
            }

            TValue IValueConverter<TValue, TParameter>.ConvertBack(object value, TParameter parameter)
            {
                if (inverseConverter is null)
                {
                    throw new NotImplementedException();
                }

                return inverseConverter.Invoke(value, value.GetType(), parameter, CultureInfo.CurrentCulture);
            }


            protected sealed override object Convert(TValue value, Type targetType, TParameter parameter, CultureInfo culture)
            {
                return converter.Invoke(value, targetType, parameter, culture);
            }



            protected sealed override object ConvertBack(object value, Type targetType, TParameter parameter, CultureInfo culture)
            {
                if (inverseConverter is null)
                {
                    throw new NotImplementedException();
                }

                return inverseConverter.Invoke(value, targetType, parameter, culture);
            }
        }

        /// <summary>
        /// value converter base
        /// </summary>
        /// <typeparam name="TValue">object type</typeparam>
        /// <typeparam name="TParameter">parameter type</typeparam>
        /// <typeparam name="TReturn">return value type</typeparam>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract record ValueConverterBase<TValue, TParameter, TReturn> : IValueConverter
        {

            protected abstract TReturn Convert(TValue value, Type targetType, TParameter parameter, CultureInfo culture);

            protected abstract object ConvertBack(TReturn value, Type targetType, TParameter parameter, CultureInfo culture);

            object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                TValue tvalue = value.To<TValue>();
                TParameter tparameter = parameter.To<TParameter>();

                return Convert(tvalue, targetType, tparameter, culture);
            }

            object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                TReturn treturn = value.To<TReturn>();
                TParameter tparameter = parameter.To<TParameter>();
                return ConvertBack(treturn, targetType, tparameter, culture);
            }
        }

        #endregion
    }
}
