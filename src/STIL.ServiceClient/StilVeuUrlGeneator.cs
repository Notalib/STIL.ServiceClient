using System;

namespace STIL.ServiceClient
{
    public class StilVeuUrlGeneator : IStilUrlGeneator
    {
        private const string UrlServiceAffix = "services";
        private const string Version = "v1";
        private readonly string _baseUrl;

        public StilVeuUrlGeneator(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Uri Generate(string methodName)
        {
            return new Uri($"{_baseUrl.TrimEnd('/')}/{UrlServiceAffix}/VEU/{methodName}/v1");
        }
    }
}
