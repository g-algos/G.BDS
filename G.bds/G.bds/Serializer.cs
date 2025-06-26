using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace G.bds;
public static class Serializer
{
    /// <summary>
    /// Serialize BDS object to XML string
    /// </summary>
    /// <param name="bds">The BDS object to serialize</param>
    /// <returns>XML string representation of the BDS object</returns>
    public static string Serialize(Schemes.BDS bds)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(Schemes.BDS));
            using var writer = new StringWriter();
            serializer.Serialize(writer, bds);
            var result = writer.ToString();
            Console.Write(result);
            ValidateXmlAgainstXsd(result);
            return result;
        }
        catch (InvalidOperationException ex)
        {
            // Log or handle serialization specific errors
            throw new InvalidOperationException("Error occurred while serializing the BDS object.", ex);
        }
        catch (Exception ex)
        {
            // Log or handle any unexpected errors
            throw new Exception("An unexpected error occurred during serialization.", ex);
        }
    }

    public static void Save(Schemes.BDS bds, string outputPath, string outputfileName)
    {
        string xmlCrs = Serialize(bds);
        string resultPath = Path.Combine(outputPath, outputfileName, ".crs");
        File.WriteAllText(resultPath, xmlCrs);
    }

    /// <summary>
    /// Deserialize bds string back to BDS object
    /// </summary>
    /// <param name="bds">bds string to deserialize</param>
    /// <returns>Deserialized BDS object</returns>
    public static Schemes.BDS Deserialize(string bds)
    {
        try
        {
            ValidateXmlAgainstXsd(bds);

            var serializer = new XmlSerializer(typeof(Schemes.BDS));
            using var reader = new StringReader(bds);
            return (Schemes.BDS)serializer.Deserialize(reader)!; // Deserialize the XML back to BDS object
        }
        catch (InvalidOperationException ex)
        {
            // Log or handle deserialization specific errors
            throw new InvalidOperationException("Error occurred while deserializing the XML string.", ex);
        }
        catch (Exception ex)
        {
            // Log or handle any unexpected errors
            throw new Exception("An unexpected error occurred during deserialization.", ex);
        }
    }

    private static void ValidateXmlAgainstXsd(string xmlContent)
    {
        string xsdSchemaPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "BDS.1.0.xsd");
        XmlSchemaSet schemaSet = new();
        schemaSet.Add("https://g-algo/standards/schemas/bds.1.0", xsdSchemaPath);

        XmlReaderSettings settings = new();
        settings.Schemas.Add(schemaSet);
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationEventHandler += SettingsValidationEventHandler!;

        using StringReader stringReader = new(xmlContent);
        using XmlReader xmlReader = XmlReader.Create(stringReader, settings);
        while (xmlReader.Read()) { }
    }
    private static void SettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("WARNING: ");
            Console.WriteLine(e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Console.Write("ERROR: ");
            Console.WriteLine(e.Message);
            throw new Exception(e.Message);
        }
    }
}
