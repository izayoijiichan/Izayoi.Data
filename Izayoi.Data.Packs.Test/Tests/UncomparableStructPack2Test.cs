// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs.Test
// @Class     : StructPack2Test
// ----------------------------------------------------------------------
namespace Izayoi.Data.Packs.Test
{
    using Izayoi.Data.Packs;
    using Xunit;

    public class UncomparableStructPack2Test
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
            UncomparableStructPack<int, int> usp = new(value1, value2);

            Assert.Equal(value1, usp.Value1);
            Assert.Equal(value2, usp.Value2);
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
            UncomparableStructPack<int, int> usp = new(value1, value2);

            (int v1, int v2) = usp;

            Assert.Equal(v1, usp.Value1);
            Assert.Equal(v2, usp.Value2);
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
        public void Test_Pack2_int_int_Equals(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expectedResult)
        {
            UncomparableStructPack<int, int> usp1 = new(value_1_1, value_1_2);
            UncomparableStructPack<int, int> usp2 = new(value_2_1, value_2_2);

            bool actualResult = usp1.Equals(usp2);

            Assert.Equal(expectedResult, actualResult);
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
        public void Test_Pack2_int_int_operator_Equals(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expectedResult)
        {
            UncomparableStructPack<int, int> usp1 = new(value_1_1, value_1_2);
            UncomparableStructPack<int, int> usp2 = new(value_2_1, value_2_2);

            bool actualResult = usp1 == usp2;

            Assert.Equal(expectedResult, actualResult);
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
        public void Test_Pack2_int_int_operator_NotEquals(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expectedResult)
        {
            UncomparableStructPack<int, int> usp1 = new(value_1_1, value_1_2);
            UncomparableStructPack<int, int> usp2 = new(value_2_1, value_2_2);

            bool actualResult = usp1 != usp2;

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion
    }
}