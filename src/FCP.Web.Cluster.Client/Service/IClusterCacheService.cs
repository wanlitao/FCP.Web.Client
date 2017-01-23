using System;
using System.Threading.Tasks;

namespace FCP.Web.Cluster.Client
{
    public interface IClusterCacheService
    {
        Task<Uri> GetGatewayUriAsync();

        Task<Uri> GetServiceUriAsync(string name);
    }
}
