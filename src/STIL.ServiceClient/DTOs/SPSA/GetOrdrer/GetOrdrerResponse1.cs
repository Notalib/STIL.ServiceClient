using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetOrdrerResponse1
{
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public GetOrdrerResponse GetOrdrerResponse { get; set; }

    public GetOrdrerResponse1()
    {
    }

    public GetOrdrerResponse1(GetOrdrerResponse getOrdrerResponse)
    {
        GetOrdrerResponse = getOrdrerResponse;
    }
}