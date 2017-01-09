using FCP.Util;
using System;

namespace FCP.Web.Api.Client
{
    public static class StringUriExtensions
    {
        private readonly static Uri LocalhostBaseUri = new Uri("http://127.0.0.1/");

        public static Uri ToUri(this string url)
        {
            return url.ToUri(UriKind.RelativeOrAbsolute);
        }

        public static Uri ToUri(this string url, UriKind uriKind)
        {
            if (url.isNullOrEmpty())
            {
                return null;
            }
            return new Uri(url, uriKind);
        }

        public static Uri ToAbsolute(this Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            if (uri.IsAbsoluteUri)
                return uri;

            return new Uri(LocalhostBaseUri, uri);
        }
    }
}
