using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentInstitutionerRequest class.
/// </summary>
public class hentInstitutionerRequest
{
    /// <summary>
    /// Gets or sets the <see cref="hentInstitutioner"/> value.
    /// </summary>
    [MessageBodyMember(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6", Order=0)]
    [XmlArrayItem("instnr", IsNullable=false)]
    public string[] hentInstitutioner { get; set; }
}
