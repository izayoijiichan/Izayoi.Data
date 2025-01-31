// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs.Test
// @Class     : ComparableStructPack2Test
// ----------------------------------------------------------------------
namespace Izayoi.Data.Packs.Test
{
    using Izayoi.Data.Packs;
    using Xunit;

    public class ComparableStructPack2Test
    {
        #region Methods

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void Test_Pack2_int_int_Construct(int value1, int value2)
        {
            ComparableStructPack<int, int> csp = new(value1, value2);

            Assert.Equal(value1, csp.Value1);
            Assert.Equal(value2, csp.Value2);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void Test_Pack2_int_int_Deconstruct(int value1, int value2)
        {
            ComparableStructPack<int, int> csp = new(value1, value2);

            (int v1, int v2) = csp;

            Assert.Equal(v1, csp.Value1);
            Assert.Equal(v2, csp.Value2);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, true)]
        [InlineData(1, 0, 0, 0, false)]
        [InlineData(0, 1, 0, 0, false)]
        [InlineData(0, 0, 1, 0, false)]
        [InlineData(0, 0, 0, 1, false)]
        [InlineData(1, 1, 1, 1, true)]
        [InlineData(0, 1, 1, 1, false)]
        [InlineData(1, 0, 1, 1, false)]
        [InlineData(1, 1, 0, 0, false)]
        [InlineData(2, 2, 2, 2, true)]
        [InlineData(1, 2, 2, 2, false)]
        [InlineData(2, 1, 2, 2, false)]
        [InlineData(2, 2, 1, 2, false)]
        [InlineData(2, 2, 2, 1, false)]
        [InlineData(-1, -1, -1, -1, true)]
        [InlineData(0, -1, -1, -1, false)]
        [InlineData(-1, 0, -1, -1, false)]
        [InlineData(-1, -1, 0, -1, false)]
        [InlineData(-1, -1, -1, 0, false)]
        [InlineData(-2, -2, -2, -2, true)]
        [InlineData(-1, -2, -2, -2, false)]
        [InlineData(-2, -1, -2, -2, false)]
        [InlineData(-2, -2, -1, -2, false)]
        [InlineData(-2, -2, -2, -1, false)]
        public void Test_Pack2_int_int_Equals(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expected)
        {
            ComparableStructPack<int, int> csp1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> csp2 = new(value_2_1, value_2_2);

            bool actual = csp1.Equals(csp2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, 0)]
        [InlineData(1, 0, 2, 0, -1)]
        [InlineData(1, 1, 2, 0, -1)]
        [InlineData(1, 1, 2, 1, -1)]
        [InlineData(1, 2, 2, 1, -1)]
        [InlineData(2, 0, 1, 0, 1)]
        [InlineData(2, 0, 1, 1, 1)]
        [InlineData(2, 1, 1, 1, 1)]
        [InlineData(2, 1, 1, 2, 1)]
        public void Test_Pack2_int_int_CompareTo(int value_1_1, int value_1_2, int value_2_1, int value_2_2, int expected)
        {
            ComparableStructPack<int, int> csp1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> csp2 = new(value_2_1, value_2_2);

            int actual = csp1.CompareTo(csp2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, false, 1, false, 0)]
        [InlineData(1, false, 2, false, -1)]
        [InlineData(2, false, 1, false, 1)]
        [InlineData(1, false, 1, true, -1)]
        [InlineData(1, true, 1, false, 1)]
        [InlineData(1, true, 1, true, 0)]
        public void Test_Pack2_int_bool_CompareTo(int value_1_1, bool value_1_2, int value_2_1, bool value_2_2, int expected)
        {
            ComparableStructPack<int, bool> csp1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, bool> csp2 = new(value_2_1, value_2_2);

            int actual = csp1.CompareTo(csp2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, true)]
        [InlineData(1, 0, 0, 0, false)]
        [InlineData(0, 1, 0, 0, false)]
        [InlineData(0, 0, 1, 0, false)]
        [InlineData(0, 0, 0, 1, false)]
        [InlineData(1, 1, 1, 1, true)]
        [InlineData(0, 1, 1, 1, false)]
        [InlineData(1, 0, 1, 1, false)]
        [InlineData(1, 1, 0, 0, false)]
        [InlineData(2, 2, 2, 2, true)]
        [InlineData(1, 2, 2, 2, false)]
        [InlineData(2, 1, 2, 2, false)]
        [InlineData(2, 2, 1, 2, false)]
        [InlineData(2, 2, 2, 1, false)]
        [InlineData(-1, -1, -1, -1, true)]
        [InlineData(0, -1, -1, -1, false)]
        [InlineData(-1, 0, -1, -1, false)]
        [InlineData(-1, -1, 0, -1, false)]
        [InlineData(-1, -1, -1, 0, false)]
        [InlineData(-2, -2, -2, -2, true)]
        [InlineData(-1, -2, -2, -2, false)]
        [InlineData(-2, -1, -2, -2, false)]
        [InlineData(-2, -2, -1, -2, false)]
        [InlineData(-2, -2, -2, -1, false)]
        public void Test_Pack2_int_int_operator_Equals(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expected)
        {
            ComparableStructPack<int, int> csp1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> csp2 = new(value_2_1, value_2_2);

            bool actual = csp1 == csp2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, false)]
        [InlineData(1, 0, 0, 0, true)]
        [InlineData(0, 1, 0, 0, true)]
        [InlineData(0, 0, 1, 0, true)]
        [InlineData(0, 0, 0, 1, true)]
        [InlineData(1, 1, 1, 1, false)]
        [InlineData(0, 1, 1, 1, true)]
        [InlineData(1, 0, 1, 1, true)]
        [InlineData(1, 1, 0, 0, true)]
        [InlineData(2, 2, 2, 2, false)]
        [InlineData(1, 2, 2, 2, true)]
        [InlineData(2, 1, 2, 2, true)]
        [InlineData(2, 2, 1, 2, true)]
        [InlineData(2, 2, 2, 1, true)]
        [InlineData(-1, -1, -1, -1, false)]
        [InlineData(0, -1, -1, -1, true)]
        [InlineData(-1, 0, -1, -1, true)]
        [InlineData(-1, -1, 0, -1, true)]
        [InlineData(-1, -1, -1, 0, true)]
        [InlineData(-2, -2, -2, -2, false)]
        [InlineData(-1, -2, -2, -2, true)]
        [InlineData(-2, -1, -2, -2, true)]
        [InlineData(-2, -2, -1, -2, true)]
        [InlineData(-2, -2, -2, -1, true)]
        public void Test_Pack2_int_int_operator_NotEquals(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expected)
        {
            ComparableStructPack<int, int> csp1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> csp2 = new(value_2_1, value_2_2);

            bool actual = csp1 != csp2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, false)]
        [InlineData(1, 0, 2, 0, true)]
        [InlineData(1, 1, 2, 0, true)]
        [InlineData(1, 1, 2, 1, true)]
        [InlineData(1, 2, 2, 1, true)]
        [InlineData(2, 0, 1, 0, false)]
        [InlineData(2, 0, 1, 1, false)]
        [InlineData(2, 1, 1, 1, false)]
        [InlineData(2, 1, 1, 2, false)]
        public void Test_Pack2_int_int_operator_LessThen(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expected)
        {
            ComparableStructPack<int, int> csp1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> csp2 = new(value_2_1, value_2_2);

            bool actual = csp1 < csp2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, true)]
        [InlineData(1, 0, 2, 0, true)]
        [InlineData(1, 1, 2, 0, true)]
        [InlineData(1, 1, 2, 1, true)]
        [InlineData(1, 2, 2, 1, true)]
        [InlineData(2, 0, 1, 0, false)]
        [InlineData(2, 0, 1, 1, false)]
        [InlineData(2, 1, 1, 1, false)]
        [InlineData(2, 1, 1, 2, false)]
        public void Test_Pack2_int_int_operator_LessThenOrEqual(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expected)
        {
            ComparableStructPack<int, int> csp1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> csp2 = new(value_2_1, value_2_2);

            bool actual = csp1 <= csp2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, false)]
        [InlineData(1, 0, 2, 0, false)]
        [InlineData(1, 1, 2, 0, false)]
        [InlineData(1, 1, 2, 1, false)]
        [InlineData(1, 2, 2, 1, false)]
        [InlineData(2, 0, 1, 0, true)]
        [InlineData(2, 0, 1, 1, true)]
        [InlineData(2, 1, 1, 1, true)]
        [InlineData(2, 1, 1, 2, true)]
        public void Test_Pack2_int_int_operator_GreaterThen(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expected)
        {
            ComparableStructPack<int, int> csp1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> csp2 = new(value_2_1, value_2_2);

            bool actual = csp1 > csp2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, true)]
        [InlineData(1, 0, 2, 0, false)]
        [InlineData(1, 1, 2, 0, false)]
        [InlineData(1, 1, 2, 1, false)]
        [InlineData(1, 2, 2, 1, false)]
        [InlineData(2, 0, 1, 0, true)]
        [InlineData(2, 0, 1, 1, true)]
        [InlineData(2, 1, 1, 1, true)]
        [InlineData(2, 1, 1, 2, true)]
        public void Test_Pack2_int_int_operator_GreaterThenOrEqual(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expected)
        {
            ComparableStructPack<int, int> csp1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> csp2 = new(value_2_1, value_2_2);

            bool actual = csp1 >= csp2;

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}