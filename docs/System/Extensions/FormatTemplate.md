# Extensions.FormatTemplate method

Format a string template based on the dynamic input data. It's the additional method to complement String Interpolation, except that the string can be stored as a file or configuration outside the assembly.

```csharp
public static string FormatTemplate(this string input, object data)
```

## Examples

Standard example to use FormatTemplate.

```csharp
string template = "I'm sure that {FirstName} needs {Amount} since {RequestedDate} with specific {ID}";
dynamic data = new {
	FirstName = "Radityo",
	Amount = 546481237.523498,
	RequestedDate = DateTime.Now.AddYears(-3),
	ID = Guid.NewGuid()
};
Console.WriteLine(template.FormatTemplate(data));
//Returns "I'm sure that Radityo needs 546481237.523498 since Friday, October 31, 2008 with specific 0561c0b3-0d09-4969-af2c-5c39d5c4af6a"
//Note that DateTime string return is highly-dependent on ToString method output and your system (Windows or Linux).
```

Advanced example to use FormatTemplate.

```csharp
string template = "I'm sure that {FirstName} needs {Amount:#,##0.00} since {RequestedDate:ddMMMyyyy} with specific {ID:B}";
dynamic data = new {
	FirstName = "Radityo",
	Amount = 546481237.523498,
	RequestedDate = DateTime.Now.AddYears(-3),
	ID = Guid.NewGuid()
};
Console.WriteLine(template.FormatTemplate(data));
//Returns "I'm sure that Radityo needs 546,481,237.52 since 31Oct2008 with specific {0561c0b3-0d09-4969-af2c-5c39d5c4af6a}"
//Note that DateTime string return is highly-dependent on ToString method output and your system (Windows or Linux).
```

## See Also

* class [Extensions](../Extensions.md)
* namespace [System](../../Rdz.Net.Library.md)

<!-- DO NOT EDIT: generated by xmldocmd for Rdz.Net.Library.dll -->