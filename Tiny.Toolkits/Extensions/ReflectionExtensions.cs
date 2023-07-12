using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Tiny.Toolkits
{
    /// <summary>
    /// ref 
    /// </summary>
    public static partial class ReflectionExtensions
    {
        /// <summary>
        /// get proprety name from expression
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="propertySelector">property Selector</param>
        /// <returns></returns>
        public static string GetPropertyName<TSource>(Expression<Func<TSource, object>> propertySelector)
        {
            if (propertySelector.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            UnaryExpression unaryExpression = propertySelector.Body as UnaryExpression;

            return unaryExpression?.Operand is MemberExpression memberExpression2 ? memberExpression2.Member.Name : string.Empty;
        }

        /// <summary>
        ///  get proprety name from expression
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TPropertyType"></typeparam>
        /// <param name="propertySelector">property Selector</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static string GetPropertyName<TSource, TPropertyType>(Expression<Func<TSource, TPropertyType>> propertySelector)
        {
            if (propertySelector is null)
            {
                throw new ArgumentNullException(nameof(propertySelector));
            }

            if (propertySelector.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            UnaryExpression unaryExpression = propertySelector.Body as UnaryExpression;

            return unaryExpression?.Operand is MemberExpression memberExpression2
                ? memberExpression2.Member.Name
                : string.Empty;
        }


        /// <summary>
        ///  get member name from expression
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="expression"></param>
        /// <param name="compound"></param>
        /// <returns></returns>
        public static string GetMemberName<Target>(this Expression<Func<Target>> expression, bool compound = false)
        {
            Expression body = expression.Body;
            return GetMemberName(body, compound);
        }

        /// <summary>
        ///  get member name from expression
        /// </summary> 
        /// <param name="expression"></param>
        /// <param name="compound"></param>
        /// <returns></returns>
        public static string GetMemberName(Expression expression, bool compound = false)
        {
            return expression is MemberExpression memberExpression
                ? compound && memberExpression.Expression.NodeType == ExpressionType.MemberAccess
                    ? GetMemberName(memberExpression.Expression) + "." + memberExpression.Member.Name
                    : memberExpression.Member.Name
                : expression is not UnaryExpression unaryExpression
                ? throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Could not determine member from {0}", expression))
                : unaryExpression.NodeType != ExpressionType.Convert
                ? throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Cannot interpret member from {0}", expression))
                : GetMemberName(unaryExpression.Operand);
        }



        /// <summary>
        /// create instance  from <see cref="Type"/> and  parameters
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static object CreateInstance(this Type type, params object[] parameters)
        {
            return type == null
                ? throw new ArgumentNullException(nameof(type))
                : Activator.CreateInstance(type, parameters);
        }



        /// <summary>
        /// Safe Read
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Target SafeRef<Target>(ref Target target) where Target : class
        {
            return System.Threading.Volatile.Read(ref target);
        }



        /// <summary>
        /// get type string name
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeName(Type type)
        {
            string typeName = type.Name;

            Type[] typeArguments = type.GenericTypeArguments;

            if (typeArguments != null && typeArguments.Length > 0)
            {
                typeName = type.Name.Replace($"`{typeArguments.Length}", "");

                string typeArgumentString = string.Join(",", typeArguments.Select(genericType => GetTypeName(genericType)));

                return $"{typeName}<{typeArgumentString}>";
            }

            return typeName;

        }




        /// <summary>
        /// check  <paramref fieldName="baseType"/> <c>IsAssignableFrom</c> <paramref fieldName="type"/>
        /// </summary>
        /// <param fieldName="type"></param>
        /// <param fieldName="baseType"></param>
        /// <exception cref="ArgumentException"></exception>
        public static bool IsInheritFrom(this Type type, Type baseType)
        {
            return baseType.IsAssignableFrom(type);
        }






        /// <summary>
        /// Used to set the property values of an object
        /// </summary> 
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target">object</param>
        /// <param name="propertyName">property</param>
        /// <param name="value">value to be set</param>
        /// <returns></returns>
        public static bool TrySetPropertyValue<TValue>(this object target, string propertyName, TValue value)
        {
            if (target is null || string.IsNullOrWhiteSpace(propertyName))
            {
                return false;
            }

            System.Reflection.PropertyInfo propertyInfo = target.GetType().GetProperty(propertyName);
            if (propertyInfo is null)
            {
                return false;
            }
            try
            {
                propertyInfo.SetValue(target, value);
                return true;
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// Used to set the field values of an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target">object</param>
        /// <param name="fieldName">field</param>
        /// <param name="value">value to be set</param>
        /// <returns></returns>
        public static bool TrySetFieldValue<TValue>(this object target, string fieldName, TValue value)
        {
            if (target is null || string.IsNullOrWhiteSpace(fieldName))
            {
                return false;
            }

            System.Reflection.FieldInfo fieldInfo = target.GetType().GetField(fieldName);

            if (fieldInfo is null)
            {
                return false;
            }

            try
            {
                fieldInfo.SetValue(target, value);
                return true;
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// Used to set the property values of an object
        /// </summary> 
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target">object</param>
        /// <param name="propertyName">property</param>
        /// <param name="value">value to get</param>
        /// <returns></returns>
        public static bool TryGetPropertyValue<TValue>(this object target, string propertyName, out TValue value)
        {
            value = default;
            if (target is null || string.IsNullOrWhiteSpace(propertyName))
            {
                return false;
            }

            System.Reflection.PropertyInfo propertyInfo = target.GetType().GetProperty(propertyName);
            if (propertyInfo is null)
            {
                return false;
            }

            if (propertyInfo.GetValue(target) is TValue tValue)
            {
                value = tValue;
                return true;
            }


            return false;
        }



        /// <summary>
        /// Used to set the field values of an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target">object</param>
        /// <param name="fieldName">field</param>
        /// <param name="value">value to get</param>
        /// <returns></returns>
        public static bool TryGetFieldValue<TValue>(this object target, string fieldName, out TValue value)
        {
            value = default;

            if (target is null || string.IsNullOrWhiteSpace(fieldName))
            {
                return false;
            }

            FieldInfo fieldInfo = target.GetType().GetField(fieldName);

            if (fieldInfo is null)
            {
                return false;
            }


            if (fieldInfo.GetValue(target) is TValue tValue)
            {
                value = tValue;
                return true;
            }

            return false;

        }
    }
}