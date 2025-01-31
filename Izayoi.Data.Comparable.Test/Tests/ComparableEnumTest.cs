// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Comparable.Test
// @Class     : ComparableEnumTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.Comparable.Test
{
    using System;
    using Izayoi.Data.Comparable;
    using Xunit;

    public class ComparableEnumTest
    {
        #region Enums

        public enum SampleEnum
        {
            None = 0,
            Num1 = 1,
            Num2 = 2,
        }

        #endregion

        #region Methods

        [Fact]
        public void Test_Construct_0()
        {
            ComparableEnum<SampleEnum> ce = new();

            Assert.False(ce.HasValue);

            Assert.Equal(SampleEnum.None, ce.Value);
        }

        [Theory]
        [InlineData(SampleEnum.None)]
        [InlineData(SampleEnum.Num1)]
        [InlineData(SampleEnum.Num2)]
        public void Test_Construct_1(SampleEnum value)
        {
            ComparableEnum<SampleEnum> ce = new(value);

            Assert.True(ce.HasValue);

            Assert.Equal(value, ce.Value);
        }

        //[Fact]
        //public void Test_implicit_null()
        //{
        //    ComparableEnum<SampleEnum> ce = null;

        //    Assert.False(ce.HasValue);

        //    Assert.Equal(SampleEnum.None, ce.Value);
        //}

        [Theory]
        [InlineData(SampleEnum.None)]
        [InlineData(SampleEnum.Num1)]
        [InlineData(SampleEnum.Num2)]
        public void Test_implicit(SampleEnum value)
        {
            ComparableEnum<SampleEnum> ce = value;

            Assert.True(ce.HasValue);

            Assert.Equal(value, ce.Value);
        }

        [Theory]
        [InlineData(SampleEnum.None)]
        [InlineData(SampleEnum.Num1)]
        [InlineData(SampleEnum.Num2)]
        public void Test_explicit_enum(SampleEnum value)
        {
            ComparableEnum<SampleEnum> ce = new(value);

            SampleEnum en = (SampleEnum)ce;

            Assert.Equal(value, en);
        }

        [Fact]
        public void Test_explicit_enum_null()
        {
            ComparableEnum<SampleEnum> ce = new();

            //SampleEnum en = (SampleEnum)ce;

            //Assert.Equal(SampleEnum.None, en);

            var exception = Assert.Throws<InvalidCastException>(() =>
            {
                SampleEnum en = (SampleEnum)ce;
            });

            Assert.Equal(typeof(InvalidCastException), exception.GetType());

            Assert.Equal("Specified cast is not valid.", exception.Message);
            
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, true)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, true)]
        public void Test_Equals(SampleEnum value1, SampleEnum value2, bool expected)
        {
            ComparableEnum<SampleEnum> ce1 = new(value1);
            ComparableEnum<SampleEnum> ce2 = new(value2);

            bool actual = ce1.Equals(ce2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, 0)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, -1)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, 1)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, 0)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, -1)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, 1)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, 0)]
        public void Test_CompareTo(SampleEnum value1, SampleEnum value2, int expected)
        {
            ComparableEnum<SampleEnum> ce1 = new(value1);
            ComparableEnum<SampleEnum> ce2 = new(value2);

            int actual = ce1.CompareTo(ce2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_CompareTo_null()
        {
            ComparableEnum<SampleEnum> ce1 = new();
            ComparableEnum<SampleEnum> ce2 = SampleEnum.None;

            int actual = ce1.CompareTo(ce2);

            Assert.Equal(-1, actual);

            actual = ce2.CompareTo(ce1);

            Assert.Equal(1, actual);
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, true)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, true)]
        public void Test_operator_Equal(SampleEnum value1, SampleEnum value2, bool expected)
        {
            ComparableEnum<SampleEnum> ce1 = new(value1);
            ComparableEnum<SampleEnum> ce2 = new(value2);

            bool actual = ce1 == ce2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, false)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, true)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, false)]
        public void Test_operator_NotEqual(SampleEnum value1, SampleEnum value2, bool expected)
        {
            ComparableEnum<SampleEnum> ce1 = new(value1);
            ComparableEnum<SampleEnum> ce2 = new(value2);

            bool actual = ce1 != ce2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, false)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, true)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, false)]
        public void Test_operator_LessThan(SampleEnum value1, SampleEnum value2, bool expected)
        {
            ComparableEnum<SampleEnum> ce1 = new(value1);
            ComparableEnum<SampleEnum> ce2 = new(value2);

            bool actual = ce1 < ce2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, true)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, true)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, true)]
        public void Test_operator_LessThanOrEqual(SampleEnum value1, SampleEnum value2, bool expected)
        {
            ComparableEnum<SampleEnum> ce1 = new(value1);
            ComparableEnum<SampleEnum> ce2 = new(value2);

            bool actual = ce1 <= ce2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, false)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, false)]
        public void Test_operator_GreaterThan(SampleEnum value1, SampleEnum value2, bool expected)
        {
            ComparableEnum<SampleEnum> ce1 = new(value1);
            ComparableEnum<SampleEnum> ce2 = new(value2);

            bool actual = ce1 > ce2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, true)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, true)]
        public void Test_operator_GreaterThanOrEqual(SampleEnum value1, SampleEnum value2, bool expected)
        {
            ComparableEnum<SampleEnum> ce1 = new(value1);
            ComparableEnum<SampleEnum> ce2 = new(value2);

            bool actual = ce1 >= ce2;

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}