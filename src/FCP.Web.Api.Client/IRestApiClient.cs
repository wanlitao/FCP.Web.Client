using System;
using System.Threading;
using System.Threading.Tasks;

namespace FCP.Web.Api.Client
{
    public interface IRestApiClient : IDisposable
    {
        #region Get
        Task<RestApiResult> GetAsync(string requestUrl);

        Task<RestApiResult> GetAsync(Uri requestUri);

        Task<RestApiResult> GetAsync(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult> GetAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<T>> GetAsync<T>(string requestUrl);

        Task<RestApiResult<T>> GetAsync<T>(Uri requestUri);

        Task<RestApiResult<T>> GetAsync<T>(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<T>> GetAsync<T>(Uri requestUri, CancellationToken cancellationToken);
        #endregion

        #region Post
        #endregion

        #region Put
        #endregion

        #region Delete
        #endregion
    }
}
