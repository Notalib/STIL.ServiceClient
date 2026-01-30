using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Institution
{
    [XmlElement(Order=0)]
    public string instnr { get; set; }

    [XmlElement(Order=1)]
    public string instnavn { get; set; }

    [XmlElement(Order=2)]
    public string type { get; set; }

    [XmlElement(Order=3)]
    public string typenavn { get; set; }

    [XmlElement(Order=4)]
    public string type3 { get; set; }

    [XmlElement(Order=5)]
    public string type3navn { get; set; }

    [XmlElement(Order=6)]
    public string adresse { get; set; }

    [XmlElement(Order=7)]
    public string bynavn { get; set; }

    [XmlElement(Order=8)]
    public string postnr { get; set; }

    [XmlElement(Order=9)]
    public string telefonnr { get; set; }


    [XmlElement(Order=10)]
    public string faxnr { get; set; }

    [XmlElement(Order=11)]
    public string mailadresse { get; set; }

    [XmlElement(Order=12)]
    public string www { get; set; }

    [XmlElement(Order=13)]
    public string hovedinstitutionsnr { get; set; }

    [XmlElement(Order=14)]
    public string kommunenr { get; set; }

    [XmlElement(Order=15)]
    public string kommune { get; set; }

    [XmlElement(Order=16)]
    public string admkommunenr { get; set; }

    [XmlElement(Order=17)]
    public string admkommune { get; set; }

    [XmlElement(Order=18)]
    public string regionsnr { get; set; }

    [XmlElement(Order=19)]
    public string region { get; set; }

    [XmlElement(Order=20)]
    public string enhedsart { get; set; }
}