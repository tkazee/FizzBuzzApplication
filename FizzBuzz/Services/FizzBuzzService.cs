using FizzBuzz.Entity;
using FizzBuzz.IServices;

namespace FizzBuzz.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public IEnumerable<FizzBuzzResponse> Process(IEnumerable<string> inputs)
        {
            var results = new List<FizzBuzzResponse>();
            foreach (var item in inputs)
            {
                var processed = Transform(item);
                results.Add(processed);
            }
            return results;
        }
        private FizzBuzzResponse Transform(string input)
        {
            var result = new FizzBuzzResponse { Input = input };

            if (int.TryParse(input, out int value))
            {
                bool isDiv3 = value % 3 == 0;
                bool isDiv5 = value % 5 == 0;

                if (isDiv3 && isDiv5) result.Output = "FizzBuzz";
                else if (isDiv3) result.Output = "Fizz";
                else if (isDiv5) result.Output = "Buzz";
                else result.Output = value.ToString();                
            }
            else
            {
                result.Output = "Invalid Input";                
            }
            return result;
        }
    }
}
