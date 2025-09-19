using G.bds.Interfaces;
using System.Data;

namespace G.bds.Schemes;
public class Schedule
{
    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlElement("Description")]
    public string Description { get; set; }

    [XmlArray("IfcClasses")]
    [XmlArrayItem("IfcClass", typeof(string))]
    public string[] IfcClasses { get; set; }

    private IField[] _field;
    [XmlArray("Fields")]
    [XmlArrayItem(nameof(AttributeField), typeof(AttributeField))]
    [XmlArrayItem(nameof(PropertyField), typeof(PropertyField))]
    public object[] Field
    {
        get => _field;
        set
        {
            // Validate if the object implements IFilter
            if (value != null && value.All(item => item is IField))
                _field = value.Cast<IField>().ToArray();
            else
                throw new ArgumentException("Configuration must implement IField.");
        }
    }

    [XmlArray("Filters")]
    [XmlArrayItem("Condition")]
    public Filter[]? Filters { get; set; }
    public bool ShouldSerializeFilters() => Filters != null && Filters.Any();

    [XmlArray("Sort")]
    [XmlArrayItem("Condition")]
    public Sort[]? Sort { get; set; }
    public bool ShouldSerializeSort() => Sort != null && Sort.Any();

    [XmlArray("Group")]
    [XmlArrayItem("FieldId")]
    public string[] Group { get; set; }
    public bool ShouldSerializeGroup() => Group != null && Group.Any();
    public Schedule()
    { }

    public Schedule(string name, string description, string[] ifcClasses, object[] field, Filter[]? filters, Sort[]? sort, string[] group)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
        }
        Name = name;
        Description = description;
        IfcClasses = ifcClasses;
        Field = field;
        Filters = filters;
        Sort = sort;
        Group = group;
    }
}