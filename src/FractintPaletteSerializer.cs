// Fractint Palette Map Serializer
// Copyright (c) 2021 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See license.txt for the full text.

// If you find this code useful please consider making a donation.

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

// For Cyotek Color Palette Editor to detect this class as a serialiser without having to take
// dependencies on other Cyotek libraries the following conditions must be met
//
// * The class must be public and not abstract
// * The class name must end in Serializer
// * There must be an instance of DescriptionAttribute on the class with a simple name for use in file filters
// * There must be a readable property named Extensions of type string[]
// * To enable load support, the following are required
// *   A method named CanLoad, that accepts a Stream and returns a bool
// *   A method named Load, that accepts a Stream and returns Color[]
// * To enable save support, the following are required
// *   A method named Save, that accepts a Stream and Color[] and returns void
//
// Methods and properties can be public or private.
//
// Cyotek Color Palette Editor 1.7 and above can load serialisers following the above rules,
// older versions can only load ones that are explicitly inheriting a more complicated base class.
// The ability to specific advanced functionality such as minimum/maximum counts, color types,
// etc are not available from this simplified form.
//
// The Load(String) and Save(String) overloads are convenience helpers for consumers of
// the class and are not directly used by Cyotek Color Palette Editor.

namespace Cyotek.Drawing.PaletteFormat
{
  [Description("Fractint Palette Map")]
  public sealed class FractintPaletteSerializer
  {
    #region Private Fields

    private static readonly string[] _extensions = { "map" };

    private static readonly char[] _sepratorChars = { ' ' };

    private static readonly Encoding _utf8WithoutBom = new UTF8Encoding(false);

    #endregion Private Fields

    #region Public Properties

    public string[] Extensions => _extensions;

    #endregion Public Properties

    #region Public Methods

    public bool CanLoad(Stream stream)
    {
      bool result;

      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      result = true;

      using (TextReader reader = new StreamReader(stream, _utf8WithoutBom))
      {
        CultureInfo culture;
        string line;
        int count;

        culture = CultureInfo.InvariantCulture;
        count = 0;

        do
        {
          line = reader.ReadLine();

          if (!string.IsNullOrEmpty(line))
          {
            string[] parts;

            parts = line.Split(_sepratorChars, 4);

            if (!int.TryParse(parts[0], NumberStyles.Integer, culture, out int _)
                || !int.TryParse(parts[1], NumberStyles.Integer, culture, out int _)
                || !int.TryParse(parts[2], NumberStyles.Integer, culture, out int _))
            {
              result = false;
              break;
            }

            count++;
          }
        } while (!string.IsNullOrEmpty(line));

        if (count == 0)
        {
          result = false;
        }
      }

      return result;
    }

    public bool CanLoad(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }

      using (Stream stream = File.OpenRead(fileName))
      {
        return this.CanLoad(stream);
      }
    }

    public Color[] Load(Stream stream)
    {
      int count;
      Color[] results;

      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      // C reference
      // https://svn.fractint.net/trunk/allegro/loadmap.c

      count = 0;
      results = new Color[256]; // default size is 256

      using (TextReader reader = new StreamReader(stream, _utf8WithoutBom))
      {
        CultureInfo culture;
        string line;

        culture = CultureInfo.InvariantCulture;

        do
        {
          line = reader.ReadLine();

          if (!string.IsNullOrEmpty(line))
          {
            string[] parts;
            int r;
            int g;
            int b;

            parts = line.Split(_sepratorChars, 4);

            r = int.Parse(parts[0], NumberStyles.Integer, culture);
            g = int.Parse(parts[1], NumberStyles.Integer, culture);
            b = int.Parse(parts[2], NumberStyles.Integer, culture);

            if (count == results.Length)
            {
              Array.Resize(ref results, count * 2);
            }

            results[count] = Color.FromArgb(r, g, b);

            count++;
          }
        } while (!string.IsNullOrEmpty(line));

        if (count < results.Length)
        {
          Array.Resize(ref results, count);
        }
      }

      return results;
    }

    public Color[] Load(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }

      if (!File.Exists(fileName))
      {
        throw new FileNotFoundException("Cannot find file '" + fileName + "'.", fileName);
      }

      using (Stream stream = File.OpenRead(fileName))
      {
        return this.Load(stream);
      }
    }

    public void Save(string fileName, Color[] values)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }

      if (values == null)
      {
        throw new ArgumentNullException(nameof(values));
      }

      using (Stream stream = File.Create(fileName))
      {
        this.Save(stream, values);
      }
    }

    public void Save(Stream stream, Color[] values)
    {
      StringBuilder sb;

      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      if (values == null)
      {
        throw new ArgumentNullException(nameof(values));
      }

      sb = new StringBuilder(3380);

      for (int i = 0; i < values.Length; i++)
      {
        Color value;

        value = values[i];

        sb.Append(value.R);
        sb.Append(' ');
        sb.Append(value.G);
        sb.Append(' ');
        sb.Append(value.B);
        sb.AppendLine();
      }

      using (TextWriter writer = new StreamWriter(stream, _utf8WithoutBom))
      {
        writer.Write(sb.ToString());
      }
    }

    #endregion Public Methods
  }
}