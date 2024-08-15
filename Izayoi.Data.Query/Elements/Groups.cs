// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Groups
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Collections.Generic;
    using System.Linq;

    public class Groups : List<string>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Groups class.
        /// </summary>
        public Groups() { }

        /// <summary>
        /// Initializes a new instance of the Groups class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Groups(int capacity) : base(capacity) { }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldExpression">The field name or expression.</param>
        /// <returns></returns>
        public new Groups Add(string fieldExpression)
        {
            base.Add(fieldExpression);

            return this;
        }

        public string GetFieldName(string fieldExpression, QuotationMarkSet quotationMarks)
        {
            if (quotationMarks.IsAvailable == false)
            {
                return fieldExpression;
            }

            string field;

            if (fieldExpression.Contains('.'))
            {
                string[] strs = fieldExpression.Split('.');

                field = string.Join('.', strs.Select(str => quotationMarks.Enclose(str)));
            }
            else
            {
                field = quotationMarks.Enclose(fieldExpression);
            }

            return field;
        }

        public string ToQuery(QuotationMarkSet quotationMarks)
        {
            return Count == 0
                ? string.Empty
                : quotationMarks.IsAvailable
                ? "GROUP BY " + string.Join(", ", this.Select(f => GetFieldName(f, quotationMarks)))
                : "GROUP BY " + string.Join(", ", this);
        }

        #endregion
    }
}
