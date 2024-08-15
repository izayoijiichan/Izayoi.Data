// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Enum      : OpType
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Operator Type
    /// </summary>
    public enum OpType
    {
        /// <summary></summary>
        None = 0,
        /// <summary>LIKE string_expression</summary>
        LIKE,
        /// <summary>NOT LIKE string_expression</summary>
        NOT_LIKE,
        /// <summary>BETWEEN expression AND expression</summary>
        BETWEEN,
        /// <summary>NOT BETWEEN expression AND expression</summary>
        NOT_BETWEEN,
        /// <summary>IS NULL</summary>
        IS_NULL,
        /// <summary>IS NOT NULL</summary>
        IS_NOT_NULL,
        /// <summary>IN</summary>
        IN,
        /// <summary>NOT IN</summary>
        NOT_IN,
        /// <summary>=</summary>
        EQUAL,
        /// <summary>!=</summary>
        NOT_EQUAL,
    }
}
