using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public class AuthentificationError
{
    [XmlElement(Order=0)]
    public AuthentificationErrorType type { get; set; }
}