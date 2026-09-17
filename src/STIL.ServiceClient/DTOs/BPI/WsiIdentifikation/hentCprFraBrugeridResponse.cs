using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

/// <summary>
/// The hentCprFraBrugeridResponse class.
/// </summary>
public class hentCprFraBrugeridResponse
{
    /// <summary>
    /// Gets or sets the <see cref="hentCprResponse"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6", Order=0)]
    public hentCprResponse hentCprResponse { get; set; }
}