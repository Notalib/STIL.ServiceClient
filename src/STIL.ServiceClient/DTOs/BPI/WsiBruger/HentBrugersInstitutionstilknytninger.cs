using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The hentBrugersInstitutionstilknytninger class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class hentBrugersInstitutionstilknytninger
{
    /// <summary>
    /// Gets or sets the <see cref="brugerid"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public string brugerid { get; set; }
}