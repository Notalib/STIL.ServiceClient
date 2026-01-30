using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

public class hentGrupperRequest
{
    [MessageHeader(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
    public UdbydersystemIdType UdbydersystemId { get; set; }

    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    public HentGrupper hentGrupper { get; set; }
}