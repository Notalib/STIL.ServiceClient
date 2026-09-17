using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient;

/// <summary>
/// Base class for clients that talk to the STIL BPI (Brugerdatabasen Programmatisk Interface) SOAP services.
/// </summary>
public abstract class BaseStilBpiServiceClient
{
    /// <summary>
    /// The base URL of the BPI service.
    /// </summary>
    protected readonly Uri _baseUrl;

    /// <summary>
    /// The certificate used to sign outgoing SOAP requests.
    /// </summary>
    protected readonly X509Certificate2 _signingCertificate;

    /// <summary>
    /// The client used to send SOAP requests and parse the responses.
    /// </summary>
    protected readonly ISoapServiceClient _soapServiceClient;

    /// <summary>
    /// The generator used to build signed BPI SOAP requests.
    /// </summary>
    protected readonly BpiSoapRequestGenerator _requestGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseStilBpiServiceClient"/> class.
    /// </summary>
    /// <param name="baseUrl">The base URL of the BPI service.</param>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    protected BaseStilBpiServiceClient(string baseUrl, string systemId, X509Certificate2 signingCertificate, ISoapServiceClient soapServiceClient)
    {
        _baseUrl = new Uri(baseUrl);
        _signingCertificate = signingCertificate;
        _soapServiceClient = soapServiceClient;
        _requestGenerator = new BpiSoapRequestGenerator(baseUrl, systemId);
    }

    /// <summary>
    /// Calls the BPI "hello world" operation to verify that the configured certificate is accepted by the service.
    /// </summary>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>A task that completes once the ping request has succeeded.</returns>
    public async Task Ping(Guid? messageId = null)
    {
        helloWorldWithCertificateResponse response = await _soapServiceClient.SendSoapRequest<helloWorldWithCertificateResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(new helloWorldWithCertificate(), _signingCertificate, messageId));
    }

    /// <summary>
    /// Retrieves the data agreements ("dataaftaler") associated with the configured BPI system.
    /// </summary>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The data agreements response returned by the BPI service.</returns>
    public async Task<hentDataAftalerResponse> hentDataAftaler(Guid? messageId = null)
    {
        hentDataAftalerResponse response = await _soapServiceClient.SendSoapRequest<hentDataAftalerResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(new hentDataAftaler(), _signingCertificate, messageId));

        return response;
    }
}
