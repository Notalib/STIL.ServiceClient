using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

/// <summary>
/// The UpdateOrdreStatusesCommand class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusesCommand
{
    /// <summary>
    /// Gets or sets the <see cref="updateOrdreStatusCommands"/> value.
    /// </summary>
    [XmlArray(IsNullable = true, Order = 0)]
    [XmlArrayItem("UpdateOrdreStatusCommand", IsNullable = false)]
    public UpdateOrdreStatusCommand[] updateOrdreStatusCommands { get; set; }
}