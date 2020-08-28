using System.Globalization;

namespace Fdo.Api.Contato.Vistoria.Services.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }
    }
}
