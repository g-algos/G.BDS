using G.bds.Interfaces;

namespace G.bds.Schemes;
public class PropertyField : IField
{
    [XmlAttribute("Id")]
    public string Id { get; set; }

    [XmlElement("PropertySetName")]
    public string PropertySetName { get; set; }

    [XmlElement("PropertyName")]
    public string Name { get; set; }


    [XmlElement("Formula")]
    public string? Formula { get; set; }

    public PropertyField()
    {
        Id = Guid.NewGuid().ToString("N")[..8];
    }
}
