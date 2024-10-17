using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class UpdateOrdreStatusesResponse1
{
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public UpdateOrdreStatusesResponse UpdateOrdreStatusesResponse { get; set; }

    public UpdateOrdreStatusesResponse1()
    {
    }

    public UpdateOrdreStatusesResponse1(UpdateOrdreStatusesResponse updateOrdreStatusesResponse)
    {
        UpdateOrdreStatusesResponse = updateOrdreStatusesResponse;
    }
}