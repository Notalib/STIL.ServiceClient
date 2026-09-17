using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentInstitutionResponse1 class.
/// </summary>
public class hentInstitutionResponse1
{
    /// <summary>
    /// Gets or sets the <see cref="hentInstitutionResponse"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    public hentInstitutionResponse hentInstitutionResponse { get; set; }
}