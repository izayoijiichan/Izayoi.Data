// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Order
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Linq;

    /// <summary>
    /// Order
    /// </summary>
    public class Order
    {
        #region Fields

        private readonly string _orderExpression;

        private readonly OType _type;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Order class with the specified orderExpression.
        /// </summary>
        /// <param name="orderExpression">The order expression.</param>
        public Order(string orderExpression)
        {
            _orderExpression = orderExpression;

            _type = OType.None;
        }

        /// <summary>
        /// Initializes a new instance of the Order class with the specified orderExpression and type.
        /// </summary>
        /// <param name="orderExpression">The order expression.</param>
        /// <param name="type">The order type.</param>
        public Order(string orderExpression, OType type)
        {
            _orderExpression = orderExpression;

            _type = type;
        }

        #endregion

        #region Properties

        /// <summary>The order expression.</summary>
        public string OrderExpression => _orderExpression;

        /// <summary>The order type.</summary>
        public OType Type => _type;

        #endregion

        #region Methods

        public string GetOrderExpression(QuotationMarkSet quotationMarks)
        {
            if (quotationMarks.IsAvailable == false)
            {
                return _orderExpression;
            }

            string orderExpression;

            if (_orderExpression.Contains('.'))
            {
                string[] strs = _orderExpression.Split('.');

                orderExpression = string.Join('.', strs.Select(str => quotationMarks.Enclose(str)));
            }
            else
            {
                orderExpression = quotationMarks.Enclose(_orderExpression);
            }

            return orderExpression;
        }

        public string ToQuery(QuotationMarkSet quotationMarks)
        {
            string orderExpression = GetOrderExpression(quotationMarks);

            string orderType = 
                  _type == OType.ASC ? " ASC"
                : _type == OType.DESC ? " DESC"
                : string.Empty;

            return orderExpression + orderType;
        }

        public override string ToString()
        {
            return $"{nameof(OrderExpression)}: {_orderExpression}, {nameof(Type)}: {_type}";
        }

        #endregion
    }
}
