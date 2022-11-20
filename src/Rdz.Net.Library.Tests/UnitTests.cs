using Xunit;

namespace Rdz.Net.Library.Tests
{
	public class UnitTests
	{
		[Theory]
		[InlineData(1)]
		[InlineData(100)]
		[InlineData(9999)]
		public void SuccessTests(int value)
		{
			Assert.True(value.IsPositive());
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-100)]
		[InlineData(-9999)]
		[InlineData(0)]
		public void FailedTests(int value)
		{
			Assert.True(!value.IsPositive());
		}
	}
}