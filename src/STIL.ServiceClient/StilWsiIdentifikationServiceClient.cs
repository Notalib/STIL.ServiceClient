using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using STIL.ServiceClient.DTOs.BPI.Common;
using STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

namespace STIL.ServiceClient;

/// <summary>
/// Client for the STIL BPI WsiIdentifikation (identity lookup) SOAP service.
/// </summary>
public class StilWsiIdentifikationServiceClient : BaseStilBpiServiceClient
{
    private const string BaseUrl = "https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6";

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiIdentifikationServiceClient"/> class targeting the default WsiIdentifikation endpoint.
    /// </summary>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="httpClient">The <see cref="HttpClient"/> used to send SOAP requests.</param>
    public StilWsiIdentifikationServiceClient(string systemId, X509Certificate2 signingCertificate, HttpClient httpClient)
        : base(BaseUrl, systemId, signingCertificate, new SoapServiceClient(httpClient))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiIdentifikationServiceClient"/> class targeting the default WsiIdentifikation endpoint.
    /// </summary>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    public StilWsiIdentifikationServiceClient(string systemId, X509Certificate2 signingCertificate, ISoapServiceClient soapServiceClient)
        : base(BaseUrl, systemId, signingCertificate, soapServiceClient)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiIdentifikationServiceClient"/> class targeting a custom WsiIdentifikation endpoint.
    /// </summary>
    /// <param name="baseUrl">The base URL of the WsiIdentifikation service.</param>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="httpClient">The <see cref="HttpClient"/> used to send SOAP requests.</param>
    public StilWsiIdentifikationServiceClient(string baseUrl, string systemId, X509Certificate2 signingCertificate, HttpClient httpClient)
        : base(baseUrl, systemId, signingCertificate, new SoapServiceClient(httpClient))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiIdentifikationServiceClient"/> class targeting a custom WsiIdentifikation endpoint.
    /// </summary>
    /// <param name="baseUrl">The base URL of the WsiIdentifikation service.</param>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    public StilWsiIdentifikationServiceClient(string baseUrl, string systemId, X509Certificate2 signingCertificate, ISoapServiceClient soapServiceClient)
        : base(baseUrl, systemId, signingCertificate, soapServiceClient)
    {
    }

    /// <summary>
    /// Looks up the user identifier ("brugerid") for the given CPR number.
    /// </summary>
    /// <param name="cpr">The CPR number to look up.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The matching user identifier.</returns>
    public async Task<string> HentBrugeridFraCpr(string cpr, Guid? messageId = null)
    {
        hentBrugeridFraCpr request = new()
        {
            cpr = cpr,
        };

        hentBrugeridResponse response = await _soapServiceClient.SendSoapRequest<hentBrugeridResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(request, _signingCertificate, messageId));

        return response.brugerid;
    }

    /// <summary>
    /// Looks up the CPR number for the given user identifier ("brugerid").
    /// </summary>
    /// <param name="brugerId">The user identifier to look up.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The matching CPR number.</returns>
    public async Task<string> HentCprFraBrugerid(string brugerId, Guid? messageId = null)
    {
        hentCprFraBrugerid request = new()
        {
            brugerid = brugerId,
        };

        hentCprResponse response = await _soapServiceClient.SendSoapRequest<hentCprResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(request, _signingCertificate, messageId));

        return response.cpr;
    }
}
