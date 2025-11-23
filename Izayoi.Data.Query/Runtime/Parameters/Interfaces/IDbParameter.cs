// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Interface : IDbParameter
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System.Data;

    /// <summary>
    /// DB Parameter Interface
    /// </summary>
    public interface IDbParameter : IDbDataParameter
    {
        #region Properties

        //DbType DbType { get; set; }

        //ParameterDirection Direction { get; set; }

        //bool IsNullable { get; set; }

        //string ParameterName { get; set; }

        //byte Precision { get; set; }

        //byte Scale { get; set; }

        //int Size { get; set; }

        //string SourceColumn { get; set; }

        bool SourceColumnNullMapping { get; set; }

        //DataRowVersion SourceVersion { get; set; }

        //object? Value { get; set; }

        #endregion

        #region Methods

        //void ResetDbType();

        #endregion
    }
}
