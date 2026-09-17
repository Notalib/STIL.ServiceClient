using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.Ping;

/// <summary>
/// The PingResponse1 class.
/// </summary>
[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class PingResponse1
{
    /// <summary>
    /// Gets or sets the <see cref="PingResponse"/> value.
    /// </summary>
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public PingResponse PingResponse { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PingResponse1"/> class.
    /// </summary>
    public PingResponse1()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PingResponse1"/> class.
    /// </summary>
    /// <param name="pingResponse">The pingResponse.</param>
    public PingResponse1(PingResponse pingResponse)
    {
        PingResponse = pingResponse;
    }
}