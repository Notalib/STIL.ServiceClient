using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Linq;
using STIL.SoapHelper;

namespace STIL.ServiceClient.Util.SoapHelper;

/// <summary>
/// Helper class for creating a SOAP signature.
/// </summary>
public class SoapMessageSigner
{
    private const string X509TokenProfile = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3";
    private static readonly XNamespace WSSecuritySecExtNamespace = XNamespace.Get("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");

    private readonly XmlDocument _xmlDocument;
    private readonly List<string> _references = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="SoapSigner"/> class.
    /// </summary>
    /// <param name="soapMessage">The SOAP message to sign.</param>
    public SoapMessageSigner(XDocument soapMessage)
    {
        _xmlDocument = new XmlDocument { PreserveWhitespace = false };

        _xmlDocument.Load(soapMessage.CreateReader(ReaderOptions.OmitDuplicateNamespaces));
    }

    /// <summary>
    /// Adds a reference to an XML element to be included in the signature.
    /// </summary>
    /// <param name="reference">The id of the element to reference.</param>
    /// <returns>The current <see cref="SoapMessageSigner"/> instance.</returns>
    public SoapMessageSigner AddReference(string reference)
    {
        _references.Add($"#{reference}");

        return this;
    }

    /// <summary>
    /// Adds a reference to an XML element to be included in the signature, using the element id built from
    /// <paramref name="reference"/> and <paramref name="requestId"/>.
    /// </summary>
    /// <param name="reference">The name of the element to reference.</param>
    /// <param name="requestId">The request identifier used to build the element's id.</param>
    /// <returns>The current <see cref="SoapMessageSigner"/> instance.</returns>
    public SoapMessageSigner AddReference(string reference, Guid requestId)
    {
        _references.Add($"#{reference}-{requestId}");

        return this;
    }

    /// <summary>
    /// Signs the SOAP message.
    /// </summary>
    /// <returns>A signed SOAP message.</returns>
    /// <param name="requestId">RequestId.</param>
    /// <param name="signingCertificate">The certificate to use for signing the SOAP message.</param>
    /// <param name="signingMethod">Canonical URL of the signing method.</param>
    /// <remarks>WARNING: Do not reformat the returned XML, as the added whitespace will break the signature.</remarks>
    public string Sign(Guid requestId, X509Certificate2 signingCertificate, string signingMethod)
    {
        SignedXml signatureGenerator = GetXmlSigner(signingCertificate, _xmlDocument, signingMethod);

        AddReferencesToSignedXml(_references, signatureGenerator);
        AddSecurityTokenReference(requestId, signatureGenerator);

        signatureGenerator.ComputeSignature();

        XmlElement signature = signatureGenerator.GetXml();
        AppendComputedSignature(_xmlDocument, signature);

        return _xmlDocument.OuterXml;
    }

    /// <summary>
    /// Append the computed signature to the 'Security' element in the SOAP Header.
    /// </summary>
    /// <param name="xmlDocument">The document containing the unsigned SOAP message.</param>
    /// <param name="signature">The signature to append to the unsigned SOAP message.</param>
    private static void AppendComputedSignature(XmlDocument xmlDocument, XmlElement signature)
    {
        SoapMessageValidator validator = new(xmlDocument);
        XmlNode securityNode = validator.FindSecurityElement();
        securityNode.AppendChild(signature);
    }

    /// <summary>
    /// Add a reference to the SOAP Body element.
    /// </summary>
    /// <param name="references">References to add to signed XML document.</param>
    /// <param name="signedXml">The signed XML to add the references to.</param>
    private static void AddReferencesToSignedXml(IEnumerable<string> references, SignedXml signedXml)
    {
        foreach (string referenceLink in references)
        {
            Reference reference = new(referenceLink);
            reference.AddTransform(new XmlDsigExcC14NTransform());
            reference.DigestMethod = SignedXml.XmlDsigSHA256Url;
            signedXml.AddReference(reference);
        }
    }

    /// <summary>
    /// Creates a new instance of the <see cref="SignedXmlWithNamespacedIdElement"/> class
    /// with the supplied certificate and <see cref="XmlDocument"/>.
    /// </summary>
    /// <param name="signingCertificate">The certificate to be used for computing the XML signature.</param>
    /// <param name="xmlDocument">The document to be signed.</param>
    /// <param name="signingMethod">Canonical URL of the signing method.</param>
    /// <returns>The <see cref="SignedXml"/> object.</returns>
    private static SignedXml GetXmlSigner(X509Certificate2 signingCertificate, XmlDocument xmlDocument, string signingMethod)
    {
        return new SignedXmlWithNamespacedIdElement(xmlDocument)
        {
            SigningKey = signingCertificate.GetRSAPrivateKey(),
            SignedInfo =
            {
                CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl,
                SignatureMethod = signingMethod,
            },
        };
    }

    /// <summary>
    /// Add a reference to the public key of the certificate used to sign the document.
    /// </summary>
    /// <param name="tokenId">The GUID part of the signing certificate id.</param>
    /// <param name="signedXml">The signed XML to add the certificate reference to.</param>
    private static void AddSecurityTokenReference(Guid tokenId, SignedXml signedXml)
    {
        signedXml.KeyInfo = new KeyInfo();
        XmlElement securityTokenReference = new XElement(
                WSSecuritySecExtNamespace + "SecurityTokenReference",
                new XElement(
                    WSSecuritySecExtNamespace + "Reference",
                    new XAttribute("ValueType", X509TokenProfile),
                    new XAttribute("URI", $"#SecurityToken-{tokenId}")))
            .ToXmlElement();
        signedXml.KeyInfo.AddClause(new KeyInfoNode(securityTokenReference));
    }
}
