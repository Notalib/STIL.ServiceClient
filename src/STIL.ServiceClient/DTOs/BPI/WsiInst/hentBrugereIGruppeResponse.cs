using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentBrugereIGruppeResponse class.
/// </summary>
public class hentBrugereIGruppeResponse
{
    /// <summary>
    /// Gets or sets the <see cref="hentBrugereIGruppeResponse1"/> value.
    /// </summary>
    [MessageBodyMember(Name="hentBrugereIGruppeResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    [XmlArrayItem("brugertilknytning", IsNullable=false)]
    public Brugertilknytning[] hentBrugereIGruppeResponse1 { get; set; }
}