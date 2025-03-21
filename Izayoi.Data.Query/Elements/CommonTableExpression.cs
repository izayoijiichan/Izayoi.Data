// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : CommonTableExpression
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Common Table Expression
    /// </summary>
    public class CommonTableExpression
    {
        #region Fields

        private string _expressionName;

        private readonly List<string> _columnNames;

        private readonly List<Select> _selects;

        /// <summary></summary>
        /// <remarks>UNION | UNION ALL | EXCEPT | INTERSECT</remarks>
        private readonly Dictionary<int, string> _connects;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the CommonTableExpression class with the specified expressionName.
        /// </summary>
        /// <param name="expressionName">The expression name.</param>
        public CommonTableExpression(string expressionName)
        {
            _expressionName = expressionName;

            _columnNames = new List<string>();

            _selects = new List<Select>();

            _connects = new Dictionary<int, string>();
        }

        /// <summary>
        /// Initializes a new instance of the CommonTableExpression class with the specified expressionName and columnName.
        /// </summary>
        /// <param name="expressionName">The expression name.</param>
        /// <param name="columnName">The column name.</param>
        public CommonTableExpression(string expressionName, string columnName)
        {
            _expressionName = expressionName;

            _columnNames = new List<string>()
            {
                columnName
            };

            _selects = new List<Select>();

            _connects = new Dictionary<int, string>();
        }

        /// <summary>
        /// Initializes a new instance of the CommonTableExpression class with the specified expressionName and columnNames.
        /// </summary>
        /// <param name="expressionName">The expression name.</param>
        /// <param name="columnNames"></param>
        public CommonTableExpression(string expressionName, IEnumerable<string> columnNames)
        {
            _expressionName = expressionName;

            _columnNames = new List<string>(columnNames);

            _selects = new List<Select>();

            _connects = new Dictionary<int, string>();
        }

        #endregion

        #region Properties

        /// <summary>The expression name.</summary>
        public string ExpressionName
        {
            get => _expressionName;
            set => _expressionName = value;
        }

        /// <summary>List of column name.</summary>
        public IReadOnlyList<string> ColumnNames => _columnNames;

        /// <summary>List of select.</summary>
        public IReadOnlyList<Select> Selects => _selects;

        #endregion

        #region Methods

        public CommonTableExpression AddColumn(in string columnName)
        {
            _columnNames.Add(columnName);

            return this;
        }

        public CommonTableExpression AddColumns(in IEnumerable<string> columnNames)
        {
            _columnNames.AddRange(columnNames);

            return this;
        }

        public CommonTableExpression ClearColumns()
        {
            _columnNames.Clear();

            return this;
        }

        public CommonTableExpression AddSelect(in Select select)
        {
            _selects.Add(select);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connect">UNION | UNION ALL | EXCEPT | INTERSECT</param>
        /// <param name="select"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CommonTableExpression AddSelect(in string connect, in Select select)
        {
            _selects.Add(select);

            int index = _selects.Count - 1;

            if (_connects.ContainsKey(index))
            {
                throw new Exception();
            }

            if (!string.IsNullOrEmpty(connect))
            {
                _connects.Add(index, connect);
            }

            return this;
        }

        public CommonTableExpression ClearSelect()
        {
            _selects.Clear();

            _connects.Clear();

            return this;
        }

        public string GetExpression(QuotationMarkSet quotationMarks)
        {
            string expressionName = GetExpressionName(quotationMarks);

            if (_columnNames.Count == 0)
            {
                return expressionName;
            }

            string columnNames = GetColumnNames(quotationMarks);

            return $"{expressionName}({columnNames})";
        }

        public string GetExpressionName(QuotationMarkSet quotationMarks)
        {
            string expressionName;

            if (quotationMarks.IsAvailable)
            {
                if (_expressionName.Contains(quotationMarks.L))
                {
                    expressionName = _expressionName;
                }
                else if (_expressionName.Contains(quotationMarks.R))
                {
                    expressionName = _expressionName;
                }
                else if (_expressionName.Contains('.'))
                {
                    string[] strs = _expressionName.Split('.');

                    expressionName = string.Join('.', strs.Select(str => quotationMarks.Enclose(str)));
                }
                else
                {
                    expressionName = quotationMarks.Enclose(_expressionName);
                }
            }
            else
            {
                expressionName = _expressionName;
            }

            return expressionName;
        }

        public string GetColumnNames(QuotationMarkSet quotationMarks)
        {
            if (_columnNames.Count == 0)
            {
                return string.Empty;
            }

            if (quotationMarks.IsAvailable == false)
            {
                return string.Join(", ", _columnNames);
            }

            List<string> enclosedColumnNames = new List<string>(_columnNames.Count);

            foreach (string columnName in _columnNames)
            {
                if (columnName.Contains(quotationMarks.L))
                {
                    enclosedColumnNames.Add(columnName);
                }
                else if (columnName.Contains(quotationMarks.R))
                {
                    enclosedColumnNames.Add(columnName);
                }
                else if (columnName.Contains('.'))
                {
                    string[] strs = columnName.Split('.');

                    enclosedColumnNames.Add(string.Join('.', strs.Select(str => quotationMarks.Enclose(str))));
                }
                else
                {
                    enclosedColumnNames.Add(quotationMarks.Enclose(columnName));
                }
            }

            return string.Join(", ", enclosedColumnNames);
        }

        public string GetConnect(in int index, in string defaultValue = "UNION")
        {
            if (_connects.TryGetValue(index, out string? connect))
            {
                if (string.IsNullOrEmpty(connect))
                {
                    return defaultValue;
                }
                else
                {
                    return connect;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public override string ToString()
        {
            return $"{nameof(ExpressionName)}: {_expressionName}, {nameof(ColumnNames)}: {string.Join(',', _columnNames)}";
        }

        #endregion
    }
}
