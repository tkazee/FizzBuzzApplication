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
    }
}
