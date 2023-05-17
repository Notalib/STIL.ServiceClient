﻿using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace STIL.ServiceClient.Tests.Util;

/// <summary>
/// Utility helper class for common helper methods.
/// </summary>
public static class TestHelper
{
    /// <summary>
    /// Creates a self signed certificate used for testing.
    /// </summary>
    /// <param name="subjectName">The subject name.</param>
    /// <param name="validFrom">Valid from date.</param>
    /// <param name="validTo">Validt to date.</param>
    /// <returns></returns>
    public static X509Certificate2 CreateSelfSignedCertificate(string subjectName, DateTime validFrom, DateTime validTo)
    {
        // Create a new RSA key pair
        using var rsa = RSA.Create(2048);

        // Create a certificate request with the subject name and public key
        var request = new CertificateRequest($"CN={subjectName}", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        request.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.DigitalSignature, false));
        request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }, false));
        request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

        var certificate = request.CreateSelfSigned(validFrom, validTo);

        return new X509Certificate2(certificate.Export(X509ContentType.Pfx), (string?)null, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
    }

    /// <summary>
    /// Gets content from embedded file located in the samples folder.
    /// </summary>
    /// <param name="fileName">Name of the file. Ex. reponse.xml.</param>
    /// <returns>The string content of the embedded file.</returns>
    public static string GetXmlContentFromFile(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        string fullFileName = $"{assembly.GetName().Name}.Samples.{fileName}" ?? throw new ArgumentNullException($"Filename {fileName} could not be found.");

        using (Stream? stream = assembly.GetManifestResourceStream(fullFileName) ?? throw new NullReferenceException($"No content found in file: {fileName} or file was not set as embedded resource."))
        {
            // Read the XML file from the stream
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}