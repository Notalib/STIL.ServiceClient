using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

/// <summary>
/// The OrdreDetails class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class OrdreDetails
{
    /// <summary>
    /// Gets or sets the <see cref="ordrenummer"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 0)]
    public string ordrenummer { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the person's name and address are protected ("navne- og adressebeskyttet").
    /// </summary>
    [XmlElement(IsNullable = true, Order = 1)]
    public bool? personNavneOgAdresseBeskyttet { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="personNavn"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 2)]
    public string personNavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="personFoedselsdato"/> value.
    /// </summary>
    [XmlElement(DataType = "date", Order = 3)]
    public DateTime personFoedselsdato { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="personTlfNr"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 4)]
    public string personTlfNr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="personEmail"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 5)]
    public string personEmail { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="uddStedNr"/> value.
    /// </summary>
    [XmlElement(DataType = "integer", IsNullable = true, Order = 6)]
    public string uddStedNr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="uddStedNavn"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 7)]
    public string uddStedNavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="leveringVejNavn"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 8)]
    public string leveringVejNavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="leveringPostNr"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 9)]
    public string leveringPostNr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="leveringPostDistrikt"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 10)]
    public string leveringPostDistrikt { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="leveringKontaktNavn"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 11)]
    public string leveringKontaktNavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="leveringKontaktEmail"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 12)]
    public string leveringKontaktEmail { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="leveringKontaktTlfNr"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 13)]
    public string leveringKontaktTlfNr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="fakturerVejNavn"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 14)]
    public string fakturerVejNavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="fakturerPostNr"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 15)]
    public string fakturerPostNr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="fakturerPostDistrikt"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 16)]
    public string fakturerPostDistrikt { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="fakturerKontaktNavn"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 17)]
    public string fakturerKontaktNavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="fakturerKontaktEmail"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 18)]
    public string fakturerKontaktEmail { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="fakturerKontaktTlfNr"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 19)]
    public string fakturerKontaktTlfNr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="cvrNr"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 20)]
    public string cvrNr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="eanNummer"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 21)]
    public string eanNummer { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="uddOmraade"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 22)]
    public string uddOmraade { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="uddRetning"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 23)]
    public string uddRetning { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="stoetteForm"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 24)]
    public string stoetteForm { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="kommentar"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 25)]
    public string kommentar { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="produktId"/> value.
    /// </summary>
    [XmlElement(DataType = "integer", IsNullable = true, Order = 26)]
    public string produktId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="produkt"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 27)]
    public string produkt { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="status"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 28)]
    public string status { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="stoetteStart"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 29)]
    public DateTime? stoetteStart { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="stoetteSlut"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 30)]
    public DateTime? stoetteSlut { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="enheder"/> value.
    /// </summary>
    [XmlElement(DataType = "integer", Order = 31)]
    public string enheder { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="enhedspris"/> value.
    /// </summary>
    [XmlElement(Order = 32)]
    public double enhedspris { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="oprettetTms"/> value.
    /// </summary>
    [XmlElement(Order = 33)]
    public DateTime oprettetTms { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="senestOpdatTms"/> value.
    /// </summary>
    [XmlElement(Order = 34)]
    public DateTime senestOpdatTms { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="funktionsnedsaettelse"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 35)]
    public string funktionsnedsaettelse { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="uddannelsesStartdato"/> value.
    /// </summary>
    [XmlElement(Order = 36)]
    public DateTime uddannelsesStartdato { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="uddannelsesSlutdato"/> value.
    /// </summary>
    [XmlElement(Order = 37)]
    public DateTime uddannelsesSlutdato { get; set; }
}
