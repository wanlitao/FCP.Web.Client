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

        Task<RestApiResult<string>> GetRawAsync(string service, string requestUrl);

        Task<RestApiResult<string>> GetRawAsync(string service, Uri requestUri);

        Task<RestApiResult<string>> GetRawAsync(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<string>> GetRawAsync(string service, Uri requestUri, CancellationToken cancellationToken);
        #endregion

        #region Post

        #region Post Empty
        Task<RestApiResult> PostEmptyAsync(string service, string requestUrl);

        Task<RestApiResult> PostEmptyAsync(string service, Uri requestUri);

        Task<RestApiResult> PostEmptyAsync(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult> PostEmptyAsync(string service, Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PostEmptyAsync<T>(string service, string requestUrl);

        Task<RestApiResult<T>> PostEmptyAsync<T>(string service, Uri requestUri);

        Task<RestApiResult<T>> PostEmptyAsync<T>(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PostEmptyAsync<T>(string service, Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostEmptyRawAsync(string service, string requestUrl);

        Task<RestApiResult<string>> PostEmptyRawAsync(string service, Uri requestUri);

        Task<RestApiResult<string>> PostEmptyRawAsync(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostEmptyRawAsync(string service, Uri requestUri, CancellationToken cancellationToken);
        #endregion

        #region Post Json String
        Task<RestApiResult> PostJsonAsync(string service, string requestUrl, string requestJson);

        Task<RestApiResult> PostJsonAsync(string service, Uri requestUri, string requestJson);

        Task<RestApiResult> PostJsonAsync(string service, string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult> PostJsonAsync(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PostJsonAsync<T>(string service, string requestUrl, string requestJson);

        Task<RestApiResult<T>> PostJsonAsync<T>(string service, Uri requestUri, string requestJson);

        Task<RestApiResult<T>> PostJsonAsync<T>(string service, string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PostJsonAsync<T>(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostJsonRawAsync(string service, string requestUrl, string requestJson);

        Task<RestApiResult<string>> PostJsonRawAsync(string service, Uri requestUri, string requestJson);

        Task<RestApiResult<string>> PostJsonRawAsync(string service, string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostJsonRawAsync(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken);
        #endregion

        #region Post Data AsJson
        Task<RestApiResult> PostAsJsonAsync<T>(string service, string requestUrl, T requestData);

        Task<RestApiResult> PostAsJsonAsync<T>(string service, Uri requestUri, T requestData);

        Task<RestApiResult> PostAsJsonAsync<T>(string service, string requestUrl, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult> PostAsJsonAsync<T>(string service, Uri requestUri, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string service, string requestUrl, TRequest requestData);

        Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string service, Uri requestUri, TRequest requestData);

        Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string service, string requestUrl, TRequest requestData, CancellationToken cancellationToken);

        Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string service, Uri requestUri, TRequest requestData, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostAsJsonRawAsync<T>(string service, string requestUrl, T requestData);

        Task<RestApiResult<string>> PostAsJsonRawAsync<T>(string service, Uri requestUri, T requestData);

        Task<RestApiResult<string>> PostAsJsonRawAsync<T>(string service, string requestUrl, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostAsJsonRawAsync<T>(string service, Uri requestUri, T requestData, CancellationToken cancellationToken);
        #endregion

        #endregion

        #region Put

        #region Put Empty
        Task<RestApiResult> PutEmptyAsync(string service, string requestUrl);

        Task<RestApiResult> PutEmptyAsync(string service, Uri requestUri);

        Task<RestApiResult> PutEmptyAsync(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult> PutEmptyAsync(string service, Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PutEmptyAsync<T>(string service, string requestUrl);

        Task<RestApiResult<T>> PutEmptyAsync<T>(string service, Uri requestUri);

        Task<RestApiResult<T>> PutEmptyAsync<T>(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PutEmptyAsync<T>(string service, Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutEmptyRawAsync(string service, string requestUrl);

        Task<RestApiResult<string>> PutEmptyRawAsync(string service, Uri requestUri);

        Task<RestApiResult<string>> PutEmptyRawAsync(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutEmptyRawAsync(string service, Uri requestUri, CancellationToken cancellationToken);
        #endregion

        #region Put Json String
        Task<RestApiResult> PutJsonAsync(string service, string requestUrl, string requestJson);

        Task<RestApiResult> PutJsonAsync(string service, Uri requestUri, string requestJson);

        Task<RestApiResult> PutJsonAsync(string service, string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult> PutJsonAsync(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PutJsonAsync<T>(string service, string requestUrl, string requestJson);

        Task<RestApiResult<T>> PutJsonAsync<T>(string service, Uri requestUri, string requestJson);

        Task<RestApiResult<T>> PutJsonAsync<T>(string service, string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PutJsonAsync<T>(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutJsonRawAsync(string service, string requestUrl, string requestJson);

        Task<RestApiResult<string>> PutJsonRawAsync(string service, Uri requestUri, string requestJson);

        Task<RestApiResult<string>> PutJsonRawAsync(string service, string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutJsonRawAsync(string service, Uri requestUri, string requestJson, CancellationToken cancellationToken);
        #endregion

        #region Put Data AsJson
        Task<RestApiResult> PutAsJsonAsync<T>(string service, string requestUrl, T requestData);

        Task<RestApiResult> PutAsJsonAsync<T>(string service, Uri requestUri, T requestData);

        Task<RestApiResult> PutAsJsonAsync<T>(string service, string requestUrl, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult> PutAsJsonAsync<T>(string service, Uri requestUri, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string service, string requestUrl, TRequest requestData);

        Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string service, Uri requestUri, TRequest requestData);

        Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string service, string requestUrl, TRequest requestData, CancellationToken cancellationToken);

        Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string service, Uri requestUri, TRequest requestData, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutAsJsonRawAsync<T>(string service, string requestUrl, T requestData);

        Task<RestApiResult<string>> PutAsJsonRawAsync<T>(string service, Uri requestUri, T requestData);

        Task<RestApiResult<string>> PutAsJsonRawAsync<T>(string service, string requestUrl, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutAsJsonRawAsync<T>(string service, Uri requestUri, T requestData, CancellationToken cancellationToken);
        #endregion

        #endregion

        #region Delete
        Task<RestApiResult> DeleteAsync(string service, string requestUrl);

        Task<RestApiResult> DeleteAsync(string service, Uri requestUri);

        Task<RestApiResult> DeleteAsync(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult> DeleteAsync(string service, Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<T>> DeleteAsync<T>(string service, string requestUrl);

        Task<RestApiResult<T>> DeleteAsync<T>(string service, Uri requestUri);

        Task<RestApiResult<T>> DeleteAsync<T>(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<T>> DeleteAsync<T>(string service, Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<string>> DeleteRawAsync(string service, string requestUrl);

        Task<RestApiResult<string>> DeleteRawAsync(string service, Uri requestUri);

        Task<RestApiResult<string>> DeleteRawAsync(string service, string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<string>> DeleteRawAsync(string service, Uri requestUri, CancellationToken cancellationToken);
        #endregion

        #region Send
        Task<RestApiResult> SendAsync(RestApiRequest request);

        Task<RestApiResult> SendAsync(RestApiRequest request, CancellationToken cancellationToken);

        Task<RestApiResult<T>> SendAsync<T>(RestApiRequest request);

        Task<RestApiResult<T>> SendAsync<T>(RestApiRequest request, CancellationToken cancellationToken);

        Task<RestApiResult<string>> SendRawAsync(RestApiRequest request);

        Task<RestApiResult<string>> SendRawAsync(RestApiRequest request, CancellationToken cancellationToken);
        #endregion
    }
}
