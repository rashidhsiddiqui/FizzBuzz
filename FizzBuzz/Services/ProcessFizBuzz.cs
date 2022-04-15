using FizzBuzz.Interfaces;
using FizzBuzz.Models;
using FizzBuzz.Shared;
using System.Text;

namespace FizzBuzz.Services
{
    public class ProcessFizBuzz : IFizBuzz
    {
        private IDictionary<string[], ProcessResult> dictResponses = new Dictionary<string[], ProcessResult>();

        public IDictionary<string[], ProcessResult> ProcessAndReturn(string sbInput)
        {
            string[] strSplitValues = sbInput.Split(',');

            Enumerable.Range(0, strSplitValues.Length)
                .Select(
                        v =>
                        strSplitValues[v].Any(c => char.IsNumber(c)) 
                        ? 
                            (
                                (Helper.ParseNumber(strSplitValues[v]) % 3 == 0 && Helper.ParseNumber(strSplitValues[v]) % 5 == 0) 
                                ? 
                                addDictionaryReponse(strSplitValues[v], new List<string> { Constants.FizzBuzz }) :
                                (Helper.ParseNumber(strSplitValues[v]) % 3 == 0) ? addDictionaryReponse(strSplitValues[v], new List<string> { Constants.Fizz }) :
                                (Helper.ParseNumber(strSplitValues[v]) % 5 == 0) ? addDictionaryReponse(strSplitValues[v], new List<string> { Constants.Buzz })
                                :
                                addDictionaryReponse(strSplitValues[v], new List<string> { $"Divided {strSplitValues[v]} by 3", $"Divided {strSplitValues[v]} by 5" })
                            )
                        : 
                            addDictionaryReponse(string.IsNullOrWhiteSpace(strSplitValues[v]) ? "<Empty>" : strSplitValues[v], new List<string> { Constants.InvalidItem })
                ).ToList<string>();

            return dictResponses;
        }

        private string addDictionaryReponse(string inputValue, List<string> responses)
        {
            dictResponses.Add(new string[] { Guid.NewGuid().ToString(), inputValue }, new ProcessResult { Results = responses });
            return "";
        }
    }
}
