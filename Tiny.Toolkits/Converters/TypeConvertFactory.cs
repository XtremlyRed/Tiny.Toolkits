using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;

namespace Tiny.Toolkits
{
    public static class TypeConvertFactory
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ConcurrentDictionary<Type, TypeConverter> typeConverters = new();

        /// <summary>
        /// cast object value to target Type
        /// </summary>
        /// <typeparam fieldName="To"></typeparam>
        /// <param fieldName="value">object value</param> 
        /// <returns>cast success</returns>
        public static To To<To>(this object value, TypeConverter converter = null)
        {
            if (value is null)
            {
                return default!;
            }

            if (value is To target)
            {
                return target;
            }

            Type targetType = typeof(To);
            Type currentType = value.GetType();

            converter ??= typeConverters.GetOrAdd(targetType, static i => TypeDescriptor.GetConverter(i));

            if (converter.CanConvertFrom(currentType))
            {
                object convertValue = converter.ConvertFrom(value);

                if (convertValue is To targetValue)
                {
                    return targetValue;
                }
            }

            throw new System.InvalidCastException($"Can not convert {currentType} to {targetType},Please pass in a valid type converter");

        }



        /// <summary>
        /// cast object value to target Type
        /// </summary>
        /// <typeparam fieldName="To"></typeparam>
        /// <param fieldName="value">object value</param> 
        /// <returns>cast success</returns>
        public static To To<From, To>(this From value, Func<From, To> lambdaConverter)
        {
            if (value is null)
            {
                return default!;
            }

            if (value is To target)
            {
                return target;
            }

            Type targetType = typeof(To);
            Type currentType = value.GetType();

            TypeConverter converter = typeConverters.GetOrAdd(targetType, i =>
            {
                //TypeConverter cvt = TypeDescriptor.GetConverter(i); 
                //if ((cvt is null || cvt.CanConvertFrom(currentType) == false) && lambdaConverter != null)
                //{
                //    cvt = new TypeConvertFactory<From, To>(lambdaConverter, null);
                //}

                return new TypeConvertFactory<From, To>(lambdaConverter, null);
            });

            object convertValue = converter.ConvertFrom(value);

            if (convertValue is To targetValue)
            {
                return targetValue;
            }

            if (lambdaConverter is null)
            {
                throw new System.InvalidCastException($"Can not convert {currentType} to {targetType},Please pass in a valid lambda converter");
            }

            return lambdaConverter(value);
        }


        public static void AppendConverter<TFrom, TTo>(Func<TFrom, TTo> lambdaConverter)
        {
            _ = typeConverters.GetOrAdd(typeof(TTo), i =>
            {
                //Type currentType = typeof(TFrom);
                //TypeConverter cvt = TypeDescriptor.GetConverter(i);

                //if ((cvt is null || cvt.CanConvertFrom(currentType) == false) && lambdaConverter != null)
                //{
                //    cvt = new TypeConvertFactory<TFrom, TTo>(lambdaConverter, null);
                //}

                return new TypeConvertFactory<TFrom, TTo>(lambdaConverter, null);
            });
        }
    }
}
