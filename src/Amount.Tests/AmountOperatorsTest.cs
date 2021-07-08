using Xunit;

namespace Money.Tests
{
    public class amount_operators
    {
        [Theory]
        [InlineData("5.12", "4.34", "9.46")]
        public void amounts_can_be_added(string amount1, string amount2, string sum)
        {
            Assert.Equal(new Amount(sum), new Amount(amount1) + new Amount(amount2));
        }

        [Theory]
        [InlineData("5.12", "4.34", "0.78")]
        public void amounts_can_be_subtracted(string amount1, string amount2, string result)
        {
            Assert.Equal(new Amount(result), new Amount(amount1) - new Amount(amount2));
        }

        [Theory]
        [InlineData("5.12", 2,    "10.24")]
        [InlineData("5.12", 2.05, "10.50")]
        public void amounts_can_be_multiplied(string amount, decimal factor, string result)
        {
            Assert.Equal(new Amount(result), new Amount(amount) * factor);
        }
    }
}
