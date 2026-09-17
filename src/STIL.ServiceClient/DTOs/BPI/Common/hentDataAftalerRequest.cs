using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The hentDataAftalerRequest class.
/// </summary>
public class hentDataAftalerRequest
{
    /// <summary>
    /// Gets or sets the <see cref="UdbydersystemId"/> value.
    /// </summary>
    [MessageHeader(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
    public UdbydersystemIdType UdbydersystemId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="hentDataAftaler"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3", Order=0)]
    public NoArgs hentDataAftaler { get; set; }
}