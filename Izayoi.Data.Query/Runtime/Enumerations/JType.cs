// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Enum      : JType
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System;

    /// <summary>
    /// Join Type
    /// </summary>
    public enum JType
    {
        /// <summary></summary>
        None = 0,
        /// <summary>CROSS JOIN</summary>
        CROSS_JOIN,
        /// <summary>INNER JOIN</summary>
        INNER_JOIN,
        /// <summary>LEFT JOIN</summary>
        LEFT_JOIN,
        /// <summary>LEFT OUTER JOIN</summary>
        LEFT_OUTER_JOIN,
        /// <summary>RIGHT JOIN</summary>
        RIGHT_JOIN,
        /// <summary>RIGHT OUTER JOIN</summary>
        RIGHT_OUTER_JOIN,
        /// <summary>FULL JOIN</summary>
        FULL_JOIN,
        /// <summary>FULL OUTER JOIN</summary>
        FULL_OUTER_JOIN,
    }

    public static class JTypesExtensions
    {
        public static string Name(this JType joinType)
        {
            return joinType switch
            {
                JType.CROSS_JOIN => "CROSS JOIN",
                JType.INNER_JOIN => "INNER JOIN",
                JType.LEFT_JOIN => "LEFT JOIN",
                JType.LEFT_OUTER_JOIN => "LEFT OUTER JOIN",
                JType.RIGHT_JOIN => "RIGHT JOIN",
                JType.RIGHT_OUTER_JOIN => "RIGHT OUTER JOIN",
                JType.FULL_JOIN => "FULL JOIN",
                JType.FULL_OUTER_JOIN => "FULL OUTER JOIN",
                JType.None => string.Empty,
                _ => throw new ArgumentOutOfRangeException(nameof(joinType)),
            };
        }

        public static int Value(this JType self)
        {
            return (int)self;
        }
    }
}
