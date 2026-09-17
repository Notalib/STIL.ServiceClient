using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <remarks/>
[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
[DebuggerStepThrough]
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class Gruppe
{
    /// <summary>
    /// Gets or sets the <see cref="instnr"/> value.
    /// </summary>
    [XmlElement(DataType="token", Order=0)]
    public string instnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="gruppeid"/> value.
    /// </summary>
    [XmlElement(Order=1)]
    public string gruppeid { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="gruppenavn"/> value.
    /// </summary>
    [XmlElement(Order=2)]
    public string gruppenavn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="gruppetype"/> value.
    /// </summary>
    [XmlElement(Order=3)]
    public Gruppetype gruppetype { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="gruppetrin"/> value.
    /// </summary>
    [XmlElement(Order=4)]
    public trin gruppetrin { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the <see cref="gruppetrin"/> property should be serialized.
    /// </summary>
    [XmlIgnore]
    public bool gruppetrinSpecified { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="fradato"/> value.
    /// </summary>
    [XmlElement(DataType="date", Order=5)]
    public DateTime fradato { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the <see cref="fradato"/> property should be serialized.
    /// </summary>
    [XmlIgnore]
    public bool fradatoSpecified { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="tildato"/> value.
    /// </summary>
    [XmlElement(DataType="date", Order=6)]
    public DateTime tildato { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the <see cref="tildato"/> property should be serialized.
    /// </summary>
    [XmlIgnore]
    public bool tildatoSpecified { get; set; }
}