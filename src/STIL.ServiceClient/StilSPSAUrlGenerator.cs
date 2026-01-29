using System;

namespace STIL.ServiceClient;

public class StilSPSAUrlGenerator : IStilUrlGenerator
{
    private readonly Uri _url;

    public StilSPSAUrlGenerator(string baseUrl)
    {
        _url = new Uri($"{baseUrl.TrimEnd('/')}/services/SPSA/OrdreService/v1.0/");
    }

    public Uri Generate(string methodName)
    {
        return _url;
    }
}
