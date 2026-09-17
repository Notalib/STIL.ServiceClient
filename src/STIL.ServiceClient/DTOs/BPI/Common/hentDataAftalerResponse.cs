using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The hentDataAftalerResponse class.
/// </summary>
public class hentDataAftalerResponse
{
    /// <summary>
    /// Gets or sets the <see cref="hentDataAftalerResponse1"/> value.
    /// </summary>
    [MessageBodyMember(Name="hentDataAftalerResponse", Namespace="https://brugerdatabasen.stil.dk/bpi/common/3", Order=0)]
    [XmlArrayItem("regnr", DataType="token", IsNullable=false)]
    public string[] hentDataAftalerResponse1 { get; set; }
}