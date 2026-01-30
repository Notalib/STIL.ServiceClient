using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.HelloWorld;

public class helloWorldWithCertificateResponse
{
    [MessageBodyMember(Name="helloWorldWithCertificateResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/common/3", Order=0)]
    public HelloWorldResponse helloWorldWithCertificateResponse1  { get; set; }
}