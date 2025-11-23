// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data
// @Class     : DbDataMapperOption
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data
{
    /// <summary>
    /// DB data mapper option
    /// </summary>
    public class DbDataMapperOption
    {
        #region Properties

        /// <summary>Gets or sets whether ignore exception.</summary>
        /// <remarks>If <see langword="true" />, exceptions raised by SetPropertyValueAsync method are ignored.</remarks>
        public bool IgnoreException { get; set; } = false;

        /// <summary>Gets or sets whether inherit [Column] attribute.</summary>
        public bool InheritColumnAttribute { get; set; } = true;

        /// <summary>Gets or sets whether inherit [Key] attribute.</summary>
        public bool InheritKeyAttribute { get; set; } = true;

        /// <summary>Gets or sets whether inherit [NotMapped] attribute.</summary>
        public bool InheritNotMappedAttribute { get; set; } = true;

        #endregion
    }
}
