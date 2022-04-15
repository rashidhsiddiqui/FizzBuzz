using FizzBuzz.Interfaces;

namespace FizzBuzz.Models
{
    public class FizBuzzModel
    {
        public string FizBuzzString { get; set; }

        public IDictionary<string[], ProcessResult> FizBuzzResult { get; set; }

        public bool IsFizBuzzStringError { get; set; } = false;

        public string FizBuzzStringError { get; set; } = string.Empty;
    }
}
