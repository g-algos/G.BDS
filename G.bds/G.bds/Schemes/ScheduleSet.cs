namespace G.bds.Schemes;
public class ScheduleSet
{
    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlElement("Description")]
    public string? Description { get; set; }
    public bool ShouldSerializeDescription() => Description != null && Description.Any();

    [XmlElement("Discipline")]
    public string? Discipline { get; set; }
    public bool ShouldSerializeDiscipline() => Discipline != null && Discipline.Any();

    [XmlArray("Schedules")]
    [XmlArrayItem("Schedule")]
    public Schedule[]? Schedules { get; set; }

    public ScheduleSet(string name, string? description,string? discipline, Schedule[]? schedules)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
        }
        Name = name;
        Description = description;
        Discipline = discipline;
        Schedules = schedules;
    }

    public ScheduleSet()
    { }
}