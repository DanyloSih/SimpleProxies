using System.Net;
using SimpleConfigs.Core.ConfigsServiceInterfaces;

namespace SimpleProxies.ProxiesLoaders
{
    public interface IProxiesLoader
    {
        public Task<List<WebProxy>> LoadAsync(bool inParallel = false);
    }
}
