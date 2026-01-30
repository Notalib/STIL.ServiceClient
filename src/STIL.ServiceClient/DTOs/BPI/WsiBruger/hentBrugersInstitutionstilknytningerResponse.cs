using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

public class hentBrugersInstitutionstilknytningerResponse
{
    [MessageBodyMember(Name="hentBrugersInstitutionstilknytningerResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7", Order=0)]
    [XmlArrayItem("institutionstilknytning", IsNullable=false)]
    public Institutionstilknytning[] hentBrugersInstitutionstilknytningerResponse1  { get; set; }
}