using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentInstitutionshierarkiResponse1 class.
/// </summary>
public class hentInstitutionshierarkiResponse1
{
    /// <summary>
    /// Gets or sets the <see cref="hentInstitutionshierarkiResponse"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    public HentInstitutionshierarkiResponse hentInstitutionshierarkiResponse { get; set; }
}