using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

/// <summary>
/// The UpdateOrdreStatusesRequest1 class.
/// </summary>
[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class UpdateOrdreStatusesRequest1
{
    /// <summary>
    /// Gets or sets the <see cref="UpdateOrdreStatusesRequest"/> value.
    /// </summary>
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public UpdateOrdreStatusesRequest UpdateOrdreStatusesRequest { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateOrdreStatusesRequest1"/> class.
    /// </summary>
    public UpdateOrdreStatusesRequest1()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateOrdreStatusesRequest1"/> class.
    /// </summary>
    /// <param name="updateOrdreStatusesRequest">The updateOrdreStatusesRequest.</param>
    public UpdateOrdreStatusesRequest1(UpdateOrdreStatusesRequest updateOrdreStatusesRequest)
    {
        UpdateOrdreStatusesRequest = updateOrdreStatusesRequest;
    }
}