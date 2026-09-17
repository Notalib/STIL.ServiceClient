using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using STIL.ServiceClient.DTOs.BPI.Common;
using STIL.ServiceClient.DTOs.BPI.WsiBruger;

namespace STIL.ServiceClient;

/// <summary>
/// Client for the STIL BPI WsiBruger (user information) SOAP service.
/// </summary>
public class StilWsiBrugerServiceClient : BaseStilBpiServiceClient
{
    private const string BaseUrl = "https://brugerdatabasen.stil.dk/bpi/wsibruger/7";

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiBrugerServiceClient"/> class targeting the default WsiBruger endpoint.
    /// </summary>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="httpClient">The <see cref="HttpClient"/> used to send SOAP requests.</param>
    public StilWsiBrugerServiceClient(string systemId, X509Certificate2 signingCertificate, HttpClient httpClient)
        : base(BaseUrl, systemId, signingCertificate, new SoapServiceClient(httpClient))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiBrugerServiceClient"/> class targeting the default WsiBruger endpoint.
    /// </summary>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    public StilWsiBrugerServiceClient(string systemId, X509Certificate2 signingCertificate, ISoapServiceClient soapServiceClient)
        : base(BaseUrl, systemId, signingCertificate, soapServiceClient)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiBrugerServiceClient"/> class targeting a custom WsiBruger endpoint.
    /// </summary>
    /// <param name="baseUrl">The base URL of the WsiBruger service.</param>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="httpClient">The <see cref="HttpClient"/> used to send SOAP requests.</param>
    public StilWsiBrugerServiceClient(string baseUrl, string systemId, X509Certificate2 signingCertificate, HttpClient httpClient)
        : base(baseUrl, systemId, signingCertificate, new SoapServiceClient(httpClient))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiBrugerServiceClient"/> class targeting a custom WsiBruger endpoint.
    /// </summary>
    /// <param name="baseUrl">The base URL of the WsiBruger service.</param>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    public StilWsiBrugerServiceClient(string baseUrl, string systemId, X509Certificate2 signingCertificate, ISoapServiceClient soapServiceClient)
        : base(baseUrl, systemId, signingCertificate, soapServiceClient)
    {
    }

    /// <summary>
    /// Retrieves the institution affiliations ("institutionstilknytninger") of the user identified by <paramref name="brugerId"/>.
    /// </summary>
    /// <param name="brugerId">The user identifier to look up.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The institution affiliations response returned by the BPI service.</returns>
    public async Task<hentBrugersInstitutionstilknytningerResponse> HentBrugersInstitutionstilknytninger(string brugerId, Guid? messageId = null)
    {
        hentBrugersInstitutionstilknytninger request = new()
        {
            brugerid = brugerId,
        };

        hentBrugersInstitutionstilknytningerResponse response = await _soapServiceClient.SendSoapRequest<hentBrugersInstitutionstilknytningerResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(request, _signingCertificate, messageId));

        return response;
    }
}
