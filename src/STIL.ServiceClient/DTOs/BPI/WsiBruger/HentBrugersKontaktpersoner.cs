using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The HentBrugersKontaktpersoner class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class HentBrugersKontaktpersoner
{
    /// <summary>
    /// Gets or sets the <see cref="instnr"/> value.
    /// </summary>
    [XmlElement(DataType="token", Order=0)]
    public string instnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="brugerid"/> value.
    /// </summary>
    [XmlElement(Order=1)]
    public string brugerid { get; set; }
}