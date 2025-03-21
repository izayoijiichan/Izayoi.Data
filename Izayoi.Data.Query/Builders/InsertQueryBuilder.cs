// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : InsertQueryBuilder
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Insert Query Builder
    /// </summary>
    public class InsertQueryBuilder : SelectQueryBuilderBase, IInsertQueryBuilder
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the InsertQueryBuilder class.
        /// </summary>
        public InsertQueryBuilder() : base() { }

        /// <summary>
        /// Initializes a new instance of the InsertQueryBuilder class with the specified queryOption.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        public InsertQueryBuilder(QueryOption queryOption) : base(queryOption) { }

        /// <summary>
        /// Initializes a new instance of the InsertQueryBuilder class with the specified queryOption, stringBuilder and bindParameters.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="bindParameters">The bind parameters.</param>
        public InsertQueryBuilder(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)
            : base(queryOption, stringBuilder, bindParameters) { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the specified insert.
        /// </summary>
        /// <param name="insert">An insert source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        public virtual bool Build(in Insert insert)
        {
            Clean();

            return BuildQuery(insert);
        }

        #endregion

        #region Protected Methods

        protected virtual bool BuildQuery(in Insert insert)
        {
            // WITH
            AppendWith(insert.With);

            bool existsValues = insert.Values.Count > 0;
            bool existsSelect = insert.Select is not null;

            // INSERT INTO
            AppendInsertInto(insert.Into);

            if ((existsValues == true && existsSelect == true) ||
                (existsValues == false && existsSelect == false))
            {
                throw new ArgumentException("Only one of Value and Select can be specified.");
            }

            if (existsValues)
            {
                // column list
                AppendColumnList(insert.Values);

                // VALUES
                AppendValues(insert.Values);

                AddBindParameters(insert.Values);
            }
            else if (insert.Select is not null)
            {
                // column list
                AppendColumnList(insert.ColumnList);

                _stringBuilder.AppendLine();

                // SELECT
                BuildQuery(insert.Select);
            }

            return true;
        }

        protected virtual void AppendInsertInto(in TableSource into)
        {
            if (_option.EnableFormat)
            {
                _stringBuilder
                    .AppendLine("INSERT")
                    .Append("INTO ")
                    .Append(into.GetSchemaDotTableAsAlias(_option.QuotationMarks));
            }
            else
            {
                _stringBuilder
                    .Append("INSERT INTO ")
                    .Append(into.GetSchemaDotTableAsAlias(_option.QuotationMarks));
            }
        }

        protected virtual void AppendColumnList(in Fields? fields)
        {
            if (fields is null)
            {
                return;
            }

            if (fields.Count == 0)
            {
                return;
            }

            string[] columnNames = fields
                .Select(field => field.GetAliasOrFieldName(_option.QuotationMarks))
                .ToArray();

            if (_option.EnableFormat == false)
            {
                _stringBuilder
                    .AppendLine()
                    .Append('(')
                    .Append(string.Join(", ", columnNames))
                    .Append(')');
                return;
            }

            int indent = GetFixedIndentCount();

            _stringBuilder
                .AppendLine()
                .Append('(');

            if (_option.BeforeComma)
            {
                for (int index = 0; index < columnNames.Length; index++)
                {
                    string columnName = columnNames[index];

                    _stringBuilder.AppendLine();

                    if (index == 0)
                    {
                        _stringBuilder.Append(new string(' ', indent));
                    }
                    else
                    {
                        if (indent >= 3)
                        {
                            _stringBuilder.Append(new string(' ', indent - 2));
                        }

                        _stringBuilder.Append(", ");
                    }

                    _stringBuilder.Append(columnName);
                }
            }
            else  // After Comma
            {
                for (int index = 0; index < columnNames.Length; index++)
                {
                    string columnName = columnNames[index];

                    _stringBuilder
                        .AppendLine()
                        .Append(new string(' ', indent))
                        .Append(columnName);

                    if (index < columnNames.Length - 1)
                    {
                        _stringBuilder.Append(',');
                    }
                }
            }

            _stringBuilder
                .AppendLine()
                .Append(')');
        }

        protected virtual void AppendColumnList(in Values values)
        {
            if (values.Count == 0)
            {
                return;
            }

            string[] columnNames = values
                .Select(value => _option.QuotationMarks.Enclose(value.ColumnName))
                .ToArray();

            if (_option.EnableFormat == false)
            {
                _stringBuilder
                    .AppendLine()
                    .Append('(')
                    .Append(string.Join(", ", columnNames))
                    .Append(')');

                return;
            }

            int indent = GetFixedIndentCount();

            _stringBuilder
                .AppendLine()
                .Append('(');

            if (_option.BeforeComma)
            {
                for (int index = 0; index < columnNames.Length; index++)
                {
                    string columnName = columnNames[index];

                    _stringBuilder.AppendLine();

                    if (index == 0)
                    {
                        _stringBuilder.Append(new string(' ', indent));
                    }
                    else
                    {
                        if (indent >= 3)
                        {
                            _stringBuilder.Append(new string(' ', indent - 2));
                        }

                        _stringBuilder.Append(", ");
                    }

                    _stringBuilder.Append(columnName);
                }
            }
            else  // After Comma
            {
                for (int index = 0; index < columnNames.Length; index++)
                {
                    string columnName = columnNames[index];

                    _stringBuilder
                        .AppendLine()
                        .Append(new string(' ', indent))
                        .Append(columnName);

                    if (index < columnNames.Length - 1)
                    {
                        _stringBuilder.Append(',');
                    }
                }
            }

            _stringBuilder
                .AppendLine()
                .Append(')');
        }

        protected virtual void AppendValues(in Values values)
        {
            if (values.Count == 0)
            {
                return;
            }

            string[] parameterNames = values
                .Select((value, index) => $"@v_{index}")
                .ToArray();

            _stringBuilder
                .AppendLine()
                .AppendLine("VALUES");

            if (_option.EnableFormat == false)
            {
                _stringBuilder.Append('(');

                for (int index = 0; index < values.Count; index++)
                {
                    Value value = values[index];

                    if (index > 0)
                    {
                        _stringBuilder.Append(", ");
                    }

                    if (value.IsExpression)
                    {
                        _stringBuilder.Append(value.Value_);
                    }
                    else
                    {
                        _stringBuilder.Append(parameterNames[index]);
                    }
                }

                _stringBuilder.Append(')');

                return;
            }

            int indent = GetFixedIndentCount();

            _stringBuilder
                .Append('(');

            if (_option.BeforeComma)
            {
                for (int index = 0; index < values.Count; index++)
                {
                    Value value = values[index];

                    _stringBuilder.AppendLine();

                    if (index == 0)
                    {
                        _stringBuilder.Append(new string(' ', indent));
                    }
                    else
                    {
                        if (indent >= 3)
                        {
                            _stringBuilder.Append(new string(' ', indent - 2));
                        }

                        _stringBuilder.Append(", ");
                    }

                    if (value.IsExpression)
                    {
                        _stringBuilder.Append(value.Value_);
                    }
                    else
                    {
                        _stringBuilder.Append(parameterNames[index]);
                    }
                }
            }
            else  // After Comma
            {
                for (int index = 0; index < values.Count; index++)
                {
                    Value value = values[index];

                    _stringBuilder
                        .AppendLine()
                        .Append(new string(' ', indent));

                    if (value.IsExpression)
                    {
                        _stringBuilder.Append(value.Value_);
                    }
                    else
                    {
                        _stringBuilder.Append(parameterNames[index]);
                    }

                    if (index < values.Count - 1)
                    {
                        _stringBuilder.Append(',');
                    }
                }
            }

            _stringBuilder
                .AppendLine()
                .Append(')');
        }

        protected virtual void AddBindParameters(in Values values)
        {
            for (int index = 0; index < values.Count; index++)
            {
                Value value = values[index];

                if (value.IsExpression)
                {
                    continue;
                }

                string parameterName = $"@v_{index}";

                _bindParameters.Add(new BindParameter(parameterName, value.Value_, value.DbType));
            }
        }

        #endregion
    }
}
