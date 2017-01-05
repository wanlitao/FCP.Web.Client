using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FCP.Util;

namespace FCP.Web.Api.Client
{
    public class RestApiClient : IRestApiClient
    {
        private HttpClient _httpClient;

        #region Constructors
        public RestApiClient(string baseUrl)
            : this()
        {
            if (baseUrl.isNullOrEmpty())
                throw new ArgumentNullException(nameof(baseUrl));

            BaseUri = baseUrl.ToUri();
        }

        public RestApiClient(Uri baseUri)
            : this()
        {
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));

            BaseUri = baseUri;
        }

        public RestApiClient()
        {
            _httpClient = new HttpClient();
        }
        #endregion

        #region Properties
        public virtual Uri BaseUri { get; set; }

        protected HttpClient Client { get { return GetHttpClient(); } }
        #endregion

        #region Helper Functions
        protected HttpClient GetHttpClient()
        {
            _httpClient.BaseAddress = BaseUri;

            return _httpClient;
        }
        #endregion

        #region Get
        public Task<RestApiResult> GetAsync(string requestUrl)
        {
            return GetAsync(requestUrl.ToUri());
        }

        public Task<RestApiResult> GetAsync(Uri requestUri)
        {
            return GetAsync(requestUri, CancellationToken.None);
        }

        public Task<RestApiResult> GetAsync(string requestUrl, CancellationToken cancellationToken)
        {
            return GetAsync(requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return SendAsync(new RestApiEmptyRequest(HttpMethod.Get, requestUri), cancellationToken);
        }

        public Task<RestApiResult<T>> GetAsync<T>(string requestUrl)
        {
            return GetAsync<T>(requestUrl.ToUri());
        }

        public Task<RestApiResult<T>> GetAsync<T>(Uri requestUri)
        {
            return GetAsync<T>(requestUri, CancellationToken.None);
        }

        public Task<RestApiResult<T>> GetAsync<T>(string requestUrl, CancellationToken cancellationToken)
        {
            return GetAsync<T>(requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult<T>> GetAsync<T>(Uri requestUri, CancellationToken cancellationToken)
        {
            return SendAsync<T>(new RestApiEmptyRequest(HttpMethod.Get, requestUri), cancellationToken);
        }
        #endregion

        #region Send
        protected async Task<RestApiResult> SendAsync(RestApiRequest request, CancellationToken cancellationToken)
        {
            var response = await Client.SendAsync(request.ToRequestMessage(), cancellationToken).ConfigureAwait(false);

            return await response.ToRestResultAsync().ConfigureAwait(false);
        }

        protected async Task<RestApiResult<T>> SendAsync<T>(RestApiRequest request, CancellationToken cancellationToken)
        {
            var response = await Client.SendAsync(request.ToRequestMessage(), cancellationToken).ConfigureAwait(false);

            return await response.ToRestResultAsync<T>().ConfigureAwait(false);
        }
        #endregion

        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }
            }
            this.disposed = true;
        }

        ~RestApiClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
