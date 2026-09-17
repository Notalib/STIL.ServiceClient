using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentGrupperResponse class.
/// </summary>
public class hentGrupperResponse
{
    /// <summary>
    /// Gets or sets the <see cref="hentGrupperResponse1"/> value.
    /// </summary>
    [MessageBodyMember(Name="hentGrupperResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    [XmlArrayItem("gruppe", IsNullable=false)]
    public Gruppe[] hentGrupperResponse1 { get; set; }
}