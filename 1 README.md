# c-10stringandreg

- Strings in C#
- The importance of immutability
- String encoding basics
- Introduce regular expressions (Regex)

## Introducing Strings

System.String “A string represents text as a sequence of UTF-16 code units.”

Advantages

-   Strings can be safely shared without the need
-   to defensively copy them
-   Easy to reason about 
-   Thread-safe by default
-   Can be optimized by the CLR    

Managed Heap
Stack
message (variable)
String
    object header
    method table
    data (length = 6)

## Character Encoding

Encoding
The means by which characters are mapped to bytes of binary data stored in memory, on disk or transmitted over a network.

ASCII American Standard Code for Information
Interchange

Unicode Uses a 16-bit character model

A Unicode Transformation Format (UTF) encodes code points to and from binary data

## UTF-16 Encoding

.NET uses UTF-16 encoding for strings

Requires at leasttwo bytes per character (char)

Higher code points may require two chars
- Known as a surrogate pair
- Requires four bytes

## UTF-8 and the Internet
-   UTF-8 is the most prevalent encoding on the web. Most sites accept UTF-8 encoded requests and return UTF-8 encoded data (HTML/JSON) in responses
-   Variable width character encoding
-   Can encode all Unicode code points
-   Length varies between 1 and 4 bytes
-   - 1 byte: Sufficient for US-ASCII
-   - 2 bytes: Supports an extra 1,920 characters
-   - 3 bytes: Sufficient for the whole BMP range
-   - 4 bytes: Supports the supplementary range
-   For most text, UTF-8 results in less data to transmit, vs. UTF-16 encoding

# Working With STrings

Globalization

Rules can change over time as new standards are adopted
-   Applications which parse or display data must respect local preferences
-   - Known as globalization
-   .NET relies on the OS for cultural rules
-   Linux uses Internal Components for Unicode (ICU)
-   Prior to Windows 10 (May 2019 update) 
-   Windows used National Language Support (NLS)
-   .NET 5 and later prefer ICU on Windows when available

Globalization is crucial to ensure applications apply the correct rules when parsing, formatting and sorting string data

- Culture is particularly important when presenting text or working with strings which may  contain culture-specific formatting
- -The culture of a .NET application defaults to that of the runtime OS
- Threads can be assigned a specific culture at runtime

Culture and globalization are particularly important when presenting text or working with strings which may contain culture-specific formatting

Set application culture
Create a string literal

## String Interning

- The .NET CLR maintains a table called the “Intern Pool”, stored in the **large object heap**
- - Used to deduplicate strings
- Unique string literals are stored in the intern pool
- Avoids repeat allocations for the same string value

Strings created at runtime may be manually interned, but this is an advanced topic and rarely needed

## CultureInfo Name

    aa-bb
    Language Code Country Code

## String Convenience Methods

## Escape special characters in strings


