using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The AuthentificationErrorType enum.
/// </summary>
[XmlType(AnonymousType=true, Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public enum AuthentificationErrorType
{
    /// <summary>
    /// The Signatur value.
    /// </summary>
    Signatur,

    /// <summary>
    /// The SignaturMangler value.
    /// </summary>
    SignaturMangler,

    /// <summary>
    /// The UdbydersytemIdMangler value.
    /// </summary>
    UdbydersytemIdMangler,

    /// <summary>
    /// The BrugeridEllerPassword value.
    /// </summary>
    BrugeridEllerPassword,

    /// <summary>
    /// The Rettigheder value.
    /// </summary>
    Rettigheder,
}
