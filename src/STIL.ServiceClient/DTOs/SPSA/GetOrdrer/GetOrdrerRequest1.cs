using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

/// <summary>
/// The GetOrdrerRequest1 class.
/// </summary>
[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetOrdrerRequest1
{
    /// <summary>
    /// Gets or sets the <see cref="GetOrdrerRequest"/> value.
    /// </summary>
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public GetOrdrerRequest GetOrdrerRequest { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetOrdrerRequest1"/> class.
    /// </summary>
    public GetOrdrerRequest1()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetOrdrerRequest1"/> class.
    /// </summary>
    /// <param name="getOrdrerRequest">The getOrdrerRequest.</param>
    public GetOrdrerRequest1(GetOrdrerRequest getOrdrerRequest)
    {
        GetOrdrerRequest = getOrdrerRequest;
    }
}