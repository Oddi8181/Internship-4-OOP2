using System.Text.RegularExpressions;

namespace UserApp.Application.Common.Utils
{
    public class URLUtils
    {

        private static readonly Regex _urlRegex =
              new Regex(@"([\w -]+\.)+[\w-]+(/[\w- ./?%&=]*)?$", RegexOptions.Compiled);
        public static bool IsValid(string url)
        {
            return !string.IsNullOrWhiteSpace(url)
                   && _urlRegex.IsMatch(url);
        }
    }
}
