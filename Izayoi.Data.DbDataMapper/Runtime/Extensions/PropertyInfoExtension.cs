// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Extensions
// @Class     : PropertyInfoExtension
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Extensions
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Property Info Extension
    /// </summary>
    public static class PropertyInfoExtension
    {
        /// <summary>
        /// Whether the specified property info have the specified custom attribute.
        /// </summary>
        /// <typeparam name="T">The type of the custom attribute to search for.</typeparam>
        /// <param name="propertyInfo">A PropertyInfo class.</param>
        /// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of element for custom attribute.</param>
        /// <returns><see langword="true" /> if the specified property info has the specified custom attribute; <see langword="false" /> otherwise.</returns>
        public static bool HasCustomAttribute<T>(this PropertyInfo propertyInfo, bool inherit)
             where T : Attribute
        {
            return propertyInfo.GetCustomAttribute<T>(inherit) is not null;
        }

        /// <summary>
        /// Whether the specified property info have the specified custom attribute.
        /// </summary>
        /// <typeparam name="T">The type of the custom attribute to search for.</typeparam>
        /// <param name="propertyInfo">A PropertyInfo class.</param>
        /// <param name="type">A type of the custom attribute to search for.</param>
        /// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of element for custom attribute.</param>
        /// <returns><see langword="true" /> if the specified property info has the specified custom attribute; <see langword="false" /> otherwise.</returns>
        public static bool HasCustomAttribute<T>(this PropertyInfo propertyInfo, Type type, bool inherit)
             where T : Attribute
        {
            return Attribute.GetCustomAttribute(propertyInfo, type, inherit) is not null;
        }
    }
}
