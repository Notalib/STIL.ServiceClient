using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.Ping;

/// <summary>
/// The PingRequest class.
/// </summary>
[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class PingRequest
{
    /// <summary>
    /// Gets or sets the <see cref="Ping"/> value.
    /// </summary>
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public Ping Ping { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PingRequest"/> class.
    /// </summary>
    public PingRequest()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PingRequest"/> class.
    /// </summary>
    /// <param name="ping">The ping.</param>
    public PingRequest(Ping ping)
    {
        Ping = ping;
    }
}
