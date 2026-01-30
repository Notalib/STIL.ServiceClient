using System;

namespace STIL.ServiceClient;

public class StilBPIAUrlGenerator : IStilUrlGenerator
{
    private readonly Uri _url;

    public StilBPIAUrlGenerator(BPIService service)
    {
        _url = new Uri(service switch
        {
            BPIService.Identifikation => "https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6",
            BPIService.Inst => "https://brugerdatabasen.stil.dk/bpi/wsiinst/6",
            BPIService.Bruger => "https://brugerdatabasen.stil.dk/bpi/wsibruger/7",
            _ => throw new ArgumentOutOfRangeException(nameof(service), service, null)
        });
    }

    public Uri Generate(string methodName)
    {
        return new Uri(_url, methodName);
    }
}

public enum BPIService
{
    Identifikation,
    Inst,
    Bruger,
}
