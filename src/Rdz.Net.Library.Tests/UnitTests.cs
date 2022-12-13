using System.Text.RegularExpressions;
using Xunit;

namespace Rdz.Net.Library.Tests
{
	public class UnitTests
	{
		[Theory]
		[InlineData(1, true)]
		[InlineData(100, true)]
		[InlineData(9999, true)]
		[InlineData(0, false)]
		[InlineData(-1, false)]
		[InlineData(-100, false)]
		[InlineData(-9999, false)]
		void IsPositiveIntTests(int value, bool expected)
		{
			Assert.Equal(expected, value.IsPositive());
		}

		[Theory]
		[InlineData(0.000000000000000000000000000000001, true)]
		[InlineData(1, true)]
		[InlineData(100, true)]
		[InlineData(9999, true)]
		[InlineData(0, false)]
		[InlineData(-0.000000000000000000000000000000001, false)]
		[InlineData(-1, false)]
		[InlineData(-100, false)]
		[InlineData(-9999, false)]
		void IsPositiveDoubleTests(double value, bool expected)
		{
			Assert.Equal(expected, value.IsPositive());
		}

		[Theory]
		[InlineData("String: {Text}, Double: {NumberDouble}, Int32: {NumberInteger}, ID: {ID}", "String: this is string, Double: 1234.5678, Int32: 1234, ID: 0561c0b3-0d09-4969-af2c-5c39d5c4af6a")]
		[InlineData("String: {Text}, Double: {NumberDouble:#,##0.0}, Int32: {NumberInteger:#,##0.00}, Date: {DateFirst:ddMMyyyy}, ID: {ID:B}", "String: this is string, Double: 1,234.6, Int32: 1,234.00, Date: 01010001, ID: {0561c0b3-0d09-4969-af2c-5c39d5c4af6a}")]
		[InlineData("Date1: {DateFirst:ddMMyyyy}", "Date1: 01010001")]
		[InlineData("Date2: {DateFirst:HHmmss}", "Date2: 000000")]
		[InlineData("Date3: {DateFirst:ddd}", "Date3: Mon")]
		[InlineData("Date4: {DateFirst:dddd}", "Date4: Monday")]
		[InlineData("Date5: {DateFirst:MMM}", "Date5: Jan")]
		[InlineData("Date6: {DateFirst:MMMM}", "Date6: January")]
		[InlineData("ID: {ID}", "ID: 0561c0b3-0d09-4969-af2c-5c39d5c4af6a")]
		[InlineData("ID: {ID:B}", "ID: {0561c0b3-0d09-4969-af2c-5c39d5c4af6a}")]
		[InlineData("ID: {ID:P}", "ID: (0561c0b3-0d09-4969-af2c-5c39d5c4af6a)")]
		[InlineData("NotFoundProps: {NonExistProps}", "NotFoundProps: {NonExistProps}")]
		void FormatTemplateTests(string value, string expected)
		{
			object data = new
			{
				Text = "this is string",
				NumberDouble = 1234.5678,
				NumberInteger = 1234,
				DateFirst = DateTime.MinValue,
				ID = Guid.Parse("0561c0b3-0d09-4969-af2c-5c39d5c4af6a"),
			};
			Assert.Equal(expected, value.FormatTemplate(data));
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		void FormatTemplateInputError(string value)
		{
			var ex = Assert.Throws<ArgumentNullException>(() => value.FormatTemplate(null));
		}

		[Theory]
		[InlineData(null, true)]
		[InlineData("123", false)]
		[InlineData(true, false)]
		[InlineData(false, false)]
		void TestObjectIsNull(object value, bool expected)
		{
			Assert.Equal(expected, value.IsNull());
		}

		[Fact]
		void TestClassIsNotNull()
		{
			var data = new { };
			Assert.False(data.IsNull());
		}

		[Fact]
		void TestClassIsNull()
		{
			List<int> list = new List<int>();
			list.AddRange(new[] { 1, 2 });
			var info = list.FirstOrDefault(x => x > 10);
			Assert.False(info.IsNull());
		}
	}
}