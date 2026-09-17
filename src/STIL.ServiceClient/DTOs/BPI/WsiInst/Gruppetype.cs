using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The Gruppetype enum.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public enum Gruppetype
{
    /// <summary>
    /// The Hovedgruppe value.
    /// </summary>
    Hovedgruppe,

    /// <summary>
    /// The Årgang value.
    /// </summary>
    Årgang,

    /// <summary>
    /// The Retning value.
    /// </summary>
    Retning,

    /// <summary>
    /// The Hold value.
    /// </summary>
    Hold,

    /// <summary>
    /// The SFO value.
    /// </summary>
    SFO,

    /// <summary>
    /// The Team value.
    /// </summary>
    Team,

    /// <summary>
    /// The Institution value.
    /// </summary>
    Institution,

    /// <summary>
    /// The Andet value.
    /// </summary>
    Andet,
}