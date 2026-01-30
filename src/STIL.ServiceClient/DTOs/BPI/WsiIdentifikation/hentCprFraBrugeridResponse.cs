using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

public class hentCprFraBrugeridResponse
{
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6", Order=0)]
    public HentCprResponse hentCprResponse { get; set; }
}