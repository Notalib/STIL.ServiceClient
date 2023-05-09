using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Moq;
using Moq.Protected;
using STIL.Entities.Entities.VEU.HentTilmeldingerVeuInteressenter;
using STIL.Entities.Entities.VEU.HentUdbud;
using STIL.ServiceClient.Tests.Extensions;

namespace STIL.ServiceClient.Tests
{
    public class StilVeuTests
    {
        ////[Fact(Skip = "Only relevant when live testing locally")]
        [Fact]
        [Trait("Category", "Integration")]
        public async Task Get_HentTilmeldingerVeuInteressenter_ReturnsCorrectResult()
        {
            var request = new HentTilmeldingerRequest
            {
                Identifier = new Entities.Entities.VEU.HentTilmeldingerVeuInteressenter.Identifier
                {
                    SystemName = "MGL3010",
                    SystemTransactionID = Guid.NewGuid().ToString()
                },
                Message = new HentTilmeldingerRequestMessage
                {
                    hentTilmeldinger = new hentTilmeldinger
                    {
                        wsSyncReqModtagerV2 = new wsSyncReqModtagerV2
                        {
                            ModtagerSystemID = "MGL3010",
                            ModtagerSystemTransaktionsID = Guid.NewGuid().ToString()
                        },
                        Besked = new hentTilmeldingerRequest
                        {
                            Indhold = new hentTilmeldingerReqIndhold
                            {
                                FraDato = new DateTime(2022, 01, 01),
                                TilDato = new DateTime(2022, 02, 15),
                                InstNr = "A00827",
                                CVRnr = "0",
                                CPRnummerListe = new[] { "0101198000", "0101198001", "0101198002", "0101198003", "0101198004", "0101198005", "0101198006", "0101198007", "0101198008", "0101198009" }
                            }
                        }
                    }
                }
            };

            // Retrieve certificate locally.
            var thumbprint = "87BA4C291BBBCDBC118723EFBE05C8785D1A5C32";
            var certStore = new X509Store(StoreLocation.CurrentUser);
            certStore.Open(OpenFlags.ReadOnly);
            X509Certificate2? certificate = certStore.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: false).FirstOrDefault();
            var baseUrl = "https://et.integrationsplatformen.dk";
            var stilServiceClient = new StilServiceClient(baseUrl, certificate);

            var result = await stilServiceClient.VEU.HentTilmeldingerVeuInteressenter(request);

            result.Should().NotBeNull();

            result.Message.hentTilmeldingerResponse.Resultat.Resultat.PersonListe.Length.Should().Be(10);
        }

        ////[Fact(Skip = "Only relevant when live testing locally")]
        [Fact]
        [Trait("Category", "Integration")]
        public async Task Get_HentUdbud_ReturnsCorrectResult()
        {
            var request = new HentUdbudRequest()
            {
                Identifier = new Entities.Entities.VEU.HentUdbud.Identifier
                {
                    SystemName = "MGL3010",
                    SystemTransactionID = Guid.NewGuid().ToString()
                },
                Message = new HentUdbudRequestMessage()
                {
                    HentUdbudRequest = new HentUdbudRequest1()
                    {
                        Indhold = new IndholdRequestType()
                        {
                            DsNummerListe = new []{"123"}
                        },
                        Modtager = new ModtagerType()
                        {
                            ModtagerSystemId = "MGL3010",
                            ModtagerSystemTransaktionsID = Guid.NewGuid().ToString(),
                        }
                    }
                }
            };
             
            // Retrieve certificate locally.
            var baseUrl = "https://et.integrationsplatformen.dk";
            IStilServiceClient stilServiceClient = new StilServiceClient(baseUrl, GetCertificate());

            var request2 = new HentUdbudRequest();
            
            var result = await stilServiceClient.VEU.HentUdbud(request2);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task HentTilmeldingerVeuInteressenter_ShouldReturnExpectedResult()
        {
            // Arrange
            var sut = UtilMethods.CreateStilServiceClientMock("hentTilmeldingerResponse.xml");
            // Act
            var request = new HentTilmeldingerRequest();

            var response = await sut.VEU.HentTilmeldingerVeuInteressenter(request);

            // Assert
            response.Should().NotBeNull();
            response.Message.hentTilmeldingerResponse.Resultat.Resultat.PersonListe.Length.Should().Be(10);
        }

        public static X509Certificate2 GetCertificate()
        {
            // Retrieve certificate locally.
            var thumbprint = "87BA4C291BBBCDBC118723EFBE05C8785D1A5C32";
            var certStore = new X509Store(StoreLocation.CurrentUser);
            certStore.Open(OpenFlags.ReadOnly);
            return certStore.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: false).FirstOrDefault();
            
        }
    }


}