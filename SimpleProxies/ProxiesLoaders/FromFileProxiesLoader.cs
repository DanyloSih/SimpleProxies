using System.Net;
using SimpleConfigs.Core;
using SimpleProxies.Core;

namespace SimpleProxies.ProxiesLoaders
{
    public class FromFileProxiesLoader : IProxiesLoader
    {
        private ConfigsServicesHub _proxiesConfigsServicesHub;

        public FromFileProxiesLoader(ConfigsServicesHub proxiesConfigsServicesHub)
        {
            _proxiesConfigsServicesHub = proxiesConfigsServicesHub;

            GetChunks();
        }

        public async Task<List<WebProxy>> LoadAsync(bool inParallel = false)
        {
            await _proxiesConfigsServicesHub.InitializeTypeForAllAsync(typeof(ProxiesChunk), inParallel);
            List<ProxiesChunk?> chunks = GetChunks();
            
            List<WebProxy> proxies = new List<WebProxy>();

            foreach (var chunk in chunks)
            {
                foreach (var proxy in chunk!.Proxies)
                {
                    proxies.Add(new WebProxy(proxy.Key));
                }
            }

            return proxies;
        }

        private List<ProxiesChunk?> GetChunks()
        {
            List<ProxiesChunk?> chunks = _proxiesConfigsServicesHub.GetTypeInstances<ProxiesChunk>();
            chunks.ForEach(x =>
            {
                if (x == null)
                {
                    throw new ArgumentException($"All configs services must contains " +
                        $"registered config with type: \"{typeof(ProxiesChunk).Name}\"");
                }
            });

            return chunks;
        }
    }
}
