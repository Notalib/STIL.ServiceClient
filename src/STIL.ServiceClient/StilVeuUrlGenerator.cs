using System;

namespace STIL.ServiceClient
{
    public class StilVeuUrlGenerator : IStilUrlGenerator
    {
        private const string UrlServiceAffix = "services";
        private const string Version = "v1";
        private readonly string _baseUrl;

        public StilVeuUrlGenerator(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Uri Generate(string methodName)
        {
            return new Uri($"{_baseUrl.TrimEnd('/')}/{UrlServiceAffix}/VEU/{methodName}/v1");
        }
    }
}
