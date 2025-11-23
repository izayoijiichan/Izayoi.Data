// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Class     : AttributeType
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Attribute Type
    /// </summary>
    public class AttributeType
    {
        /// <summary>The type of the ColumnAttribute.</summary>
        public static readonly Type Column = typeof(ColumnAttribute);

        /// <summary>The type of the KeyAttribute.</summary>
        public static readonly Type Key = typeof(KeyAttribute);

        /// <summary>The type of the NotMappedAttribute.</summary>
        public static readonly Type NotMapped = typeof(NotMappedAttribute);
    }
}
