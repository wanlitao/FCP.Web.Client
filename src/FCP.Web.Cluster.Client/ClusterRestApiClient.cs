using FCP.Util;
using FCP.Web.Api.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FCP.Web.Cluster.Client
{
    public class ClusterRestApiClient : IClusterRestApiClient
    {
        private readonly ILoadBalanceClusterProvider _clusterProvider;
        private readonly IRestApiClient _restClient;

        #region Constructors
        public ClusterRestApiClient(ILoadBalanceClusterProvider clusterProvider)
            : this()
        {
            if (clusterProvider == null)
                throw new ArgumentNullException(nameof(clusterProvider));

            _clusterProvider = clusterProvider;
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

            return _restClient.GetAsync(fullRequestUri, cancellationToken);
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

            return _restClient.GetAsync<T>(fullRequestUri, cancellationToken);
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
