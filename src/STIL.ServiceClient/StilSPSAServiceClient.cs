using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using STIL.ServiceClient.DTOs.SPSA;
using STIL.ServiceClient.DTOs.SPSA.GetOrdrer;
using STIL.ServiceClient.DTOs.SPSA.Ping;
using STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

namespace STIL.ServiceClient;

/// <summary>
/// Client for the STIL SPSA (Special Pædagogisk Støtte til voksne) order service.
/// </summary>
public class StilSPSAServiceClient
{
    private const string BaseUrl = "https://integrationsplatformen.dk/services/SPSA/OrdreService/v1.0";

    private readonly Uri _baseUrl;
    private readonly X509Certificate2 _signingCertificate;
    private readonly ISoapServiceClient _soapServiceClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="StilSPSAServiceClient"/> class targeting the default SPSA endpoint.
    /// </summary>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="httpClient">The <see cref="HttpClient"/> used to send SOAP requests.</param>
    public StilSPSAServiceClient(X509Certificate2 signingCertificate, HttpClient httpClient)
        : this(BaseUrl, signingCertificate, new SoapServiceClient(httpClient))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilSPSAServiceClient"/> class targeting the default SPSA endpoint.
    /// </summary>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    public StilSPSAServiceClient(X509Certificate2 signingCertificate, ISoapServiceClient soapServiceClient)
        : this(BaseUrl, signingCertificate, soapServiceClient)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilSPSAServiceClient"/> class targeting a custom SPSA endpoint.
    /// </summary>
    /// <param name="baseUrl">The base URL of the SPSA service.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="httpClient">The <see cref="HttpClient"/> used to send SOAP requests.</param>
    public StilSPSAServiceClient(string baseUrl, X509Certificate2 signingCertificate, HttpClient httpClient)
        : this(baseUrl, signingCertificate, new SoapServiceClient(httpClient))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilSPSAServiceClient"/> class targeting a custom SPSA endpoint.
    /// </summary>
    /// <param name="baseUrl">The base URL of the SPSA service.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    public StilSPSAServiceClient(string baseUrl, X509Certificate2 signingCertificate, ISoapServiceClient soapServiceClient)
    {
        _baseUrl = new Uri(baseUrl);
        _signingCertificate = signingCertificate;
        _soapServiceClient = soapServiceClient;
    }

    /// <summary>
    /// Calls the SPSA "ping" operation to verify that the configured certificate is accepted by the service.
    /// </summary>
    /// <returns>A task that completes once the ping request has succeeded.</returns>
    public async Task Ping()
    {
        // action Ping
        BasicSoapRequestGenerator requestGenerator = new();

        await _soapServiceClient.SendSoapRequest<PingResponse, ServiceFaultDetailer>(_baseUrl, requestGenerator.GetSignedRequest(new Ping(), _signingCertificate));
    }

    /// <summary>
    /// Retrieves orders ("ordrer") matching the given <paramref name="request"/>.
    /// </summary>
    /// <param name="request">The request describing which orders to retrieve.</param>
    /// <returns>The orders returned by the SPSA service.</returns>
    public async Task<GetOrdrerResponse> GetOrdrer(GetOrdrerRequest request)
    {
        // action GetOrdrer
        BasicSoapRequestGenerator requestGenerator = new();

        return await _soapServiceClient.SendSoapRequest<GetOrdrerResponse, ServiceFaultDetailer>(_baseUrl, requestGenerator.GetSignedRequest(request, _signingCertificate));
    }

    /// <summary>
    /// Updates the status of one or more orders ("ordrer").
    /// </summary>
    /// <param name="request">The request describing the order status updates to apply.</param>
    /// <returns>The response returned by the SPSA service.</returns>
    public async Task<UpdateOrdreStatusesResponse> UpdateOrdreStatuses(UpdateOrdreStatusesRequest request)
    {
        // action UpdateOrdreStatuses
        BasicSoapRequestGenerator requestGenerator = new();

        return await _soapServiceClient.SendSoapRequest<UpdateOrdreStatusesResponse, ServiceFaultDetailer>(_baseUrl, requestGenerator.GetSignedRequest(request, _signingCertificate));
    }
}
