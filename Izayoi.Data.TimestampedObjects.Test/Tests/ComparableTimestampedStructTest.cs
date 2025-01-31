// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test
// @Class     : ComparableTimestampedStructTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test
{
    using System;
    using Izayoi.Data.Comparable;
    using Izayoi.Data.Packs;
    using Izayoi.Data.TimestampedObjects;
    using Xunit;

    public class ComparableTimestampedStructTest
    {
        #region Fields

        private readonly long baseTimestamp;

        #endregion

        #region Constructors

        public ComparableTimestampedStructTest()
        {
            baseTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        #endregion

        #region Methods

        [Fact]
        public void Test_Construct_0_int()
        {
            ComparableTimestampedStruct<int> cts = new();

            Assert.Equal(0, cts.Timestamp);

            Assert.Equal(0, cts.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        public void Test_Construct_1_int(int value)
        {
            ComparableTimestampedStruct<int> cts = new(value);

            Assert.True(baseTimestamp <= cts.Timestamp);

            Assert.Equal(value, cts.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(null)]
        public void Test_Construct_1_ComparableNullable_int(int? value)
        {
            ComparableTimestampedStruct<ComparableNullable<int>> cts = new(value);

            Assert.True(baseTimestamp <= cts.Timestamp);

            Assert.Equal(value.HasValue, cts.Value.HasValue);

            Assert.Equal(value.GetValueOrDefault(), cts.Value.GetValueOrDefault());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Test_Construct_2_int(long timestamp, int value)
        {
            ComparableTimestampedStruct<int> cts = new(timestamp, value);

            Assert.Equal(timestamp, cts.Timestamp);

            Assert.Equal(value, cts.Value);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(0, null)]
        public void Test_Construct_2_ComparableNullable_int(long timestamp, int? value)
        {
            ComparableTimestampedStruct<ComparableNullable<int>> cts = new(timestamp, value);

            Assert.Equal(timestamp, cts.Timestamp);

            Assert.Equal(value.HasValue, cts.Value.HasValue);

            Assert.Equal(value.GetValueOrDefault(), cts.Value.GetValueOrDefault());
        }

        //[Theory]
        //[InlineData(0, SampleEnum.None)]
        //public void Test_Construct_2_enum(long timestamp, SampleEnum value)
        //{
        //    ComparableTimestampedStruct<SampleEnum> cts = new(timestamp, value);

        //    Assert.Equal(timestamp, cts.Timestamp);

        //    Assert.Equal(value, cts.Value);
        //}

        //[Theory]
        //[InlineData(0, SampleEnum.None)]
        //public void Test_Construct_2_ComparableNullable_enum(long timestamp, SampleEnum? value)
        //{
        //    ComparableTimestampedStruct<ComparableNullable<SampleEnum>> cts = new(timestamp, value);

        //    Assert.Equal(timestamp, cts.Timestamp);

        //    Assert.Equal(value.HasValue, cts.Value.HasValue);

        //    Assert.Equal(value.GetValueOrDefault(), cts.Value.GetValueOrDefault());
        //}

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(1, 1, true)]
        public void Test_Equals_int(int value1, int value2, bool expected)
        {
            ComparableTimestampedStruct<int> cts1 = new(baseTimestamp, value1);
            ComparableTimestampedStruct<int> cts2 = new(baseTimestamp, value2);

            bool actual = cts1.Equals(cts2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(null, null, true)]
        [InlineData(null, 0, false)]
        [InlineData(0, null, false)]
        public void Test_Equals_ComparableNullable_int(int? value1, int? value2, bool expected)
        {
            ComparableNullable<int> nullable1 = value1;
            ComparableNullable<int> nullable2 = value2;

            ComparableTimestampedStruct<ComparableNullable<int>> cts1 = new(baseTimestamp, nullable1);
            ComparableTimestampedStruct<ComparableNullable<int>> cts2 = new(baseTimestamp, nullable2);

            bool actual = cts1.Equals(cts2);

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
            ComparableStructPack<int, int> pack1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> pack2 = new(value_2_1, value_2_2);

            ComparableTimestampedStruct<ComparableStructPack<int, int>> cts1 = new(baseTimestamp, pack1);
            ComparableTimestampedStruct<ComparableStructPack<int, int>> cts2 = new(baseTimestamp, pack2);

            bool actual = cts1.Equals(cts2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        public void Test_ComparableTo_int(int value1, int value2, int expected)
        {
            ComparableTimestampedStruct<int> cts1 = new(baseTimestamp, value1);
            ComparableTimestampedStruct<int> cts2 = new(baseTimestamp, value2);

            int actual = cts1.CompareTo(cts2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(1, 0, 1)]
        [InlineData(null, null, 0)]
        [InlineData(null, 0, -1)]
        [InlineData(0, null, 1)]
        public void Test_ComparableTo_ComparableNullable_int(int? value1, int? value2, int expected)
        {
            ComparableNullable<int> nullable1 = value1;
            ComparableNullable<int> nullable2 = value2;

            ComparableTimestampedStruct<ComparableNullable<int>> cts1 = new(baseTimestamp, nullable1);
            ComparableTimestampedStruct<ComparableNullable<int>> cts2 = new(baseTimestamp, nullable2);

            int actual = cts1.CompareTo(cts2);

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
        public void Test_ComparableTo_StructPack(int value_1_1, int value_1_2, int value_2_1, int value_2_2, int expected)
        {
            ComparableStructPack<int, int> pack1 = new(value_1_1, value_1_2);
            ComparableStructPack<int, int> pack2 = new(value_2_1, value_2_2);

            ComparableTimestampedStruct<ComparableStructPack<int, int>> cts1 = new(baseTimestamp, pack1);
            ComparableTimestampedStruct<ComparableStructPack<int, int>> cts2 = new(baseTimestamp, pack2);

            int actual = cts1.CompareTo(cts2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_ComparableTo_StructPack_null()
        {
            ComparableStructPack<int, ComparableNullable<int>> pack1 = new(1, null);
            ComparableStructPack<int, ComparableNullable<int>> pack2 = new(1, 0);

            ComparableTimestampedStruct<ComparableStructPack<int, ComparableNullable<int>>> cts1 = new(baseTimestamp, pack1);
            ComparableTimestampedStruct<ComparableStructPack<int, ComparableNullable<int>>> cts2 = new(baseTimestamp, pack2);

            int actual = cts1.CompareTo(cts2);  // null < 0

            Assert.Equal(-1, actual);
        }

        #endregion
    }
}