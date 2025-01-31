// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test
// @Class     : UncomparableTimestampedClassTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test
{
    using System;
    using Izayoi.Data.TimestampedObjects;
    using Izayoi.Data.TimestampedObjects.Test.Samples;
    using Xunit;

    public class UncomparableTimestampedClassTest
    {
        #region Fields

        private readonly long baseTimestamp;

        #endregion

        #region Constructors

        public UncomparableTimestampedClassTest()
        {
            baseTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        #endregion

        #region Methods

        [Fact]
        public void Test_Construct_0_SampleClass()
        {
            UncomparableTimestampedClass<UncomparableSample1Class> utc = new();

            Assert.Equal(0, utc.Timestamp);

            Assert.Null(utc.Value);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        [InlineData(-1, -1)]
        [InlineData(1, -1)]
        [InlineData(-1, 1)]
        public void Test_Construct_1_SampleClass(int value1, int value2)
        {
            UncomparableSample2Class sampleClass = new(value1, value2);

            UncomparableTimestampedClass<UncomparableSample2Class> utc = new(sampleClass);

            Assert.True(baseTimestamp <= utc.Timestamp);

            Assert.NotNull(utc.Value);

            Assert.Equal(value1, utc.Value.Value1);
            Assert.Equal(value2, utc.Value.Value2);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(1, -1)]
        public void Test_Construct_2_Sample1(long timestamp, int value1)
        {
            UncomparableSample1Class sampleClass = new(value1);

            UncomparableTimestampedClass<UncomparableSample1Class> utc = new(timestamp, sampleClass);

            Assert.Equal(timestamp, utc.Timestamp);

            Assert.NotNull(utc.Value);

            Assert.Equal(value1, utc.Value.Value1);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 0, -1)]
        [InlineData(0, -1, 0)]
        [InlineData(0, -1, -1)]
        [InlineData(0, 1, -1)]
        [InlineData(0, -1, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 0, -1)]
        [InlineData(1, -1, 0)]
        [InlineData(1, -1, -1)]
        [InlineData(1, 1, -1)]
        [InlineData(1, -1, 1)]
        public void Test_Construct_2_Sample2(long timestamp, int value1, int value2)
        {
            UncomparableSample2Class sampleClass = new(value1, value2);

            UncomparableTimestampedClass<UncomparableSample2Class> utc = new(timestamp, sampleClass);

            Assert.Equal(timestamp, utc.Timestamp);

            Assert.NotNull(utc.Value);

            Assert.Equal(value1, utc.Value.Value1);
            Assert.Equal(value2, utc.Value.Value2);
        }

        [Theory]
        [InlineData(0, 0, 0, true)]
        [InlineData(1, 0, 0, false)]
        [InlineData(1, 1, 0, true)]
        public void Test_Equals_Sample1_SameClass(long timestamp1, long timestamp2, int value, bool expected)
        {
            UncomparableSample1Class sampleClass = new(value);

            UncomparableTimestampedClass<UncomparableSample1Class> utc1 = new(timestamp1, sampleClass);
            UncomparableTimestampedClass<UncomparableSample1Class> utc2 = new(timestamp2, sampleClass);

            bool actual = utc1.Equals(utc2);

            Assert.Equal(expected, actual);
        }

        // compare address
        [Theory]
        [InlineData(0, 0, 1, 0, false)]
        [InlineData(1, 0, 0, 0, false)]
        [InlineData(0, 0, 0, 0, false)]  // not true
        [InlineData(0, 1, 0, 1, false)]  // not true
        [InlineData(0, 2, 0, 2, false)]  // not true
        [InlineData(1, 0, 1, 0, false)]  // not true
        [InlineData(1, 1, 1, 1, false)]  // not true
        [InlineData(1, 2, 1, 2, false)]  // not true
        public void Test_Equals_Sample1_DeferClass(long timestamp1, int value1, long timestamp2, int value2, bool expected)
        {
            UncomparableSample1Class sampleClass1 = new(value1);
            UncomparableSample1Class sampleClass2 = new(value2);

            UncomparableTimestampedClass<UncomparableSample1Class> utc1 = new(timestamp1, sampleClass1);
            UncomparableTimestampedClass<UncomparableSample1Class> utc2 = new(timestamp2, sampleClass2);

            bool actual = utc1.Equals(utc2);

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}