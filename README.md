# Rdz.Net.Library
It's a lightweight .NET library to simplify your code. The library consist of methods that extends the current data type in .NET Core.

## How to Install
Run the following command (dotnet CLI).
```
dotnet add "{your-project-path}" package Rdz.Net.Library
```
Otherwise, go to your Visual Studio Package Manager, and look for Rdz.Net.Library. You don't need to use `using` directive, as the assembly extension tagged to `System` namespace which always available on project creation.

# Auto-generated Documentations
Read this [Rdz.Net.Library documentation](docs/Rdz.Net.Library.md) for further information.

# String.FormatTemplate Method
Namespace: System

Converts the value of objects to strings based on the formats specified and inserts them into another string.

If you are new to the `String.FormatTemplate` or `String.Format` method, see the [Get started with the String.Format method section](https://learn.microsoft.com/en-us/dotnet/api/system.string.format?view=net-7.0#Starting) for a quick overview. Additionally, the concept is exactly the same as `String.Format` method with a slight ease of use.

Note: this method is after discussion with the dotnet team that addition of this function would result in conflict with the existing `String.Format(String, Object[])` since the compiler can't differentiate overloads between `Dynamic` and `Object[]`.

There is no overloads for this method, it accepts only the following arguments.
```
String.FormatTemplate(String, Dynamic)
```
The rest of formatting methods are simply the same.

## Examples

```
var data = new { Description = "This is the description" };
String s = String.FormatTemplate("The description for this message is '{Description}'.", data);
Console.WriteLine(s);
// Result: The description for this message is 'This is the description'.
```

```
var data = new { Price = 1234.456 };
String s = String.FormatTemplate("The price was decided at USD {Price:#,##0.00}.", data);
Console.WriteLine(s);
// Result: The price was decided at USD 1,234.46.
```

```
var data = new { Expired = DateTime.Now }; //it will generate a dynamic value since it gets the Now method.
String s = String.FormatTemplate("This food will be expired from {Expired:yyyy}, {Expired:MMMM}, and {Expired:dd}.", data);
Console.WriteLine(s);
// Result: This food will be expired from 2022, November, and 01.
```

# Other Information
_other documentations will follow..._