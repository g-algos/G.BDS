namespace G.bds.Interfaces;
public class IField
{
    int Id { get; set; }
    string Name { get; set; }
    /// <summary>
    /// Defines the aggregation or transformation formula to apply.
    /// Accepts standard operations like:
    /// "Sum", "Average", "Count", "Max", "Min", "DistinctCount", "Percentile"
    /// or custom expressions (e.g., "*10", "/100 + 2").
    /// Custom formulas are parsed using NCalc: https://archive.codeplex.com/?p=ncalc
    /// </summary>
    string? Formula { get; set; }

}
