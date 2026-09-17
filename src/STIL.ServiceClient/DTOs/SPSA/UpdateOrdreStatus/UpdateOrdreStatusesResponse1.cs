using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

/// <summary>
/// The UpdateOrdreStatusesResponse1 class.
/// </summary>
[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class UpdateOrdreStatusesResponse1
{
    /// <summary>
    /// Gets or sets the <see cref="UpdateOrdreStatusesResponse"/> value.
    /// </summary>
    [MessageBodyMember(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0", Order = 0)]
    public UpdateOrdreStatusesResponse UpdateOrdreStatusesResponse { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateOrdreStatusesResponse1"/> class.
    /// </summary>
    public UpdateOrdreStatusesResponse1()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateOrdreStatusesResponse1"/> class.
    /// </summary>
    /// <param name="updateOrdreStatusesResponse">The updateOrdreStatusesResponse.</param>
    public UpdateOrdreStatusesResponse1(UpdateOrdreStatusesResponse updateOrdreStatusesResponse)
    {
        UpdateOrdreStatusesResponse = updateOrdreStatusesResponse;
    }
}