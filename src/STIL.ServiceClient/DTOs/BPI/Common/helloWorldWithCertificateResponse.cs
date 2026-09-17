using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The helloWorldWithCertificateResponse class.
/// </summary>
public class helloWorldWithCertificateResponse
{
    /// <summary>
    /// Gets or sets the <see cref="helloWorldWithCertificateResponse1"/> value.
    /// </summary>
    [MessageBodyMember(Name="helloWorldWithCertificateResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/common/3", Order=0)]
    public HelloWorldResponse helloWorldWithCertificateResponse1  { get; set; }
}