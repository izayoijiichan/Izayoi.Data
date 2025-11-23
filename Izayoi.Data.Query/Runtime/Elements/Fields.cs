// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Fields
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Fields
    /// </summary>
    public class Fields : List<Field>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Fields class.
        /// </summary>
        public Fields() { }

        /// <summary>
        /// Initializes a new instance of the Fields class with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public Fields(int capacity) : base(capacity) { }

        #endregion

        #region Methods

        public new Fields Add(Field field)
        {
            base.Add(field);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">The field name or expression.</param>
        /// <param name="isExpression">Whether the field name is expression.</param>
        /// <returns></returns>
        public Fields Add(string fieldName, bool? isExpression = null)
        {
            base.Add(new Field(fieldName, isExpression));

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">The field name or expression.</param>
        /// <param name="fieldAlias">The field alias.</param>
        /// <param name="isExpression">Whether the field name is expression.</param>
        /// <returns></returns>
        public Fields Add(string fieldName, string fieldAlias, bool? isExpression = null)
        {
            base.Add(new Field(fieldName, fieldAlias, isExpression));

            return this;
        }

        public string ToQuery(QuotationMarkSet quotationMarks)
        {
            return string.Join(", ", this.Select(x => x.ToQuery(quotationMarks)));
        }

        #endregion
    }
}
