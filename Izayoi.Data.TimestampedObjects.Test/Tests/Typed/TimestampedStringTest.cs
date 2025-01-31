// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.TimestampedObjects.Test
// @Class     : TimestampedStringTest
// ----------------------------------------------------------------------
namespace Izayoi.Data.TimestampedObjects.Test
{
    using System;
    using Izayoi.Data.TimestampedObjects;
    using Xunit;

    public class TimestampedStringTest
    {
        #region Fields

        private readonly long baseTimestamp;

        #endregion

        #region Constructors

        public TimestampedStringTest()
        {
            baseTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        #endregion

        #region Methods
        [Fact]
        public void Test_Construct_0()
        {
            TimestampedString tsString = new();

            Assert.Equal(0, tsString.Timestamp);

            Assert.Equal((string?)null, tsString.Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("b")]
        [InlineData("ab")]
        public void Test_Construct_1(string value)
        {
            TimestampedString tsString = new(value);

            Assert.True(baseTimestamp <= tsString.Timestamp);

            Assert.Equal(value, tsString.Value);
        }

        [Fact]
        public void Test_Construct_1_null()
        {
            //TimestampedString tsString = new(null);

            TimestampedString tsString = new(default(string?));

            Assert.True(baseTimestamp <= tsString.Timestamp);

            Assert.Null(tsString.Value);
        }

        [Theory]
        [InlineData('a', 1)]
        [InlineData('b', 1)]
        public void Test_Construct_1_char(char c, int count)
        {
            TimestampedString tsString = new(c, count);

            string expectedStr = new(c, count);

            Assert.True(baseTimestamp <= tsString.Timestamp);

            Assert.Equal(expectedStr, tsString.Value);
        }

        [Theory]
        [InlineData("abc")]
        public void Test_Construct_1_chars(string str)
        {
            char[] chars = str.ToCharArray();

            TimestampedString tsString = new(chars);

            string expectedStr = new(chars);

            Assert.True(baseTimestamp <= tsString.Timestamp);

            Assert.Equal(expectedStr, tsString.Value);

            Assert.Equal(str, tsString.Value);
        }

        [Theory]
        [InlineData("abc", 0, 1)]
        [InlineData("abc", 0, 2)]
        [InlineData("abc", 0, 3)]
        [InlineData("abc", 1, 1)]
        [InlineData("abc", 1, 2)]
        [InlineData("abc", 2, 1)]
        public void Test_Construct_1_chars_3(string str, int startIndex, int length)
        {
            char[] chars = str.ToCharArray();

            TimestampedString tsString = new(chars, startIndex, length);

            string expectedStr = new(chars, startIndex, length);

            Assert.True(baseTimestamp <= tsString.Timestamp);

            Assert.Equal(expectedStr, tsString.Value);
        }

        [Theory]
        [InlineData(0, "")]
        [InlineData(0, "a")]
        [InlineData(0, "b")]
        [InlineData(1, "")]
        [InlineData(1, "a")]
        [InlineData(1, "b")]
        public void Test_Construct_2(long timestamp, string value)
        {
            TimestampedString tsString = new(timestamp, value);

            Assert.Equal(timestamp, tsString.Timestamp);

            Assert.Equal(value, tsString.Value);
        }

        [Theory]
        [InlineData(0, 'a', 1)]
        [InlineData(0, 'b', 1)]
        [InlineData(1, 'a', 1)]
        [InlineData(1, 'b', 1)]
        public void Test_Construct_2_char(long timestamp, char c, int count)
        {
            TimestampedString tsString = new(timestamp, c, count);

            string expectedStr = new(c, count);

            Assert.Equal(timestamp, tsString.Timestamp);

            Assert.Equal(expectedStr, tsString.Value);
        }

        [Theory]
        [InlineData(0, "abc")]
        [InlineData(1, "abc")]
        public void Test_Construct_2_chars(long timestamp, string str)
        {
            char[] chars = str.ToCharArray();

            TimestampedString tsString = new(timestamp, chars);

            string expectedStr = new(chars);

            Assert.Equal(timestamp, tsString.Timestamp);

            Assert.Equal(expectedStr, tsString.Value);

            Assert.Equal(str, tsString.Value);
        }

        [Theory]
        [InlineData(0, "abc", 0, 1)]
        [InlineData(0, "abc", 0, 2)]
        [InlineData(0, "abc", 0, 3)]
        [InlineData(0, "abc", 1, 1)]
        [InlineData(0, "abc", 1, 2)]
        [InlineData(0, "abc", 2, 1)]
        [InlineData(1, "abc", 0, 1)]
        [InlineData(1, "abc", 0, 2)]
        [InlineData(1, "abc", 0, 3)]
        [InlineData(1, "abc", 1, 1)]
        [InlineData(1, "abc", 1, 2)]
        [InlineData(1, "abc", 2, 1)]
        public void Test_Construct_2_chars_3(long timestamp, string str, int startIndex, int length)
        {
            char[] chars = str.ToCharArray();

            TimestampedString tsString = new(timestamp, chars, startIndex, length);

            string expectedStr = new(chars, startIndex, length);

            Assert.Equal(timestamp, tsString.Timestamp);

            Assert.Equal(expectedStr, tsString.Value);
        }

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
        public void Test_string_Equals(string? str1, string? str2, bool expected)
        {
            TimestampedString tsString1 = new(baseTimestamp, str1);
            TimestampedString tsString2 = new(baseTimestamp, str2);

            bool actual = tsString1.Equals(tsString2);

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
        public void Test_string_CompareTo(string? str1, string? str2, int expected)
        {
            TimestampedString tsString1 = new(baseTimestamp, str1);
            TimestampedString tsString2 = new(baseTimestamp, str2);

            int actual = tsString1.CompareTo(tsString2);

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}