using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

public class hentDataAftalerResponse
{
    [MessageBodyMember(Name="hentDataAftalerResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/common/3", Order=0)]
    [XmlArrayItem("regnr", DataType="token", IsNullable=false)]
    public string[] hentDataAftalerResponse1 { get; set; }
}