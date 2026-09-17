using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using STIL.ServiceClient.DTOs.BPI.Common;
using STIL.ServiceClient.DTOs.BPI.WsiInst;

namespace STIL.ServiceClient;

/// <summary>
/// Client for the STIL BPI WsiInst (institution information) SOAP service.
/// </summary>
public class StilWsiInstServiceClient : BaseStilBpiServiceClient
{
    private const string BaseUrl = "https://brugerdatabasen.stil.dk/bpi/wsiinst/6";

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiInstServiceClient"/> class targeting the default WsiInst endpoint.
    /// </summary>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="httpClient">The <see cref="HttpClient"/> used to send SOAP requests.</param>
    public StilWsiInstServiceClient(string systemId, X509Certificate2 signingCertificate, HttpClient httpClient)
        : base(BaseUrl, systemId, signingCertificate, new SoapServiceClient(httpClient))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiInstServiceClient"/> class targeting the default WsiInst endpoint.
    /// </summary>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    public StilWsiInstServiceClient(string systemId, X509Certificate2 signingCertificate, ISoapServiceClient soapServiceClient)
        : base(BaseUrl, systemId, signingCertificate, soapServiceClient)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiInstServiceClient"/> class targeting a custom WsiInst endpoint.
    /// </summary>
    /// <param name="baseUrl">The base URL of the WsiInst service.</param>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="httpClient">The <see cref="HttpClient"/> used to send SOAP requests.</param>
    public StilWsiInstServiceClient(string baseUrl, string systemId, X509Certificate2 signingCertificate, HttpClient httpClient)
        : base(baseUrl, systemId, signingCertificate, new SoapServiceClient(httpClient))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilWsiInstServiceClient"/> class targeting a custom WsiInst endpoint.
    /// </summary>
    /// <param name="baseUrl">The base URL of the WsiInst service.</param>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to authenticate as.</param>
    /// <param name="signingCertificate">The certificate used to sign outgoing SOAP requests.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    public StilWsiInstServiceClient(string baseUrl, string systemId, X509Certificate2 signingCertificate, ISoapServiceClient soapServiceClient)
        : base(baseUrl, systemId, signingCertificate, soapServiceClient)
    {
    }

    /// <summary>
    /// Retrieves the groups ("grupper") belonging to the institution identified by <paramref name="instnr"/>.
    /// </summary>
    /// <param name="instnr">The institution number to look up.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The groups response returned by the BPI service.</returns>
    public async Task<hentGrupperResponse> HentGrupper(string instnr, Guid? messageId = null)
    {
        hentGrupperResponse response = await _soapServiceClient.SendSoapRequest<hentGrupperResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(new hentGrupper { instnr = instnr}, _signingCertificate, messageId));

        return response;
    }

    /// <summary>
    /// Retrieves the users ("brugere") belonging to the given group at the given institution.
    /// </summary>
    /// <param name="instnr">The institution number the group belongs to.</param>
    /// <param name="gruppeId">The group identifier to look up.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The users response returned by the BPI service.</returns>
    public async Task<hentBrugereIGruppeResponse> HentBrugereIGruppe(string instnr, string gruppeId, Guid? messageId = null)
    {
        hentBrugereIGruppe request = new()
        {
            instnr = instnr,
            gruppeid = gruppeId,
        };

        hentBrugereIGruppeResponse response = await _soapServiceClient.SendSoapRequest<hentBrugereIGruppeResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(request, _signingCertificate, messageId));

        return response;
    }

    /// <summary>
    /// Retrieves the institution identified by <paramref name="instnr"/>.
    /// </summary>
    /// <param name="instnr">The institution number to look up.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The institution response returned by the BPI service.</returns>
    public async Task<hentInstitutionResponse> HentInstitution(string instnr, Guid? messageId = null)
    {
        hentInstitution request = new()
        {
            instnr = instnr,
        };

        hentInstitutionResponse response = await _soapServiceClient.SendSoapRequest<hentInstitutionResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(request, _signingCertificate, messageId));

        return response;
    }

    /// <summary>
    /// Retrieves multiple institutions in a single request.
    /// </summary>
    /// <param name="instnr">The institution numbers to look up.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The institutions response returned by the BPI service.</returns>
    public async Task<hentInstitutionerResponse> HentInstitutioner(string[] instnr, Guid? messageId = null)
    {
        hentInstitutionerRequest request = new()
        {
            hentInstitutioner = instnr,
        };

        hentInstitutionerResponse response = await _soapServiceClient.SendSoapRequest<hentInstitutionerResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(request, "hentInstitutioner", _signingCertificate, messageId));

        return response;
    }

    /// <summary>
    /// Retrieves the user identified by <paramref name="brugerId"/> at the given institution.
    /// </summary>
    /// <param name="instnr">The institution number the user belongs to.</param>
    /// <param name="brugerId">The user identifier to look up.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The user response returned by the BPI service.</returns>
    public async Task<hentInstBrugerResponse> HentInstBruger(string instnr, string brugerId, Guid? messageId = null)
    {
        hentInstBruger request = new()
        {
            instnr = instnr,
            brugerid = brugerId,
        };

        hentInstBrugerResponse response = await _soapServiceClient.SendSoapRequest<hentInstBrugerResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(request, _signingCertificate, messageId));

        return response;
    }

    /// <summary>
    /// Retrieves the institution hierarchy ("institutionshierarki") rooted at the institution identified by <paramref name="instnr"/>.
    /// </summary>
    /// <param name="instnr">The institution number to look up.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The institution hierarchy response returned by the BPI service.</returns>
    public async Task<HentInstitutionshierarkiResponse> HentInstitutionshierarki(string instnr, Guid? messageId = null)
    {
        hentInstitutionshierarki request = new()
        {
            instnr = instnr,
        };

        HentInstitutionshierarkiResponse response = await _soapServiceClient.SendSoapRequest<HentInstitutionshierarkiResponse, AuthentificationError>(
            _baseUrl,
            _requestGenerator.GetSignedRequest(request, _signingCertificate, messageId));

        return response;
    }
}
