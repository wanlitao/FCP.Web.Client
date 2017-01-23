using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FCP.Util;

namespace FCP.Web.Api.Client
{
    public class RestApiClient : IRestApiClient
    {
        private readonly HttpClient _httpClient;

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
        public Uri BaseUri { get; set; }

        protected HttpClient Client { get { return GetHttpClient(); } }
        #endregion

        #region Helper Functions
        protected virtual HttpClient GetHttpClient()
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

        #region Post

        #region Post Empty
        public Task<RestApiResult> PostEmptyAsync(string requestUrl)
        {
            return PostEmptyAsync(requestUrl.ToUri());            
        }

        public Task<RestApiResult> PostEmptyAsync(Uri requestUri)
        {
            return PostEmptyAsync(requestUri, CancellationToken.None);
        }

        public Task<RestApiResult> PostEmptyAsync(string requestUrl, CancellationToken cancellationToken)
        {
            return PostEmptyAsync(requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult> PostEmptyAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return SendAsync(new RestApiEmptyRequest(HttpMethod.Post, requestUri), cancellationToken);
        }

        public Task<RestApiResult<T>> PostEmptyAsync<T>(string requestUrl)
        {
            return PostEmptyAsync<T>(requestUrl.ToUri());
        }

        public Task<RestApiResult<T>> PostEmptyAsync<T>(Uri requestUri)
        {
            return PostEmptyAsync<T>(requestUri, CancellationToken.None);
        }

        public Task<RestApiResult<T>> PostEmptyAsync<T>(string requestUrl, CancellationToken cancellationToken)
        {
            return PostEmptyAsync<T>(requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult<T>> PostEmptyAsync<T>(Uri requestUri, CancellationToken cancellationToken)
        {
            return SendAsync<T>(new RestApiEmptyRequest(HttpMethod.Post, requestUri), cancellationToken);
        }
        #endregion

        #region Post Json String
        public Task<RestApiResult> PostJsonAsync(string requestUrl, string requestJson)
        {
            return PostJsonAsync(requestUrl.ToUri(), requestJson);
        }

        public Task<RestApiResult> PostJsonAsync(Uri requestUri, string requestJson)
        {
            return PostJsonAsync(requestUri, requestJson, CancellationToken.None);
        }

        public Task<RestApiResult> PostJsonAsync(string requestUrl, string requestJson, CancellationToken cancellationToken)
        {
            return PostJsonAsync(requestUrl.ToUri(), requestJson, cancellationToken);
        }

        public Task<RestApiResult> PostJsonAsync(Uri requestUri, string requestJson, CancellationToken cancellationToken)
        {
            return SendAsync(new RestApiJsonRequest(HttpMethod.Post, requestUri) { Json = requestJson }, cancellationToken);
        }

        public Task<RestApiResult<T>> PostJsonAsync<T>(string requestUrl, string requestJson)
        {
            return PostJsonAsync<T>(requestUrl.ToUri(), requestJson);
        }

        public Task<RestApiResult<T>> PostJsonAsync<T>(Uri requestUri, string requestJson)
        {
            return PostJsonAsync<T>(requestUri, requestJson, CancellationToken.None);
        }

        public Task<RestApiResult<T>> PostJsonAsync<T>(string requestUrl, string requestJson, CancellationToken cancellationToken)
        {
            return PostJsonAsync<T>(requestUrl.ToUri(), requestJson, cancellationToken);
        }

        public Task<RestApiResult<T>> PostJsonAsync<T>(Uri requestUri, string requestJson, CancellationToken cancellationToken)
        {
            return SendAsync<T>(new RestApiJsonRequest(HttpMethod.Post, requestUri) { Json = requestJson }, cancellationToken);
        }
        #endregion

        #region Post Data AsJson
        public Task<RestApiResult> PostAsJsonAsync<T>(string requestUrl, T requestData)
        {
            return PostAsJsonAsync(requestUrl.ToUri(), requestData);
        }

        public Task<RestApiResult> PostAsJsonAsync<T>(Uri requestUri, T requestData)
        {
            return PostAsJsonAsync(requestUri, requestData, CancellationToken.None);
        }

        public Task<RestApiResult> PostAsJsonAsync<T>(string requestUrl, T requestData, CancellationToken cancellationToken)
        {
            return PostAsJsonAsync(requestUrl.ToUri(), requestData, cancellationToken);
        }

        public Task<RestApiResult> PostAsJsonAsync<T>(Uri requestUri, T requestData, CancellationToken cancellationToken)
        {
            return SendAsync(new RestApiJsonRequest<T>(HttpMethod.Post, requestUri) { Data = requestData }, cancellationToken);
        }

        public Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string requestUrl, TRequest requestData)
        {
            return PostAsJsonAsync<TRequest, TResult>(requestUrl.ToUri(), requestData);
        }

        public Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(Uri requestUri, TRequest requestData)
        {
            return PostAsJsonAsync<TRequest, TResult>(requestUri, requestData, CancellationToken.None);
        }

        public Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string requestUrl, TRequest requestData, CancellationToken cancellationToken)
        {
            return PostAsJsonAsync<TRequest, TResult>(requestUrl.ToUri(), requestData, cancellationToken);
        }

        public Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(Uri requestUri, TRequest requestData, CancellationToken cancellationToken)
        {
            return SendAsync<TResult>(new RestApiJsonRequest<TRequest>(HttpMethod.Post, requestUri) { Data = requestData }, cancellationToken);
        }
        #endregion

        #endregion

        #region Put

        #region Put Empty
        public Task<RestApiResult> PutEmptyAsync(string requestUrl)
        {
            return PutEmptyAsync(requestUrl.ToUri());
        }

        public Task<RestApiResult> PutEmptyAsync(Uri requestUri)
        {
            return PutEmptyAsync(requestUri, CancellationToken.None);
        }

        public Task<RestApiResult> PutEmptyAsync(string requestUrl, CancellationToken cancellationToken)
        {
            return PutEmptyAsync(requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult> PutEmptyAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return SendAsync(new RestApiEmptyRequest(HttpMethod.Put, requestUri), cancellationToken);
        }

        public Task<RestApiResult<T>> PutEmptyAsync<T>(string requestUrl)
        {
            return PutEmptyAsync<T>(requestUrl.ToUri());
        }

        public Task<RestApiResult<T>> PutEmptyAsync<T>(Uri requestUri)
        {
            return PutEmptyAsync<T>(requestUri, CancellationToken.None);
        }

        public Task<RestApiResult<T>> PutEmptyAsync<T>(string requestUrl, CancellationToken cancellationToken)
        {
            return PutEmptyAsync<T>(requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult<T>> PutEmptyAsync<T>(Uri requestUri, CancellationToken cancellationToken)
        {
            return SendAsync<T>(new RestApiEmptyRequest(HttpMethod.Put, requestUri), cancellationToken);
        }
        #endregion

        #region Put Json String
        public Task<RestApiResult> PutJsonAsync(string requestUrl, string requestJson)
        {
            return PutJsonAsync(requestUrl.ToUri(), requestJson);
        }

        public Task<RestApiResult> PutJsonAsync(Uri requestUri, string requestJson)
        {
            return PutJsonAsync(requestUri, requestJson, CancellationToken.None);
        }

        public Task<RestApiResult> PutJsonAsync(string requestUrl, string requestJson, CancellationToken cancellationToken)
        {
            return PutJsonAsync(requestUrl.ToUri(), requestJson, cancellationToken);
        }

        public Task<RestApiResult> PutJsonAsync(Uri requestUri, string requestJson, CancellationToken cancellationToken)
        {
            return SendAsync(new RestApiJsonRequest(HttpMethod.Put, requestUri) { Json = requestJson }, cancellationToken);
        }

        public Task<RestApiResult<T>> PutJsonAsync<T>(string requestUrl, string requestJson)
        {
            return PutJsonAsync<T>(requestUrl.ToUri(), requestJson);
        }

        public Task<RestApiResult<T>> PutJsonAsync<T>(Uri requestUri, string requestJson)
        {
            return PutJsonAsync<T>(requestUri, requestJson, CancellationToken.None);
        }

        public Task<RestApiResult<T>> PutJsonAsync<T>(string requestUrl, string requestJson, CancellationToken cancellationToken)
        {
            return PutJsonAsync<T>(requestUrl.ToUri(), requestJson, cancellationToken);
        }

        public Task<RestApiResult<T>> PutJsonAsync<T>(Uri requestUri, string requestJson, CancellationToken cancellationToken)
        {
            return SendAsync<T>(new RestApiJsonRequest(HttpMethod.Put, requestUri) { Json = requestJson }, cancellationToken);
        }
        #endregion

        #region Put Data AsJson
        public Task<RestApiResult> PutAsJsonAsync<T>(string requestUrl, T requestData)
        {
            return PutAsJsonAsync(requestUrl.ToUri(), requestData);
        }

        public Task<RestApiResult> PutAsJsonAsync<T>(Uri requestUri, T requestData)
        {
            return PutAsJsonAsync(requestUri, requestData, CancellationToken.None);
        }

        public Task<RestApiResult> PutAsJsonAsync<T>(string requestUrl, T requestData, CancellationToken cancellationToken)
        {
            return PutAsJsonAsync(requestUrl.ToUri(), requestData, cancellationToken);
        }

        public Task<RestApiResult> PutAsJsonAsync<T>(Uri requestUri, T requestData, CancellationToken cancellationToken)
        {
            return SendAsync(new RestApiJsonRequest<T>(HttpMethod.Put, requestUri) { Data = requestData }, cancellationToken);
        }

        public Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string requestUrl, TRequest requestData)
        {
            return PutAsJsonAsync<TRequest, TResult>(requestUrl.ToUri(), requestData);
        }

        public Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(Uri requestUri, TRequest requestData)
        {
            return PutAsJsonAsync<TRequest, TResult>(requestUri, requestData, CancellationToken.None);
        }

        public Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string requestUrl, TRequest requestData, CancellationToken cancellationToken)
        {
            return PutAsJsonAsync<TRequest, TResult>(requestUrl.ToUri(), requestData, cancellationToken);
        }

        public Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(Uri requestUri, TRequest requestData, CancellationToken cancellationToken)
        {
            return SendAsync<TResult>(new RestApiJsonRequest<TRequest>(HttpMethod.Put, requestUri) { Data = requestData }, cancellationToken);
        }
        #endregion

        #endregion

        #region Delete
        public Task<RestApiResult> DeleteAsync(string requestUrl)
        {
            return DeleteAsync(requestUrl.ToUri());
        }

        public Task<RestApiResult> DeleteAsync(Uri requestUri)
        {
            return DeleteAsync(requestUri, CancellationToken.None);
        }

        public Task<RestApiResult> DeleteAsync(string requestUrl, CancellationToken cancellationToken)
        {
            return DeleteAsync(requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return SendAsync(new RestApiEmptyRequest(HttpMethod.Delete, requestUri), cancellationToken);
        }

        public Task<RestApiResult<T>> DeleteAsync<T>(string requestUrl)
        {
            return DeleteAsync<T>(requestUrl.ToUri());
        }

        public Task<RestApiResult<T>> DeleteAsync<T>(Uri requestUri)
        {
            return DeleteAsync<T>(requestUri, CancellationToken.None);
        }

        public Task<RestApiResult<T>> DeleteAsync<T>(string requestUrl, CancellationToken cancellationToken)
        {
            return DeleteAsync<T>(requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult<T>> DeleteAsync<T>(Uri requestUri, CancellationToken cancellationToken)
        {
            return SendAsync<T>(new RestApiEmptyRequest(HttpMethod.Delete, requestUri), cancellationToken);
        }
        #endregion

        #region Send
        public Task<RestApiResult> SendAsync(RestApiRequest request)
        {
            return SendAsync(request, CancellationToken.None);
        }

        public async Task<RestApiResult> SendAsync(RestApiRequest request, CancellationToken cancellationToken)
        {
            var response = await Client.SendAsync(request.ToRequestMessage(), cancellationToken).ConfigureAwait(false);

            return await response.ToRestResultAsync().ConfigureAwait(false);
        }

        public Task<RestApiResult<T>> SendAsync<T>(RestApiRequest request)
        {
            return SendAsync<T>(request, CancellationToken.None);
        }

        public async Task<RestApiResult<T>> SendAsync<T>(RestApiRequest request, CancellationToken cancellationToken)
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
