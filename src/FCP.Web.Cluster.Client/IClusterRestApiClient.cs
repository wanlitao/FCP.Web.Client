using FCP.Web.Api.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FCP.Web.Cluster.Client
{
    public interface IClusterRestApiClient : IDisposable
    {
        #region Get
        Task<RestApiResult> GetAsync(string service, string requestUrl);

        Task<RestApiResult> GetAsync(string service, Uri requestUri);

        Task<RestApiResult> GetAsync(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult> GetAsync(string service, Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<T>> GetAsync<T>(string service, string requestUrl);

        Task<RestApiResult<T>> GetAsync<T>(string service, Uri requestUri);

        Task<RestApiResult<T>> GetAsync<T>(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<T>> GetAsync<T>(string service, Uri requestUri, CancellationToken cancellationToken);
        #endregion

        #region Post
        #endregion

        #region Put
        #endregion

        #region Delete
        #endregion
    }
}
