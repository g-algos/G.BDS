using G.bds.Helpers;

namespace G.bds.Schemes;
public class Filter
{
    [XmlElement("Field")]
    public string FieldId { get; set; }

    [XmlElement("Operator")]
    public ComparisonOperator Operator { get; set; }

    [XmlElement("Value")]
    public object Value { get; set; }
}
