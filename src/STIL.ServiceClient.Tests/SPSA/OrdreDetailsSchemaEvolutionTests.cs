using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using STIL.ServiceClient.DTOs.SPSA.GetOrdrer;
using Xunit;

namespace STIL.ServiceClient.Tests.SPSA;

/// <summary>
/// STIL added funktionsnedsaettelse, uddannelsesStartdato and uddannelsesSlutdato to the end of the
/// OrdreDetails xs:sequence. These tests confirm the client handles both directions of that schema
/// change safely: a server that now sends the new trailing elements, and a server that has not been
/// upgraded yet and omits them.
/// </summary>
public class OrdreDetailsSchemaEvolutionTests
{
    private const string Namespace = "http://stil.dk/spsa/ordreservice/v1.0";

    private static OrdreDetails Deserialize(string xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(OrdreDetails), Namespace);
        using StringReader stringReader = new StringReader(xml);
        using XmlReader reader = XmlReader.Create(stringReader);
        return serializer.Deserialize(reader) as OrdreDetails;
    }

    [Fact]
    public void Deserialise_NewServerResponse_WithTrailingFields_PopulatesAllFields()
    {
        string xml = $@"<OrdreDetails xmlns=""{Namespace}"">
            <ordrenummer>12345</ordrenummer>
            <personNavneOgAdresseBeskyttet>false</personNavneOgAdresseBeskyttet>
            <personNavn>Test Testesen</personNavn>
            <personFoedselsdato>2000-01-01</personFoedselsdato>
            <uddStedNr>12345</uddStedNr>
            <uddStedNavn>Skole</uddStedNavn>
            <uddOmraade>Omraade</uddOmraade>
            <uddRetning>Retning</uddRetning>
            <stoetteForm>Form</stoetteForm>
            <produktId>1</produktId>
            <produkt>Produkt</produkt>
            <status>Status</status>
            <enheder>10</enheder>
            <enhedspris>100.5</enhedspris>
            <oprettetTms>2024-01-01T00:00:00</oprettetTms>
            <senestOpdatTms>2024-01-01T00:00:00</senestOpdatTms>
            <funktionsnedsaettelse>Nedsat syn</funktionsnedsaettelse>
            <uddannelsesStartdato>2024-08-01T00:00:00</uddannelsesStartdato>
            <uddannelsesSlutdato>2026-06-30T00:00:00</uddannelsesSlutdato>
        </OrdreDetails>";

        OrdreDetails result = Deserialize(xml);

        Assert.NotNull(result);
        Assert.Equal("Produkt", result.produkt);
        Assert.Equal("Nedsat syn", result.funktionsnedsaettelse);
        Assert.Equal(new DateTime(2024, 8, 1), result.uddannelsesStartdato);
        Assert.Equal(new DateTime(2026, 6, 30), result.uddannelsesSlutdato);
    }

    [Fact]
    public void Deserialise_OldServerResponse_WithoutNewFields_StillPopulatesExistingFields()
    {
        string xml = $@"<OrdreDetails xmlns=""{Namespace}"">
            <ordrenummer>12345</ordrenummer>
            <personNavneOgAdresseBeskyttet>false</personNavneOgAdresseBeskyttet>
            <personNavn>Test Testesen</personNavn>
            <personFoedselsdato>2000-01-01</personFoedselsdato>
            <uddStedNr>12345</uddStedNr>
            <uddStedNavn>Skole</uddStedNavn>
            <uddOmraade>Omraade</uddOmraade>
            <uddRetning>Retning</uddRetning>
            <stoetteForm>Form</stoetteForm>
            <produktId>1</produktId>
            <produkt>Produkt</produkt>
            <status>Status</status>
            <enheder>10</enheder>
            <enhedspris>100.5</enhedspris>
            <oprettetTms>2024-01-01T00:00:00</oprettetTms>
            <senestOpdatTms>2024-01-01T00:00:00</senestOpdatTms>
        </OrdreDetails>";

        OrdreDetails result = Deserialize(xml);

        Assert.NotNull(result);
        Assert.Equal("Produkt", result.produkt);
        Assert.Null(result.funktionsnedsaettelse);
    }
}
