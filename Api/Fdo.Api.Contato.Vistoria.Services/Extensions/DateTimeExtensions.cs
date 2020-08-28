using System;
using System.Globalization;

namespace Fdo.Api.Contato.Vistoria.Services.Extensions
{
    public static class DateTimeExtensions
    {
        private const string CULTURE = "pt-BR";

        private static CultureInfo _cultureInfo => CultureInfo.GetCultureInfo(CULTURE);

        public static string GetFullDateNameBr(this DateTime dateTime)
        {
            return string.Format(dateTime.ToString("yyyy/MM-{0}/dd-MM-yyyy", _cultureInfo), dateTime.GetMonthTitleCaseBr());
        }

        private static string GetMonthTitleCaseBr(this DateTime dateTime)
        {
            return dateTime.ToString("MMMM", _cultureInfo).ToTitleCase();
        }
    }
}
