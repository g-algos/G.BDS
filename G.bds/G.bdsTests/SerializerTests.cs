using G.bds.Helpers;
using G.bds.Schemes;
using System.Reflection;

namespace G.bds.Tests;

[TestClass()]
public class SerializerTests
{
    private static readonly BDS _bds = new BDS(
                name: "TestSchedulePackage",
                description: "Sample BDS schedule structure",
                fileVersion: "1.0",
                schedules: new[]
                {
                    new ScheduleSet(
                        name: "Architecture Set",
                        description: "Walls and doors",
                        discipline: "Architecture",
                        schedules: new[]
                        {
                            new Schedule(
                                name: "Wall Quantities",
                                description: "Quantities per wall type",
                                ifcClasses: new[] { "IfcWall", "IfcWallStandardCase" },
                                field: new object[]
                                {
                                    new AttributeField
                                    {
                                        Name = "Length",
                                        Formula = "*2"
                                    },
                                    new PropertyField
                                    {
                                        PropertySetName = "Pset_WallCommon",
                                        Name = "IsExternal",
                                        Formula = null
                                    }
                                },
                                filters: new[]
                                {
                                    new Filter
                                    {
                                        FieldId = "Length",
                                        Operator = ComparisonOperator.GreaterThan,
                                        Value = 5
                                    }
                                },
                                sort: new[]
                                {
                                    new Sort
                                    {
                                        FieldId = "Length",
                                        Order = Order.Descending
                                    }
                                },
                                group: new[] { "IsExternal" }
                            )
                        }
                    )
                },
                responsibleParty: "AEC Department");
    
    [TestMethod()]
    public void SerializeTest()
    {

        var result = Serializer.Serialize(_bds);
        Console.Write(result);
        Assert.IsNotNull(result);
    }

    private string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    [TestMethod()]
    public void SaveTest()
    {
        
        Serializer.Save(_bds, directory!, "test");
        Assert.IsTrue(File.Exists(Path.Combine(directory!, $"test.bds")));
    }

    [TestMethod()]
    public void DeserializeTest()
    {
        string crsXml = "<BDS>...</BDS>"; // A sample BDS XML string

        // Act
        var result = Serializer.Deserialize(Path.Combine(directory!, $"test.bds"));

        // Assert
        Assert.IsNotNull(result);
    }
}