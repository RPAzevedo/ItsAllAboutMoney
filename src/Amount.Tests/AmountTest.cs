using Xunit;

namespace Money.Tests
{
    public class amount_as_a_value
    {
        [Theory]
        [InlineData("5.00", "5")]
        [InlineData("5.00", "5.00")]
        [InlineData("5.67", "5.67")]
        [InlineData("5.67", "5.674")]
        [InlineData("5.68", "5.675")]
        public void equivalent_amounts_are_equal(string input1, string input2)
        {
            Assert.Equal(new Amount(input1), new Amount(input2));
        }

        [Theory]
        [InlineData("5.67", "5.68")]
        [InlineData("5.67", "5.675")]
        public void different_amounts_are_not_equal(string input1, string input2)
        {
            Assert.NotEqual(new Amount(input1), new Amount(input2));
        }

        [Theory]
        [InlineData("5.00",  "5.00")]
        [InlineData("5.1",   "5.10")]
        [InlineData("5.12",  "5.12")]
        [InlineData("5.124", "5.12")]
        [InlineData("5.125", "5.13")]
        public void amounts_display_with_two_decimal_digits(string input, string expected)
        {
            Assert.Equal(expected, new Amount(input).ToString());
        }
    }
}
