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
		[InlineData("String: {Text}, Double: {NumberDouble}, Int32: {NumberInteger}", "String: this is string, Double: 1234.5678, Int32: 1234")]
		[InlineData("String: {Text}, Double: {NumberDouble:#,##0.0}, Int32: {NumberInteger:#,##0.00}, Date: {DateFirst:ddMMyyyy}", "String: this is string, Double: 1,234.6, Int32: 1,234.00, Date: 01010001")]
		[InlineData("Date1: {DateFirst:ddMMyyyy}", "Date1: 01010001")]
		[InlineData("Date2: {DateFirst:HHmmss}", "Date2: 000000")]
		[InlineData("Date3: {DateFirst:ddd}", "Date3: Mon")]
		[InlineData("Date4: {DateFirst:dddd}", "Date4: Monday")]
		[InlineData("Date5: {DateFirst:MMM}", "Date5: Jan")]
		[InlineData("Date6: {DateFirst:MMMM}", "Date6: January")]
		[InlineData("NotFoundProps: {NonExistProps}", "NotFoundProps: {NonExistProps}")]
		void FormatTemplateTests(string value, string expected)
		{
			object data = new
			{
				Text = "this is string",
				NumberDouble = 1234.5678,
				NumberInteger = 1234,
				DateFirst = DateTime.MinValue,
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
	}
}