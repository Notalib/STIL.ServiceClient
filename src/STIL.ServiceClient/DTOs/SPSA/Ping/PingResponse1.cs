using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.Ping;

[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class PingResponse1
{
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public PingResponse PingResponse { get; set; }

    public PingResponse1()
    {
    }

    public PingResponse1(PingResponse pingResponse)
    {
        PingResponse = pingResponse;
    }
}