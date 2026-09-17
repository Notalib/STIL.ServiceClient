using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The hentKontaktpersonsBrugereResponse class.
/// </summary>
public class hentKontaktpersonsBrugereResponse
{
    /// <summary>
    /// Gets or sets the <see cref="hentKontaktpersonsBrugereResponse1"/> value.
    /// </summary>
    [MessageBodyMember(Name="hentKontaktpersonsBrugereResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7", Order=0)]
    [XmlArrayItem("elev", IsNullable=false)]
    public Elevbruger[] hentKontaktpersonsBrugereResponse1 { get; set; }
}