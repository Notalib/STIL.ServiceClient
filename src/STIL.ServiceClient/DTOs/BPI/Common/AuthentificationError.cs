using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The AuthentificationError class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public class AuthentificationError
{
    /// <summary>
    /// Gets or sets the <see cref="type"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public AuthentificationErrorType type { get; set; }
}