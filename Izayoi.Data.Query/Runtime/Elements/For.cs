// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : For
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    /// <summary>
    /// For
    /// </summary>
    public class For
    {
        #region Fields

        private Json? _json;

        #endregion

        #region Constructors

        public For()
        {
        }

        public For(Json json)
        {
            _json = json;
        }

        public For(JsonMode mode, string? rootName = null, bool includeNullValues = false, bool withoutArrayWrapper = false)
        {
            _json = new Json(mode, rootName, includeNullValues, withoutArrayWrapper);
        }

        #endregion

        #region Properties

        public bool IsEnabled =>
            _json != null &&
            _json.Mode != JsonMode.None;

        public Json Json => _json ??= new Json();

        #endregion

        #region Methods

        public void Clear()
        {
            if (_json != null)
            {
                _json = null;
            }
        }

        public Json GetOrCreateJson()
        {
            _json ??= new Json();

            return _json;
        }

        public For SetJson(Json json)
        {
            _json = json;

            return this;
        }

        public For SetJson(JsonMode mode)
        {
            if (_json is null)
            {
                _json = new Json(mode, rootName: null, includeNullValues: false, withoutArrayWrapper: false);
            }
            else
            {
                _json.Mode = mode;
            }

            return this;
        }

        public For SetJson(JsonMode mode, string? rootName)
        {
            if (_json is null)
            {
                _json = new Json(mode, rootName, includeNullValues: false, withoutArrayWrapper: false);
            }
            else
            {
                _json.Mode = mode;
                _json.RootName = rootName;
            }

            return this;
        }

        public For SetJson(JsonMode mode, string? rootName, bool includeNullValues, bool withoutArrayWrapper)
        {
            if (_json is null)
            {
                _json = new Json(mode, rootName, includeNullValues, withoutArrayWrapper);
            }
            else
            {
                _json.Mode = mode;
                _json.RootName = rootName;
                _json.IncludeNullValues = includeNullValues;
                _json.WithoutArrayWrapper = withoutArrayWrapper;
            }

            return this;
        }

        public void Disable()
        {
            if (_json is null)
            {
                return;
            }

            if (_json.Mode != JsonMode.None)
            {
                _json.Mode = JsonMode.None;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Json)}: {{{_json}}}";
        }

        #endregion
    }
}
