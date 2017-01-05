using FCP.Util;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FCP.Web.Api.Client
{
    internal static class HttpRestExtensions
    {
        private readonly static IDictionary<string, ISerializer> _mediaTypeSerializerMap = new Dictionary<string, ISerializer>();
         
        #region Constructors
        static HttpRestExtensions()
        {
            InitContentTypeSerializerMap();
        }

        private static void InitContentTypeSerializerMap()
        {
            _mediaTypeSerializerMap.Add("application/json", SerializerFactory.JsonSerializer);
            _mediaTypeSerializerMap.Add("*", SerializerFactory.JsonSerializer);
        }
        #endregion

        #region Request
        internal static HttpRequestMessage ToRequestMessage(this RestApiRequest request)
        {
            return new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Content = request.Content
            };
        }
        #endregion

        #region Response
        internal static async Task<RestApiResult> ToRestResultAsync(this HttpResponseMessage response)
        {
            var apiResult = new RestApiResult
            {
                code = response.StatusCode,
                flag = response.IsSuccessStatusCode
            };
            
            if (!response.IsSuccessStatusCode)
            {
                var responseStr = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                apiResult.msg = responseStr;
            }

            return apiResult;
        }

        internal static async Task<RestApiResult<T>> ToRestResultAsync<T>(this HttpResponseMessage response)
        {
            var apiResult = new RestApiResult<T>
            {
                code = response.StatusCode,
                flag = response.IsSuccessStatusCode
            };

            var responseStr = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var serializer = GetHttpContentSerializer(response.Content.Headers.ContentType);
                apiResult.data = serializer.DeserializeString<T>(responseStr);
            }
            else
            {
                apiResult.msg = responseStr;
            }

            return apiResult;
        }

        private static ISerializer GetHttpContentSerializer(MediaTypeHeaderValue contentType)
        {
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));

            ISerializer serializer;
            var mediaType = contentType.MediaType;
            if (_mediaTypeSerializerMap.TryGetValue(mediaType, out serializer))            
                return serializer;            

            throw new NotImplementedException($"not found serializer of mediaType: {mediaType}");
        }
        #endregion
    }
}
