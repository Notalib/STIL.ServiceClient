using System.ServiceModel;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentInstitutionRequest class.
/// </summary>
public class hentInstitutionRequest
{
    /// <summary>
    /// Gets or sets the <see cref="UdbydersystemId"/> value.
    /// </summary>
    [MessageHeader(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
    public UdbydersystemIdType UdbydersystemId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="hentInstitution"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    public hentInstitution hentInstitution { get; set; }
}
