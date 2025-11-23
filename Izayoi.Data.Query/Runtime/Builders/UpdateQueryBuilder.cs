// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : UpdateQueryBuilder
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Update Query Builder
    /// </summary>
    public class UpdateQueryBuilder : SelectQueryBuilderBase, IUpdateQueryBuilder
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UpdateQueryBuilder class.
        /// </summary>
        public UpdateQueryBuilder() : base() { }

        /// <summary>
        /// Initializes a new instance of the UpdateQueryBuilder class with the specified queryOption.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        public UpdateQueryBuilder(QueryOption queryOption) : base(queryOption) { }

        /// <summary>
        /// Initializes a new instance of the UpdateQueryBuilder class with the specified queryOption, stringBuilder and bindParameters.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="bindParameters">The bind parameters.</param>
        public UpdateQueryBuilder(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)
            : base(queryOption, stringBuilder, bindParameters) { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the specified update.
        /// </summary>
        /// <param name="update">An update source.</param>
        /// <returns><see langword="true" /> if the query and parameter was successfully built; otherwise, <see langword="false" />.</returns>
        public virtual bool Build(in Update update)
        {
            Clean();

            return BuildQuery(update);
        }

        #endregion

        #region Protected Methods

        protected virtual bool BuildQuery(in Update update)
        {
            // WITH
            AppendWith(update.With);

            // UPDATE
            AppendUpdate(update.TableSource, update.From);

            if (_option.RdbKind == RdbKind.Mysql)
            {
                // JOIN
                if (update.TableSource.Joins.Count > 0)
                {
                    AppendJoin(update.TableSource.Joins);
                }
                else if (update.From != null && update.From.Joins.Count > 0)
                {
                    AppendJoin(update.From.Joins);
                }
            }

            // SET
            AppendSets(update.Sets);
            AddBindParameters(update.Sets);

            if (_option.RdbKind == RdbKind.Pgsql ||
                _option.RdbKind == RdbKind.Sqlite ||
                _option.RdbKind == RdbKind.SqlServer)
            {
                // FROM
                // JOIN
                AppendJoin(update.From);
            }

            // WHERE
            AppendWhere(update.Wheres);

            return true;
        }

        protected virtual void AppendUpdate(in TableSource tableSource, in From? from)
        {
            if (_option.EnableFormat)
            {
                int indent = GetFixedIndentCount();

                _stringBuilder
                    .AppendLine("UPDATE")
                    .Append(new string(' ', indent));
            }
            else
            {
                _stringBuilder.Append("UPDATE ");
            }

            if ((tableSource.Joins.Count > 0) || (from != null && from.Joins.Count > 0))
            {
                if (tableSource.TableName.Length == 0)
                {
                    _stringBuilder.Append(tableSource.GetSchemaDotTableOrAlias(_option.QuotationMarks));
                }
                else
                {
                    _stringBuilder.Append(tableSource.GetSchemaDotTableAsAlias(_option.QuotationMarks));
                }
            }
            else
            {
                _stringBuilder.Append(tableSource.GetSchemaDotTable(_option.QuotationMarks));

                return;
            }
        }

        protected virtual void AppendJoin(in From? from)
        {
            if (from is null)
            {
                return;
            }

            if (from.Joins.Count == 0)
            {
                return;
            }

            if (_option.RdbKind == RdbKind.Mysql)
            {
                // JOIN
                AppendJoin(from.Joins);
            }
            else if (_option.RdbKind == RdbKind.Pgsql)
            {
                // FROM
                AppendFrom(from);

                // JOIN
                AppendJoin(from.Joins);
            }
            else if (_option.RdbKind == RdbKind.Sqlite)
            {
                // FROM
                AppendFrom(from);

                // JOIN
                AppendJoin(from.Joins);
            }
            else if (_option.RdbKind == RdbKind.SqlServer)
            {
                // FROM
                AppendFrom(from);

                // JOIN
                AppendJoin(from.Joins);
            }
        }

        protected virtual void AppendSets(in Sets sets)
        {
            if (sets.Count == 0)
            {
                return;
            }

            string[] parameterNames = sets
                .Select((value, index) => $"@s_{index}")
                .ToArray();

            int indent = GetFixedIndentCount();

            _stringBuilder
                .AppendLine()
                .Append("SET");

            if (_option.EnableFormat == false)
            {
                for (int index = 0; index < sets.Count; index++)
                {
                    Set set = sets[index];

                    _stringBuilder
                        .Append(' ')
                        .Append(set.GetColumnName(_option.QuotationMarks))
                        .Append(" = ");

                    if (set.IsExpression)
                    {
                        _stringBuilder.Append(set.Value);
                    }
                    else
                    {
                        _stringBuilder.Append(parameterNames[index]);
                    }

                    if (index < sets.Count - 1)
                    {
                        _stringBuilder.Append(',');
                    }
                }

                return;
            }

            if (_option.BeforeComma)
            {
                for (int index = 0; index < sets.Count; index++)
                {
                    Set set = sets[index];

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

                    _stringBuilder
                        .Append(set.GetColumnName(_option.QuotationMarks))
                        .Append(" = ");

                    if (set.IsExpression)
                    {
                        _stringBuilder.Append(set.Value);
                    }
                    else
                    {
                        _stringBuilder.Append(parameterNames[index]);
                    }
                }
            }
            else  // After Comma
            {
                for (int index = 0; index < sets.Count; index++)
                {
                    Set set = sets[index];

                    _stringBuilder
                        .AppendLine()
                        .Append(new string(' ', indent))
                        .Append(set.GetColumnName(_option.QuotationMarks))
                        .Append(" = ");

                    if (set.IsExpression)
                    {
                        _stringBuilder.Append(set.Value);
                    }
                    else
                    {
                        _stringBuilder.Append(parameterNames[index]);
                    }

                    if (index < sets.Count - 1)
                    {
                        _stringBuilder.Append(',');
                    }
                }
            }
        }

        protected virtual void AddBindParameters(in Sets sets)
        {
            for (int index = 0; index < sets.Count; index++)
            {
                Set set = sets[index];

                if (set.IsExpression)
                {
                    continue;
                }

                string parameterName = $"@s_{index}";

                _bindParameters.Add(new BindParameter(parameterName, set.Value, set.DbType));
            }
        }

        #endregion
    }
}
