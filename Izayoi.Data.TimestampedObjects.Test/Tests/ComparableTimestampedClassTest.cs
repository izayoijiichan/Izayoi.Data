// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test
// @Class     : ComparableTimestampedClassTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test
{
    using System;
    using Izayoi.Data.Comparable;
    using Izayoi.Data.TimestampedObjects;
    using Izayoi.Data.TimestampedObjects.Test.Samples;
    using Xunit;

    public class ComparableTimestampedClassTest
    {
        #region Fields

        private readonly long baseTimestamp;

        #endregion

        #region Constructors

        public ComparableTimestampedClassTest()
        {
            baseTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        #endregion

        #region Methods

        [Fact]
        public void Test_Construct_0_string()
        {
            ComparableTimestampedClass<string> ctc = new();

            Assert.Equal(0, ctc.Timestamp);

            Assert.Null(ctc.Value);
        }

        [Fact]
        public void Test_Construct_0_SampleClass()
        {
            ComparableTimestampedClass<ComparableSample1Class> ctc = new();

            Assert.Equal(0, ctc.Timestamp);

            Assert.Null(ctc.Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("b")]
        [InlineData("ab")]
        public void Test_Construct_1_string(string str)
        {
            ComparableTimestampedClass<string> ctc = new(str);

            Assert.True(baseTimestamp <= ctc.Timestamp);

            Assert.NotNull(ctc.Value);

            Assert.Equal(str, ctc.Value);
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
            ComparableSample2Class sampleClass = new(value1, value2);

            ComparableTimestampedClass<ComparableSample2Class> ctc = new(sampleClass);

            Assert.True(baseTimestamp <= ctc.Timestamp);

            Assert.NotNull(ctc.Value);

            Assert.Equal(value1, ctc.Value.Value1);
            Assert.Equal(value2, ctc.Value.Value2);
        }

        [Theory]
        [InlineData(0, "")]
        [InlineData(0, "a")]
        [InlineData(0, "b")]
        [InlineData(0, "ab")]
        [InlineData(1, "")]
        [InlineData(1, "a")]
        [InlineData(1, "b")]
        [InlineData(1, "ab")]
        public void Test_Construct_2_string(long timestamp, string str)
        {
            ComparableTimestampedClass<string> ctc = new(timestamp, str);

            Assert.Equal(timestamp, ctc.Timestamp);

            Assert.NotNull(ctc.Value);

            Assert.Equal(str, ctc.Value);
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
        public void Test_Construct_2_SampleClass(long timestamp, int value1, int value2)
        {
            ComparableSample2Class sampleClass = new(value1, value2);

            ComparableTimestampedClass<ComparableSample2Class> ctc = new(timestamp, sampleClass);

            Assert.Equal(timestamp, ctc.Timestamp);

            Assert.NotNull(ctc.Value);

            Assert.Equal(value1, ctc.Value.Value1);
            Assert.Equal(value2, ctc.Value.Value2);
        }

        [Theory]
        [InlineData(SampleEnum.None)]
        [InlineData(SampleEnum.Num1)]
        [InlineData(SampleEnum.Num2)]
        public void Test_Construct_2_ComparableEnum(SampleEnum value)
        {
            ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc = new(baseTimestamp, value);

            Assert.Equal(baseTimestamp, ctc.Timestamp);

            Assert.NotNull(ctc.Value);

            Assert.Equal(value, ctc.Value.Value);
        }

        // compare value
        [Theory]
        [InlineData("a", "a", true)]
        [InlineData("a", "b", false)]
        [InlineData("b", "a", false)]
        [InlineData("", "", true)]
        [InlineData("", "a", false)]
        [InlineData("a", "", false)]
        [InlineData(null, null, true)]
        [InlineData(null, "a", false)]
        [InlineData("a", null, false)]
        [InlineData(null, "", false)]
        [InlineData("", null, false)]
        public void Test_Equals_string(string? str1, string? str2, bool expected)
        {
            ComparableTimestampedClass<string> ctc1 = new(baseTimestamp, str1);
            ComparableTimestampedClass<string> ctc2 = new(baseTimestamp, str2);

            bool actual = ctc1.Equals(ctc2);

            Assert.Equal(expected, actual);
        }

        // compare value
        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(1, 1, true)]
        [InlineData(-1, 0, false)]
        [InlineData(0, -1, false)]
        [InlineData(-1, -1, true)]
        public void Test_Equals_SampleClass1(int value1, int value2, bool expected)
        {
            ComparableSample1Class sampleClass1 = new(value1);
            ComparableSample1Class sampleClass2 = new(value2);

            ComparableTimestampedClass<ComparableSample1Class> ctc1 = new(baseTimestamp, sampleClass1);
            ComparableTimestampedClass<ComparableSample1Class> ctc2 = new(baseTimestamp, sampleClass2);

            bool actual = ctc1.Equals(ctc2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, true)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, false)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, true)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, false)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, true)]
        public void Test_Equals_ComparableEnum(SampleEnum value1, SampleEnum value2, bool expected)
        {
            ComparableEnum<SampleEnum> ce1 = value1;
            ComparableEnum<SampleEnum> ce2 = value2;

            ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc1 = new(baseTimestamp, ce1);
            ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc2 = new(baseTimestamp, ce2);

            bool actual = ctc1.Equals(ctc2);

            Assert.Equal(expected, actual);
        }

        // null < "" < "a"
        [Theory]
        [InlineData("a", "a", 0)]
        [InlineData("a", "b", -1)]
        [InlineData("b", "a", 1)]
        [InlineData("", "", 0)]
        [InlineData("", "a", -1)]
        [InlineData("a", "", 1)]
        [InlineData(null, null, 0)]
        [InlineData(null, "a", -1)]
        [InlineData("a", null, 1)]
        [InlineData(null, "", -1)]
        [InlineData("", null, 1)]
        public void Test_CompareTo_string(string? str1, string? str2, int expected)
        {
            ComparableTimestampedClass<string> ctc1 = new(baseTimestamp, str1);
            ComparableTimestampedClass<string> ctc2 = new(baseTimestamp, str2);

            int actual = ctc1.CompareTo(ctc2);

            Assert.Equal(expected, actual);
        }

        // compare value
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(-1, 0, -1)]
        [InlineData(0, -1, 1)]
        [InlineData(-1, -1, 0)]
        public void Test_CompareTo_SampleClass1(int value1, int value2, int expected)
        {
            ComparableSample1Class sampleClass1 = new(value1);
            ComparableSample1Class sampleClass2 = new(value2);

            ComparableTimestampedClass<ComparableSample1Class> ctc1 = new(baseTimestamp, sampleClass1);
            ComparableTimestampedClass<ComparableSample1Class> ctc2 = new(baseTimestamp, sampleClass2);

            int actual = ctc1.CompareTo(ctc2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_CompareTo_SampleClass_null()
        {
            ComparableSample1Class? sampleClass1 = null;
            ComparableSample1Class? sampleClass2 = new(0);

            ComparableTimestampedClass<ComparableSample1Class> ctc1 = new(baseTimestamp, sampleClass1);
            ComparableTimestampedClass<ComparableSample1Class> ctc2 = new(baseTimestamp, sampleClass2);

            int actual = ctc1.CompareTo(ctc2);

            Assert.Equal(-1, actual);

            actual = ctc2.CompareTo(ctc1);

            Assert.Equal(1, actual);
        }

        [Theory]
        [InlineData(SampleEnum.None, SampleEnum.None, 0)]
        [InlineData(SampleEnum.None, SampleEnum.Num1, -1)]
        [InlineData(SampleEnum.Num1, SampleEnum.None, 1)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num1, 0)]
        [InlineData(SampleEnum.Num1, SampleEnum.Num2, -1)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num1, 1)]
        [InlineData(SampleEnum.Num2, SampleEnum.Num2, 0)]
        public void Test_CompareTo_ComparableEnum(SampleEnum value1, SampleEnum value2, int expected)
        {
            ComparableEnum<SampleEnum> ce1 = value1;
            ComparableEnum<SampleEnum> ce2 = value2;

            ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc1 = new(baseTimestamp, ce1);
            ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc2 = new(baseTimestamp, ce2);

            int actual = ctc1.CompareTo(ctc2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_CompareTo_ComparableEnum_null()
        {
            ComparableEnum<SampleEnum> ce1 = new();
            ComparableEnum<SampleEnum> ce2 = SampleEnum.None;

            ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc1 = new(baseTimestamp, ce1);
            ComparableTimestampedClass<ComparableEnum<SampleEnum>> ctc2 = new(baseTimestamp, ce2);

            int actual = ctc1.CompareTo(ctc2);

            Assert.Equal(-1, actual);

            actual = ctc2.CompareTo(ctc1);

            Assert.Equal(1, actual);
        }

        #endregion
    }
}