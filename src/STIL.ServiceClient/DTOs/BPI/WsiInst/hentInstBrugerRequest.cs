using System.ServiceModel;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentInstBrugerRequest class.
/// </summary>
public class hentInstBrugerRequest
{
    /// <summary>
    /// Gets or sets the <see cref="UdbydersystemId"/> value.
    /// </summary>
    [MessageHeader(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
    public UdbydersystemIdType UdbydersystemId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="hentInstBruger"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    public hentInstBruger hentInstBruger { get; set; }
}