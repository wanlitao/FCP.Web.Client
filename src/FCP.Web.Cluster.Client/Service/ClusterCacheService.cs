using FCP.Cache;
using FCP.Cache.Service;
using FCP.Cache.Service.Memory;
using FCP.Util;
using System;
using System.Threading.Tasks;

namespace FCP.Web.Cluster.Client
{
    public class ClusterCacheService : IClusterCacheService
    {
        private readonly ILoadBalanceClusterProvider _clusterProvider;
        private readonly TimeSpan _cacheTimeout;
        private readonly ICacheService _cacheService;

        #region Constructors
        public ClusterCacheService(ILoadBalanceClusterProvider clusterProvider)
            : this(clusterProvider, ClusterConstants.DefaultCheckInterval)
        { }

        public ClusterCacheService(ILoadBalanceClusterProvider clusterProvider, int cacheExpireSeconds)
        {
            if (clusterProvider == null)
                throw new ArgumentNullException(nameof(clusterProvider));

            if (cacheExpireSeconds < 1)
                throw new ArgumentOutOfRangeException("cache expire seconds must be greater than zero");

            _clusterProvider = clusterProvider;
            _cacheTimeout = TimeSpan.FromSeconds(cacheExpireSeconds);

            _cacheService = new CacheServiceBuilder().AddMemoryCache("Cluster").UseJsonSerializer().Build();
        }
        #endregion

        public Task<Uri> GetGatewayUriAsync()
        {
            return GetServiceUriAsync(ClusterConstants.DefaultGatewayServiceCode);
        }

        public async Task<Uri> GetServiceUriAsync(string name)
        {
            if (name.isNullOrEmpty())
                throw new ArgumentNullException(nameof(name));

            var cacheOptions = CacheEntryOptionsFactory.AbSolute().Timeout(_cacheTimeout);

            var serviceInfo = await _cacheService.GetOrAddAsync(name,
                (key) => _clusterProvider.findHealthServiceAsync(key), cacheOptions).ConfigureAwait(false);

            if (serviceInfo == null)
                return null;

            return new FluentUriBuilder().Scheme("http")
                .Host(serviceInfo.address).Port(serviceInfo.port).BuildAbsolute();
        }
    }
}
