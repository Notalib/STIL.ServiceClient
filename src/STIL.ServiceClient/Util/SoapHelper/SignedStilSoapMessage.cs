﻿using System.Security.Cryptography.X509Certificates;

namespace STIL.ServiceClient.Util.SoapHelper
{
    /// <summary>
    /// Represents a Soap request for STIL (Styrelsen for IT og Læring).
    /// </summary>
    /// <typeparam name="T">The type of the Soap body content.</typeparam>
    public class SignedStilSoapMessage<T>
    {
        private readonly T _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignedStilSoapMessage{T}"/> class.
        /// </summary>
        /// <param name="data">The contents of the soap body.</param>
        public SignedStilSoapMessage(T data)
        {
            _data = data;
        }

        /// <summary>
        /// Gets a signed SOAP message as a string.
        /// </summary>
        /// <param name="signingCertificate">The certificate used to sign the document.</param>
        /// <remarks>WARNING: Do not reformat the returned XML, as changes to the whitespace will invalidate the signature.</remarks>
        /// <returns>The signed xml string.</returns>
        public string GetSignedXml(X509Certificate2 signingCertificate)
        {
            SoapBuilder<T> builder = new SoapBuilder<T>(_data);
            System.Xml.Linq.XDocument unsignedSoapMessage = builder.BuildUnsignedSoapMessage(signingCertificate);
            SoapSigner signer = new SoapSigner(unsignedSoapMessage, signingCertificate, builder.TokenId);
            string signedDocument = signer.GetSignedXml();

            return signedDocument;
        }
    }
}