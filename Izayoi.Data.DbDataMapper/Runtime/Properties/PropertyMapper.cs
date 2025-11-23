// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Class     : PropertyMapper
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data
{
    using Izayoi.Data.Extensions;
    using System;
    using System.Collections.Concurrent;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection;

    /// <summary>
    /// Property Mapper
    /// </summary>
    /// <remarks>
    /// Key: PropertyName (ColumnName), Value: MapperPropertyInfo
    /// </remarks>
    public class PropertyMapper : ConcurrentDictionary<string, MapperPropertyInfo>
    {
        #region Methods

        ///// <summary>
        ///// Create new property mapper of the specified object type.
        ///// </summary>
        ///// <param name="objectType"></param>
        ///// <returns>The property mapper of the specified object type.</returns>
        //public static PropertyMapper Create(Type objectType)
        //{
        //    PropertyInfo[] properties = objectType.GetProperties();

        //    PropertyMapper propertyMapper = [];

        //    foreach (PropertyInfo property in properties)
        //    {
        //        propertyMapper.TryAdd(property.Name, property);
        //    }

        //    return propertyMapper;
        //}

        /// <summary>
        /// Create new column name mapper of the specified object type.
        /// </summary>
        /// <param name="objectType">The object type for which you want to get the column name mapper.</param>
        /// <param name="inheritColumnAttribute">If <see langword="true" />, specifies to also search the ancestors of element for ColumnAttribute.</param>
        /// <param name="inheritKeyAttribute">If <see langword="true" />, specifies to also search the ancestors of element for KeyAttribute.</param>
        /// <param name="inheritNotMappedAttribute">If <see langword="true" />, specifies to also search the ancestors of element for NotMappedAttribute.</param>
        /// <returns>The column name mapper of the specified object type.</returns>
        public static PropertyMapper CreateColumnNameMapper(
            Type objectType,
            bool inheritColumnAttribute = false,
            bool inheritKeyAttribute = false,
            bool inheritNotMappedAttribute = false)
        {
            PropertyInfo[] properties = objectType.GetProperties();

            PropertyMapper propertyMapper = new();

            bool foundKey = false;

            foreach (PropertyInfo property in properties)
            {
                bool isNotMapped = property.HasCustomAttribute<NotMappedAttribute>(AttributeType.NotMapped, inheritNotMappedAttribute);

                if (isNotMapped)
                {
                    continue;
                }

                MapperPropertyInfo mapperProperty = new MapperPropertyInfo(property);

                string columnNameOrPropertyName = mapperProperty.GetColumnNameOrPropertyName(inheritColumnAttribute);

                if (propertyMapper.ContainsKey(columnNameOrPropertyName))
                {
                    throw new FormatException($"The {objectType} contains duplicate column name. {columnNameOrPropertyName}");
                }

                bool isKey;

                if (foundKey)
                {
                    isKey = false;  // @notice Omitted for speed optimization.
                }
                else
                {
                    isKey = property.HasCustomAttribute<KeyAttribute>(AttributeType.Key, inheritKeyAttribute);

                    if (isKey)
                    {
                        foundKey = true;
                    }
                }

                mapperProperty.IsKey = isKey;

                mapperProperty.IsNotMapped = isNotMapped;

                propertyMapper.TryAdd(columnNameOrPropertyName, mapperProperty);
            }

            return propertyMapper;
        }

        #endregion
    }
}
