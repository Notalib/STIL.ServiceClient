using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using STIL.ServiceClient.ConfigurationProviders;
using STIL.ServiceClient.Util.SoapHelper;

namespace STIL.ServiceClient
{
    /// <inheritdoc />
    public class StilServiceClient : IStilServiceClient
    {
        private readonly X509Certificate2 _clientCertificate;
        private readonly X509Certificate2 _signingCertificate;
        private readonly IRetryPolicyProvider _retryPolicyProvider;
        private readonly IStilUrlGenerator _urlGenerator;
        private HttpClient _stilHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="StilServiceClient" /> class.
        /// </summary>
        /// <param name="baseUrl">The baseUrl for the SOAP services, ex. https://et.integrationsplatformen.dk.</param>
        /// <param name="urlGenerator"></param>
        /// <param name="clientCertificate">The http client certificate.</param>
        /// <param name="signingCertificate">The xml signing certificate.</param>
        public StilServiceClient(IStilUrlGenerator urlGenerator, X509Certificate2 clientCertificate, X509Certificate2 signingCertificate)
            : this(urlGenerator, clientCertificate, signingCertificate, new DefaultRetryPolicyProvider())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StilServiceClient" /> class.
        /// </summary>
        /// <param name="baseUrl">The baseUrl for the SOAP services, ex. https://et.integrationsplatformen.dk.</param>
        /// <param name="urlGenerator"></param>
        /// <param name="clientCertificate">The http client certificate.</param>
        /// <param name="signingCertificate">The xml signing certificate.</param>
        /// <param name="retryPolicyProvider">The retry policy provider.</param>
        public StilServiceClient(IStilUrlGenerator urlGenerator, X509Certificate2 clientCertificate, X509Certificate2 signingCertificate, IRetryPolicyProvider retryPolicyProvider)
        {
            _urlGenerator = urlGenerator;
            _clientCertificate = clientCertificate;
            _signingCertificate = signingCertificate;
            _retryPolicyProvider = retryPolicyProvider;

            HttpClientHandler clientHttpHandler = new HttpClientHandler
            {
                ClientCertificates = { _clientCertificate },
            };

            _stilHttpClient = new HttpClient(clientHttpHandler);
        }

        /// <inheritdoc />
        public async Task<TResponse> SendSoapRequest<TRequest, TResponse, TServiceFaultDetailer>(string methodName, TRequest dataRequest, CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class
            where TServiceFaultDetailer : class
        {
            Polly.Retry.AsyncRetryPolicy<HttpResponseMessage> retryHandler = _retryPolicyProvider.GetRetryPolicy();
            SignedStilSoapMessage<TRequest> stilRequest = new SignedStilSoapMessage<TRequest>(dataRequest);

            HttpResponseMessage response = await retryHandler.ExecuteAsync(async () =>
            {
                string signedRequest = stilRequest.GetSignedXml(_signingCertificate);
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Post;
                    request.Content = new StringContent(signedRequest, Encoding.UTF8, "application/soap+xml");
                    request.RequestUri = _urlGenerator.Generate(methodName);
                    return await _stilHttpClient
                               .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                               .ConfigureAwait(false)
                           ?? throw new InvalidOperationException(
                               $"{nameof(_stilHttpClient.SendAsync)} returned null for response type: {typeof(TResponse).Name}.");
                }
            });

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await ReadObjectResponseAsync<TResponse>(response).ConfigureAwait(false)
                           ?? throw new FaultException(
                               $"{nameof(ReadObjectResponseAsync)} returned null for response type: {typeof(TResponse).Name}.");
                }

                throw await GetFaultException<TServiceFaultDetailer>(response);
            }
            finally
            {
                response.Dispose();
            }
        }

        /// <summary>
        /// sets the instance of the <see cref="HttpClient" /> class.
        /// Used for test purposes.
        /// </summary>
        /// <param name="httpClientHandler">The http client.</param>
        public void SetHttpClient(HttpClientHandler httpClientHandler)
        {
            _stilHttpClient = new HttpClient(httpClientHandler);
        }

        /// <summary>
        /// Deserialize response from xml.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>The deserialized response.</returns>
        /// <exception cref="InvalidOperationException">Thrown when document cannot be deserialized.</exception>
        private static async Task<T?> ReadObjectResponseAsync<T>(
            HttpResponseMessage? response)
            where T : class
        {
            if (response?.Content == null)
            {
                return default;
            }

            string responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            XDocument document = XDocument.Parse(responseText);
            string responseTypeName = typeof(T)
                .GetCustomAttributes(typeof(XmlRootAttribute), true)
                .OfType<XmlRootAttribute>()
                .Select(attr => attr.ElementName)
                .FirstOrDefault() ?? typeof(T).Name;

            XElement? body = document.Root?.Descendants().FirstOrDefault(d => d.Name.LocalName == responseTypeName);
            if (body == null)
            {
                throw new InvalidOperationException(
                    $"The response type: {typeof(T).Name} does not match the response name of the xml element.");
            }

            XmlSerializer serializer = new XmlSerializer(
                typeof(T),
                //body.GetNamespaceOfPrefix(Version)?.NamespaceName ??
                body.GetDefaultNamespace().NamespaceName);
            using (XmlReader reader = body.CreateReader())
            {
                return serializer.Deserialize(reader) as T;
            }
        }

        /// <summary>
        /// Gets the fault exception <see cref="FaultException"/>
        /// Returns null if error could not be deserialized.
        /// </summary>
        /// <typeparam name="TServiceFaultDetailer">The type of ServiceFaultDetailer model.</typeparam>
        /// <param name="response">The http response.</param>
        /// <returns>instance of <see cref="FaultException"/>.</returns>
        private static async Task<FaultException> GetFaultException<TServiceFaultDetailer>(
            HttpResponseMessage response)
            where TServiceFaultDetailer : class
        {
            if (response.Content == null)
            {
                return new FaultException(new FaultReason(response.ReasonPhrase), new FaultCode("no content found on error"), response.RequestMessage.RequestUri.AbsoluteUri);
            }

            string responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            using XmlReader xmlReader = XmlReader.Create(new StringReader(responseText));
            Message message = Message.CreateMessage(xmlReader, int.MaxValue, MessageVersion.Soap12WSAddressing10);
            MessageFault msgFault = MessageFault.CreateFault(message, int.MaxValue);

            (TServiceFaultDetailer? serviceFaultDetailer, string? errorMessage) details = GetErrorDetails<TServiceFaultDetailer>(responseText);

            if (details.serviceFaultDetailer != null)
            {
                return new FaultException<TServiceFaultDetailer>(details.serviceFaultDetailer, msgFault.Reason, msgFault.Code, response.RequestMessage?.RequestUri.AbsoluteUri);
            }

            if (details.errorMessage != null)
            {
                return new FaultException(details.errorMessage);
            }

            return new FaultException(msgFault, response.RequestMessage?.RequestUri.AbsoluteUri);
        }

        private static (TServiceFaultDetailer? serviceFaultDetailer, string? errorMessage) GetErrorDetails<TServiceFaultDetailer>(string responseText)
            where TServiceFaultDetailer : class
        {
            XDocument document = XDocument.Parse(responseText);
            XElement? body = document.Root?.Descendants().FirstOrDefault(d => d.Name.LocalName == typeof(TServiceFaultDetailer).Name);
            if (body == null)
            {
                return (null, null);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(TServiceFaultDetailer), body.GetDefaultNamespace().NamespaceName);
            using (XmlReader reader = body.CreateReader())
            {
                return (serializer.Deserialize(reader) as TServiceFaultDetailer, null);
            }
        }
    }
}