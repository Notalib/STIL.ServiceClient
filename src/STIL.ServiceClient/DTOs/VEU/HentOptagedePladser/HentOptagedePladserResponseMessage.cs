namespace STIL.ServiceClient.DTOs.VEU.HentOptagedePladser
{
    /// <summary>
    /// HentOptagedePladserResponseMessage.
    /// </summary>
    [System.SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/veu/hentoptagedepladser/v1")]
    public class HentOptagedePladserResponseMessage
    {
        /// <summary>
        /// The hent optagede pladser response field.
        /// </summary>
        private HentOptagedePladserResponse1 hentOptagedePladserResponseField;

        /// <summary>
        /// Gets or sets the <see cref="HentOptagedePladserResponse"/> value.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.veu.stil.dk/hentudbud/webservice/hentoptagedepladser", Order = 0)]
        public HentOptagedePladserResponse1 HentOptagedePladserResponse
        {
            get => hentOptagedePladserResponseField;
            set => hentOptagedePladserResponseField = value;
        }
    }
}