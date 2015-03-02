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

The classes will be provided by various NuGet packages. You can select suitable element attributes according to your codes' world view. Of course, you can define your own elements by your needs.

### Author

Written by [Takeshi KIRIYA (aka takeshik)](https://takeshik.org).

### Licensing

The codes are licensed under the zlib License. For more details, see [LICENSE.txt](https://github.com/takeshik/ElementalAnnotations/blob/master/LICENSE.txt).
