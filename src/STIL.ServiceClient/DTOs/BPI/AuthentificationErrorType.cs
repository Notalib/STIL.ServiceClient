using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI;

[XmlType(AnonymousType=true, Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public enum AuthentificationErrorType
{
    Signatur,
    SignaturMangler,
    UdbydersytemIdMangler,
    BrugeridEllerPassword,
    Rettigheder,
}
