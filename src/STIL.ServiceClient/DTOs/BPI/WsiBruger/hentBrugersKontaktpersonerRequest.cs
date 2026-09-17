using System.ServiceModel;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The hentBrugersKontaktpersonerRequest class.
/// </summary>
public class hentBrugersKontaktpersonerRequest
{
    /// <summary>
    /// Gets or sets the <see cref="UdbydersystemId"/> value.
    /// </summary>
    [MessageHeader(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
    public UdbydersystemIdType UdbydersystemId  { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="hentBrugersKontaktpersoner"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7", Order=0)]
    public HentBrugersKontaktpersoner hentBrugersKontaktpersoner  { get; set; }
}