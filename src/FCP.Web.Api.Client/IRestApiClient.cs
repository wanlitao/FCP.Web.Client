﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace FCP.Web.Api.Client
{
    public interface IRestApiClient : IDisposable
    {
        #region Properties
        Uri BaseUri { get; set; }
        #endregion

        #region Get
        Task<RestApiResult> GetAsync(string requestUrl);

        Task<RestApiResult> GetAsync(Uri requestUri);

        Task<RestApiResult> GetAsync(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult> GetAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<T>> GetAsync<T>(string requestUrl);

        Task<RestApiResult<T>> GetAsync<T>(Uri requestUri);

        Task<RestApiResult<T>> GetAsync<T>(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<T>> GetAsync<T>(Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<string>> GetRawAsync(string requestUrl);

        Task<RestApiResult<string>> GetRawAsync(Uri requestUri);

        Task<RestApiResult<string>> GetRawAsync(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<string>> GetRawAsync(Uri requestUri, CancellationToken cancellationToken);
        #endregion

        #region Post

        #region Post Empty
        Task<RestApiResult> PostEmptyAsync(string requestUrl);

        Task<RestApiResult> PostEmptyAsync(Uri requestUri);

        Task<RestApiResult> PostEmptyAsync(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult> PostEmptyAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PostEmptyAsync<T>(string requestUrl);

        Task<RestApiResult<T>> PostEmptyAsync<T>(Uri requestUri);

        Task<RestApiResult<T>> PostEmptyAsync<T>(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PostEmptyAsync<T>(Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostEmptyRawAsync(string requestUrl);

        Task<RestApiResult<string>> PostEmptyRawAsync(Uri requestUri);

        Task<RestApiResult<string>> PostEmptyRawAsync(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostEmptyRawAsync(Uri requestUri, CancellationToken cancellationToken);
        #endregion

        #region Post Json String
        Task<RestApiResult> PostJsonAsync(string requestUrl, string requestJson);

        Task<RestApiResult> PostJsonAsync(Uri requestUri, string requestJson);

        Task<RestApiResult> PostJsonAsync(string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult> PostJsonAsync(Uri requestUri, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PostJsonAsync<T>(string requestUrl, string requestJson);

        Task<RestApiResult<T>> PostJsonAsync<T>(Uri requestUri, string requestJson);

        Task<RestApiResult<T>> PostJsonAsync<T>(string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PostJsonAsync<T>(Uri requestUri, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostJsonRawAsync(string requestUrl, string requestJson);

        Task<RestApiResult<string>> PostJsonRawAsync(Uri requestUri, string requestJson);

        Task<RestApiResult<string>> PostJsonRawAsync(string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostJsonRawAsync(Uri requestUri, string requestJson, CancellationToken cancellationToken);
        #endregion

        #region Post Data AsJson
        Task<RestApiResult> PostAsJsonAsync<T>(string requestUrl, T requestData);

        Task<RestApiResult> PostAsJsonAsync<T>(Uri requestUri, T requestData);

        Task<RestApiResult> PostAsJsonAsync<T>(string requestUrl, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult> PostAsJsonAsync<T>(Uri requestUri, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string requestUrl, TRequest requestData);

        Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(Uri requestUri, TRequest requestData);

        Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(string requestUrl, TRequest requestData, CancellationToken cancellationToken);

        Task<RestApiResult<TResult>> PostAsJsonAsync<TRequest, TResult>(Uri requestUri, TRequest requestData, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostAsJsonRawAsync<T>(string requestUrl, T requestData);

        Task<RestApiResult<string>> PostAsJsonRawAsync<T>(Uri requestUri, T requestData);

        Task<RestApiResult<string>> PostAsJsonRawAsync<T>(string requestUrl, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PostAsJsonRawAsync<T>(Uri requestUri, T requestData, CancellationToken cancellationToken);
        #endregion

        #endregion

        #region Put

        #region Put Empty
        Task<RestApiResult> PutEmptyAsync(string requestUrl);

        Task<RestApiResult> PutEmptyAsync(Uri requestUri);

        Task<RestApiResult> PutEmptyAsync(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult> PutEmptyAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PutEmptyAsync<T>(string requestUrl);

        Task<RestApiResult<T>> PutEmptyAsync<T>(Uri requestUri);

        Task<RestApiResult<T>> PutEmptyAsync<T>(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PutEmptyAsync<T>(Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutEmptyRawAsync(string requestUrl);

        Task<RestApiResult<string>> PutEmptyRawAsync(Uri requestUri);

        Task<RestApiResult<string>> PutEmptyRawAsync(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutEmptyRawAsync(Uri requestUri, CancellationToken cancellationToken);
        #endregion

        #region Put Json String
        Task<RestApiResult> PutJsonAsync(string requestUrl, string requestJson);

        Task<RestApiResult> PutJsonAsync(Uri requestUri, string requestJson);

        Task<RestApiResult> PutJsonAsync(string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult> PutJsonAsync(Uri requestUri, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PutJsonAsync<T>(string requestUrl, string requestJson);

        Task<RestApiResult<T>> PutJsonAsync<T>(Uri requestUri, string requestJson);

        Task<RestApiResult<T>> PutJsonAsync<T>(string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<T>> PutJsonAsync<T>(Uri requestUri, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutJsonRawAsync(string requestUrl, string requestJson);

        Task<RestApiResult<string>> PutJsonRawAsync(Uri requestUri, string requestJson);

        Task<RestApiResult<string>> PutJsonRawAsync(string requestUrl, string requestJson, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutJsonRawAsync(Uri requestUri, string requestJson, CancellationToken cancellationToken);
        #endregion

        #region Put Data AsJson
        Task<RestApiResult> PutAsJsonAsync<T>(string requestUrl, T requestData);

        Task<RestApiResult> PutAsJsonAsync<T>(Uri requestUri, T requestData);

        Task<RestApiResult> PutAsJsonAsync<T>(string requestUrl, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult> PutAsJsonAsync<T>(Uri requestUri, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string requestUrl, TRequest requestData);

        Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(Uri requestUri, TRequest requestData);

        Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(string requestUrl, TRequest requestData, CancellationToken cancellationToken);

        Task<RestApiResult<TResult>> PutAsJsonAsync<TRequest, TResult>(Uri requestUri, TRequest requestData, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutAsJsonRawAsync<T>(string requestUrl, T requestData);

        Task<RestApiResult<string>> PutAsJsonRawAsync<T>(Uri requestUri, T requestData);

        Task<RestApiResult<string>> PutAsJsonRawAsync<T>(string requestUrl, T requestData, CancellationToken cancellationToken);

        Task<RestApiResult<string>> PutAsJsonRawAsync<T>(Uri requestUri, T requestData, CancellationToken cancellationToken);
        #endregion

        #endregion

        #region Delete
        Task<RestApiResult> DeleteAsync(string requestUrl);

        Task<RestApiResult> DeleteAsync(Uri requestUri);

        Task<RestApiResult> DeleteAsync(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult> DeleteAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<T>> DeleteAsync<T>(string requestUrl);

        Task<RestApiResult<T>> DeleteAsync<T>(Uri requestUri);

        Task<RestApiResult<T>> DeleteAsync<T>(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<T>> DeleteAsync<T>(Uri requestUri, CancellationToken cancellationToken);

        Task<RestApiResult<string>> DeleteRawAsync(string requestUrl);

        Task<RestApiResult<string>> DeleteRawAsync(Uri requestUri);

        Task<RestApiResult<string>> DeleteRawAsync(string requestUrl, CancellationToken cancellationToken);

        Task<RestApiResult<string>> DeleteRawAsync(Uri requestUri, CancellationToken cancellationToken);
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
