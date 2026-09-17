using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
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

namespace STIL.ServiceClient
{
    /// <inheritdoc />
    public class SoapServiceClient : ISoapServiceClient, IDisposable
    {
        private readonly IRetryPolicyProvider _retryPolicyProvider;

        private bool _ownsHttpClient;
        private HttpClient _soapHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoapServiceClient" /> class.
        /// </summary>
        /// <param name="preconfiguredClient">A preconfigured HttpClient.</param>
        public SoapServiceClient(HttpClient preconfiguredClient)
            : this(preconfiguredClient, new DefaultRetryPolicyProvider())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SoapServiceClient" /> class.
        /// </summary>
        /// <param name="preconfiguredClient">A preconfigured HttpClient.</param>
        /// <param name="retryPolicyProvider">The retry policy provider.</param>
        public SoapServiceClient(HttpClient preconfiguredClient, IRetryPolicyProvider retryPolicyProvider)
        {
            _soapHttpClient = preconfiguredClient;
            _retryPolicyProvider = retryPolicyProvider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SoapServiceClient" /> class.
        /// </summary>
        /// <param name="clientCertificate">The http client certificate.</param>
        /// <param name="signingCertificate">The XML signing certificate.</param>
        public SoapServiceClient(X509Certificate2 clientCertificate)
            : this(clientCertificate, new DefaultRetryPolicyProvider())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SoapServiceClient" /> class.
        /// </summary>
        /// <param name="clientCertificate">The http client certificate.</param>
        /// <param name="signingCertificate">The XML signing certificate.</param>
        /// <param name="retryPolicyProvider">The retry policy provider.</param>
        public SoapServiceClient(X509Certificate2 clientCertificate, IRetryPolicyProvider retryPolicyProvider)
        {
            _retryPolicyProvider = retryPolicyProvider;

            HttpClientHandler clientHttpHandler = new HttpClientHandler
            {
                ClientCertificates = { clientCertificate },
            };

            _ownsHttpClient = true;
            _soapHttpClient = new HttpClient(clientHttpHandler);
        }

        /// <inheritdoc />
        public async Task<TResponse> SendSoapRequest<TResponse, TServiceFaultDetailer>(Uri requestUri, string requestXml, CancellationToken cancellationToken = default)
            where TResponse : class
            where TServiceFaultDetailer : class
        {
            Polly.Retry.AsyncRetryPolicy<HttpResponseMessage> retryHandler = _retryPolicyProvider.GetRetryPolicy();

            HttpResponseMessage response = await retryHandler.ExecuteAsync(async () =>
            {
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Post;
                    request.Content = new StringContent(requestXml, Encoding.UTF8, MediaTypeNames.Application.Soap);
                    request.RequestUri = requestUri;

                    return await _soapHttpClient
                               .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                               .ConfigureAwait(false)
                           ?? throw new InvalidOperationException(
                               $"{nameof(_soapHttpClient.SendAsync)} returned null for response type: {typeof(TResponse).Name}.");
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

            string nameSpace = body.Name.NamespaceName;
            XmlSerializer serializer = new XmlSerializer(
                typeof(T),
                nameSpace);

            using (XmlReader reader = body.CreateReader())
            {
                reader.MoveToContent();
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
            if (response.Content is null)
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

        /// <summary>
        /// Disposes the underlying <see cref="HttpClient"/>, if it is owned by this instance.
        /// </summary>
        public void Dispose()
        {
            if (_ownsHttpClient)
            {
                _soapHttpClient.Dispose();
            }
        }
    }
}
