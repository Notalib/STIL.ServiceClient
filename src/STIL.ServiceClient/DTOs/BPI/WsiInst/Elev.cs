using System.Xml.Serialization;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The Elev class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Elev
{
    /// <summary>
    /// Gets or sets the <see cref="rolle"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public Elevrolle rolle { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="hovedgruppeid"/> value.
    /// </summary>
    [XmlElement(Order=1)]
    public string hovedgruppeid { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="hovedgruppenavn"/> value.
    /// </summary>
    [XmlElement(Order=2)]
    public string hovedgruppenavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="elevtrin"/> value.
    /// </summary>
    [XmlElement(Order=3)]
    public trin elevtrin { get; set; }
}