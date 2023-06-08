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
        private static readonly ConcurrentDictionary<string, Attribute[]> attributeMapper = new();
         
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

            string key = $"{member.DeclaringType.Namespace}.{member.DeclaringType.Name}";

            if (attributeMapper.TryGetValue(key, out Attribute[] attributes) == false)
            { 
                attributeMapper[key] = attributes = member.GetCustomAttributes().OfType<Attribute>().ToArray();
            }

            return attributes.OfType<TAttribute>().FirstOrDefault();
        }


        /// <summary>
        ///   get  <typeparamref name="TAttribute"/>  from <see cref="Enum"/>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"><see cref="Enum"/></param>

        /// <returns></returns>
        public static TAttribute GetAttribute<TEnum, TAttribute>(this TEnum enumValue)
            where TEnum : struct, Enum
            where TAttribute : Attribute
        {

            ICollection<Attribute> attributes = GetAttributes(enumValue);

            return attributes?.OfType<TAttribute>().FirstOrDefault()!;
        }

     
         

        /// <summary>
        /// get all attributes from  <typeparamref name="TEnum"/>
        /// </summary>
        /// <param name="enumValue"><typeparamref name="TEnum"/></param>

        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static Attribute[] GetAttributes<TEnum>(this TEnum enumValue) where TEnum : struct, Enum
        { 
            Type type = enumValue.GetType();

            string enumName = Enum.GetName(type, enumValue);

            string key = $"{type.Namespace}.{type.Name}.{enumName}";

            if (attributeMapper.TryGetValue(key, out Attribute[] attributes) == false)
            {
                FieldInfo field = type.GetField(enumName);

                attributeMapper[key] = attributes = field.GetCustomAttributes().OfType<Attribute>().ToArray();
            }

            return attributes;
        }
         
    }
}