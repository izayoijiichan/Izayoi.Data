// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Comparable.Test
// @Class     : ComparableNullableTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Comparable.Test
{
    using System;
    using Izayoi.Data.Comparable;
    using Xunit;

    public class ComparableNullableTest
    {
        #region Methods

        [Fact]
        public void Test_Construct_Default_bool()
        {
            ComparableNullable<bool> nullable = new();

            Assert.False(nullable.HasValue);

            Assert.False(nullable.Value);
        }

        [Fact]
        public void Test_Construct_Default_byte()
        {
            ComparableNullable<byte> nullable = new();

            Assert.False(nullable.HasValue);

            Assert.Equal(0, nullable.Value);
        }

        [Fact]
        public void Test_Construct_Default_decimal()
        {
            ComparableNullable<decimal> nullable = new();

            Assert.False(nullable.HasValue);

            Assert.Equal(0, nullable.Value);
        }

        [Fact]
        public void Test_Construct_Default_float()
        {
            ComparableNullable<float> nullable = new();

            Assert.False(nullable.HasValue);

            Assert.Equal(0.0f, nullable.Value);
        }

        [Fact]
        public void Test_Construct_Default_Guid()
        {
            ComparableNullable<Guid> nullable = new();

            Assert.False(nullable.HasValue);

            Assert.Equal(Guid.Empty, nullable.Value);
        }

        [Fact]
        public void Test_Construct_Default_int()
        {
            ComparableNullable<int> nullable = new();

            Assert.False(nullable.HasValue);

            Assert.Equal(0, nullable.Value);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Test_Construct_Value_bool(bool value)
        {
            ComparableNullable<bool> nullable = new(value);

            Assert.True(nullable.HasValue);

            Assert.Equal(value, nullable.Value);
        }

        [Theory]
        [InlineData(byte.MinValue)]
        [InlineData(byte.MaxValue)]
        public void Test_Construct_Value_byte(byte value)
        {
            ComparableNullable<byte> nullable = new(value);

            Assert.True(nullable.HasValue);

            Assert.Equal(value, nullable.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        [InlineData(float.MinValue)]
        [InlineData(float.MaxValue)]
        public void Test_Construct_Value_float(float value)
        {
            ComparableNullable<float> nullable = new(value);

            Assert.True(nullable.HasValue);

            Assert.Equal(value, nullable.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void Test_Construct_Value_int(int value)
        {
            ComparableNullable<int> nullable = new(value);

            Assert.True(nullable.HasValue);

            Assert.Equal(value, nullable.Value);
        }

        [Fact]
        public void Test_implicit_1_null()
        {
            ComparableNullable<int> nullable = null;

            Assert.False(nullable.HasValue);

            Assert.Equal(0, nullable.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        [InlineData(null)]
        public void Test_implicit_1(int? value)
        {
            ComparableNullable<int> comparableNullable = value;

            Assert.Equal(value.HasValue, comparableNullable.HasValue);

            if (value.HasValue && comparableNullable.HasValue)
            {
                Assert.Equal(value.Value, comparableNullable.Value);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        [InlineData(null)]
        public void Test_implicit_2(int? value1)
        {
            ComparableNullable<int> comparableNullable = value1;

            Nullable<int> nullable = comparableNullable;

            Assert.Equal(comparableNullable.HasValue, nullable.HasValue);

            if (comparableNullable.HasValue && nullable.HasValue)
            {
                Assert.Equal(comparableNullable.Value, nullable.Value);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void Test_implicit_value_to_ComparableNullableValue(int value)
        {
            ComparableNullable<int> nullable = value;

            Assert.Equal(value, nullable.Value);
        }

        [Fact]
        public void Test_implicit_null_to_ComparableNullableValue()
        {
            ComparableNullable<int> nullable = null;

            Assert.False(nullable.HasValue);
        }

        [Fact]
        public void Test_GetValueOrDefault()
        {
            ComparableNullable<int> nullable = new();

            Assert.False(nullable.HasValue);

            Assert.Equal(0, nullable.Value);

            Assert.Equal(0, nullable.GetValueOrDefault());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void Test_GetValueOrDefault_value(int defaultValue)
        {
            ComparableNullable<int> nullable = new();

            Assert.False(nullable.HasValue);

            Assert.Equal(0, nullable.Value);

            int value = nullable.GetValueOrDefault(defaultValue);

            Assert.Equal(defaultValue, value);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(int.MinValue, int.MaxValue, false)]
        [InlineData(int.MaxValue, int.MinValue, false)]
        [InlineData(int.MinValue, int.MinValue, true)]
        [InlineData(int.MaxValue, int.MaxValue, true)]
        [InlineData(null, null, true)]
        [InlineData(null, 0, false)]
        [InlineData(0, null, false)]
        public void Test_Equals(int? value1, int? value2, bool expected)
        {
            ComparableNullable<int> nullable1 = value1;

            ComparableNullable<int> nullable2 = value2;

            bool actual = nullable1.Equals(nullable2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(1, 0, 1)]
        [InlineData(int.MinValue, int.MaxValue, -1)]
        [InlineData(int.MaxValue, int.MinValue, 1)]
        [InlineData(int.MinValue, int.MinValue, 0)]
        [InlineData(int.MaxValue, int.MaxValue, 0)]
        [InlineData(null, null, 0)]
        [InlineData(null, 0, -1)]
        [InlineData(0, null, 1)]
        public void Test_CompareTo(int? value1, int? value2, int expected)
        {
            ComparableNullable<int> nullable1 = value1;

            ComparableNullable<int> nullable2 = value2;

            int actual = nullable1.CompareTo(nullable2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(int.MinValue, int.MaxValue, false)]
        [InlineData(int.MaxValue, int.MinValue, false)]
        [InlineData(int.MinValue, int.MinValue, true)]
        [InlineData(int.MaxValue, int.MaxValue, true)]
        [InlineData(null, null, true)]
        [InlineData(null, 0, false)]
        [InlineData(0, null, false)]
        [InlineData(null, -1, false)]
        [InlineData(-1, null, false)]
        public void Test_operator_Equal(int? value1, int? value2, bool expected)
        {
            ComparableNullable<int> nullable1 = value1;

            ComparableNullable<int> nullable2 = value2;

            bool actual = nullable1 == nullable2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, true)]
        [InlineData(1, 0, true)]
        [InlineData(int.MinValue, int.MaxValue, true)]
        [InlineData(int.MaxValue, int.MinValue, true)]
        [InlineData(int.MinValue, int.MinValue, false)]
        [InlineData(int.MaxValue, int.MaxValue, false)]
        [InlineData(null, null, false)]
        [InlineData(null, 0, true)]
        [InlineData(0, null, true)]
        [InlineData(null, -1, true)]
        [InlineData(-1, null, true)]
        public void Test_operator_NotEqual(int? value1, int? value2, bool expected)
        {
            ComparableNullable<int> nullable1 = value1;

            ComparableNullable<int> nullable2 = value2;

            bool actual = nullable1 != nullable2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, true)]
        [InlineData(1, 0, false)]
        [InlineData(int.MinValue, int.MaxValue, true)]
        [InlineData(int.MaxValue, int.MinValue, false)]
        [InlineData(int.MinValue, int.MinValue, false)]
        [InlineData(int.MaxValue, int.MaxValue, false)]
        [InlineData(null, null, false)]
        [InlineData(null, 0, true)]
        [InlineData(0, null, false)]
        [InlineData(null, -1, true)]
        [InlineData(-1, null, false)]
        public void Test_operator_LessThan(int? value1, int? value2, bool expected)
        {
            ComparableNullable<int> nullable1 = value1;

            ComparableNullable<int> nullable2 = value2;

            bool actual = nullable1 < nullable2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, true)]
        [InlineData(1, 0, false)]
        [InlineData(int.MinValue, int.MaxValue, true)]
        [InlineData(int.MaxValue, int.MinValue, false)]
        [InlineData(int.MinValue, int.MinValue, true)]
        [InlineData(int.MaxValue, int.MaxValue, true)]
        [InlineData(null, null, true)]
        [InlineData(null, 0, true)]
        [InlineData(0, null, false)]
        [InlineData(null, -1, true)]
        [InlineData(-1, null, false)]
        public void Test_operator_LessThanOrEqual(int? value1, int? value2, bool expected)
        {
            ComparableNullable<int> nullable1 = value1;

            ComparableNullable<int> nullable2 = value2;

            bool actual = nullable1 <= nullable2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, true)]
        [InlineData(int.MinValue, int.MaxValue, false)]
        [InlineData(int.MaxValue, int.MinValue, true)]
        [InlineData(int.MinValue, int.MinValue, false)]
        [InlineData(int.MaxValue, int.MaxValue, false)]
        [InlineData(null, null, false)]
        [InlineData(null, 0, false)]
        [InlineData(0, null, true)]
        [InlineData(null, -1, false)]
        [InlineData(-1, null, true)]
        public void Test_operator_GreaterThan(int? value1, int? value2, bool expected)
        {
            ComparableNullable<int> nullable1 = value1;

            ComparableNullable<int> nullable2 = value2;

            bool actual = nullable1 > nullable2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, true)]
        [InlineData(int.MinValue, int.MaxValue, false)]
        [InlineData(int.MaxValue, int.MinValue, true)]
        [InlineData(int.MinValue, int.MinValue, true)]
        [InlineData(int.MaxValue, int.MaxValue, true)]
        [InlineData(null, null, true)]
        [InlineData(null, 0, false)]
        [InlineData(0, null, true)]
        [InlineData(null, -1, false)]
        [InlineData(-1, null, true)]
        public void Test_operator_GreaterThanOrEqual(int? value1, int? value2, bool expected)
        {
            ComparableNullable<int> nullable1 = value1;

            ComparableNullable<int> nullable2 = value2;

            bool actual = nullable1 >= nullable2;

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}