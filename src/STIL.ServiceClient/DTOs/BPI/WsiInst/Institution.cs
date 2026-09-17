using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The Institution class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Institution
{
    /// <summary>
    /// Gets or sets the <see cref="instnr"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public string instnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="instnavn"/> value.
    /// </summary>
    [XmlElement(Order=1)]
    public string instnavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="type"/> value.
    /// </summary>
    [XmlElement(Order=2)]
    public string type { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="typenavn"/> value.
    /// </summary>
    [XmlElement(Order=3)]
    public string typenavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="type3"/> value.
    /// </summary>
    [XmlElement(Order=4)]
    public string type3 { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="type3navn"/> value.
    /// </summary>
    [XmlElement(Order=5)]
    public string type3navn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="adresse"/> value.
    /// </summary>
    [XmlElement(Order=6)]
    public string adresse { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="bynavn"/> value.
    /// </summary>
    [XmlElement(Order=7)]
    public string bynavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="postnr"/> value.
    /// </summary>
    [XmlElement(Order=8)]
    public string postnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="telefonnr"/> value.
    /// </summary>
    [XmlElement(Order=9)]
    public string telefonnr { get; set; }


    /// <summary>
    /// Gets or sets the <see cref="faxnr"/> value.
    /// </summary>
    [XmlElement(Order=10)]
    public string faxnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="mailadresse"/> value.
    /// </summary>
    [XmlElement(Order=11)]
    public string mailadresse { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="www"/> value.
    /// </summary>
    [XmlElement(Order=12)]
    public string www { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="hovedinstitutionsnr"/> value.
    /// </summary>
    [XmlElement(Order=13)]
    public string hovedinstitutionsnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="kommunenr"/> value.
    /// </summary>
    [XmlElement(Order=14)]
    public string kommunenr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="kommune"/> value.
    /// </summary>
    [XmlElement(Order=15)]
    public string kommune { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="admkommunenr"/> value.
    /// </summary>
    [XmlElement(Order=16)]
    public string admkommunenr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="admkommune"/> value.
    /// </summary>
    [XmlElement(Order=17)]
    public string admkommune { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="regionsnr"/> value.
    /// </summary>
    [XmlElement(Order=18)]
    public string regionsnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="region"/> value.
    /// </summary>
    [XmlElement(Order=19)]
    public string region { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="enhedsart"/> value.
    /// </summary>
    [XmlElement(Order=20)]
    public string enhedsart { get; set; }
}