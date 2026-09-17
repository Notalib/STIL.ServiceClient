using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The HelloWorldResponse class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public class HelloWorldResponse
{
    /// <summary>
    /// Gets or sets the <see cref="helloWorldResult"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public string helloWorldResult { get; set; }
}