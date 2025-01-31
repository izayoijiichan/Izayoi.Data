// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test
// @Class     : ComparableTimestampedObjectTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test
{
    using System;
    using Izayoi.Data.Comparable;
    using Izayoi.Data.TimestampedObjects;
    using Xunit;

    public class ComparableTimestampedObjectTest
    {
        #region Fields

        private readonly long baseTimestamp;

        #endregion

        #region Constructors

        public ComparableTimestampedObjectTest()
        {
            baseTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        #endregion

        #region Methods

        [Fact]
        public void Test_Construct_0_string()
        {
            ComparableTimestampedObject<string> cto = new();

            Assert.Equal(0, cto.Timestamp);

            Assert.Null(cto.Value);
        }

        [Fact]
        public void Test_Construct_0_int()
        {
            ComparableTimestampedObject<int> cto = new();

            Assert.Equal(0, cto.Timestamp);

            Assert.Equal(0, cto.Value);
        }

        [Fact]
        public void Test_Construct_0_ComparableNullable_int()
        {
            ComparableTimestampedObject<ComparableNullable<int>> cto = new();

            Assert.Equal(0, cto.Timestamp);

            Assert.False(cto.Value.HasValue);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        public void Test_Construct_1_int(int value)
        {
            ComparableTimestampedObject<int> cto = new(value);

            Assert.True(baseTimestamp <= cto.Timestamp);

            Assert.Equal(value, cto.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(null)]
        public void Test_Construct_1_ComparableNullable_int(int? value)
        {
            ComparableTimestampedObject<ComparableNullable<int>> cto = new(value);

            Assert.True(baseTimestamp <= cto.Timestamp);

            Assert.Equal(value.HasValue, cto.Value.HasValue);

            Assert.Equal(value.GetValueOrDefault(), cto.Value.GetValueOrDefault());
        }

        #endregion
    }
}