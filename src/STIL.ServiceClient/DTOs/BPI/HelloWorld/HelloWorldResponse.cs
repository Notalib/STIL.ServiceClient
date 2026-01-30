using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.HelloWorld;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public class HelloWorldResponse
{
    [XmlElement(Order=0)]
    public string helloWorldResult { get; set; }
}