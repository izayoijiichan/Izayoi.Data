// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : BindParameter
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Bind Parameter
    /// </summary>
    public class BindParameter : DbParameter, IDbParameter
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BindParameter class.
        /// </summary>
        public BindParameter()
        {
            ParameterName = string.Empty;

            DbType = DbType.String;

            Direction = ParameterDirection.Input;

            IsNullable = false;

            Precision = 0;

            Scale = 0;

            Size = 0;

            SourceColumn = string.Empty;

            SourceColumnNullMapping = false;

            Value = null;
        }

        /// <summary>
        /// Initializes a new instance of the BindParameter class with the specified parameterName and value.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="value">The value of the parameter.</param>
        public BindParameter(string parameterName, object value)
        {
            ParameterName = parameterName;

            DbType = DbTypeUtility.JudgeDbType(value);

            Direction = ParameterDirection.Input;

            IsNullable = false;

            Precision = 0;

            Scale = 0;

            Size = 0;

            SourceColumn = string.Empty;

            SourceColumnNullMapping = false;

            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the BindParameter class with the specified parameterName, value and dbType.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="dbType">The DB type of the parameter.</param>
        public BindParameter(string parameterName, object value, DbType dbType)
        {
            ParameterName = parameterName;

            DbType = dbType;

            Direction = ParameterDirection.Input;

            IsNullable = false;

            Precision = 0;

            Size = 0;

            SourceColumn = string.Empty;

            SourceColumnNullMapping = false;

            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the BindParameter class with the specified dbParameter.
        /// </summary>
        /// <param name="dbParameter">The db parameter.</param>
        public BindParameter(DbParameter dbParameter)
        {
            ParameterName = dbParameter.ParameterName;

            DbType = dbParameter.DbType;

            Direction = dbParameter.Direction;

            IsNullable = dbParameter.IsNullable;

            Precision = dbParameter.Precision;

            Scale = dbParameter.Scale;

            Size = dbParameter.Size;

            SourceColumn = dbParameter.SourceColumn;

            SourceColumnNullMapping = dbParameter.SourceColumnNullMapping;

            Value = dbParameter.Value;
        }

        #endregion

        #region Properties

        public override DbType DbType { get; set; }

        public override ParameterDirection Direction { get; set; }

        public override bool IsNullable { get; set; }

        [DefaultValue("")]
        [AllowNull]
        public override string ParameterName { get; set; }

        //public override byte Precision { get; set; }

        //public override byte Scale { get; set; }

        public override int Size { get; set; }

        [DefaultValue("")]
        [AllowNull]
        public override string SourceColumn { get; set; }

        public override bool SourceColumnNullMapping { get; set; }

        public override DataRowVersion SourceVersion { get; set; }

        public override object? Value { get; set; }

        #endregion

        #region Methods

        public override void ResetDbType()
        {
            DbType = DbType.String;
        }

        public override string ToString()
        {
            return $"{nameof(ParameterName)}: {ParameterName}, {nameof(DbType)}: {DbType}, {nameof(Value)}: {Value}";
        }

        #endregion
    }
}
