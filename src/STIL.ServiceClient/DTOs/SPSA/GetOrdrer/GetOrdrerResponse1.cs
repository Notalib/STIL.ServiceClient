using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

/// <summary>
/// The GetOrdrerResponse1 class.
/// </summary>
[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetOrdrerResponse1
{
    /// <summary>
    /// Gets or sets the <see cref="GetOrdrerResponse"/> value.
    /// </summary>
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public GetOrdrerResponse GetOrdrerResponse { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetOrdrerResponse1"/> class.
    /// </summary>
    public GetOrdrerResponse1()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetOrdrerResponse1"/> class.
    /// </summary>
    /// <param name="getOrdrerResponse">The getOrdrerResponse.</param>
    public GetOrdrerResponse1(GetOrdrerResponse getOrdrerResponse)
    {
        GetOrdrerResponse = getOrdrerResponse;
    }
}