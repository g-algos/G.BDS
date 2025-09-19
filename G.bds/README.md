# G.BDS — Building Data Share Library

**G.BDS** is a lightweight .NET library that facilitates the creation, management, and validation of **BDS (Building Data Share)** files.  
It provides tools for defining and sharing standardized data schedule templates that can be used to extract **structured tables** from IFC models.

BDS enables project teams to **standardize schedules and reports**, ensuring consistency and improving collaboration across different software platforms and disciplines.

---

## What is BDS?

**Building Data Share (BDS)** is an **open-source, XML-based schema** for defining reusable data schedules in building projects.  
It ensures everyone in a project team uses the **same definitions for schedules and reports**, bridging gaps between different BIM software.

BDS builds on **IFC (Industry Foundation Classes)** — the open global standard for building data — so it is compatible with **any IFC-compliant model**.

**Example workflow:**
- An AEC team (architects, engineers, contractors, etc.) creates a **BDS template** to define:
  - Which **IFC classes** (e.g., `IfcWall`, `IfcDoor`, `IfcSpace`) to target.
  - Which **attributes or property values** to include.
  - Filters, sorting, and output structure.
- The BDS file is **shared** across teams or projects.
- Any IFC-reading software can then **extract standardized schedules** directly from the model.

---

## Key Features

- **Interdisciplinary scope**  
  Supports all AEC disciplines by leveraging IFC model classes.  
  Any software that can read IFC can also use BDS templates for data extraction.

- **Template sharing**  
  Define schedules **once** and reuse them.  
  Distribute BDS files to ensure every stakeholder uses the same rules for data extraction.

- **Standardized outputs**  
  Generate **consistent, structured tables** with predefined columns and filters.  
  Perfect for multi-project reporting and comparison.

---

## Schema Reference

The official BDS schema file is available here:  
[`g-algos/standards/bds.1.0.xsd`](https://github.com/g-algos/standards/bds.1.0.xsd)

Include this schema in your BDS XML files for validation:

```xml
<?xml version="1.0" encoding="utf-8"?>
<BDS xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
     xsi:noNamespaceSchemaLocation="bds.1.0.xsd">
  <!-- Your schedule definitions here -->
</BDS>
```
___

## Installation

Install the package via NuGet :   
```bash
dotnet add package G.bds
```
Or add it directly to your .csproj file:
```xml
<PackageReference Include="G.bds" Version="1.0.0" 
```
## Usage Example

Here’s a simple example of loading and validating a BDS file:

```csharp
using G.Bds;
using System.Xml.Serialization;
using System.IO;

// Load a BDS file
var filePath =""; // Your file
var bds = Serializer.Deserialize(filePath);

// Access schedules
foreach (var set in bds.Schedules)
{
    Console.WriteLine($"Schedule Set: {set.Name}");
    foreach( var schedule in set.Schedules)
    {
        Console.WriteLine($"Schedule: {schedule.Name}");
    }
    Console.WriteLine($"");
}
```
## License

This project is licensed under the Apache License 2.0.
See the LICENSE file for more details.

## Repository & Contributions

Repository URL: https://github.com/g-algos/G.BDS
Contributions are welcome!
Please open issues or submit pull requests to help improve the BDS ecosystem.

## Why BDS?

BDS is designed for teams that need clarity and consistency when extracting data from BIM models.
By standardizing schedule templates, you ensure repeatable, reliable outputs, eliminating confusion between different software tools or manual reporting workflows.


