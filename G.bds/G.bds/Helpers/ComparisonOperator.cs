namespace G.bds.Helpers;
public enum ComparisonOperator
{
    Equal,                // Value matches exactly
    NotEqual,             // Value does not match
    In,                   // Value is in a list of allowed values
    NotIn,                // Value is NOT in a list of allowed values
    StartsWith,           // String starts with a specific value
    EndsWith,             // String ends with a specific value
    GreaterThan,          // Numeric value is greater
    GreaterThanOrEqual,   // Numeric value is greater or equal
    LessThan,             // Numeric value is smaller
    LessThanOrEqual,      // Numeric value is smaller or equal
    Between,              // Numeric value is within a range (inclusive)
    NotBetween,           // Numeric value is outside a range
    MatchesRegex,         // String matches a regular expression pattern
    IsNull,               // Property value is null or not set
    IsNotNull,            // Property value is NOT null
    ApproximatelyEqual    // Numeric values are approximately equal (within a tolerance)
}
