using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using STIL.SoapHelper;

namespace STIL.ServiceClient.Util.SoapHelper;

/// <summary>
/// Helper class for building a SOAP message for STIL.
/// </summary>
/// <typeparam name="T">The type of the SOAP Body content.</typeparam>
public class SoapRequestBuilder<T>
{
    /// <summary>
    /// The WS-Security X.509 token profile value type used for the binary security token.
    /// </summary>
    public const string ValueType = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3";

    /// <summary>
    /// The WS-Security encoding type used for the binary security token.
    /// </summary>
    public const string EncodingType = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";

    /// <summary>
    /// The XML namespace prefix used for the XML Schema instance namespace.
    /// </summary>
    public const string XMLSchemaInstance = "xsi";

    /// <summary>
    /// The XML Schema instance namespace.
    /// </summary>
    public static readonly XNamespace XMLSchemaInstanceNamespace = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");

    /// <summary>
    /// The XML namespace prefix used for the XML Schema namespace.
    /// </summary>
    public const string XMLSchema = "xsd";

    /// <summary>
    /// The XML Schema namespace.
    /// </summary>
    public static readonly XNamespace XMLSchemaNamespace = XNamespace.Get("http://www.w3.org/2001/XMLSchema");

    /// <summary>
    /// The XML namespace prefix used for the SOAP envelope namespace.
    /// </summary>
    public const string SoapEnvelope = "soap";

    /// <summary>
    /// The SOAP envelope namespace.
    /// </summary>
    public static readonly XNamespace SoapEnvelopeNamespace = XNamespace.Get("http://www.w3.org/2003/05/soap-envelope");

    /// <summary>
    /// The XML namespace prefix used for the WS-Security utility namespace.
    /// </summary>
    public const string WSSecurityUtility = "wsu";

    /// <summary>
    /// The WS-Security utility namespace, used for element ids and the timestamp header.
    /// </summary>
    public static readonly XNamespace WSSecurityUtilityNamespace = XNamespace.Get("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");

    /// <summary>
    /// The XML namespace prefix used for the WS-Security extension namespace.
    /// </summary>
    public const string WsSecuritySecExt = "wsse";

    /// <summary>
    /// The WS-Security extension namespace, used for the Security header and binary security token.
    /// </summary>
    public static readonly XNamespace WSSecuritySecExtNamespace = XNamespace.Get("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");

    /// <summary>
    /// The XML namespace prefix used for the BPI namespace.
    /// </summary>
    public const string BPI = "bpi";

    /// <summary>
    /// The BPI namespace, used for the UdbydersystemId header required by STIL BPI services.
    /// </summary>
    public static readonly XNamespace BPINamespace = XNamespace.Get("https://brugerdatabasen.stil.dk/bpi/common/3");

    /// <summary>
    /// The XML namespace prefix used for the WS-Addressing namespace.
    /// </summary>
    public const string WSAdressing = "wsa";

    /// <summary>
    /// The WS-Addressing namespace, used for the Action and MessageID headers.
    /// </summary>
    public static readonly XNamespace WSAdressingNamespace = XNamespace.Get("http://www.w3.org/2005/08/addressing");

    private readonly XDocument _document;

    private XElement Envelope => _document.Root;

    private XElement Header => _document.Descendants(SoapEnvelopeNamespace + "Header").Single();

    private XElement? Security => _document.Descendants(WSSecuritySecExtNamespace + "Security").SingleOrDefault();

    /// <summary>
    /// Initializes a new instance of the <see cref="SoapRequestBuilder{T}"/> class.
    /// </summary>
    public SoapRequestBuilder()
        : this(Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SoapRequestBuilder{T}"/> class.
    /// </summary>
    /// <param name="requestId">RequestId use </param>
    public SoapRequestBuilder(Guid requestId)
    {
        _document = new XDocument(new XDeclaration("1.0", Encoding.UTF8.EncodingName, null));
        RequestId = requestId;

        AddEnvelope().AddHeader();
    }

    /// <summary>
    /// Gets the identifier that identifies the signing certificate element (a.k.a. BinarySecurityToken).
    /// </summary>
    public Guid RequestId { get; private set; }

    /// <summary>
    /// Builds an unsigned SOAP message. This constructs all parts needed to sign the SOAP Envelope.
    /// </summary>
    /// <returns>A document ready to be signed with the signing certificate.</returns>
    public XDocument Build()
    {
        return _document;
    }

    /// <summary>
    /// Adds the top level SOAP Envelope element.
    /// </summary>
    private SoapRequestBuilder<T> AddEnvelope()
    {
        _document.Add(new XElement(
            SoapEnvelopeNamespace + "Envelope",
            new XAttribute(XNamespace.Xmlns + SoapEnvelope, SoapEnvelopeNamespace),
            new XAttribute(XNamespace.Xmlns + WSSecurityUtility, WSSecurityUtilityNamespace),
            new XAttribute(XNamespace.Xmlns + XMLSchemaInstance, XMLSchemaInstanceNamespace),
            new XAttribute(XNamespace.Xmlns + XMLSchema, XMLSchemaNamespace)));

        return this;
    }

    /// <summary>
    /// Adds the SOAP Header element.
    /// </summary>
    /// <param name="document">The document to add the header to.</param>
    /// <param name="signingCertificate">The certificate which will be used to sign the document.</param>
    /// <returns>A part of the identifier that identifies the signing certificate element.</returns>
    private SoapRequestBuilder<T> AddHeader()
    {
        Envelope.Add(new XElement(SoapEnvelopeNamespace + "Header"));

        return this;
    }

    /// <summary>
    /// Adds the SOAP Body element.
    /// </summary>
    /// <param name="requestObject">Object representing the actual request.</param>
    /// <returns>SoapRequestBuilder with the SOAP Body element added.</returns>
    public SoapRequestBuilder<T> AddBody(T requestObject)
    {
        XElement bodyElement = new XElement(
            SoapEnvelopeNamespace + "Body",
            new XAttribute(WSSecurityUtilityNamespace + "Id", $"Body-{RequestId}"));

        XElement bodyObject = requestObject.Serialize();

        if (Attribute.GetCustomAttribute(requestObject.GetType(), typeof(XmlTypeAttribute)) is XmlTypeAttribute xmlTypeAttribute &&
            !string.IsNullOrWhiteSpace(xmlTypeAttribute.Namespace))
        {
            XNamespace bodyNamespace = XNamespace.Get(xmlTypeAttribute.Namespace);
            bodyObject.Name = XName.Get(bodyObject.Name.LocalName, xmlTypeAttribute.Namespace);
            bodyElement.Add(new XAttribute(XNamespace.Xmlns + "ns", bodyNamespace));
        }

        bodyElement.Add(bodyObject);
        Envelope.Add(bodyElement);

        return this;
    }

    /// <summary>
    /// Adds the public key of the certificate that will be used to sign the document.
    /// </summary>
    /// <param name="signingCertificate">The certificate that will be used to sign the document with.</param>
    /// <returns>A part of the identifier that identifies the signing certificate element.</returns>
    public SoapRequestBuilder<T> AddBinarySecurityToken(X509Certificate2 signingCertificate)
    {
        if (Security is null)
        {
            AddSecurityElement();
        }

        Security.Add(new XElement(
            WSSecuritySecExtNamespace + "BinarySecurityToken",
            new XAttribute(WSSecurityUtilityNamespace + "Id", $"SecurityToken-{RequestId}"),
            new XAttribute("ValueType", ValueType),
            new XAttribute("EncodingType", EncodingType),
            Convert.ToBase64String(signingCertificate.GetRawCertData())));

        return this;
    }

    /// <summary>
    /// Adds a Timestamp element to the header element.
    /// </summary>
    /// <returns>SoapRequestBuilder with timestamp for UtcNow added to header.</returns>
    public SoapRequestBuilder<T> AddTimeStamp()
    {
        return AddTimeStamp(DateTime.UtcNow);
    }

    /// <summary>
    /// Adds a Timestamp element to the header element.
    /// </summary>
    /// <param name="dt">The timestamp to add to header.</param>
    /// <returns>SoapRequestBuilder with supplied dt timestamp added to header.</returns>
    public SoapRequestBuilder<T> AddTimeStamp(DateTime dt)
    {
        if (Security is null)
        {
            AddSecurityElement();
        }

        string created = dt.ToSoapString();
        string expires = dt.AddMinutes(5).ToSoapString();

        Security.Add(new XElement(
            WSSecurityUtilityNamespace + "Timestamp",
            new XAttribute(WSSecurityUtilityNamespace + "Id", $"Timestamp-{RequestId}"),
            new XElement(WSSecurityUtilityNamespace + "Created", created),
            new XElement(WSSecurityUtilityNamespace + "Expires", expires)));

        return this;
    }

    /// <summary>
    /// Adds a 'Security' element to the SOAP Header element.
    /// </summary>
    /// <returns>SoapRequestBuilder with a security element added to header.</returns>
    private SoapRequestBuilder<T> AddSecurityElement()
    {
        Header.Add(
            new XElement(
                WSSecuritySecExtNamespace + "Security",
                new XAttribute(new XAttribute(SoapEnvelopeNamespace + "mustUnderstand", "1")),
                new XAttribute(XNamespace.Xmlns + WsSecuritySecExt, WSSecuritySecExtNamespace)));

        return this;
    }

    /// <summary>
    /// Add MessageId and Action to a WS-Addressing header element.
    /// </summary>
    /// <param name="action">Url to action to perform.</param>
    /// <returns>SoapRequestBuilder with a WS-Addressing element with MessageID and Action set, added to the header.</returns>
    public SoapRequestBuilder<T> AddWSAActionAndMessageId(string action)
    {
        if (Header.GetNamespaceOfPrefix(WSAdressing) is null)
        {
            Header.Add(new XAttribute(XNamespace.Xmlns + WSAdressing, WSAdressingNamespace));
        }

        XElement actionElemeent = new(
            WSAdressingNamespace + "Action",
            action,
            new XAttribute(SoapEnvelopeNamespace + "mustUnderstand", "1"),
            new XAttribute(WSSecurityUtilityNamespace + "Id", $"Action-{RequestId}"));

        XElement messageIdElement = new(
            WSAdressingNamespace + "MessageID",
            $"{RequestId}",
            new XAttribute(SoapEnvelopeNamespace + "mustUnderstand", "1"),
            new XAttribute(WSSecurityUtilityNamespace + "Id", $"MessageId-{RequestId}"));

        Header.Add(actionElemeent, messageIdElement);

        return this;
    }

    /// <summary>
    /// Add ProviderSystemId element to header, required by STIL BPI services.
    /// </summary>
    /// <param name="systemId">Provider systemId.</param>
    /// <returns>SoapRequestBuilder with BPI systemId added to the header.</returns>
    public SoapRequestBuilder<T> AddBPISystemId(string systemId)
    {
        Envelope.Add(new XAttribute(XNamespace.Xmlns + BPI, BPINamespace));

        XElement systemIdElement = new(
            BPINamespace + "UdbydersystemId", systemId,
            new XAttribute(WSSecurityUtilityNamespace + "Id", $"UdbydersystemId-{RequestId}"));

        Header.Add(systemIdElement);

        return this;
    }
}