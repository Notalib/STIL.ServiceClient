using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

using STIL.ServiceClient.Util.SoapHelper;

namespace STIL.ServiceClient;

/// <summary>
/// Builds and signs SOAP requests for the STIL BPI services, adding the WS-Addressing and
/// BPI-specific ("udbydersystem id") headers those services require in addition to the SOAP body.
/// </summary>
public class BpiSoapRequestGenerator
{
    private readonly string _serviceUrl;
    private readonly string _systemId;

    /// <summary>
    /// Initializes a new instance of the <see cref="BpiSoapRequestGenerator"/> class.
    /// </summary>
    /// <param name="serviceUrl">The base URL of the BPI service, used to build the WS-Addressing action.</param>
    /// <param name="systemId">The BPI system identifier ("udbydersystem id") to include in signed requests.</param>
    public BpiSoapRequestGenerator(string serviceUrl, string systemId)
    {
        _serviceUrl = serviceUrl;
        _systemId = systemId;
    }

    /// <summary>
    /// Builds a SOAP envelope for <paramref name="requestObject"/>, adds the WS-Addressing and BPI headers,
    /// and signs it with <paramref name="signingCertificate"/>.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request body to serialize into the SOAP envelope.</typeparam>
    /// <param name="requestObject">The request body to serialize into the SOAP envelope.</param>
    /// <param name="action">The WS-Addressing action name, appended to the service URL.</param>
    /// <param name="signingCertificate">The certificate used to sign the request.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The signed SOAP request as an XML string.</returns>
    public string GetSignedRequest<TRequest>(TRequest requestObject,
                                             string action,
                                             X509Certificate2 signingCertificate,
                                             Guid? messageId = null)
    {
        Guid requestId = messageId ?? Guid.NewGuid();

        SoapRequestBuilder<TRequest> builder = new(requestId);

        XDocument requestDoc = builder.AddBody(requestObject)
            .AddBinarySecurityToken(signingCertificate)
            .AddTimeStamp()
            .AddWSAActionAndMessageId($"{_serviceUrl}/{action}")
            .AddBPISystemId(_systemId)
            .Build();

        SoapMessageSigner signer = new(requestDoc);
        string requestXml = signer
            .AddReference("Timestamp", requestId)
            .AddReference("Body", requestId)
            .AddReference("Action", requestId)
            .AddReference("MessageId", requestId)
            .AddReference("UdbydersystemId", requestId)
            .Sign(requestId, signingCertificate, SignedXml.XmlDsigRSASHA256Url);

        return requestXml;
    }

    /// <summary>
    /// Builds a SOAP envelope for <paramref name="requestObject"/>, adds the WS-Addressing and BPI headers,
    /// and signs it with <paramref name="signingCertificate"/>, using the request object's type name as the WS-Addressing action.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request body to serialize into the SOAP envelope.</typeparam>
    /// <param name="requestObject">The request body to serialize into the SOAP envelope.</param>
    /// <param name="signingCertificate">The certificate used to sign the request.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The signed SOAP request as an XML string.</returns>
    public string GetSignedRequest<TRequest>(TRequest requestObject,
                                             X509Certificate2 signingCertificate,
                                             Guid? messageId = null)
    {
        return GetSignedRequest(requestObject, requestObject.GetType().Name, signingCertificate, messageId);
    }
}
