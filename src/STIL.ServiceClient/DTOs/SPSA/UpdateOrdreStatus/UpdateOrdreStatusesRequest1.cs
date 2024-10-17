using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class UpdateOrdreStatusesRequest1
{
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public UpdateOrdreStatusesRequest UpdateOrdreStatusesRequest { get; set; }

    public UpdateOrdreStatusesRequest1()
    {
    }

    public UpdateOrdreStatusesRequest1(UpdateOrdreStatusesRequest updateOrdreStatusesRequest)
    {
        UpdateOrdreStatusesRequest = updateOrdreStatusesRequest;
    }
}