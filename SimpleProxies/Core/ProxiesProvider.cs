using SimpleProxies.ProxiesLoaders;
using SimpleProxies.ProxyFilters;

namespace SimpleProxies.Core
{
    public class ProxiesProvider
    {
        private readonly IProxiesLoader _proxiesLoader;
        private readonly IProxyFilter _proxyFilter;
        private readonly string _proxiesTargetUrl;

        public ProxiesProvider(
            IProxiesLoader proxiesLoader,
            IProxyFilter proxyFilter,
            string proxiesTargetUrl)
        {
            _proxiesLoader = proxiesLoader;
            _proxyFilter = proxyFilter;
            _proxiesTargetUrl = proxiesTargetUrl;
        }

        //public async Task RemoveUnavailableProxiesFromCash()
        //{

        //}

        //public async Task<List<WebProxy>> LoadToCash()
        //{

        //}
    }
}
