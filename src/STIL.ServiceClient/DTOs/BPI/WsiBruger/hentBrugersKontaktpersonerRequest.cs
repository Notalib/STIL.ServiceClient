using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

public class hentBrugersKontaktpersonerRequest
{
    [MessageHeader(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
    public UdbydersystemIdType UdbydersystemId  { get; set; }

    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7", Order=0)]
    public HentBrugersKontaktpersoner hentBrugersKontaktpersoner  { get; set; }
}