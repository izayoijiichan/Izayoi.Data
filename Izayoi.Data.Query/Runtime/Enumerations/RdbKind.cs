// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Enum      : RdbKind
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Relational Database Kind
    /// </summary>
    public enum RdbKind
    {
        /// <summary></summary>
        None = 0,
        /// <summary>MySQL</summary>
        Mysql,
        /// <summary>Oracle Database</summary>
        Oracle,
        /// <summary>PostgreSQL</summary>
        Pgsql,
        /// <summary>SQLite</summary>
        Sqlite,
        /// <summary>Microsoft SQL Server or Azure SQL databases</summary>
        SqlServer,
    }
}
