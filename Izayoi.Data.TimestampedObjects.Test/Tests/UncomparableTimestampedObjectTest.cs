// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test
// @Class     : UncomparableTimestampedObjectTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test
{
    using System;
    using Izayoi.Data.TimestampedObjects;
    using Izayoi.Data.TimestampedObjects.Test.Samples;
    using Xunit;

    public class UncomparableTimestampedObjectTest
    {
        #region Fields

        private readonly long baseTimestamp;

        #endregion

        #region Constructors

        public UncomparableTimestampedObjectTest()
        {
            baseTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        #endregion

        #region Methods

        [Fact]
        public void Test_Construct_0_int()
        {
            UncomparableTimestampedObject<int> uto = new();

            Assert.Equal(0, uto.Timestamp);

            Assert.Equal(0, uto.Value);
        }

        [Fact]
        public void Test_Construct_0_enum()
        {
            UncomparableTimestampedObject<SampleEnum> uto = new();

            Assert.Equal(0, uto.Timestamp);

            Assert.Equal(SampleEnum.None, uto.Value);
        }

        [Fact]
        public void Test_Construct_1_int()
        {
            int value = 1;

            UncomparableTimestampedObject<int> uto = new(value);

            Assert.True(baseTimestamp <= uto.Timestamp);

            Assert.Equal(value, uto.Value);
        }

        [Theory]
        [InlineData(SampleEnum.None)]
        [InlineData(SampleEnum.Num1)]
        [InlineData(SampleEnum.Num2)]
        public void Test_Construct_1_enum(SampleEnum value)
        {
            UncomparableTimestampedObject<SampleEnum> uto = new(value);

            Assert.True(baseTimestamp <= uto.Timestamp);

            Assert.Equal(value, uto.Value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        public void Test_Construct_1_nullable_int(int? value)
        {
            UncomparableTimestampedObject<int?> uto = new(value);

            Assert.True(baseTimestamp <= uto.Timestamp);

            Assert.Equal(value, uto.Value);
        }

        [Theory]
        [InlineData(SampleEnum.None)]
        [InlineData(SampleEnum.Num1)]
        [InlineData(SampleEnum.Num2)]
        public void Test_Equals_enum(SampleEnum value)
        {
            UncomparableTimestampedObject<SampleEnum> uto1 = new(baseTimestamp, value);
            UncomparableTimestampedObject<SampleEnum> uto2 = new(baseTimestamp, value);

            Assert.Equal(uto1.Timestamp, uto2.Timestamp);

            Assert.Equal(uto1.Value, uto2.Value);

            bool actual = uto1.Equals(uto2);

            Assert.True(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        public void Test_Equals_nullable_int(int? value)
        {
            UncomparableTimestampedObject<int?> uto1 = new(baseTimestamp, value);
            UncomparableTimestampedObject<int?> uto2 = new(baseTimestamp, value);

            Assert.Equal(uto1.Timestamp, uto2.Timestamp);

            Assert.Equal(uto1.Value, uto2.Value);

            bool actual = uto1.Equals(uto2);

            Assert.True(actual);
        }

        [Theory]
        [InlineData(SampleEnum.None)]
        [InlineData(SampleEnum.Num1)]
        [InlineData(SampleEnum.Num2)]
        public void Test_operator_Equals_enum(SampleEnum value)
        {
            UncomparableTimestampedObject<SampleEnum> uto1 = new(baseTimestamp, value);
            UncomparableTimestampedObject<SampleEnum> uto2 = new(baseTimestamp, value);

            Assert.Equal(uto1.Timestamp, uto2.Timestamp);

            Assert.Equal(uto1.Value, uto2.Value);

            bool actual = uto1 == uto2;

            Assert.True(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        public void Test_operator_Equals_nullable_int(int? value)
        {
            UncomparableTimestampedObject<int?> uto1 = new(baseTimestamp, value);
            UncomparableTimestampedObject<int?> uto2 = new(baseTimestamp, value);

            Assert.Equal(uto1.Timestamp, uto2.Timestamp);

            Assert.Equal(uto1.Value, uto2.Value);

            bool actual = uto1 == uto2;

            Assert.True(actual);
        }

        #endregion
    }
}