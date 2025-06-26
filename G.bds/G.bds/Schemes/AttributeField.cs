using G.bds.Interfaces;

namespace G.bds.Schemes;
public class AttributeField : IField
{
    [XmlAttribute("Id")]
    public string Id { get; set; }

    [XmlElement("Attribute")]
    public string Name { get; set; }

    [XmlElement("Formula")]
    public string? Formula { get; set; }

    public AttributeField()
    {
        Id = Guid.NewGuid().ToString("N")[..8];
    }

}
