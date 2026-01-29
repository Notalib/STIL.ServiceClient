using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

public class hentInstitutionshierarkiResponse1
{
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    public HentInstitutionshierarkiResponse hentInstitutionshierarkiResponse { get; set; }
}