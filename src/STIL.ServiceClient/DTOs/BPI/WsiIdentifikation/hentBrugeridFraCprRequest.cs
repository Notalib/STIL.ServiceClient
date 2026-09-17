using System.ServiceModel;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

/// <summary>
/// The hentBrugeridFraCprRequest class.
/// </summary>
public class hentBrugeridFraCprRequest
{
    /// <summary>
    /// Gets or sets the <see cref="UdbydersystemId"/> value.
    /// </summary>
    [MessageHeader(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
    public UdbydersystemIdType UdbydersystemId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="hentBrugeridFraCpr"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6", Order=0)]
    public hentBrugeridFraCpr hentBrugeridFraCpr { get; set; }
}
