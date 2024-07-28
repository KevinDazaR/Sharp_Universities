using System.Text.RegularExpressions;

namespace HTML_Componentes.Utils.Functions
{
    public static class PhoneNumberUtils
    {
        public static string CleanPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return string.Empty;
            }

            // Remover todos los caracteres que no sean números o 'x'
            var cleaned = Regex.Replace(phoneNumber, @"[^\dx]", string.Empty);

            // Manejar la extensión separadamente si es necesario
            var extensionIndex = phoneNumber.IndexOf('x');
            if (extensionIndex > -1)
            {
                var mainNumber = Regex.Replace(phoneNumber.Substring(0, extensionIndex), @"[^\d]", string.Empty);
                var extension = Regex.Replace(phoneNumber.Substring(extensionIndex + 1), @"[^\d]", string.Empty);
                cleaned = mainNumber + "x" + extension;
            }

            return cleaned;
        }
    }
}
