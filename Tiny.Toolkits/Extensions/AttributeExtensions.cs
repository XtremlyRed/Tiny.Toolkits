﻿using System;
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

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TAttribute GetAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            ICollection<Attribute> attributes = GetAttributes(type);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }

        /// <summary>
        /// get  <typeparamref name="TAttribute"/>  from <see cref="PropertyInfo"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="property"></param>

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TAttribute GetAttribute<TAttribute>(this PropertyInfo property) where TAttribute : Attribute
        {
            if (property is null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            ICollection<Attribute> attributes = GetAttributes(property);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }

        /// <summary>
        ///  get  <typeparamref name="TAttribute"/>  from <see cref="FieldInfo"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="field"></param>

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TAttribute GetAttribute<TAttribute>(this FieldInfo field) where TAttribute : Attribute
        {
            if (field is null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            ICollection<Attribute> attributes = GetAttributes(field);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }

        /// <summary>
        /// get  <typeparamref name="TAttribute"/>  from <see cref="MemberInfo"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="member"></param>

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo member) where TAttribute : Attribute
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            ICollection<Attribute> attributes = GetAttributes(member);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }


        /// <summary>
        ///   get  <typeparamref name="TAttribute"/>  from <see cref="Enum"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="enumValue"><see cref="Enum"/></param>

        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            if (enumValue is null)
            {
                throw new ArgumentNullException(nameof(enumValue));
            }

            ICollection<Attribute> attributes = GetAttributes(enumValue);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }

        /// <summary>
        /// get all attributes from <see cref="Type"/>
        /// </summary>
        /// <param name="type"><see cref="Type"/></param>

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (attributeMapper.TryGetValue(type, out Attribute[] attributes) == false)
            {
                attributeMapper[type] = attributes = type.GetCustomAttributes().OfType<Attribute>().ToArray();
            }

            return attributes;
        }

        /// <summary>
        /// get all attributes from <see cref="PropertyInfo"/>
        /// </summary>
        /// <param name="property"><see cref="PropertyInfo"/></param>

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this PropertyInfo property)
        {
            if (property is null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (attributeMapper.TryGetValue(property, out Attribute[] attributes) == false)
            {
                attributeMapper[property] = attributes = property.GetCustomAttributes().OfType<Attribute>().ToArray();
            }

            return attributes;
        }
        /// <summary>
        /// get all attributes from <see cref="FieldInfo"/>
        /// </summary>
        /// <param name="field"><see cref="FieldInfo"/></param>

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this FieldInfo field)
        {
            if (field is null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (attributeMapper.TryGetValue(field, out Attribute[] attributes) == false)
            {
                attributeMapper[field] = attributes = field.GetCustomAttributes().OfType<Attribute>().ToArray();
            }

            return attributes;
        }



        /// <summary>
        /// get all attributes from <see cref="MemberInfo"/>
        /// </summary>
        /// <param name="member"><see cref="MemberInfo"/></param>

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this MemberInfo member)
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (attributeMapper.TryGetValue(member, out Attribute[] attributes) == false)
            {
                attributeMapper[member] = attributes = member.GetCustomAttributes().OfType<Attribute>().ToArray();
            }

            return attributes;
        }


        /// <summary>
        /// get all attributes from <see cref="Enum"/>
        /// </summary>
        /// <param name="enumValue"><see cref="Enum"/></param>

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes(this Enum enumValue)
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

                attributeMapper[enumValue] = attributes = field.GetCustomAttributes().OfType<Attribute>().ToArray();
            }

            return attributes;
        }
    }
}