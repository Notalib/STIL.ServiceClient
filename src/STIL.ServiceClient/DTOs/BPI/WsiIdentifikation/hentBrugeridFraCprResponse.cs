using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

/// <summary>
/// The hentBrugeridFraCprResponse class.
/// </summary>
public class hentBrugeridFraCprResponse
{
    /// <summary>
    /// Gets or sets the <see cref="hentBrugeridResponse"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6", Order=0)]
    public hentBrugeridResponse hentBrugeridResponse { get; set; }
}