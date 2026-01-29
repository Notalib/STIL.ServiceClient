using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <remarks/>
[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
[DebuggerStepThrough]
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class Gruppe
{
    [XmlElement(DataType="token", Order=0)]
    public string instnr { get; set; }

    [XmlElement(Order=1)]
    public string gruppeid { get; set; }

    [XmlElement(Order=2)]
    public string gruppenavn { get; set; }

    [XmlElement(Order=3)]
    public Gruppetype gruppetype { get; set; }

    [XmlElement(Order=4)]
    public trin gruppetrin { get; set; }

    [XmlIgnore]
    public bool gruppetrinSpecified { get; set; }

    [XmlElement(DataType="date", Order=5)]
    public DateTime fradato { get; set; }

    [XmlIgnore]
    public bool fradatoSpecified { get; set; }

    [XmlElement(DataType="date", Order=6)]
    public DateTime tildato { get; set; }

    [XmlIgnore]
    public bool tildatoSpecified { get; set; }
}