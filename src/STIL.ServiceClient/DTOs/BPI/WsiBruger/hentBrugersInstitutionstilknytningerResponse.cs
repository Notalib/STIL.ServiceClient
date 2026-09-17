using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The hentBrugersInstitutionstilknytningerResponse class.
/// </summary>
[MessageContract(IsWrapped=false)]
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
[XmlRoot(ElementName="hentBrugersInstitutionstilknytningerResponse")]
public class hentBrugersInstitutionstilknytningerResponse
{
    /// <summary>
    /// Gets or sets the <see cref="institutionstilknytning"/> value.
    /// </summary>
    [XmlElement("institutionstilknytning", IsNullable=false)]
    public Institutionstilknytning[] institutionstilknytning { get; set; }
}
