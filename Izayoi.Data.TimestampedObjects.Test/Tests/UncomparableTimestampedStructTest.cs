// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test
// @Class     : UncomparableTimestampedStructTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test
{
    using System;
    using Izayoi.Data.Packs;
    using Izayoi.Data.TimestampedObjects;
    using Izayoi.Data.TimestampedObjects.Test.Samples;
    using Xunit;

    public class UncomparableTimestampedStructTest
    {
        #region Fields

        private readonly long baseTimestamp;

        #endregion

        #region Constructors

        public UncomparableTimestampedStructTest()
        {
            baseTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        #endregion

        #region Methods

        [Fact]
        public void Test_Construct_0_int()
        {
            UncomparableTimestampedStruct<int> uts = new();

            Assert.Equal(0, uts.Timestamp);

            Assert.Equal(0, uts.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Test_Construct_1_int(int value)
        {
            UncomparableTimestampedStruct<int> uts = new(value);

            Assert.True(baseTimestamp <= uts.Timestamp);

            Assert.Equal(value, uts.Value);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Test_Construct_2_int(long timestamp, int value)
        {
            UncomparableTimestampedStruct<int> uts = new(timestamp, value);

            Assert.Equal(timestamp, uts.Timestamp);

            Assert.Equal(value, uts.Value);
        }

        [Theory]
        [InlineData(0, SampleEnum.None)]
        public void Test_Construct_2_enum(long timestamp, SampleEnum value)
        {
            UncomparableTimestampedStruct<SampleEnum> uts = new(timestamp, value);

            Assert.True(uts.Timestamp < baseTimestamp);

            Assert.Equal(value, uts.Value);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, true)]
        [InlineData(1, 0, 2, 0, false)]
        [InlineData(1, 1, 2, 0, false)]
        [InlineData(1, 1, 2, 1, false)]
        [InlineData(1, 2, 2, 1, false)]
        [InlineData(2, 0, 1, 0, false)]
        [InlineData(2, 0, 1, 1, false)]
        [InlineData(2, 1, 1, 1, false)]
        [InlineData(2, 1, 1, 2, false)]
        public void Test_Equals_Struct(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expected)
        {
            UncomparableSample2Struct struct1 = new(value_1_1, value_1_2);
            UncomparableSample2Struct struct2 = new(value_2_1, value_2_2);

            UncomparableTimestampedStruct<UncomparableSample2Struct> uts1 = new(baseTimestamp, struct1);
            UncomparableTimestampedStruct<UncomparableSample2Struct> uts2 = new(baseTimestamp, struct2);

            bool actual = uts1.Equals(uts2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, true)]
        [InlineData(1, 0, 2, 0, false)]
        [InlineData(1, 1, 2, 0, false)]
        [InlineData(1, 1, 2, 1, false)]
        [InlineData(1, 2, 2, 1, false)]
        [InlineData(2, 0, 1, 0, false)]
        [InlineData(2, 0, 1, 1, false)]
        [InlineData(2, 1, 1, 1, false)]
        [InlineData(2, 1, 1, 2, false)]
        public void Test_Equals_StructPack(int value_1_1, int value_1_2, int value_2_1, int value_2_2, bool expected)
        {
            UncomparableStructPack<int, int> pack1 = new(value_1_1, value_1_2);
            UncomparableStructPack<int, int> pack2 = new(value_2_1, value_2_2);

            UncomparableTimestampedStruct<UncomparableStructPack<int, int>> uts1 = new(baseTimestamp, pack1);
            UncomparableTimestampedStruct<UncomparableStructPack<int, int>> uts2 = new(baseTimestamp, pack2);

            bool actual = uts1.Equals(uts2);

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}