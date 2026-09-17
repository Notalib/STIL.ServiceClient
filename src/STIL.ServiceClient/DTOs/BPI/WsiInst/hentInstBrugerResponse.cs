using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentInstBrugerResponse class.
/// </summary>
public class hentInstBrugerResponse
{
    /// <summary>
    /// Gets or sets the <see cref="hentInstBrugerResponse1"/> value.
    /// </summary>
    [MessageBodyMember(Name="hentInstBrugerResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    [XmlArrayItem("instBruger", IsNullable=false)]
    public Instbruger[] hentInstBrugerResponse1 { get; set; }
}