using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetOrdrerRequest1
{
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public GetOrdrerRequest GetOrdrerRequest { get; set; }

    public GetOrdrerRequest1()
    {
    }

    public GetOrdrerRequest1(GetOrdrerRequest getOrdrerRequest)
    {
        GetOrdrerRequest = getOrdrerRequest;
    }
}