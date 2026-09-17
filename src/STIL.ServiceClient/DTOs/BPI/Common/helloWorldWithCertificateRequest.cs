using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The helloWorldWithCertificateRequest class.
/// </summary>
public class helloWorldWithCertificateRequest
{
    /// <summary>
    /// Gets or sets the <see cref="helloWorldWithCertificate"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3", Order=0)]
    public NoArgs helloWorldWithCertificate { get; set; }
}