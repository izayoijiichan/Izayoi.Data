// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : Json
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    /// <summary>
    /// FOR JSON
    /// </summary>
    public class Json
    {
        #region Fields

        private JsonMode _mode;

        private string? _rootName;

        private bool _includeNullValues;

        private bool _withoutArrayWrapper;

        #endregion

        #region Constructors

        public Json() : this(JsonMode.None) { }

        public Json(JsonMode mode, string? rootName = null, bool includeNullValues = false, bool withoutArrayWrapper = false)
        {
            Mode = mode;

            RootName = rootName;

            IncludeNullValues = includeNullValues;

            WithoutArrayWrapper = withoutArrayWrapper;
        }

        #endregion

        #region Properties

        public JsonMode Mode
        {
            get => _mode;
            set => _mode = value;
        }

        public string? RootName
        {
            get => _rootName;
            set => _rootName = value;
        }

        public bool IncludeNullValues
        {
            get => _includeNullValues;
            set => _includeNullValues = value;
        }

        public bool WithoutArrayWrapper
        {
            get => _withoutArrayWrapper;
            set => _withoutArrayWrapper = value;
        }

        #endregion

        #region Methods

        public string ToQuery()
        {
            if (_mode == JsonMode.None)
            {
                return string.Empty;
            }

            string mode = $"FOR JSON {_mode.Name()}";

            string root =
                _rootName is null
                ? string.Empty
                : ", " + GetRootNameQuery();

            string includeNullValues
                = _includeNullValues
                ? ", INCLUDE_NULL_VALUES"
                : string.Empty;

            string withoutArrayWrapper
                = _withoutArrayWrapper
                ? ", WITHOUT_ARRAY_WRAPPER"
                : string.Empty;

            return $"{mode}{root}{includeNullValues}{withoutArrayWrapper}";
        }

        public string GetRootNameQuery()
        {
            return _rootName is null
                ? string.Empty
                : _rootName.Length == 0
                ? $"ROOT"
                : $"ROOT('{_rootName}')";
        }

        public override string ToString()
        {
            return $"{nameof(Mode)}: {_mode}, {nameof(RootName)}: {_rootName}, {nameof(IncludeNullValues)}: {_includeNullValues}, {nameof(WithoutArrayWrapper)}: {_withoutArrayWrapper}";
        }

        #endregion
    }
}
