using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;
using STIL.ServiceClient.Util.SoapHelper;

namespace STIL.ServiceClient;

/// <summary>
/// Builds and signs SOAP requests that only require a body, a binary security token, and a timestamp,
/// without any WS-Addressing or BPI-specific headers.
/// </summary>
public class BasicSoapRequestGenerator
{
    /// <summary>
    /// Builds a SOAP envelope for <paramref name="requestObject"/> and signs it with <paramref name="signingCertificate"/>.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request body to serialize into the SOAP envelope.</typeparam>
    /// <param name="requestObject">The request body to serialize into the SOAP envelope.</param>
    /// <param name="signingCertificate">The certificate used to sign the request.</param>
    /// <param name="messageId">An optional message identifier to use for the request; a new one is generated when omitted.</param>
    /// <returns>The signed SOAP request as an XML string.</returns>
    public string GetSignedRequest<TRequest>(TRequest requestObject, X509Certificate2 signingCertificate, Guid? messageId = null)
    {
        SoapRequestBuilder<TRequest> builder = new(messageId ?? Guid.NewGuid());

        XDocument requestDoc = builder.AddBody(requestObject)
                                      .AddBinarySecurityToken(signingCertificate)
                                      .AddTimeStamp()
                                      .Build();

        return new SoapMessageSigner(requestDoc)
            .AddReference("Body", builder.RequestId)
            .AddReference("Timestamp", builder.RequestId)
            .Sign(builder.RequestId, signingCertificate, SignedXml.XmlDsigRSASHA1Url);
    }
}
