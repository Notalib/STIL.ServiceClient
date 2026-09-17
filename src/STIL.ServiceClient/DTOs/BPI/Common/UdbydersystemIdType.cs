using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The UdbydersystemIdType class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public class UdbydersystemIdType
{
    /// <summary>
    /// Gets or sets the <see cref="Value"/> value.
    /// </summary>
    [XmlText(DataType="token")]
    public string Value { get; set; }
}
