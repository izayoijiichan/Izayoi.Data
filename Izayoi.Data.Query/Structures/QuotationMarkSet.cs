// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Struct    : QuotationMarkSet
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Quotation Mark Set
    /// </summary>
    public readonly struct QuotationMarkSet
    {
        #region Fields

        private readonly char _l;

        private readonly char _r;

        #endregion

        #region Constructors

        //public QuotationMarkSet()
        //{
        //    _l = char.MinValue;
        //    _r = char.MinValue;
        //}

        public QuotationMarkSet(char left, char right)
        {
            _l = left;
            _r = right;
        }

        #endregion

        #region Properties

        public bool IsAvailable =>
            _l != char.MinValue &&
            _r != char.MinValue;

        public char L => _l;

        public char R => _r;

        #endregion

        #region Methods

        public string Enclose(string word, bool excludeEmpty = false)
        {
            return
                (word.Length == 0 && excludeEmpty)
                ? string.Empty
                : IsAvailable
                ? $"{_l}{word}{_r}"
                : word;
        }

        public string Enclose(char c, bool excludeEmpty = false)
        {
            return
                (c == char.MaxValue && excludeEmpty)
                ? string.Empty
                : IsAvailable
                ? $"{_l}{c}{_r}"
                : c.ToString();
        }

        public override string ToString()
        {
            return $"{_l}, {_r}";
        }

        #endregion
    }
}
