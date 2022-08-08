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

## Common Anchors

- Example string ^  $ (start end)

### Multiline Mode

| ^      | $ |
| ----------- | ----------- |
| Multiline Mode Off      | Multiline Mode Off       |
| Match must occur at the beginning of the string   | Match must occur at the end of a string, or before the \n at the end of a string.        |


| ^      | $ |
| ----------- | ----------- |
| Multiline Mode On      | Multiline Mode On       |
| Match must occur at the beginning of each line. | Match must occur at the each line, or before \n at the end of a line.      |

    var pattern = "^Ca";
    var match = Regex.Match("Cats", pattern)

## Character Classes

**[]**

- A character class defines a set of characters
    - Any character in the set can occur within the input string for a match to succeed
- Several metacharacters represent common character sets
- A specific set or range of characters may be defined within square brackets
    - A positive character group defines a set of allowed characters which can occur
    - A negative character group defines a set of characters which should not occur

Character Group Examples

| Pattern      | Explanation |
| ----------- | ----------- |
| [aeiou] | Matches any lowercase vowel |
| [a-z] | Matches any lowercase character in the range ‘a’ through ‘z’. |
| [0-2] | Match a digit from the range (0, 1 or 2). |
| [^AEIOU] | Matches any character except uppercase vowels. |
| [a-zA-Z] | Matches any character in either of its two ranges. Essentially matches any English letter. |

**A-Z**
- Matched based on their Unicode code point
- Any code point between the start and end character (inclusive) is a match

### Unicode Code Points

| Hex      | Character |
| ----------- | ----------- | 
| ... |  | 
|58| X|
|59| Y|
|5A| Z|
|5B| [|
|5C| \|
|5D| ]|
|5E| ^|
|5F| _|
|60| `|
|61| a|
|62| b|
|63| c|
|…||

### Other Character Classes

|Pattern | Matches |
| ----------- | ----------- | 
|. | Any character (wildcard)|
|\w| Any word character|
|\W| Any non-word character|
|\d| Any digit character|
|\D| Any non-digit character|
|\s| Any whitespace character|
|\S| Any non-whitespace character|

## Quantifiers

- Used to specify how many instances of a character, group or character class must occur within the input
- Special metacharacters are available for common quantifiers
- Specific numeric values can also be provided
- Quantifiers can be either greedy or lazy
    - Greedy: Match as much as possible
    - Lazy: Match as little as possible
- Greedy by default, but can be made lazy by following them with a question mark ‘?’

**Quantifier Examples**

|Greedy | Lazy | Matches |
| ----------- | ----------- |  ----------- | 
|*    |  *?     | Zero or more times|
|+    |  +?     | One or more times|
|?    |  ??     | Zero or one time|
|{3}  |  {3}?   | Exactly 3 times|
|{3,} |  {3,}?  | At least 3 times|
|{3,6}|  {3,6}? | Between 3 and 6 times|
|{,10}|  {,10}? | Between zero and 10 times|

## Groups and Subexpressions

- Subexpressions are defined within a grouping construct
    - Extract substrings within a larger matched string for separate processing
    - Group a subexpression to apply a quantifier
- May be capturing or non-capturing
    - Groups capture by default
- Captures are automatically numbered from left to right
- Support optional naming of the group

subexpression

- Matched Subexpressions

**(subexpression)**


Parentheses are used to define a subexpression and capture the match.
- Non-capturing Subexpressions

**(?:subexpression)**


A grouping construct which includes a subexpression, but does not capture the matched 
substring. 


- Named Matched Subexpressions

**(?<name>subexpression)**

A grouping construct which includes a subexpression, capturing the matched substring with a 
name that can be used to access it from the match.

Examples

    var pattern = "(?:Az){3}";
    var match = Regex.Match("AzAzAz", pattern); // True
    match = Regex.Match("AzAz", pattern); // False
    match = Regex.Match("AzThingAzAzAzAz", pattern); // True

    @"^$" 
    @"^[^|]$" -- exclude character |match any character which is not pipe
    @"^[^|]+$" --greedy match + won't repeat character until reach pipe
    @"^[^|]+\|$" -- escape Pipe
    @"^([^|]+\|){6}$" -- repeat times
    @"^([^|]+\|){6}.+$" -- repeat times
    @"^([^|]+\|){6}.+$" -- repeat times
    @"^(?:(?<parts>[^|]+)\|){6}.+$" -- ms add parts
    @"^(?:(?<parts>[^|]+)\|){6}(?<parts>)$" -- ms add parts
    @"^(?:(?<parts>[^|]+)\|){6}(?<parts>([a-zA-Z]{3}\d{3}:.+))$" -- ms add parts
    @"^(?:(?<parts>[^|]+)\|){6}(?<parts>(?<code>[a-zA-Z]{3}\d{3}:(?<desc>.+))$" -- desc code

    var parts = match.Groups["part"];
    var productName=parts.Captures[0].Value;




