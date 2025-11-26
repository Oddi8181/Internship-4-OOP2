using System.Text.RegularExpressions;

namespace UserApp.Application.Common.Utils
{
    public class ZipcodeUtils
    {
        private static readonly Regex _zipRegex =
            new Regex(@"^\d{5}(?:[-\s]\d{4})?$", RegexOptions.Compiled);
        public static bool IsValid(string zip)
        {
            return !string.IsNullOrWhiteSpace(zip)
                   && _zipRegex.IsMatch(zip);
        }
    }
}
