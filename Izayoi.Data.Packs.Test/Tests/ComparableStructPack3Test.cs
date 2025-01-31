// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Packs.Test
// @Class     : ComparableStructPack3Test
// ----------------------------------------------------------------------
namespace Izayoi.Data.Packs.Test
{
    using Izayoi.Data.Packs;
    using Xunit;

    public class ComparableStructPack3Test
    {
        #region Methods

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        public void Test_Pack3_Construct(int value1, int value2, int value3)
        {
            ComparableStructPack<int, int, int> csp = new(value1, value2, value3);

            Assert.Equal(value1, csp.Value1);
            Assert.Equal(value2, csp.Value2);
            Assert.Equal(value3, csp.Value3);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        public void Test_Pack3_Deconstruct_2(int value1, int value2, int value3)
        {
            ComparableStructPack<int, int, int> csp = new(value1, value2, value3);

            (int v1, int v2) = csp;

            Assert.Equal(v1, csp.Value1);
            Assert.Equal(v2, csp.Value2);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        public void Test_Pack3_Deconstruct_3(int value1, int value2, int value3)
        {
            ComparableStructPack<int, int, int> csp = new(value1, value2, value3);

            (int v1, int v2, int v3) = csp;

            Assert.Equal(v1, csp.Value1);
            Assert.Equal(v2, csp.Value2);
            Assert.Equal(v3, csp.Value3);
        }

        #endregion
    }
}