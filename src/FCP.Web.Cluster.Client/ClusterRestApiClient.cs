using FCP.Util;
using FCP.Web.Api.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FCP.Web.Cluster.Client
{
    public class ClusterRestApiClient : IClusterRestApiClient
    {
        private readonly IClusterCacheService _clusterService;
        private readonly IRestApiClient _restClient;

        #region Constructors
        public ClusterRestApiClient(ILoadBalanceClusterProvider clusterProvider)
            : this()
        {
            _clusterService = new ClusterCacheService(clusterProvider);
        }

        private ClusterRestApiClient()
        {
            _restClient = new RestApiClient();
        }
        #endregion

        #region Helper Functions
        protected Uri BuildClusterServiceRequestUri(string service, Uri requestUri)
        {
            if (service.isNullOrEmpty())
                throw new ArgumentNullException(nameof(service));

            if (requestUri == null)
                throw new ArgumentNullException(nameof(requestUri));

            var requestAbsoluteUri = requestUri.ToAbsolute();

            var uriBuilder = new FluentUriBuilder().Scheme(requestAbsoluteUri.Scheme)
                .Host(requestAbsoluteUri.Host).Port(requestAbsoluteUri.Port)
                .AppendSegment(service).AppendSegment(requestAbsoluteUri.AbsolutePath)
                .Query(requestAbsoluteUri.Query);

            return uriBuilder.Build();
        }
        #endregion

        #region Get
        public Task<RestApiResult> GetAsync(string service, string requestUrl)
        {
            return GetAsync(service, requestUrl.ToUri());
        }

        public Task<RestApiResult> GetAsync(string service, Uri requestUri)
        {
            return GetAsync(service, requestUri, CancellationToken.None);
        }

        public Task<RestApiResult> GetAsync(string service, string requestUrl, CancellationToken cancellationToken)
        {
            return GetAsync(service, requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult> GetAsync(string service, Uri requestUri, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync(new RestApiEmptyRequest(HttpMethod.Get, fullRequestUri), cancellationToken);
        }

        public Task<RestApiResult<T>> GetAsync<T>(string service, string requestUrl)
        {
            return GetAsync<T>(service, requestUrl.ToUri());
        }

        public Task<RestApiResult<T>> GetAsync<T>(string service, Uri requestUri)
        {
            return GetAsync<T>(service, requestUri, CancellationToken.None);
        }

        public Task<RestApiResult<T>> GetAsync<T>(string service, string requestUrl, CancellationToken cancellationToken)
        {
            return GetAsync<T>(service, requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult<T>> GetAsync<T>(string service, Uri requestUri, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync<T>(new RestApiEmptyRequest(HttpMethod.Get, fullRequestUri), cancellationToken);
        }
        #endregion

        #region Post

        #region Post Empty
        public Task<RestApiResult> PostEmptyAsync(string service, string requestUrl)
        {
            return PostEmptyAsync(service, requestUrl.ToUri());            
        }

        public Task<RestApiResult> PostEmptyAsync(string service, Uri requestUri)
        {
            return PostEmptyAsync(service, requestUri, CancellationToken.None);
        }

        public Task<RestApiResult> PostEmptyAsync(string service, string requestUrl, CancellationToken cancellationToken)
        {
            return PostEmptyAsync(service, requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult> PostEmptyAsync(string service, Uri requestUri, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync(new RestApiEmptyRequest(HttpMethod.Post, fullRequestUri), cancellationToken);
        }

        public Task<RestApiResult<T>> PostEmptyAsync<T>(string service, string requestUrl)
        {
            return PostEmptyAsync<T>(service, requestUrl.ToUri());
        }

        public Task<RestApiResult<T>> PostEmptyAsync<T>(string service, Uri requestUri)
        {
            return PostEmptyAsync<T>(service, requestUri, CancellationToken.None);
        }

        public Task<RestApiResult<T>> PostEmptyAsync<T>(string service, string requestUrl, CancellationToken cancellationToken)
        {
            return PostEmptyAsync<T>(service, requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult<T>> PostEmptyAsync<T>(string service, Uri requestUri, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync<T>(new RestApiEmptyRequest(HttpMethod.Post, fullRequestUri), cancellationToken);
        }
        #endregion

        #region Post Json String
        public Task<RestApiResult> PostJsonAsync(string service, string requestUrl, string requestJson)
        {
            return PostJsonAsync(service, requestUrl.ToUri(), requestJson);
        }

        public Task<RestApiResult> PostJsonAsync(string service, Uri requestUri, string requestJson)
        {
            return PostJsonAsync(service, requestUri, requestJson, CancellationToken.None);
        }

        public Task<RestApiResult> PostJsonAsync(string service, string requestUrl, string requestJson, CancellationToken cancellationToken)
        {
            return PostJsonAsync(service, requestUrl.ToUri(), requestJson, cancellationToken);
        }

        public Task<RestApiResult> PostJsonAsync(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync(new RestApiJsonRequest(HttpMethod.Post, fullRequestUri) { Json = requestJson }, cancellationToken);
        }

        public Task<RestApiResult<T>> PostJsonAsync<T>(string service, string requestUrl, string requestJson)
        {
            return PostJsonAsync<T>(service, requestUrl.ToUri(), requestJson);
        }

        public Task<RestApiResult<T>> PostJsonAsync<T>(string service, Uri requestUri, string requestJson)
        {
            return PostJsonAsync<T>(service, requestUri, requestJson, CancellationToken.None);
        }

        public Task<RestApiResult<T>> PostJsonAsync<T>(string service, string requestUrl, string requestJson, CancellationToken cancellationToken)
        {
            return PostJsonAsync<T>(service, requestUrl.ToUri(), requestJson, cancellationToken);
        }

        public Task<RestApiResult<T>> PostJsonAsync<T>(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync<T>(new RestApiJsonRequest(HttpMethod.Post, fullRequestUri) { Json = requestJson }, cancellationToken);
        }
        #endregion

        #region Post Data AsJson
        public Task<RestApiResult> PostAsJsonAsync<T>(string service, string requestUrl, T requestData)
        {
            return PostAsJsonAsync(service, requestUrl.ToUri(), requestData);
        }

        public Task<RestApiResult> PostAsJsonAsync<T>(string service, Uri requestUri, T requestData)
        {
            return PostAsJsonAsync(service, requestUri, requestData, CancellationToken.None);
        }

        public Task<RestApiResult> PostAsJsonAsync<T>(string service, string requestUrl, T requestData, CancellationToken cancellationToken)
        {
            return PostAsJsonAsync(service, requestUrl.ToUri(), requestData, cancellationToken);
        }

        public Task<RestApiResult> PostAsJsonAsync<T>(string service, Uri requestUri, T requestData, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync(new RestApiJsonRequest<T>(HttpMethod.Post, fullRequestUri) { Data = requestData }, cancellationToken);
        }

        public Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string service, string requestUrl, TRequest requestData)
        {
            return PostAsJsonAsync<TRequest, TResult>(service, requestUrl.ToUri(), requestData);
        }

        public Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string service, Uri requestUri, TRequest requestData)
        {
            return PostAsJsonAsync<TRequest, TResult>(service, requestUri, requestData, CancellationToken.None);
        }

        public Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string service, string requestUrl, TRequest requestData, CancellationToken cancellationToken)
        {
            return PostAsJsonAsync<TRequest, TResult>(service, requestUrl.ToUri(), requestData, cancellationToken);
        }

        public Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string service, Uri requestUri, TRequest requestData, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync<TResult>(new RestApiJsonRequest<TRequest>(HttpMethod.Post, fullRequestUri) { Data = requestData }, cancellationToken);
        }
        #endregion

        #endregion

        #region Put

        #region Put Empty
        public Task<RestApiResult> PutEmptyAsync(string service, string requestUrl)
        {
            return PutEmptyAsync(service, requestUrl.ToUri());
        }

        public Task<RestApiResult> PutEmptyAsync(string service, Uri requestUri)
        {
            return PutEmptyAsync(service, requestUri, CancellationToken.None);
        }

        public Task<RestApiResult> PutEmptyAsync(string service, string requestUrl, CancellationToken cancellationToken)
        {
            return PutEmptyAsync(service, requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult> PutEmptyAsync(string service, Uri requestUri, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync(new RestApiEmptyRequest(HttpMethod.Put, fullRequestUri), cancellationToken);
        }

        public Task<RestApiResult<T>> PutEmptyAsync<T>(string service, string requestUrl)
        {
            return PutEmptyAsync<T>(service, requestUrl.ToUri());
        }

        public Task<RestApiResult<T>> PutEmptyAsync<T>(string service, Uri requestUri)
        {
            return PutEmptyAsync<T>(service, requestUri, CancellationToken.None);
        }

        public Task<RestApiResult<T>> PutEmptyAsync<T>(string service, string requestUrl, CancellationToken cancellationToken)
        {
            return PutEmptyAsync<T>(service, requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult<T>> PutEmptyAsync<T>(string service, Uri requestUri, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync<T>(new RestApiEmptyRequest(HttpMethod.Put, fullRequestUri), cancellationToken);
        }
        #endregion

        #region Put Json String
        public Task<RestApiResult> PutJsonAsync(string service, string requestUrl, string requestJson)
        {
            return PutJsonAsync(service, requestUrl.ToUri(), requestJson);
        }

        public Task<RestApiResult> PutJsonAsync(string service, Uri requestUri, string requestJson)
        {
            return PutJsonAsync(service, requestUri, requestJson, CancellationToken.None);
        }

        public Task<RestApiResult> PutJsonAsync(string service, string requestUrl, string requestJson, CancellationToken cancellationToken)
        {
            return PutJsonAsync(service, requestUrl.ToUri(), requestJson, cancellationToken);
        }

        public Task<RestApiResult> PutJsonAsync(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync(new RestApiJsonRequest(HttpMethod.Put, fullRequestUri) { Json = requestJson }, cancellationToken);
        }

        public Task<RestApiResult<T>> PutJsonAsync<T>(string service, string requestUrl, string requestJson)
        {
            return PutJsonAsync<T>(service, requestUrl.ToUri(), requestJson);
        }

        public Task<RestApiResult<T>> PutJsonAsync<T>(string service, Uri requestUri, string requestJson)
        {
            return PutJsonAsync<T>(service, requestUri, requestJson, CancellationToken.None);
        }

        public Task<RestApiResult<T>> PutJsonAsync<T>(string service, string requestUrl, string requestJson, CancellationToken cancellationToken)
        {
            return PutJsonAsync<T>(service, requestUrl.ToUri(), requestJson, cancellationToken);
        }

        public Task<RestApiResult<T>> PutJsonAsync<T>(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync<T>(new RestApiJsonRequest(HttpMethod.Put, fullRequestUri) { Json = requestJson }, cancellationToken);
        }
        #endregion

        #region Put Data AsJson
        public Task<RestApiResult> PutAsJsonAsync<T>(string service, string requestUrl, T requestData)
        {
            return PutAsJsonAsync(service, requestUrl.ToUri(), requestData);
        }

        public Task<RestApiResult> PutAsJsonAsync<T>(string service, Uri requestUri, T requestData)
        {
            return PutAsJsonAsync(service, requestUri, requestData, CancellationToken.None);
        }

        public Task<RestApiResult> PutAsJsonAsync<T>(string service, string requestUrl, T requestData, CancellationToken cancellationToken)
        {
            return PutAsJsonAsync(service, requestUrl.ToUri(), requestData, cancellationToken);
        }

        public Task<RestApiResult> PutAsJsonAsync<T>(string service, Uri requestUri, T requestData, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync(new RestApiJsonRequest<T>(HttpMethod.Put, fullRequestUri) { Data = requestData }, cancellationToken);
        }

        public Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string service, string requestUrl, TRequest requestData)
        {
            return PutAsJsonAsync<TRequest, TResult>(service, requestUrl.ToUri(), requestData);
        }

        public Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string service, Uri requestUri, TRequest requestData)
        {
            return PutAsJsonAsync<TRequest, TResult>(service, requestUri, requestData, CancellationToken.None);
        }

        public Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string service, string requestUrl, TRequest requestData, CancellationToken cancellationToken)
        {
            return PutAsJsonAsync<TRequest, TResult>(service, requestUrl.ToUri(), requestData, cancellationToken);
        }

        public Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string service, Uri requestUri, TRequest requestData, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync<TResult>(new RestApiJsonRequest<TRequest>(HttpMethod.Put, fullRequestUri) { Data = requestData }, cancellationToken);
        }
        #endregion

        #endregion

        #region Delete
        public Task<RestApiResult> DeleteAsync(string service, string requestUrl)
        {
            return DeleteAsync(service, requestUrl.ToUri());
        }

        public Task<RestApiResult> DeleteAsync(string service, Uri requestUri)
        {
            return DeleteAsync(service, requestUri, CancellationToken.None);
        }

        public Task<RestApiResult> DeleteAsync(string service, string requestUrl, CancellationToken cancellationToken)
        {
            return DeleteAsync(service, requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult> DeleteAsync(string service, Uri requestUri, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync(new RestApiEmptyRequest(HttpMethod.Delete, fullRequestUri), cancellationToken);
        }

        public Task<RestApiResult<T>> DeleteAsync<T>(string service, string requestUrl)
        {
            return DeleteAsync<T>(service, requestUrl.ToUri());
        }

        public Task<RestApiResult<T>> DeleteAsync<T>(string service, Uri requestUri)
        {
            return DeleteAsync<T>(service, requestUri, CancellationToken.None);
        }

        public Task<RestApiResult<T>> DeleteAsync<T>(string service, string requestUrl, CancellationToken cancellationToken)
        {
            return DeleteAsync<T>(service, requestUrl.ToUri(), cancellationToken);
        }

        public Task<RestApiResult<T>> DeleteAsync<T>(string service, Uri requestUri, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildClusterServiceRequestUri(service, requestUri);

            return SendAsync<T>(new RestApiEmptyRequest(HttpMethod.Delete, fullRequestUri), cancellationToken);
        }
        #endregion

        #region Send
        public Task<RestApiResult> SendAsync(RestApiRequest request)
        {
            return SendAsync(request, CancellationToken.None);
        }

        public async Task<RestApiResult> SendAsync(RestApiRequest request, CancellationToken cancellationToken)
        {
            _restClient.BaseUri = await _clusterService.GetGatewayUriAsync().ConfigureAwait(false);

            return await _restClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        public Task<RestApiResult<T>> SendAsync<T>(RestApiRequest request)
        {
            return SendAsync<T>(request, CancellationToken.None);
        }

        public async Task<RestApiResult<T>> SendAsync<T>(RestApiRequest request, CancellationToken cancellationToken)
        {
            _restClient.BaseUri = await _clusterService.GetGatewayUriAsync().ConfigureAwait(false);

            return await _restClient.SendAsync<T>(request, cancellationToken).ConfigureAwait(false);
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
                    _restClient.Dispose();
                }
            }
            this.disposed = true;
        }

        ~ClusterRestApiClient()
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
