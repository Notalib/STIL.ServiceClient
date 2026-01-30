using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

public class hentBrugersKontaktpersonerResponse
{
    [MessageBodyMember(Name="hentBrugersKontaktpersonerResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7", Order=0)]
    [XmlArrayItem("kontaktperson", IsNullable=false)]
    public Kontaktperson[] hentBrugersKontaktpersonerResponse1 { get; set; }
}