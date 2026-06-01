using FizzBuzz.Services;

namespace FizzBuzzTest
{
    public class FizzBuzzServiceTests
    {
        private readonly FizzBuzzService _service = new FizzBuzzService();

        [Theory]
        [InlineData("3", "Fizz")]
        [InlineData("5", "Buzz")]
        [InlineData("15", "FizzBuzz")]
        [InlineData("7", "7")]
        [InlineData("A", "Invalid Input")]
        public void Process_ShouldReturnCorrectOutput(string input, string expected)
        {
            var result = _service.Process(new[] { input }).First();
            Assert.Equal(expected, result.Output);
        }


        [Fact]
        public void Process_EmptyString_ReturnsInvalidInput()
        {
            var result = _service.Process(new[] { "" }).First();
            Assert.Equal("Invalid Input", result.Output);
        }

        [Fact]
        public void Process_NonNumericString_ReturnsInvalidInput()
        {
            var result = _service.Process(new[] { "A" }).First();
            Assert.Equal("Invalid Input", result.Output);
        }

        [Fact]
        public void Process_NullInput_ReturnsInvalidInput()
        {
            var result = _service.Process(new[] { (string)null }).First();
            Assert.Equal("Invalid Input", result.Output);
        }

        [Fact]
        public void Process_NegativeMultipleOfThree_ReturnsFizz()
        {
            var result = _service.Process(new[] { "-9" }).First();
            Assert.Equal("Fizz", result.Output);
        }

        [Fact]
        public void Process_MultipleInputs_ReturnsCorrectCountAndOrder()
        {
            var inputs = new[] { "1", "3", "5", "15", "A" };
            var results = _service.Process(inputs).ToList();

            Assert.Equal(5, results.Count);
            Assert.Equal("1", results[0].Output);
            Assert.Equal("Fizz", results[1].Output);
            Assert.Equal("Buzz", results[2].Output);
            Assert.Equal("FizzBuzz", results[3].Output);
            Assert.Equal("Invalid Input", results[4].Output);
        }

    }
}
