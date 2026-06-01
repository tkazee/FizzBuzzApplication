using FizzBuzz.Entity;

namespace FizzBuzz.IServices
{
        public interface IFizzBuzzService
        {
            IEnumerable<FizzBuzzResponse> Process(IEnumerable<string> inputs);
        }
}
