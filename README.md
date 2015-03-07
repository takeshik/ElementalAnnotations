## Elemental Annotations

**Elemental Annotations** is a bunch of little C# class files for *Elemental Programming*.

*Elemental Programming* is a way to describe an aura of program elements: assemblies, types, members, etc., by elements (like [this](http://en.wikipedia.org/wiki/Classical_element)).

For instance:

```csharp
[Light]
public void AwesomeMethod() { /* ... */ }

[Dark]
public void TerribleMethod() { /* ... */ }
```

The classes are provided by various NuGet packages. You can select suitable element attributes according to your codes' world view. Of course, you can define your own elements by your needs.

### Installation

Install NuGet package(s). For example:

```
PM> Install-Package ElementalAnnotations-Dualism
```

`ElementalAnnotations-Dualism` is meta package to install below dependent packages:

* `ElementalAnnotations-Core` - Core classes for all elemental attribute classes
* `ElementalAnnotations-Dark` - Provides the Dark element
* `ElementalAnnotations-Light` - Provides the Light element

Package adds C# source files. If you are using other language, please make a class library with installed classes and refer it.

[Search NuGet packages which starts with "ElementalAnnotations-" in the official repository](https://www.nuget.org/packages?q=ElementalAnnotations-).

### Author

Written by [Takeshi KIRIYA (aka takeshik)](https://takeshik.org).

### Licensing

The codes are licensed under the zlib License. For more details, see [LICENSE.txt](https://github.com/takeshik/ElementalAnnotations/blob/master/LICENSE.txt).
