﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FCP.Util;

namespace FCP.Web.Api.Client
{
    public class RestApiClient : IRestApiClient
    {
        private HttpClient _httpClient;       

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
        protected HttpClient GetHttpClient()
        {
            _httpClient.BaseAddress = BaseUri;

            return _httpClient;
        }
        #endregion

        #region Get
        public Task<RestApiResult> GetAsync(Uri requestUri)
        {
            throw new NotImplementedException();
        }

        public Task<RestApiResult> GetAsync(string requestUri)
        {
            throw new NotImplementedException();
        }

        public Task<RestApiResult> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RestApiResult> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
