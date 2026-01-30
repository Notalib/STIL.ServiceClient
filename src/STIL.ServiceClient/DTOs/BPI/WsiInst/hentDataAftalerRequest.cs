using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

public class hentDataAftalerRequest
{
    [MessageHeader(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
    public UdbydersystemIdType UdbydersystemId { get; set; }

    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3", Order=0)]
    public NoArgs hentDataAftaler { get; set; }
}