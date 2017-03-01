using FCP.Web.Api.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FCP.Web.Cluster.Client
{
    public static class ClusterApiClientCRUDExtensions
    {
        #region GetByKey
        public static Task<RestApiResult<TResult>> GetByKeyAsync<TKey, TResult>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam)
        {
            return GetByKeyAsync<TKey, TResult>(clusterClient, service, requestUrl.ToUri(), keyParam);
        }

        public static Task<RestApiResult<TResult>> GetByKeyAsync<TKey, TResult>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam)
        {
            return GetByKeyAsync<TKey, TResult>(clusterClient, service, requestUri, keyParam, CancellationToken.None);
        }

        public static Task<RestApiResult<TResult>> GetByKeyAsync<TKey, TResult>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam, CancellationToken cancellationToken)
        {
            return GetByKeyAsync<TKey, TResult>(clusterClient, service, requestUrl.ToUri(), keyParam, cancellationToken);
        }

        public static Task<RestApiResult<TResult>> GetByKeyAsync<TKey, TResult>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam, CancellationToken cancellationToken)
        {
            var fullRequestUri = RestApiClientCRUDExtensions.BuildByKeyRequestUri(requestUri, keyParam);

            return clusterClient.GetAsync<TResult>(service, fullRequestUri, cancellationToken);
        }

        public static Task<RestApiResult<string>> GetByKeyRawAsync<TKey>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam)
        {
            return GetByKeyRawAsync(clusterClient, service, requestUrl.ToUri(), keyParam);
        }

        public static Task<RestApiResult<string>> GetByKeyRawAsync<TKey>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam)
        {
            return GetByKeyRawAsync(clusterClient, service, requestUri, keyParam, CancellationToken.None);
        }

        public static Task<RestApiResult<string>> GetByKeyRawAsync<TKey>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam, CancellationToken cancellationToken)
        {
            return GetByKeyRawAsync(clusterClient, service, requestUrl.ToUri(), keyParam, cancellationToken);
        }

        public static Task<RestApiResult<string>> GetByKeyRawAsync<TKey>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam, CancellationToken cancellationToken)
        {
            var fullRequestUri = RestApiClientCRUDExtensions.BuildByKeyRequestUri(requestUri, keyParam);

            return clusterClient.GetRawAsync(service, fullRequestUri, cancellationToken);
        }
        #endregion

        #region UpdateByKey
        public static Task<RestApiResult<TResult>> UpdateByKeyAsync<TKey, TUpdate, TResult>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam, TUpdate updateParam)
        {
            return UpdateByKeyAsync<TKey, TUpdate, TResult>(clusterClient, service, requestUrl.ToUri(), keyParam, updateParam);
        }

        public static Task<RestApiResult<TResult>> UpdateByKeyAsync<TKey, TUpdate, TResult>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam, TUpdate updateParam)
        {
            return UpdateByKeyAsync<TKey, TUpdate, TResult>(clusterClient, service, requestUri, keyParam, updateParam, CancellationToken.None);
        }

        public static Task<RestApiResult<TResult>> UpdateByKeyAsync<TKey, TUpdate, TResult>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam, TUpdate updateParam, CancellationToken cancellationToken)
        {
            return UpdateByKeyAsync<TKey, TUpdate, TResult>(clusterClient, service, requestUrl.ToUri(), keyParam, updateParam, cancellationToken);
        }

        public static Task<RestApiResult<TResult>> UpdateByKeyAsync<TKey, TUpdate, TResult>(this IClusterRestApiClient clusterClient,
           string service, Uri requestUri, TKey keyParam, TUpdate updateParam, CancellationToken cancellationToken)
        {
            var fullRequestUri = RestApiClientCRUDExtensions.BuildByKeyRequestUri(requestUri, keyParam);

            return clusterClient.PutAsJsonAsync<TUpdate, TResult>(service, fullRequestUri, updateParam, cancellationToken);
        }

        public static Task<RestApiResult<string>> UpdateByKeyRawAsync<TKey, TUpdate>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam, TUpdate updateParam)
        {
            return UpdateByKeyRawAsync(clusterClient, service, requestUrl.ToUri(), keyParam, updateParam);
        }

        public static Task<RestApiResult<string>> UpdateByKeyRawAsync<TKey, TUpdate>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam, TUpdate updateParam)
        {
            return UpdateByKeyRawAsync(clusterClient, service, requestUri, keyParam, updateParam, CancellationToken.None);
        }

        public static Task<RestApiResult<string>> UpdateByKeyRawAsync<TKey, TUpdate>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam, TUpdate updateParam, CancellationToken cancellationToken)
        {
            return UpdateByKeyRawAsync(clusterClient, service, requestUrl.ToUri(), keyParam, updateParam, cancellationToken);
        }

        public static Task<RestApiResult<string>> UpdateByKeyRawAsync<TKey, TUpdate>(this IClusterRestApiClient clusterClient,
           string service, Uri requestUri, TKey keyParam, TUpdate updateParam, CancellationToken cancellationToken)
        {
            var fullRequestUri = RestApiClientCRUDExtensions.BuildByKeyRequestUri(requestUri, keyParam);

            return clusterClient.PutAsJsonRawAsync(service, fullRequestUri, updateParam, cancellationToken);
        }
        #endregion

        #region DeleteByKey
        public static Task<RestApiResult<TResult>> DeleteByKeyAsync<TKey, TResult>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam)
        {
            return DeleteByKeyAsync<TKey, TResult>(clusterClient, service, requestUrl.ToUri(), keyParam);
        }

        public static Task<RestApiResult<TResult>> DeleteByKeyAsync<TKey, TResult>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam)
        {
            return DeleteByKeyAsync<TKey, TResult>(clusterClient, service, requestUri, keyParam, CancellationToken.None);
        }

        public static Task<RestApiResult<TResult>> DeleteByKeyAsync<TKey, TResult>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam, CancellationToken cancellationToken)
        {
            return DeleteByKeyAsync<TKey, TResult>(clusterClient, service, requestUrl.ToUri(), keyParam, cancellationToken);
        }

        public static Task<RestApiResult<TResult>> DeleteByKeyAsync<TKey, TResult>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam, CancellationToken cancellationToken)
        {
            var fullRequestUri = RestApiClientCRUDExtensions.BuildByKeyRequestUri(requestUri, keyParam);

            return clusterClient.DeleteAsync<TResult>(service, fullRequestUri, cancellationToken);
        }

        public static Task<RestApiResult<string>> DeleteByKeyRawAsync<TKey>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam)
        {
            return DeleteByKeyRawAsync(clusterClient, service, requestUrl.ToUri(), keyParam);
        }

        public static Task<RestApiResult<string>> DeleteByKeyRawAsync<TKey>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam)
        {
            return DeleteByKeyRawAsync(clusterClient, service, requestUri, keyParam, CancellationToken.None);
        }

        public static Task<RestApiResult<string>> DeleteByKeyRawAsync<TKey>(this IClusterRestApiClient clusterClient,
            string service, string requestUrl, TKey keyParam, CancellationToken cancellationToken)
        {
            return DeleteByKeyRawAsync(clusterClient, service, requestUrl.ToUri(), keyParam, cancellationToken);
        }

        public static Task<RestApiResult<string>> DeleteByKeyRawAsync<TKey>(this IClusterRestApiClient clusterClient,
            string service, Uri requestUri, TKey keyParam, CancellationToken cancellationToken)
        {
            var fullRequestUri = RestApiClientCRUDExtensions.BuildByKeyRequestUri(requestUri, keyParam);

            return clusterClient.DeleteRawAsync(service, fullRequestUri, cancellationToken);
        }
        #endregion
    }
}
