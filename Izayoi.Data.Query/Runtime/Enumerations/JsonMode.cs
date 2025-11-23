// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : JsonMode
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System;

    /// <summary>
    /// JSON Mode
    /// </summary>
    public enum JsonMode
    {
        /// <summary></summary>
        None = 0,
        /// <summary>AUTO mode</summary>
        Auto,
        /// <summary>PATH mode</summary>
        Path,
    }

    public static class JsonModesExtensions
    {
        public static string Name(this JsonMode jsonMode)
        {
            return jsonMode switch
            {
                JsonMode.Auto => "AUTO",
                JsonMode.Path => "PATH",
                JsonMode.None => string.Empty,
                _ => throw new ArgumentOutOfRangeException(nameof(jsonMode)),
            };
        }

        public static int Value(this JsonMode self)
        {
            return (int)self;
        }
    }
}
