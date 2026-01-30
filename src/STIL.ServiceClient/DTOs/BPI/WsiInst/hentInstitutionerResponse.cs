using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

public class hentInstitutionerResponse
{
    [MessageBodyMember(Name="hentInstitutionerResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    [XmlArrayItem("institution", IsNullable=false)]
    public Institution[] hentInstitutionerResponse1 { get; set; }
}