// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : SelectQueryBuilderBase
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Base Select Query Builder
    /// </summary>
    public abstract class SelectQueryBuilderBase : QueryBuilderBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SelectQueryBuilderBase class.
        /// </summary>
        public SelectQueryBuilderBase() : base() { }

        /// <summary>
        /// Initializes a new instance of the SelectQueryBuilderBase class with the specified queryOption.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        public SelectQueryBuilderBase(QueryOption queryOption) : base(queryOption) { }

        /// <summary>
        /// Initializes a new instance of the SelectQueryBuilderBase class with the specified queryOption, stringBuilder and bindParameters.
        /// </summary>
        /// <param name="queryOption">The query option.</param>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="bindParameters">The bind parameters.</param>
        public SelectQueryBuilderBase(QueryOption queryOption, StringBuilder stringBuilder, BindParameterCollection bindParameters)
            : base(queryOption, stringBuilder, bindParameters) { }

        #endregion

        #region Protected Select Methods

        protected virtual bool BuildQuery(in Select select)
        {
            // SELECT
            AppendSelect(select.Type, select.Fields, select.From, select.Offset, select.Limit);

            // FROM
            AppendFrom(select.From);

            // JOIN
            AppendJoin(select.From.Joins);

            // WHERE
            AppendWhere(select.Wheres);

            // GROUP BY
            AppendGroupBy(select.Groups);

            // HAVING
            AppendHaving(select.Havings);

            // ORDER BY
            AppendOrderBy(select.Orders);

            // LIMIT
            AppendLimit(select.Limit);

            // OFFSET
            AppendOffset(select.Offset);

            // OFFSET FETCH (SQLServer)
            AppendOffsetFetch(select.Offset, select.Limit, select.Orders.Any());

            // FOR
            AppendFor(select.For);

            return true;
        }

        #endregion

        #region Select Methods

        protected virtual void AppendSelect(in SType type, in Fields fields, in From from, int offset, int limit)
        {
            // SELECT
            {
                _stringBuilder.Append("SELECT");

                if (type == SType.ALL)
                {
                    _stringBuilder
                        .Append(' ')
                        .Append("ALL");
                }
                else if (type == SType.DISTINCT)
                {
                    _stringBuilder
                        .Append(' ')
                        .Append("DISTINCT");
                }
            }

            // TOP (SQLServer)
            AppendTop(offset, limit);

            // LIST
            AppendSelectList(fields, from);
        }

        protected virtual void AppendTop(int offset, int limit)
        {
            if (_option.RdbKind == RdbKind.SqlServer)
            {
                if (limit <= 0)
                {
                    return;
                }

                if (offset <= 0)
                {
                    if (_option.EnableFormat)
                    {
                        _stringBuilder.AppendLine();

                    }
                    else
                    {
                        _stringBuilder.Append(' ');
                    }

                    _stringBuilder.Append("TOP " + limit);
                }
            }
        }

        protected virtual void AppendSelectList(in Fields fields, in From from)
        {
            if (fields.Count == 0)
            {
                string table = from.GetSchemaDotTableOrAlias(_option.QuotationMarks);

                if (_option.EnableFormat)
                {
                    int indent = GetFixedIndentCount();

                    _stringBuilder
                        .AppendLine()
                        .Append(new string(' ', indent))
                        .Append(table)
                        .Append('.')
                        .Append('*');
                }
                else
                {
                    _stringBuilder
                        .Append(' ')
                        .Append(table)
                        .Append('.')
                        .Append('*');
                }

                return;
            }

            if (_option.EnableFormat == false)
            {
                _stringBuilder
                    .Append(' ')
                    .Append(fields.ToQuery(_option.QuotationMarks));

                return;
            }

            if (_option.BeforeComma)
            {
                int indent = GetFixedIndentCount();

                for (int index = 0; index < fields.Count; index++)
                {
                    Field field = fields[index];

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

                    _stringBuilder.Append(field.ToQuery(_option.QuotationMarks));
                }
            }
            else  // After Comma
            {
                int indent = GetFixedIndentCount();

                for (int index = 0; index < fields.Count; index++)
                {
                    Field field = fields[index];

                    _stringBuilder
                        .AppendLine()
                        .Append(new string(' ', indent))
                        .Append(field.ToQuery(_option.QuotationMarks));

                    if (index < fields.Count - 1)
                    {
                        _stringBuilder.Append(',');
                    }
                }
            }
        }

        #endregion

        #region From Methods

        protected virtual void AppendFrom(in From from)
        {
            _stringBuilder.AppendLine();

            if (_option.EnableFormat)
            {
                int indent = GetFixedIndentCount();

                _stringBuilder
                    .AppendLine("FROM")
                    .Append(new string(' ', indent))
                    .Append(from.GetSchemaDotTableAsAlias(_option.QuotationMarks));
            }
            else
            {
                _stringBuilder.Append(from.ToQuery(_option.QuotationMarks, excludeJoin: true));
            }
        }

        #endregion

        #region Join Methods

        protected virtual void AppendJoin(in Joins joins)
        {
            if (joins.Count == 0)
            {
                return;
            }

            if (_option.EnableFormat == false)
            {
                _stringBuilder
                    .AppendLine()
                    .Append(joins.ToQuery(_option.QuotationMarks));

                return;
            }

            int indent = GetFixedIndentCount();

            foreach (Join join in joins)
            {
                _stringBuilder
                    .AppendLine()
                    .Append(new string(' ', indent))
                    .Append(join.Type.Name())
                    .Append(' ');

                if (join.SchemaName.Length > 0)
                {
                    _stringBuilder
                        .Append(_option.QuotationMarks.Enclose(join.SchemaName))
                        .Append('.');
                }

                _stringBuilder.Append(_option.QuotationMarks.Enclose(join.TableName));

                if (join.TableAlias.Length > 0)
                {
                    _stringBuilder
                        .Append(" AS ")
                        .Append(_option.QuotationMarks.Enclose(join.TableAlias));
                }

                _stringBuilder
                    .AppendLine()
                    .Append(new string(' ', indent * 2))
                    .Append("ON (")
                    .Append(join.Condition)
                    .Append(')');
            }
        }

        #endregion

        #region Where Methods

        protected virtual void AppendWhere(in Wheres wheres)
        {
            AppendSearchCondition(wheres, "WHERE");
        }

        #endregion

        #region Group by Methods

        protected virtual void AppendGroupBy(in Groups groups)
        {
            if (groups.Count == 0)
            {
                return;
            }

            if (_option.EnableFormat == false)
            {
                _stringBuilder
                    .AppendLine()
                    .Append(groups.ToQuery(_option.QuotationMarks));

                return;
            }

            int indent = GetFixedIndentCount();

            _stringBuilder
                .AppendLine()
                .Append("GROUP BY");

            if (_option.BeforeComma)
            {
                for (int index = 0; index < groups.Count; index++)
                {
                    string fieldExpression = groups[index];

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

                    _stringBuilder.Append(groups.GetFieldName(fieldExpression, _option.QuotationMarks));
                }
            }
            else  // After Comma
            {
                for (int index = 0; index < groups.Count; index++)
                {
                    string fieldExpression = groups[index];

                    _stringBuilder
                        .AppendLine()
                        .Append(new string(' ', indent))
                        .Append(groups.GetFieldName(fieldExpression, _option.QuotationMarks));

                    if (index < groups.Count - 1)
                    {
                        _stringBuilder.Append(',');
                    }
                }
            }
        }

        #endregion

        #region Having Methods

        protected virtual void AppendHaving(in Havings havings)
        {
            AppendSearchCondition(havings, "HAVING");
        }

        #endregion

        #region Order by Methods

        protected virtual void AppendOrderBy(in Orders orders)
        {
            if (orders.Count == 0)
            {
                return;
            }

            if (_option.EnableFormat == false)
            {
                _stringBuilder
                    .AppendLine()
                    .Append(orders.ToQuery(_option.QuotationMarks));

                return;
            }

            int indent = GetFixedIndentCount();

            _stringBuilder
                .AppendLine()
                .Append("ORDER BY");

            if (_option.BeforeComma)
            {
                for (int index = 0; index < orders.Count; index++)
                {
                    Order order = orders[index];

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

                    _stringBuilder.Append(order.ToQuery(_option.QuotationMarks));
                }
            }
            else  // After Comma
            {
                for (int index = 0; index < orders.Count; index++)
                {
                    Order order = orders[index];

                    _stringBuilder
                        .AppendLine()
                        .Append(new string(' ', indent))
                        .Append(order.ToQuery(_option.QuotationMarks));

                    if (index < orders.Count - 1)
                    {
                        _stringBuilder.Append(',');
                    }
                }
            }
        }

        #endregion

        #region Offset and Limit Methods

        protected virtual void AppendLimit(int limit)
        {
            if (limit <= 0)
            {
                return;
            }

            if (_option.RdbKind == RdbKind.SqlServer)
            {
                return;
            }

            if (_option.EnableFormat)
            {
                int indent = GetFixedIndentCount();

                _stringBuilder
                    .AppendLine()
                    .AppendLine("LIMIT")
                    .Append(new string(' ', indent))
                    .Append(limit);
            }
            else
            {
                _stringBuilder
                    .AppendLine()
                    .Append("LIMIT")
                    .Append(' ')
                    .Append(limit);

            }
        }

        protected virtual void AppendOffset(int offset)
        {
            if (offset <= 0)
            {
                return;
            }

            if (_option.RdbKind == RdbKind.SqlServer)
            {
                return;
            }

            if (_option.EnableFormat)
            {
                int indent = GetFixedIndentCount();

                _stringBuilder
                    .AppendLine()
                    .AppendLine("OFFSET")
                    .Append(new string(' ', indent))
                    .Append(offset);
            }
            else
            {
                _stringBuilder
                .AppendLine()
                    .Append("OFFSET")
                    .Append(' ')
                    .Append(offset);
            }
        }

        protected virtual void AppendOffsetFetch(int offset, int limit, bool hasOrderBy)
        {
            if (_option.RdbKind == RdbKind.SqlServer)
            {
                if (_option.RdbVersion >= 2008)
                {
                    if (hasOrderBy == false)
                    {
                        return;
                    }

                    if (offset >= 1)
                    {
                        _stringBuilder
                            .AppendLine()
                            .Append($"OFFSET {offset} ROWS");

                        if (limit >= 1)
                        {
                            _stringBuilder
                                .AppendLine()
                                .Append($"FETCH NEXT {limit} ROWS ONLY");
                        }
                    }
                }
            }
        }

        #endregion

        #region For Methods

        protected virtual void AppendFor(in For for_)
        {
            if (for_.IsEnabled == false)
            {
                return;
            }

            if (_option.RdbKind != RdbKind.SqlServer)
            {
                return;
            }

            if (for_.Json is not null)
            {
                Json json = for_.Json;

                if (json.Mode == JsonMode.None)
                {
                    return;
                }

                if (_option.EnableFormat == false)
                {
                    _stringBuilder
                        .AppendLine()
                        .Append(json.ToQuery());

                    return;
                }

                _stringBuilder
                    .AppendLine()
                    .Append($"FOR JSON {json.Mode.Name()}");

                int indent = GetFixedIndentCount();

                if (_option.BeforeComma)
                {
                    if (json.RootName is not null)
                    {
                        _stringBuilder.AppendLine();

                        if (indent >= 3)
                        {
                            _stringBuilder.Append(new string(' ', indent - 2));
                        }

                        _stringBuilder
                            .Append(", ")
                            .Append(json.GetRootNameQuery());
                    }

                    if (json.IncludeNullValues)
                    {
                        _stringBuilder.AppendLine();

                        if (indent >= 3)
                        {
                            _stringBuilder.Append(new string(' ', indent - 2));
                        }

                        _stringBuilder
                            .Append(", INCLUDE_NULL_VALUES");
                    }

                    if (json.WithoutArrayWrapper)
                    {
                        _stringBuilder.AppendLine();

                        if (indent >= 3)
                        {
                            _stringBuilder.Append(new string(' ', indent - 2));
                        }

                        _stringBuilder
                            .Append(", WITHOUT_ARRAY_WRAPPER");
                    }
                }
                else  // After Comma
                {
                    if (json.RootName is not null)
                    {
                        _stringBuilder
                            .Append(',')
                            .AppendLine()
                            .Append(new string(' ', indent))
                            .Append(json.GetRootNameQuery());
                    }

                    if (json.IncludeNullValues)
                    {
                        _stringBuilder
                            .Append(',')
                            .AppendLine()
                            .Append(new string(' ', indent))
                            .Append("INCLUDE_NULL_VALUES");
                    }

                    if (json.WithoutArrayWrapper)
                    {
                        _stringBuilder
                            .Append(',')
                            .AppendLine()
                            .Append(new string(' ', indent))
                            .Append("WITHOUT_ARRAY_WRAPPER");
                    }
                }
            }
        }

        #endregion

        #region Search Condition Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchConditions"></param>
        /// <param name="clauseName">WHERE or HAVING</param>
        protected virtual void AppendSearchCondition(in SearchConditions searchConditions, in string clauseName)
        {
            if (searchConditions.Count == 0)
            {
                return;
            }

            string parameterPrefix;

            if (clauseName == "WHERE")
            {
                parameterPrefix = "w";
            }
            else if (clauseName == "HAVING")
            {
                parameterPrefix = "h";
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(clauseName));
            }

            int indent = GetFixedIndentCount();

            _stringBuilder
                .AppendLine()
                .Append(clauseName);

            for (int whereIndex = 0; whereIndex < searchConditions.Count; whereIndex++)
            {
                SearchCondition sc = searchConditions[whereIndex];

                if (sc.Connector == CType.AND)
                {
                    if (_option.EnableFormat)
                    {
                        _stringBuilder
                            .AppendLine()
                            .Append("  AND");
                    }
                    else
                    {
                        _stringBuilder.Append(" AND ");
                    }
                }
                else if (sc.Connector == CType.OR)
                {
                    if (_option.EnableFormat)
                    {
                        _stringBuilder
                            .AppendLine()
                            .Append("  OR");
                    }
                    else
                    {
                        _stringBuilder.Append(" OR ");
                    }
                }
                else
                {
                    if (_option.EnableFormat)
                    {
                        //
                    }
                    else
                    {
                        _stringBuilder.Append(' ');
                    }
                }

                if (sc.EnclosureL != char.MinValue)
                {
                    if (_option.EnableFormat)
                    {
                        _stringBuilder
                            .AppendLine()
                            .Append(new string(' ', indent))
                            .Append(sc.EnclosureL);
                    }
                    else
                    {
                        _stringBuilder.Append(sc.EnclosureL);
                    }
                }

                if (_option.EnableFormat)
                {
                    _stringBuilder
                        .AppendLine()
                        .Append(new string(' ', indent));
                }

                _stringBuilder
                    .Append(sc.GetFieldName(_option.QuotationMarks))
                    .Append(' ');

                if (sc.OpType == OpType.BETWEEN ||
                    sc.OpType == OpType.NOT_BETWEEN ||
                    sc.Operator.ToUpper().Equals("BETWEEN", StringComparison.OrdinalIgnoreCase) ||
                    sc.Operator.ToUpper().Equals("NOT BETWEEN", StringComparison.OrdinalIgnoreCase))
                {
                    string parameterName1 = $"@{parameterPrefix}_{whereIndex}_0";
                    string parameterName2 = $"@{parameterPrefix}_{whereIndex}_1";

                    if (sc.OpType == OpType.BETWEEN)
                    {
                        _stringBuilder.Append("BETWEEN");
                    }
                    else if (sc.OpType == OpType.NOT_BETWEEN)
                    {
                        _stringBuilder.Append("NOT BETWEEN");
                    }
                    else
                    {
                        _stringBuilder.Append(sc.Operator);
                    }

                    _stringBuilder
                        .Append(' ')
                        .Append(parameterName1)
                        .Append(' ')
                        .Append("AND")
                        .Append(' ')
                        .Append(parameterName2);

                    if (sc.Value is not IEnumerable enumerableValue)
                    {
                        throw new InvalidCastException();
                    }

                    int valueCount = 1;

                    foreach (object value in enumerableValue)
                    {
                        if (valueCount == 1)
                        {
                            _bindParameters.Add(new BindParameter(parameterName1, value, sc.DbType));
                        }
                        else if (valueCount == 2)
                        {
                            _bindParameters.Add(new BindParameter(parameterName2, value, sc.DbType));
                        }
                        else
                        {
                            break;
                        }

                        valueCount++;
                    }
                }
                else if (
                    sc.OpType == OpType.IN ||
                    sc.OpType == OpType.NOT_IN ||
                    sc.Operator.ToUpper().Equals("IN", StringComparison.OrdinalIgnoreCase) ||
                    sc.Operator.ToUpper().Equals("NOT IN", StringComparison.OrdinalIgnoreCase))
                {
                    if (sc.OpType == OpType.IN)
                    {
                        _stringBuilder.Append("IN");
                    }
                    else if (sc.OpType == OpType.NOT_IN)
                    {
                        _stringBuilder.Append("NOT IN");
                    }
                    else
                    {
                        _stringBuilder.Append(sc.Operator);
                    }

                    _stringBuilder
                        .Append(' ')
                        .Append('(');

                    if (sc.Value is IEnumerable enumerableValue)
                    {
                        int valueIndex = 0;

                        foreach (object value in enumerableValue)
                        {
                            if (valueIndex >= 1)
                            {
                                _stringBuilder.Append(", ");
                            }

                            string parameterName = $"@{parameterPrefix}_{whereIndex}_{valueIndex}";

                            _stringBuilder.Append(parameterName);

                            _bindParameters.Add(new BindParameter(parameterName, value, sc.DbType));

                            valueIndex++;
                        }
                    }
                    else
                    {
                        string parameterName = $"@{parameterPrefix}_{whereIndex}";

                        if (sc.Value is null)
                        {
                            throw new Exception();
                        }

                        _stringBuilder.Append(parameterName);

                        _bindParameters.Add(new BindParameter(parameterName, sc.Value, sc.DbType));
                    }

                    _stringBuilder.Append(')');
                }
                else if (
                    sc.OpType == OpType.IS_NULL ||
                    sc.OpType == OpType.IS_NOT_NULL ||
                    sc.Operator.ToUpper().StartsWith("IS", StringComparison.OrdinalIgnoreCase))
                {
                    if (sc.OpType == OpType.IS_NULL)
                    {
                        _stringBuilder.Append("IS NULL");
                    }
                    else if (sc.OpType == OpType.IS_NOT_NULL)
                    {
                        _stringBuilder.Append("IS NOT NULL");
                    }
                    else if (
                        sc.Operator.ToUpper() == "IS" ||
                        sc.Operator.ToUpper() == "IS NOT")
                    {
                        _stringBuilder.Append(sc.Operator.ToUpper());

                        if (sc.Value is null)
                        {
                            _stringBuilder
                                .Append(" NULL");
                        }
                        else
                        {
                            _stringBuilder
                                .Append(' ')
                                .Append(sc.Value);  // NULL | NOT NULL
                        }
                    }
                    else
                    {
                        _stringBuilder.Append(sc.Operator);

                        if (sc.Value is not null)
                        {
                            _stringBuilder
                                .Append(' ')
                                .Append(sc.Value);  // NULL | NOT NULL
                        }
                    }
                }
                else
                {
                    if (sc.Value is null)
                    {
                        throw new Exception();
                    }

                    string operate;

                    if (sc.OpType == OpType.LIKE)
                    {
                        operate = "LIKE";
                    }
                    else if (sc.OpType == OpType.NOT_LIKE)
                    {
                        operate = "NOT LIKE";
                    }
                    else if (sc.OpType == OpType.EQUAL)
                    {
                        operate = "=";
                    }
                    else if (sc.OpType == OpType.NOT_EQUAL)
                    {
                        operate = "!=";
                    }
                    else
                    {
                        operate = sc.Operator;
                    }

                    _stringBuilder
                        .Append(operate)
                        .Append(' ');

                    if (sc.IsExpression)
                    {
                        _stringBuilder.Append(sc.Value);
                    }
                    else
                    {
                        string parameterName = $"@{parameterPrefix}_{whereIndex}";

                        _stringBuilder.Append(parameterName);

                        _bindParameters.Add(new BindParameter(parameterName, sc.Value, sc.DbType));
                    }
                }

                if (sc.EnclosureR != char.MinValue)
                {
                    if (_option.EnableFormat)
                    {
                        _stringBuilder
                            .AppendLine()
                            .Append(new string(' ', indent))
                            .Append(sc.EnclosureR);
                    }
                    else
                    {
                        _stringBuilder
                            .Append(sc.EnclosureR);
                    }
                }
            }
        }

        #endregion
    }
}
