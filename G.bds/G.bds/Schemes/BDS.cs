using System.Reflection;

namespace G.bds.Schemes;

[XmlRoot("BDS")]
public class BDS
{
    private string _version;

    [XmlAttribute("Version")]
    public string Version
    {
        get => _version;
        set
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version!;
            _version = $"{v.Major}.{v.Minor}";
        }
    }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlElement("Description")]
    public string Description { get; set; }


    [XmlElement("FileVersion")]
    public string FileVersion { get; set; }


    [XmlArray("ScheduleSets")]
    [XmlArrayItem("Set", typeof(ScheduleSet))]
    public ScheduleSet[] Schedules { get; set; }

    [XmlElement("ResponsibleParty")]
    public string? ResponsibleParty { get; set; }

    public BDS(string name, string description, string fileVersion, ScheduleSet[] schedules, string? responsibleParty)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
        }
        Name = name;
        Description = description;
        FileVersion = fileVersion;
        Schedules = schedules;
        ResponsibleParty = responsibleParty;
    }

    public BDS()
    { }
}
