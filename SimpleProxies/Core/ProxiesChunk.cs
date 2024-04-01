using Newtonsoft.Json;
using SimpleConfigs.Core;
using SimpleProxies.Utilities;

namespace SimpleProxies.Core
{
    public class ProxiesChunk : IDataCorrectnessChecker
    {
        [JsonProperty("ChunkId")] private int _chunkID = 0;
        /// <summary>
        /// Dictionary (Proxy in format: "https://94.23.4.127:8444", time of last availability check)
        /// </summary>
        [JsonProperty("Proxies")] private Dictionary<string, DateTime> _proxies = new();

        public int ChunkID { get => _chunkID; }
        public IReadOnlyDictionary<string, DateTime> Proxies { get => _proxies; }

        public ProxiesChunk(int chunkID)
        {
            _chunkID = chunkID;
        }

        public void RegisterProxy(string proxy, DateTime timeOfLastAvailabilityCheck)
        {
            ProxyFormatUtilities.CheckProxyFormatCorrectness(proxy);
            if (_proxies.ContainsKey(proxy))
            {
                throw new ArgumentException($"Proxy \"{proxy}\" already registered.", nameof(proxy));
            }

            _proxies.Add(proxy, timeOfLastAvailabilityCheck);
        }

        public void UnregisterProxy(string proxy)
        {
            if (!_proxies.ContainsKey(proxy))
            {
                throw new ArgumentException($"Proxy \"{proxy}\" not registered.", nameof(proxy));
            }

            _proxies.Remove(proxy);
        }

        public Task CheckDataCorrectnessAsync()
        {
            foreach (var proxy in _proxies.Keys)
            {
                ProxyFormatUtilities.CheckProxyFormatCorrectness(proxy);
            }

            return Task.CompletedTask;
        }
    }
}
