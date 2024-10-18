using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusesCommand
{
    [XmlArray(IsNullable = true, Order = 0)]
    [XmlArrayItem("UpdateOrdreStatusCommand", IsNullable = false)]
    public UpdateOrdreStatusCommand[] updateOrdreStatusCommands { get; set; }
}