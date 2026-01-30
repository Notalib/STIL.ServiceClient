using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

public class hentInstitutionRequest
{
    [MessageHeader(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
    public UdbydersystemIdType UdbydersystemId { get; set; }

    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    public HentInstitution hentInstitution { get; set; }
}