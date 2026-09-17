using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using STIL.ServiceClient.DTOs.VEU.HentOptagedePladser;
using STIL.ServiceClient.DTOs.VEU.HentTilmeldingerVeuInteressenter;
using STIL.ServiceClient.DTOs.VEU.HentUdbud;
using ServiceFaultDetailer = STIL.ServiceClient.DTOs.VEU.HentOptagedePladser.ServiceFaultDetailer;

namespace STIL.ServiceClient;

/// <inheritdoc />
public class StilVeuServiceClient : IStilVeuServiceClient
{
    private readonly string _baseUrl;
    private readonly X509Certificate2 _signingCertificate;
    private readonly ISoapServiceClient _soapServiceClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="StilVeuServiceClient"/> class.
    /// </summary>
    /// <param name="baseUrl">The baseUrl for the SOAP services, ex. https://et.integrationsplatformen.dk.</param>
    /// <param name="clientAndSigningCertificate">The certificate used for both the http client and xml signing.</param>
    public StilVeuServiceClient(string baseUrl, X509Certificate2 clientAndSigningCertificate)
    {
        _baseUrl = baseUrl;
        _signingCertificate = clientAndSigningCertificate;
        _soapServiceClient = new SoapServiceClient(clientAndSigningCertificate);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilVeuServiceClient" /> class.
    /// </summary>
    /// <param name="baseUrl">The baseUrl for the SOAP services, ex. https://et.integrationsplatformen.dk.</param>
    /// <param name="clientCertificate">The http client certificate.</param>
    /// <param name="signingCertificate">The xml signing certificate.</param>
    public StilVeuServiceClient(string baseUrl, X509Certificate2 clientCertificate, X509Certificate2 signingCertificate)
    {
        _baseUrl = baseUrl;

        _signingCertificate = signingCertificate;
        _soapServiceClient = new SoapServiceClient(clientCertificate);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StilVeuServiceClient" /> class.
    /// </summary>
    /// <param name="baseUrl">The baseUrl for the SOAP services, ex. https://et.integrationsplatformen.dk.</param>
    /// <param name="soapServiceClient">The client used to send SOAP requests and parse the responses.</param>
    /// <param name="signingCertificate">The xml signing certificate.</param>
    public StilVeuServiceClient(string baseUrl, ISoapServiceClient soapServiceClient, X509Certificate2 signingCertificate)
    {
        _baseUrl = baseUrl;

        _signingCertificate = signingCertificate;
        _soapServiceClient = soapServiceClient;
    }

    private Uri GetRequestUri(string methodName)
    {
        return new Uri($"{_baseUrl.TrimEnd('/')}/services/VEU/{methodName}/v1");
    }

    /// <inheritdoc />
    public async Task<HentOptagedePladserResponse> HentOptagedePladser(
        HentOptagedePladserRequest dataRequest, CancellationToken cancellationToken = default)
    {
        BasicSoapRequestGenerator requestGenerator = new();

        return await _soapServiceClient.SendSoapRequest<HentOptagedePladserResponse, ServiceFaultDetailer>(
            GetRequestUri(nameof(HentOptagedePladser)),
            requestGenerator.GetSignedRequest(dataRequest, _signingCertificate),
            cancellationToken);
    }

    /// <inheritdoc />
    public async Task<hentTilmeldingerResponse> HentTilmeldingerVeuInteressenter(
        HentTilmeldingerRequest dataRequest, CancellationToken cancellationToken = default)
    {
        BasicSoapRequestGenerator requestGenerator = new();

        return await _soapServiceClient.SendSoapRequest<hentTilmeldingerResponse, DTOs.VEU.HentTilmeldingerVeuInteressenter.ServiceFaultDetailer>(
            GetRequestUri(nameof(HentTilmeldingerVeuInteressenter)),
            requestGenerator.GetSignedRequest(dataRequest, _signingCertificate),
            cancellationToken);
    }

    /// <inheritdoc />
    public async Task<HentUdbudResponse> HentUdbud(HentUdbudRequest dataRequest, CancellationToken cancellationToken = default)
    {
        BasicSoapRequestGenerator requestGenerator = new();

        return await _soapServiceClient.SendSoapRequest<HentUdbudResponse, DTOs.VEU.HentUdbud.ServiceFaultDetailer>(
            GetRequestUri(nameof(HentUdbud)),
            requestGenerator.GetSignedRequest(dataRequest, _signingCertificate),
            cancellationToken);
    }
}