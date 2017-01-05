using System;
using System.Net.Http;
using FCP.Util.Async;

namespace FCP.Web.Api.Client
{
    public abstract class RestApiRequest
    {
        public RestApiRequest(HttpMethod method, string requestUrl)
            : this(method, requestUrl.ToUri())
        { }

        public RestApiRequest(HttpMethod method, Uri requestUri)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));

            Method = method;
            RequestUri = requestUri;
        }

        public Uri RequestUri { get; set; }

        public HttpMethod Method { get; set; }

        public abstract HttpContent Content { get; }
    }

    public class RestApiEmptyRequest : RestApiRequest
    {
        public RestApiEmptyRequest(HttpMethod method, string requestUrl)
            : base(method, requestUrl)
        { }

        public RestApiEmptyRequest(HttpMethod method, Uri requestUri)
            : base(method, requestUri)
        { }

        public override HttpContent Content
        {
            get
            {
                return null;
            }
        }
    }

    public class RestApiJsonRequest : RestApiRequest
    {
        public RestApiJsonRequest(HttpMethod method, string requestUrl)
            : base(method, requestUrl)
        { }

        public RestApiJsonRequest(HttpMethod method, Uri requestUri)
            : base(method, requestUri)
        { }

        public string Json { get; set; }

        public override HttpContent Content
        {
            get
            {
                return new JsonStringContent(Json);
            }
        }
    }

    public class RestApiJsonRequest<T> : RestApiRequest
    {
        public RestApiJsonRequest(HttpMethod method, string requestUrl)
            : base(method, requestUrl)
        { }

        public RestApiJsonRequest(HttpMethod method, Uri requestUri)
            : base(method, requestUri)
        { }

        public T Data { get; set; }

        public override HttpContent Content
        {
            get
            {
                return new JsonStringContent<T>(Data);
            }
        }
    }
}
