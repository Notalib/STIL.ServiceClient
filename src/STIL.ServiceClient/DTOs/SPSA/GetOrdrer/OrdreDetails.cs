using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class OrdreDetails
{
    [XmlElement(IsNullable = true, Order = 0)]
    public string ordrenummer { get; set; }

    [XmlElement(IsNullable = true, Order = 1)]
    public bool? personNavneOgAdresseBeskyttet { get; set; }

    [XmlElement(IsNullable = true, Order = 2)]
    public string personNavn { get; set; }

    [XmlElement(DataType = "date", Order = 3)]
    public DateTime personFoedselsdato { get; set; }

    [XmlElement(IsNullable = true, Order = 4)]
    public string personTlfNr { get; set; }

    [XmlElement(IsNullable = true, Order = 5)]
    public string personEmail { get; set; }

    [XmlElement(DataType = "integer", IsNullable = true, Order = 6)]
    public string uddStedNr { get; set; }

    [XmlElement(IsNullable = true, Order = 7)]
    public string uddStedNavn { get; set; }

    [XmlElement(IsNullable = true, Order = 8)]
    public string leveringVejNavn { get; set; }

    [XmlElement(IsNullable = true, Order = 9)]
    public string leveringPostNr { get; set; }

    [XmlElement(IsNullable = true, Order = 10)]
    public string leveringPostDistrikt { get; set; }

    [XmlElement(IsNullable = true, Order = 11)]
    public string leveringKontaktNavn { get; set; }

    [XmlElement(IsNullable = true, Order = 12)]
    public string leveringKontaktEmail { get; set; }

    [XmlElement(IsNullable = true, Order = 13)]
    public string leveringKontaktTlfNr { get; set; }

    [XmlElement(IsNullable = true, Order = 14)]
    public string fakturerVejNavn { get; set; }

    [XmlElement(IsNullable = true, Order = 15)]
    public string fakturerPostNr { get; set; }

    [XmlElement(IsNullable = true, Order = 16)]
    public string fakturerPostDistrikt { get; set; }

    [XmlElement(IsNullable = true, Order = 17)]
    public string fakturerKontaktNavn { get; set; }

    [XmlElement(IsNullable = true, Order = 18)]
    public string fakturerKontaktEmail { get; set; }

    [XmlElement(IsNullable = true, Order = 19)]
    public string fakturerKontaktTlfNr { get; set; }

    [XmlElement(IsNullable = true, Order = 20)]
    public string cvrNr { get; set; }

    [XmlElement(IsNullable = true, Order = 21)]
    public string eanNummer { get; set; }

    [XmlElement(IsNullable = true, Order = 22)]
    public string uddOmraade { get; set; }

    [XmlElement(IsNullable = true, Order = 23)]
    public string uddRetning { get; set; }

    [XmlElement(IsNullable = true, Order = 24)]
    public string stoetteForm { get; set; }

    [XmlElement(IsNullable = true, Order = 25)]
    public string kommentar { get; set; }

    [XmlElement(DataType = "integer", IsNullable = true, Order = 26)]
    public string produktId { get; set; }

    [XmlElement(IsNullable = true, Order = 27)]
    public string produkt { get; set; }

    [XmlElement(IsNullable = true, Order = 28)]
    public string status { get; set; }

    [XmlElement(IsNullable = true, Order = 29)]
    public DateTime? stoetteStart { get; set; }

    [XmlElement(IsNullable = true, Order = 30)]
    public DateTime? stoetteSlut { get; set; }

    [XmlElement(DataType = "integer", Order = 31)]
    public string enheder { get; set; }

    [XmlElement(Order = 32)]
    public double enhedspris { get; set; }

    [XmlElement(Order = 33)]
    public DateTime oprettetTms { get; set; }

    [XmlElement(Order = 34)]
    public DateTime senestOpdatTms { get; set; }
}
