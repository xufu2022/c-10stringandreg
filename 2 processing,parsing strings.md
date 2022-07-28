# Processing and Parsing Strings

Parsing strings to other .NET types
- Integers
- Longs
- Doubles
- DateTimeOffset

What is Parsing?

- An operation which converts a string into another .NET type
- - Parse a string into a DateTime object
- The reverse of formatting types to strings
- Involves rules and considerations affected by culture
- An IFormatProvider can influence how a string value is interpreted

    Static Parsing Methods
    public static long Parse (string input);
    public static bool TryParse (string? input, out long result);
    
Prefer TryParse to avoid exception handling and simplify the flow of application code