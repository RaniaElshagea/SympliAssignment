using System;

namespace Sympli.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidUrl(this string urlString)
        {
            return Uri.IsWellFormedUriString(urlString, UriKind.RelativeOrAbsolute);
        }
    }
}
