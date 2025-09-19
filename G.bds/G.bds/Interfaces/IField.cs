namespace G.bds.Interfaces;
public interface IField
{
    public string Id { get; set; }
    public string Name { get; set; }
    /// <summary>
    /// Defines the aggregation or transformation formula to apply.
    /// Accepts standard operations like:
    /// "Sum", "Average", "Count", "Max", "Min", "DistinctCount", "Percentile"
    /// or custom expressions (e.g., "*10", "/100 + 2").
    /// Custom formulas are parsed using NCalc: https://archive.codeplex.com/?p=ncalc
    /// </summary>
    public string? Formula { get; set; }

}
