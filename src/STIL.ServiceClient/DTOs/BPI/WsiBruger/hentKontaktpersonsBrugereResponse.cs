using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

public class hentKontaktpersonsBrugereResponse
{
    [MessageBodyMember(Name="hentKontaktpersonsBrugereResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7", Order=0)]
    [XmlArrayItem("elev", IsNullable=false)]
    public Elevbruger[] hentKontaktpersonsBrugereResponse1 { get; set; }
}