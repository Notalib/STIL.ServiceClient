using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

public class hentBrugeridFraCprResponse
{
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6", Order=0)]
    public HentBrugeridResponse hentBrugeridResponse { get; set; }
}