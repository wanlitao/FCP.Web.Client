using FCP.Util;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FCP.Web.Api.Client
{
    public static class RestApiClientCRUDExtensions
    {
        #region Helper Functions
        public static Uri BuildByKeyRequestUri<TKey>(Uri requestUri, TKey keyParam)
        {
            if (keyParam == null)
                throw new ArgumentNullException(nameof(keyParam));

            var uriBuilder = new FluentUriBuilder().FromUri(requestUri.ToAbsolute())
                .SegmentParam(TypeHelper.parseString(keyParam));

            return uriBuilder.Build();
        }
        #endregion

        #region GetByKey
        public static Task<RestApiResult<TResult>> GetByKeyAsync<TKey, TResult>(this IRestApiClient restClient, string requestUrl, TKey keyParam)
        {
            return GetByKeyAsync<TKey, TResult>(restClient, requestUrl.ToUri(), keyParam);
        }

        public static Task<RestApiResult<TResult>> GetByKeyAsync<TKey, TResult>(this IRestApiClient restClient, Uri requestUri, TKey keyParam)
        {
            return GetByKeyAsync<TKey, TResult>(restClient, requestUri, keyParam, CancellationToken.None);
        }

        public static Task<RestApiResult<TResult>> GetByKeyAsync<TKey, TResult>(this IRestApiClient restClient, string requestUrl,
            TKey keyParam, CancellationToken cancellationToken)
        {
            return GetByKeyAsync<TKey, TResult>(restClient, requestUrl.ToUri(), keyParam, cancellationToken);
        }

        public static Task<RestApiResult<TResult>> GetByKeyAsync<TKey, TResult>(this IRestApiClient restClient, Uri requestUri,
            TKey keyParam, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildByKeyRequestUri(requestUri, keyParam);

            return restClient.GetAsync<TResult>(fullRequestUri, cancellationToken);
        }
        #endregion

        #region UpdateByKey
        public static Task<RestApiResult<TResult>> UpdateByKeyAsync<TKey, TUpdate, TResult>(this IRestApiClient restClient, string requestUrl,
            TKey keyParam, TUpdate updateParam)
        {
            return UpdateByKeyAsync<TKey, TUpdate, TResult>(restClient, requestUrl.ToUri(), keyParam, updateParam);
        }

        public static Task<RestApiResult<TResult>> UpdateByKeyAsync<TKey, TUpdate, TResult>(this IRestApiClient restClient, Uri requestUri,
            TKey keyParam, TUpdate updateParam)
        {
            return UpdateByKeyAsync<TKey, TUpdate, TResult>(restClient, requestUri, keyParam, updateParam, CancellationToken.None);
        }

        public static Task<RestApiResult<TResult>> UpdateByKeyAsync<TKey, TUpdate, TResult>(this IRestApiClient restClient, string requestUrl,
            TKey keyParam, TUpdate updateParam, CancellationToken cancellationToken)
        {
            return UpdateByKeyAsync<TKey, TUpdate, TResult>(restClient, requestUrl.ToUri(), keyParam, updateParam, cancellationToken);
        }

        public static Task<RestApiResult<TResult>> UpdateByKeyAsync<TKey, TUpdate, TResult>(this IRestApiClient restClient, Uri requestUri,
           TKey keyParam, TUpdate updateParam, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildByKeyRequestUri(requestUri, keyParam);

            return restClient.PutAsJsonAsync<TUpdate, TResult>(fullRequestUri, updateParam, cancellationToken);
        }
        #endregion

        #region DeleteByKey
        public static Task<RestApiResult<TResult>> DeleteByKeyAsync<TKey, TResult>(this IRestApiClient restClient, string requestUrl, TKey keyParam)
        {
            return DeleteByKeyAsync<TKey, TResult>(restClient, requestUrl.ToUri(), keyParam);
        }

        public static Task<RestApiResult<TResult>> DeleteByKeyAsync<TKey, TResult>(this IRestApiClient restClient, Uri requestUri, TKey keyParam)
        {
            return DeleteByKeyAsync<TKey, TResult>(restClient, requestUri, keyParam, CancellationToken.None);
        }

        public static Task<RestApiResult<TResult>> DeleteByKeyAsync<TKey, TResult>(this IRestApiClient restClient, string requestUrl,
            TKey keyParam, CancellationToken cancellationToken)
        {
            return DeleteByKeyAsync<TKey, TResult>(restClient, requestUrl.ToUri(), keyParam, cancellationToken);
        }

        public static Task<RestApiResult<TResult>> DeleteByKeyAsync<TKey, TResult>(this IRestApiClient restClient, Uri requestUri,
            TKey keyParam, CancellationToken cancellationToken)
        {
            var fullRequestUri = BuildByKeyRequestUri(requestUri, keyParam);

            return restClient.DeleteAsync<TResult>(fullRequestUri, cancellationToken);
        }
        #endregion
    }
}
