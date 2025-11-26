using System.Text.RegularExpressions;

namespace UserApp.Application.Common.Utils
{
    public class EmailUtils
    {
        private static readonly Regex _emailRegex =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public static bool IsValid(string email)
        {
            return !string.IsNullOrWhiteSpace(email)
                   && _emailRegex.IsMatch(email);
        }
    }
}
