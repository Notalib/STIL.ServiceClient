using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Xunit;

namespace STIL.ServiceClient.Tests.SPSA;

/// <summary>
/// Documents a gotcha in this codebase's XML DTOs: nearly every generated type decorates its
/// properties with an explicit <see cref="XmlElementAttribute.Order"/>. That makes
/// <see cref="XmlSerializer"/> deserialize using a strict positional state machine. As long as STIL
/// only ever *appends* new elements to the end of a type's xs:sequence (as it did for the
/// funktionsnedsaettelse/uddannelsesStartdato/uddannelsesSlutdato addition to OrdreDetails), this is
/// harmless - unknown trailing elements are skipped. But if a future schema change ever inserts a new
/// element in the *middle* of a sequence, every already-mapped property declared after that point will
/// silently deserialize to null/default - with no exception. Removing the Order attributes avoids the
/// footgun entirely, at the cost of also controlling write-order.
/// </summary>
public class XmlElementOrderSequencingRiskTests
{
    private const string Namespace = "http://stil.dk/spsa/ordreservice/v1.0";

    [XmlType(AnonymousType = true, Namespace = Namespace)]
    public class WithExplicitOrder
    {
        [XmlElement(IsNullable = true, Order = 0)]
        public string first { get; set; }

        [XmlElement(IsNullable = true, Order = 1)]
        public string second { get; set; }

        [XmlElement(IsNullable = true, Order = 2)]
        public string third { get; set; }
    }

    [XmlType(AnonymousType = true, Namespace = Namespace)]
    public class WithoutExplicitOrder
    {
        [XmlElement(IsNullable = true)]
        public string first { get; set; }

        [XmlElement(IsNullable = true)]
        public string second { get; set; }

        [XmlElement(IsNullable = true)]
        public string third { get; set; }
    }

    private static T Deserialize<T>(string xml)
        where T : class
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T), Namespace);
        using StringReader stringReader = new StringReader(xml);
        using XmlReader reader = XmlReader.Create(stringReader);
        return serializer.Deserialize(reader) as T;
    }

    [Fact]
    public void ExplicitOrder_UnknownElementInsertedMidSequence_DropsSubsequentFields()
    {
        string xml = $@"<WithExplicitOrder xmlns=""{Namespace}"">
            <first>a</first>
            <unknownNewElement>x</unknownNewElement>
            <second>b</second>
            <third>c</third>
        </WithExplicitOrder>";

        WithExplicitOrder result = Deserialize<WithExplicitOrder>(xml);

        Assert.Equal("a", result.first);
        Assert.Null(result.second);
        Assert.Null(result.third);
    }

    [Fact]
    public void NoExplicitOrder_UnknownElementInsertedMidSequence_StillPopulatesSubsequentFields()
    {
        string xml = $@"<WithoutExplicitOrder xmlns=""{Namespace}"">
            <first>a</first>
            <unknownNewElement>x</unknownNewElement>
            <second>b</second>
            <third>c</third>
        </WithoutExplicitOrder>";

        WithoutExplicitOrder result = Deserialize<WithoutExplicitOrder>(xml);

        Assert.Equal("a", result.first);
        Assert.Equal("b", result.second);
        Assert.Equal("c", result.third);
    }
}
