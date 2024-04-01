using System.Text.RegularExpressions;

namespace SimpleProxies.Utilities
{
    public static class ProxyFormatUtilities
    {
        public static void CheckProxyFormatCorrectness(string proxy)
        {
            if(!IsValidProxyFormat(proxy))
            {
                throw new ArgumentException(proxy, 
                    $"Incorrect proxy format, excepted: \"https://94.23.4.127:8444\", \"socks5://94.23.4.127:8444\"");
            }
        }
        
        public static bool IsValidProxyFormat(string proxy)
        {
            string pattern = @"^(https?|socks5?)://((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?):([1-9]\d{0,4})$";

            return Regex.IsMatch(proxy, pattern);
        }
    }
}
