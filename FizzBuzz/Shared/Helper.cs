namespace FizzBuzz.Shared
{
    public class Helper
    {
        public static int ParseNumber(string str, int defaultValue = 0)
        {
            int result;
            return Int32.TryParse(str, out result) ? result : defaultValue;
        }
    }
}
