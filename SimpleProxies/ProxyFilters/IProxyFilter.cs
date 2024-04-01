namespace SimpleProxies.ProxyFilters
{
    public interface IProxyFilter
    {
        public Task<bool> IsProxyAvailable(string proxiesTargetUrl);
    }
}
