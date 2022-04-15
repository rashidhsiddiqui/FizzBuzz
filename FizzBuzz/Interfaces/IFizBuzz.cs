using FizzBuzz.Models;
using System.Text;

namespace FizzBuzz.Interfaces
{
    public interface IFizBuzz
    {
        IDictionary<string[], ProcessResult> ProcessAndReturn(string sbInput);
    }
}
