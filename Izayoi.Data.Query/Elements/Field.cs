// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Field
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Field
    /// </summary>
    public class Field
    {
        #region Fields

        private readonly string _fieldAlias;

        private readonly string _fieldName;

        private readonly bool _isExpression;

        private readonly string[] _expressionKeywords = ["(", ")"];

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Field class with the specified fieldName and isExpression.
        /// </summary>
        /// <param name="fieldName">The field name or expression.</param>
        /// <param name="isExpression">Whether the field name is expression.</param>
        public Field(string fieldName, bool? isExpression = null)
            : this (fieldName, string.Empty, isExpression) { }

        /// <summary>
        /// Initializes a new instance of the Field class with the specified fieldName, fieldAlias and isExpression.
        /// </summary>
        /// <param name="fieldName">The field name or expression.</param>
        /// <param name="fieldAlias">The field alias.</param>
        /// <param name="isExpression">Whether the field name is expression.</param>
        public Field(string fieldName, string fieldAlias, bool? isExpression = null)
        {
            _fieldAlias = fieldAlias;

            _fieldName = fieldName;

            if (isExpression.HasValue)
            {
                _isExpression = isExpression.Value;
            }
            else
            {
                foreach (string expressionKeyword in _expressionKeywords)
                {
                    if (_fieldName.Contains(expressionKeyword, StringComparison.OrdinalIgnoreCase))
                    {
                        _isExpression = true;
                    }
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>The field alias.</summary>
        public string FieldAlias => _fieldAlias;

        /// <summary>The field name or expression.</summary>
        public string FieldName => _fieldName;

        /// <summary>Whether the field name is expression.</summary>
        /// <remarks>Sets <see langword="true" /> if the field name is expression.</remarks>
        public bool IsExpression => _isExpression;

        #endregion

        #region Methods

        public string GetAliasOrFieldName()
        {
            return _fieldAlias.Length > 0
                ? _fieldAlias
                : _fieldName;
        }

        public string GetAliasOrFieldName(QuotationMarkSet quotationMarks)
        {
            return _fieldAlias.Length > 0
                ? quotationMarks.Enclose(_fieldAlias)
                : GetFieldName(quotationMarks);
        }

        public string GetFieldName(QuotationMarkSet quotationMarks)
        {
            if (_isExpression)
            {
                return _fieldName;
            }

            if (_fieldName == "*")
            {
                return _fieldName;
            }

            bool fieldEnclosureAvailable;

            if (quotationMarks.IsAvailable == false)
            {
                fieldEnclosureAvailable = false;
            }
            else if (_fieldName.Contains(quotationMarks.L))
            {
                fieldEnclosureAvailable = false;
            }
            else if (_fieldName.Contains(quotationMarks.R))
            {
                fieldEnclosureAvailable = false;
            }
            else
            {
                fieldEnclosureAvailable = true;
            }

            if (fieldEnclosureAvailable == false)
            {
                return _fieldName;
            }

            string field;

            if (_fieldName.Contains('.'))
            {
                string[] strs = _fieldName.Split('.');

                field = string.Join('.', strs.Select(str => str == "*" ? str : quotationMarks.Enclose(str)));
            }
            else
            {
                field = quotationMarks.Enclose(_fieldName);
            }

            return field;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quotationMarks"></param>
        /// <returns></returns>
        /// <remarks>
        /// SQL Server requires Alias ​​enclosure characters when FOR JSON clause is in PATH mode.
        /// </remarks>
        public string ToQuery(QuotationMarkSet quotationMarks)
        {
            if (_fieldName.Length == 0)
            {
                throw new Exception(nameof(FieldName));
            }

            string field = GetFieldName(quotationMarks);

            if (_fieldAlias.Length == 0)
            {
                return field;
            }

            string alias = quotationMarks.Enclose(_fieldAlias);

            return $"{field} AS {alias}";
        }

        public override string ToString()
        {
            return $"{nameof(FieldAlias)}: {_fieldAlias}, {nameof(FieldName)}: {_fieldName}, {nameof(IsExpression)}: {_isExpression}";
        }

        #endregion
    }
}
