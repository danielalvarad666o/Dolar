using System.Text.RegularExpressions;

namespace Dolar.Helpers
{
    public static class RegexHelper
    {
        public static string NormalizeString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var cleanString = Regex.Replace(input, @"\s+", " ").Trim();

            return cleanString.ToLower();
        }

        public static bool IsValidName(string input)
        {
            var pattern = @"^[a-zA-Z\s]+$";  // Solo permite letras y espacios
            return Regex.IsMatch(input, pattern);
        }
    }
}
