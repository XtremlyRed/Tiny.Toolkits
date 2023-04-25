using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tiny.Toolkits
{
    /// <summary>
    /// Attribute Extensions
    /// </summary>
    public static partial class AttributeExtensions
    {
        /// <summary>
        /// all exist attribute map
        /// </summary>
        private static readonly ConcurrentDictionary<object, Attribute[]> attributeMapper = new();


        /// <summary>
        /// get <typeparamref name="TAttribute"/> from <see cref="Type"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TAttribute GetAttribute<TAttribute>(this Type type, bool inherit = false) where TAttribute : Attribute
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            ICollection<Attribute> attributes = GetAttributes(type, inherit);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }

        /// <summary>
        /// get  <typeparamref name="TAttribute"/>  from <see cref="PropertyInfo"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="property"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TAttribute GetAttribute<TAttribute>(this PropertyInfo property, bool inherit = false) where TAttribute : Attribute
        {
            if (property is null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            ICollection<Attribute> attributes = GetAttributes(property, inherit);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }

        /// <summary>
        ///  get  <typeparamref name="TAttribute"/>  from <see cref="FieldInfo"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="field"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TAttribute GetAttribute<TAttribute>(this FieldInfo field, bool inherit = false) where TAttribute : Attribute
        {
            if (field is null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            ICollection<Attribute> attributes = GetAttributes(field, inherit);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }

        /// <summary>
        /// get  <typeparamref name="TAttribute"/>  from <see cref="MemberInfo"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="member"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo member, bool inherit = false) where TAttribute : Attribute
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            ICollection<Attribute> attributes = GetAttributes(member, inherit);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }


        /// <summary>
        ///   get  <typeparamref name="TAttribute"/>  from <see cref="Enum"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="enumValue"><see cref="Enum"/></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue, bool inherit = false) where TAttribute : Attribute
        {
            if (enumValue is null)
            {
                throw new ArgumentNullException(nameof(enumValue));
            }

            ICollection<Attribute> attributes = GetAttributes(enumValue, inherit);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }

        /// <summary>
        /// get all attributes from <see cref="Type"/>
        /// </summary>
        /// <param name="type"><see cref="Type"/></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this Type type, bool inherit = false)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (attributeMapper.TryGetValue(type, out Attribute[] attributes) == false)
            {
                attributeMapper[type] = attributes = type.GetCustomAttributes(inherit).OfType<Attribute>().ToArray();
            }

            return attributes;
        }

        /// <summary>
        /// get all attributes from <see cref="PropertyInfo"/>
        /// </summary>
        /// <param name="property"><see cref="PropertyInfo"/></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this PropertyInfo property, bool inherit = false)
        {
            if (property is null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (attributeMapper.TryGetValue(property, out Attribute[] attributes) == false)
            {
                attributeMapper[property] = attributes = property.GetCustomAttributes(inherit).OfType<Attribute>().ToArray();
            }

            return attributes;
        }
        /// <summary>
        /// get all attributes from <see cref="FieldInfo"/>
        /// </summary>
        /// <param name="field"><see cref="FieldInfo"/></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this FieldInfo field, bool inherit = false)
        {
            if (field is null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (attributeMapper.TryGetValue(field, out Attribute[] attributes) == false)
            {
                attributeMapper[field] = attributes = field.GetCustomAttributes(inherit).OfType<Attribute>().ToArray();
            }

            return attributes;
        }



        /// <summary>
        /// get all attributes from <see cref="MemberInfo"/>
        /// </summary>
        /// <param name="member"><see cref="MemberInfo"/></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this MemberInfo member, bool inherit = false)
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (attributeMapper.TryGetValue(member, out Attribute[] attributes) == false)
            {
                attributeMapper[member] = attributes = member.GetCustomAttributes(inherit).OfType<Attribute>().ToArray();
            }

            return attributes;
        }


        /// <summary>
        /// get all attributes from <see cref="Enum"/>
        /// </summary>
        /// <param name="enumValue"><see cref="Enum"/></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this Enum enumValue, bool inherit = false)
        {
            if (enumValue is null)
            {
                throw new ArgumentNullException(nameof(enumValue));
            }

            if (attributeMapper.TryGetValue(enumValue, out Attribute[] attributes) == false)
            {
                Type type = enumValue.GetType();

                string enumName = Enum.GetName(type, enumValue);
                FieldInfo field = type.GetField(enumName);

                attributeMapper[enumValue] = attributes = field.GetCustomAttributes(inherit).OfType<Attribute>().ToArray();
            }

            return attributes;
        }
    }
}