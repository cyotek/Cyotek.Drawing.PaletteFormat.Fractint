Fractint Palette Map Serializer
================================

This is a simple class for reading and writing
`System.Drawing.Color` arrays to and from [Fractint][1] palette
maps.

It has been designed to be either directly referenced in your
own projects, or can be used as a serializer with [Cyotek Color
Palette Editor][2]). The class has no dependencies and so the
entire class can be embedded in your own code if required.

There is also a small test class to verify the critical bits of
the code are doing what they should be.

## Reading Palettes

Palette data can be read from any `Stream`

```csharp
FractintPaletteSerializer reader = new FractintPaletteSerializer();
Stream stream = GetDataStream();
Color[] colors = reader.Load(stream);
```

However, for simplicity an overload is also available to load
from a file

```csharp
FractintPaletteSerializer reader = new FractintPaletteSerializer();
string fileName = "mypalette.map";
Color[] colors = reader.Load(fileName);
```

You can also use the `CanLoad` overloads to test if a given
`Stream` or file contains a readable palette map.

## Writing Palettes

As with reading, palette data can be written to either a
`Stream` or a file.

```csharp
FractintPaletteSerializer writer = new FractintPaletteSerializer();
string fileName = "mypalette.map";
Color[] colors = new[] { Color.Red, Color.Green, Color.Blue };
writer.Save(fileName);
```

## Acknowledgements

The package icon is derived from [Color, colors, palette
icon][3] by Nick Roach. The icon is licensed according the [GNU
General Public License, version 3][4].

The `default.map` file used in the test library taken from the
[Fractint SVN repository][5].

[1]: https://fractint.org/
[2]: https://www.cyotek.com/cyotek-palette-editor
[3]: https://www.iconfinder.com/icons/1055088/color_colors_palette_icon
[4]: https://www.gnu.org/licenses/gpl-3.0.html
[5]: https://svn.fractint.net/trunk/allegro/