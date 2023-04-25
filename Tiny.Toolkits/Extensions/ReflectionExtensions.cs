using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Tiny.Toolkits
{
    /// <summary>
    /// ref 
    /// </summary>
    public static class Reflections
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

            return unaryExpression?.Operand is MemberExpression memberExpression2 ? memberExpression2.Member.Name : string.Empty;
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
            return type == null ? throw new ArgumentNullException(nameof(type)) : Activator.CreateInstance(type, parameters);
        }



        /// <summary>
        /// Safe Read
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Target SafeRead<Target>(ref Target target) where Target : class
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
    }
}