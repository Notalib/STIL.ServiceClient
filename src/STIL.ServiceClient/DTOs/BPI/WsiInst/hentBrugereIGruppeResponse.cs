using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

public class hentBrugereIGruppeResponse
{
    [MessageBodyMember(Name="hentBrugereIGruppeResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    [XmlArrayItem("brugertilknytning", IsNullable=false)]
    public Brugertilknytning[] hentBrugereIGruppeResponse1 { get; set; }
}