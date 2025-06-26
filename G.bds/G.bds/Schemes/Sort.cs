using G.bds.Helpers;

namespace G.bds.Schemes;
public class Sort
{
    [XmlElement("Field")]
    public string FieldId { get; set; }

    [XmlElement("Order")]
    public Order Order { get; set; }
}
