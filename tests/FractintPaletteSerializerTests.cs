// Fractint Palette Map Serializer
// Copyright (c) 2021 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See license.txt for the full text.

// If you find this code useful please consider making a donation.

using NUnit.Framework;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Cyotek.Drawing.PaletteFormat.Tests
{
  [TestFixture]
  public class FractintPaletteSerializerTests
  {
    #region Private Properties

    private static byte[] Data
    {
      get
      {
        return new byte[]
        {
          48, 32, 48, 32, 48, 13, 10, 48, 32, 48, 32, 49, 54, 56, 13, 10,
          48, 32, 49, 54, 56, 32, 48, 13, 10, 48, 32, 49, 54, 56, 32, 49,
          54, 56, 13, 10, 49, 54, 56, 32, 48, 32, 48, 13, 10, 49, 54, 56,
          32, 48, 32, 49, 54, 56, 13, 10, 49, 54, 56, 32, 56, 52, 32, 48,
          13, 10, 49, 54, 56, 32, 49, 54, 56, 32, 49, 54, 56, 13, 10, 56,
          52, 32, 56, 52, 32, 56, 52, 13, 10, 56, 52, 32, 56, 52, 32, 50,
          53, 50, 13, 10, 56, 52, 32, 50, 53, 50, 32, 56, 52, 13, 10, 56,
          52, 32, 50, 53, 50, 32, 50, 53, 50, 13, 10, 50, 53, 50, 32, 56,
          52, 32, 56, 52, 13, 10, 50, 53, 50, 32, 56, 52, 32, 50, 53, 50,
          13, 10, 50, 53, 50, 32, 50, 53, 50, 32, 56, 52, 13, 10, 50, 53,
          50, 32, 50, 53, 50, 32, 50, 53, 50, 13, 10, 48, 32, 48, 32, 48,
          13, 10, 50, 48, 32, 50, 48, 32, 50, 48, 13, 10, 51, 50, 32, 51,
          50, 32, 51, 50, 13, 10, 52, 52, 32, 52, 52, 32, 52, 52, 13, 10,
          53, 54, 32, 53, 54, 32, 53, 54, 13, 10, 54, 56, 32, 54, 56, 32,
          54, 56, 13, 10, 56, 48, 32, 56, 48, 32, 56, 48, 13, 10, 57, 54,
          32, 57, 54, 32, 57, 54, 13, 10, 49, 49, 50, 32, 49, 49, 50, 32,
          49, 49, 50, 13, 10, 49, 50, 56, 32, 49, 50, 56, 32, 49, 50, 56,
          13, 10, 49, 52, 52, 32, 49, 52, 52, 32, 49, 52, 52, 13, 10, 49,
          54, 48, 32, 49, 54, 48, 32, 49, 54, 48, 13, 10, 49, 56, 48, 32,
          49, 56, 48, 32, 49, 56, 48, 13, 10, 50, 48, 48, 32, 50, 48, 48,
          32, 50, 48, 48, 13, 10, 50, 50, 52, 32, 50, 50, 52, 32, 50, 50,
          52, 13, 10, 50, 53, 50, 32, 50, 53, 50, 32, 50, 53, 50, 13, 10,
          48, 32, 48, 32, 50, 53, 50, 13, 10, 54, 52, 32, 48, 32, 50, 53,
          50, 13, 10, 49, 50, 52, 32, 48, 32, 50, 53, 50, 13, 10, 49, 56,
          56, 32, 48, 32, 50, 53, 50, 13, 10, 50, 53, 50, 32, 48, 32, 50,
          53, 50, 13, 10, 50, 53, 50, 32, 48, 32, 49, 56, 56, 13, 10, 50,
          53, 50, 32, 48, 32, 49, 50, 52, 13, 10, 50, 53, 50, 32, 48, 32,
          54, 52, 13, 10, 50, 53, 50, 32, 48, 32, 48, 13, 10, 50, 53, 50,
          32, 54, 52, 32, 48, 13, 10, 50, 53, 50, 32, 49, 50, 52, 32, 48,
          13, 10, 50, 53, 50, 32, 49, 56, 56, 32, 48, 13, 10, 50, 53, 50,
          32, 50, 53, 50, 32, 48, 13, 10, 49, 56, 56, 32, 50, 53, 50, 32,
          48, 13, 10, 49, 50, 52, 32, 50, 53, 50, 32, 48, 13, 10, 54, 52,
          32, 50, 53, 50, 32, 48, 13, 10, 48, 32, 50, 53, 50, 32, 48, 13,
          10, 48, 32, 50, 53, 50, 32, 54, 52, 13, 10, 48, 32, 50, 53, 50,
          32, 49, 50, 52, 13, 10, 48, 32, 50, 53, 50, 32, 49, 56, 56, 13,
          10, 48, 32, 50, 53, 50, 32, 50, 53, 50, 13, 10, 48, 32, 49, 56,
          56, 32, 50, 53, 50, 13, 10, 48, 32, 49, 50, 52, 32, 50, 53, 50,
          13, 10, 48, 32, 54, 52, 32, 50, 53, 50, 13, 10, 49, 50, 52, 32,
          49, 50, 52, 32, 50, 53, 50, 13, 10, 49, 53, 54, 32, 49, 50, 52,
          32, 50, 53, 50, 13, 10, 49, 56, 56, 32, 49, 50, 52, 32, 50, 53,
          50, 13, 10, 50, 50, 48, 32, 49, 50, 52, 32, 50, 53, 50, 13, 10,
          50, 53, 50, 32, 49, 50, 52, 32, 50, 53, 50, 13, 10, 50, 53, 50,
          32, 49, 50, 52, 32, 50, 50, 48, 13, 10, 50, 53, 50, 32, 49, 50,
          52, 32, 49, 56, 56, 13, 10, 50, 53, 50, 32, 49, 50, 52, 32, 49,
          53, 54, 13, 10, 50, 53, 50, 32, 49, 50, 52, 32, 49, 50, 52, 13,
          10, 50, 53, 50, 32, 49, 53, 54, 32, 49, 50, 52, 13, 10, 50, 53,
          50, 32, 49, 56, 56, 32, 49, 50, 52, 13, 10, 50, 53, 50, 32, 50,
          50, 48, 32, 49, 50, 52, 13, 10, 50, 53, 50, 32, 50, 53, 50, 32,
          49, 50, 52, 13, 10, 50, 50, 48, 32, 50, 53, 50, 32, 49, 50, 52,
          13, 10, 49, 56, 56, 32, 50, 53, 50, 32, 49, 50, 52, 13, 10, 49,
          53, 54, 32, 50, 53, 50, 32, 49, 50, 52, 13, 10, 49, 50, 52, 32,
          50, 53, 50, 32, 49, 50, 52, 13, 10, 49, 50, 52, 32, 50, 53, 50,
          32, 49, 53, 54, 13, 10, 49, 50, 52, 32, 50, 53, 50, 32, 49, 56,
          56, 13, 10, 49, 50, 52, 32, 50, 53, 50, 32, 50, 50, 48, 13, 10,
          49, 50, 52, 32, 50, 53, 50, 32, 50, 53, 50, 13, 10, 49, 50, 52,
          32, 50, 50, 48, 32, 50, 53, 50, 13, 10, 49, 50, 52, 32, 49, 56,
          56, 32, 50, 53, 50, 13, 10, 49, 50, 52, 32, 49, 53, 54, 32, 50,
          53, 50, 13, 10, 49, 56, 48, 32, 49, 56, 48, 32, 50, 53, 50, 13,
          10, 49, 57, 54, 32, 49, 56, 48, 32, 50, 53, 50, 13, 10, 50, 49,
          54, 32, 49, 56, 48, 32, 50, 53, 50, 13, 10, 50, 51, 50, 32, 49,
          56, 48, 32, 50, 53, 50, 13, 10, 50, 53, 50, 32, 49, 56, 48, 32,
          50, 53, 50, 13, 10, 50, 53, 50, 32, 49, 56, 48, 32, 50, 51, 50,
          13, 10, 50, 53, 50, 32, 49, 56, 48, 32, 50, 49, 54, 13, 10, 50,
          53, 50, 32, 49, 56, 48, 32, 49, 57, 54, 13, 10, 50, 53, 50, 32,
          49, 56, 48, 32, 49, 56, 48, 13, 10, 50, 53, 50, 32, 49, 57, 54,
          32, 49, 56, 48, 13, 10, 50, 53, 50, 32, 50, 49, 54, 32, 49, 56,
          48, 13, 10, 50, 53, 50, 32, 50, 51, 50, 32, 49, 56, 48, 13, 10,
          50, 53, 50, 32, 50, 53, 50, 32, 49, 56, 48, 13, 10, 50, 51, 50,
          32, 50, 53, 50, 32, 49, 56, 48, 13, 10, 50, 49, 54, 32, 50, 53,
          50, 32, 49, 56, 48, 13, 10, 49, 57, 54, 32, 50, 53, 50, 32, 49,
          56, 48, 13, 10, 49, 56, 48, 32, 50, 53, 50, 32, 49, 56, 48, 13,
          10, 49, 56, 48, 32, 50, 53, 50, 32, 49, 57, 54, 13, 10, 49, 56,
          48, 32, 50, 53, 50, 32, 50, 49, 54, 13, 10, 49, 56, 48, 32, 50,
          53, 50, 32, 50, 51, 50, 13, 10, 49, 56, 48, 32, 50, 53, 50, 32,
          50, 53, 50, 13, 10, 49, 56, 48, 32, 50, 51, 50, 32, 50, 53, 50,
          13, 10, 49, 56, 48, 32, 50, 49, 54, 32, 50, 53, 50, 13, 10, 49,
          56, 48, 32, 49, 57, 54, 32, 50, 53, 50, 13, 10, 48, 32, 48, 32,
          49, 49, 50, 13, 10, 50, 56, 32, 48, 32, 49, 49, 50, 13, 10, 53,
          54, 32, 48, 32, 49, 49, 50, 13, 10, 56, 52, 32, 48, 32, 49, 49,
          50, 13, 10, 49, 49, 50, 32, 48, 32, 49, 49, 50, 13, 10, 49, 49,
          50, 32, 48, 32, 56, 52, 13, 10, 49, 49, 50, 32, 48, 32, 53, 54,
          13, 10, 49, 49, 50, 32, 48, 32, 50, 56, 13, 10, 49, 49, 50, 32,
          48, 32, 48, 13, 10, 49, 49, 50, 32, 50, 56, 32, 48, 13, 10, 49,
          49, 50, 32, 53, 54, 32, 48, 13, 10, 49, 49, 50, 32, 56, 52, 32,
          48, 13, 10, 49, 49, 50, 32, 49, 49, 50, 32, 48, 13, 10, 56, 52,
          32, 49, 49, 50, 32, 48, 13, 10, 53, 54, 32, 49, 49, 50, 32, 48,
          13, 10, 50, 56, 32, 49, 49, 50, 32, 48, 13, 10, 48, 32, 49, 49,
          50, 32, 48, 13, 10, 48, 32, 49, 49, 50, 32, 50, 56, 13, 10, 48,
          32, 49, 49, 50, 32, 53, 54, 13, 10, 48, 32, 49, 49, 50, 32, 56,
          52, 13, 10, 48, 32, 49, 49, 50, 32, 49, 49, 50, 13, 10, 48, 32,
          56, 52, 32, 49, 49, 50, 13, 10, 48, 32, 53, 54, 32, 49, 49, 50,
          13, 10, 48, 32, 50, 56, 32, 49, 49, 50, 13, 10, 53, 54, 32, 53,
          54, 32, 49, 49, 50, 13, 10, 54, 56, 32, 53, 54, 32, 49, 49, 50,
          13, 10, 56, 52, 32, 53, 54, 32, 49, 49, 50, 13, 10, 57, 54, 32,
          53, 54, 32, 49, 49, 50, 13, 10, 49, 49, 50, 32, 53, 54, 32, 49,
          49, 50, 13, 10, 49, 49, 50, 32, 53, 54, 32, 57, 54, 13, 10, 49,
          49, 50, 32, 53, 54, 32, 56, 52, 13, 10, 49, 49, 50, 32, 53, 54,
          32, 54, 56, 13, 10, 49, 49, 50, 32, 53, 54, 32, 53, 54, 13, 10,
          49, 49, 50, 32, 54, 56, 32, 53, 54, 13, 10, 49, 49, 50, 32, 56,
          52, 32, 53, 54, 13, 10, 49, 49, 50, 32, 57, 54, 32, 53, 54, 13,
          10, 49, 49, 50, 32, 49, 49, 50, 32, 53, 54, 13, 10, 57, 54, 32,
          49, 49, 50, 32, 53, 54, 13, 10, 56, 52, 32, 49, 49, 50, 32, 53,
          54, 13, 10, 54, 56, 32, 49, 49, 50, 32, 53, 54, 13, 10, 53, 54,
          32, 49, 49, 50, 32, 53, 54, 13, 10, 53, 54, 32, 49, 49, 50, 32,
          54, 56, 13, 10, 53, 54, 32, 49, 49, 50, 32, 56, 52, 13, 10, 53,
          54, 32, 49, 49, 50, 32, 57, 54, 13, 10, 53, 54, 32, 49, 49, 50,
          32, 49, 49, 50, 13, 10, 53, 54, 32, 57, 54, 32, 49, 49, 50, 13,
          10, 53, 54, 32, 56, 52, 32, 49, 49, 50, 13, 10, 53, 54, 32, 54,
          56, 32, 49, 49, 50, 13, 10, 56, 48, 32, 56, 48, 32, 49, 49, 50,
          13, 10, 56, 56, 32, 56, 48, 32, 49, 49, 50, 13, 10, 57, 54, 32,
          56, 48, 32, 49, 49, 50, 13, 10, 49, 48, 52, 32, 56, 48, 32, 49,
          49, 50, 13, 10, 49, 49, 50, 32, 56, 48, 32, 49, 49, 50, 13, 10,
          49, 49, 50, 32, 56, 48, 32, 49, 48, 52, 13, 10, 49, 49, 50, 32,
          56, 48, 32, 57, 54, 13, 10, 49, 49, 50, 32, 56, 48, 32, 56, 56,
          13, 10, 49, 49, 50, 32, 56, 48, 32, 56, 48, 13, 10, 49, 49, 50,
          32, 56, 56, 32, 56, 48, 13, 10, 49, 49, 50, 32, 57, 54, 32, 56,
          48, 13, 10, 49, 49, 50, 32, 49, 48, 52, 32, 56, 48, 13, 10, 49,
          49, 50, 32, 49, 49, 50, 32, 56, 48, 13, 10, 49, 48, 52, 32, 49,
          49, 50, 32, 56, 48, 13, 10, 57, 54, 32, 49, 49, 50, 32, 56, 48,
          13, 10, 56, 56, 32, 49, 49, 50, 32, 56, 48, 13, 10, 56, 48, 32,
          49, 49, 50, 32, 56, 48, 13, 10, 56, 48, 32, 49, 49, 50, 32, 56,
          56, 13, 10, 56, 48, 32, 49, 49, 50, 32, 57, 54, 13, 10, 56, 48,
          32, 49, 49, 50, 32, 49, 48, 52, 13, 10, 56, 48, 32, 49, 49, 50,
          32, 49, 49, 50, 13, 10, 56, 48, 32, 49, 48, 52, 32, 49, 49, 50,
          13, 10, 56, 48, 32, 57, 54, 32, 49, 49, 50, 13, 10, 56, 48, 32,
          56, 56, 32, 49, 49, 50, 13, 10, 48, 32, 48, 32, 54, 52, 13, 10,
          49, 54, 32, 48, 32, 54, 52, 13, 10, 51, 50, 32, 48, 32, 54, 52,
          13, 10, 52, 56, 32, 48, 32, 54, 52, 13, 10, 54, 52, 32, 48, 32,
          54, 52, 13, 10, 54, 52, 32, 48, 32, 52, 56, 13, 10, 54, 52, 32,
          48, 32, 51, 50, 13, 10, 54, 52, 32, 48, 32, 49, 54, 13, 10, 54,
          52, 32, 48, 32, 48, 13, 10, 54, 52, 32, 49, 54, 32, 48, 13, 10,
          54, 52, 32, 51, 50, 32, 48, 13, 10, 54, 52, 32, 52, 56, 32, 48,
          13, 10, 54, 52, 32, 54, 52, 32, 48, 13, 10, 52, 56, 32, 54, 52,
          32, 48, 13, 10, 51, 50, 32, 54, 52, 32, 48, 13, 10, 49, 54, 32,
          54, 52, 32, 48, 13, 10, 48, 32, 54, 52, 32, 48, 13, 10, 48, 32,
          54, 52, 32, 49, 54, 13, 10, 48, 32, 54, 52, 32, 51, 50, 13, 10,
          48, 32, 54, 52, 32, 52, 56, 13, 10, 48, 32, 54, 52, 32, 54, 52,
          13, 10, 48, 32, 52, 56, 32, 54, 52, 13, 10, 48, 32, 51, 50, 32,
          54, 52, 13, 10, 48, 32, 49, 54, 32, 54, 52, 13, 10, 51, 50, 32,
          51, 50, 32, 54, 52, 13, 10, 52, 48, 32, 51, 50, 32, 54, 52, 13,
          10, 52, 56, 32, 51, 50, 32, 54, 52, 13, 10, 53, 54, 32, 51, 50,
          32, 54, 52, 13, 10, 54, 52, 32, 51, 50, 32, 54, 52, 13, 10, 54,
          52, 32, 51, 50, 32, 53, 54, 13, 10, 54, 52, 32, 51, 50, 32, 52,
          56, 13, 10, 54, 52, 32, 51, 50, 32, 52, 48, 13, 10, 54, 52, 32,
          51, 50, 32, 51, 50, 13, 10, 54, 52, 32, 52, 48, 32, 51, 50, 13,
          10, 54, 52, 32, 52, 56, 32, 51, 50, 13, 10, 54, 52, 32, 53, 54,
          32, 51, 50, 13, 10, 54, 52, 32, 54, 52, 32, 51, 50, 13, 10, 53,
          54, 32, 54, 52, 32, 51, 50, 13, 10, 52, 56, 32, 54, 52, 32, 51,
          50, 13, 10, 52, 48, 32, 54, 52, 32, 51, 50, 13, 10, 51, 50, 32,
          54, 52, 32, 51, 50, 13, 10, 51, 50, 32, 54, 52, 32, 52, 48, 13,
          10, 51, 50, 32, 54, 52, 32, 52, 56, 13, 10, 51, 50, 32, 54, 52,
          32, 53, 54, 13, 10, 51, 50, 32, 54, 52, 32, 54, 52, 13, 10, 51,
          50, 32, 53, 54, 32, 54, 52, 13, 10, 51, 50, 32, 52, 56, 32, 54,
          52, 13, 10, 51, 50, 32, 52, 48, 32, 54, 52, 13, 10, 52, 52, 32,
          52, 52, 32, 54, 52, 13, 10, 52, 56, 32, 52, 52, 32, 54, 52, 13,
          10, 53, 50, 32, 52, 52, 32, 54, 52, 13, 10, 54, 48, 32, 52, 52,
          32, 54, 52, 13, 10, 54, 52, 32, 52, 52, 32, 54, 52, 13, 10, 54,
          52, 32, 52, 52, 32, 54, 48, 13, 10, 54, 52, 32, 52, 52, 32, 53,
          50, 13, 10, 54, 52, 32, 52, 52, 32, 52, 56, 13, 10, 54, 52, 32,
          52, 52, 32, 52, 52, 13, 10, 54, 52, 32, 52, 56, 32, 52, 52, 13,
          10, 54, 52, 32, 53, 50, 32, 52, 52, 13, 10, 54, 52, 32, 54, 48,
          32, 52, 52, 13, 10, 54, 52, 32, 54, 52, 32, 52, 52, 13, 10, 54,
          48, 32, 54, 52, 32, 52, 52, 13, 10, 53, 50, 32, 54, 52, 32, 52,
          52, 13, 10, 52, 56, 32, 54, 52, 32, 52, 52, 13, 10, 52, 52, 32,
          54, 52, 32, 52, 52, 13, 10, 52, 52, 32, 54, 52, 32, 52, 56, 13,
          10, 52, 52, 32, 54, 52, 32, 53, 50, 13, 10, 52, 52, 32, 54, 52,
          32, 54, 48, 13, 10, 52, 52, 32, 54, 52, 32, 54, 52, 13, 10, 52,
          52, 32, 54, 48, 32, 54, 52, 13, 10, 52, 52, 32, 53, 50, 32, 54,
          52, 13, 10, 52, 52, 32, 52, 56, 32, 54, 52, 13, 10, 48, 32, 48,
          32, 48, 13, 10, 48, 32, 48, 32, 48, 13, 10, 48, 32, 48, 32, 48,
          13, 10, 48, 32, 48, 32, 48, 13, 10, 48, 32, 48, 32, 48, 13, 10,
          48, 32, 48, 32, 48, 13, 10, 48, 32, 48, 32, 48, 13, 10, 48, 32,
          48, 32, 48, 13, 10
        };
      }
    }

    private static Color[] Sample
    {
      get
      {
        return new[]
               {
                  Color.FromArgb(0, 0, 0),
                  Color.FromArgb(0, 0, 168),
                  Color.FromArgb(0, 168, 0),
                  Color.FromArgb(0, 168, 168),
                  Color.FromArgb(168, 0, 0),
                  Color.FromArgb(168, 0, 168),
                  Color.FromArgb(168, 84, 0),
                  Color.FromArgb(168, 168, 168),
                  Color.FromArgb(84, 84, 84),
                  Color.FromArgb(84, 84, 252),
                  Color.FromArgb(84, 252, 84),
                  Color.FromArgb(84, 252, 252),
                  Color.FromArgb(252, 84, 84),
                  Color.FromArgb(252, 84, 252),
                  Color.FromArgb(252, 252, 84),
                  Color.FromArgb(252, 252, 252),
                  Color.FromArgb(0, 0, 0),
                  Color.FromArgb(20, 20, 20),
                  Color.FromArgb(32, 32, 32),
                  Color.FromArgb(44, 44, 44),
                  Color.FromArgb(56, 56, 56),
                  Color.FromArgb(68, 68, 68),
                  Color.FromArgb(80, 80, 80),
                  Color.FromArgb(96, 96, 96),
                  Color.FromArgb(112, 112, 112),
                  Color.FromArgb(128, 128, 128),
                  Color.FromArgb(144, 144, 144),
                  Color.FromArgb(160, 160, 160),
                  Color.FromArgb(180, 180, 180),
                  Color.FromArgb(200, 200, 200),
                  Color.FromArgb(224, 224, 224),
                  Color.FromArgb(252, 252, 252),
                  Color.FromArgb(0, 0, 252),
                  Color.FromArgb(64, 0, 252),
                  Color.FromArgb(124, 0, 252),
                  Color.FromArgb(188, 0, 252),
                  Color.FromArgb(252, 0, 252),
                  Color.FromArgb(252, 0, 188),
                  Color.FromArgb(252, 0, 124),
                  Color.FromArgb(252, 0, 64),
                  Color.FromArgb(252, 0, 0),
                  Color.FromArgb(252, 64, 0),
                  Color.FromArgb(252, 124, 0),
                  Color.FromArgb(252, 188, 0),
                  Color.FromArgb(252, 252, 0),
                  Color.FromArgb(188, 252, 0),
                  Color.FromArgb(124, 252, 0),
                  Color.FromArgb(64, 252, 0),
                  Color.FromArgb(0, 252, 0),
                  Color.FromArgb(0, 252, 64),
                  Color.FromArgb(0, 252, 124),
                  Color.FromArgb(0, 252, 188),
                  Color.FromArgb(0, 252, 252),
                  Color.FromArgb(0, 188, 252),
                  Color.FromArgb(0, 124, 252),
                  Color.FromArgb(0, 64, 252),
                  Color.FromArgb(124, 124, 252),
                  Color.FromArgb(156, 124, 252),
                  Color.FromArgb(188, 124, 252),
                  Color.FromArgb(220, 124, 252),
                  Color.FromArgb(252, 124, 252),
                  Color.FromArgb(252, 124, 220),
                  Color.FromArgb(252, 124, 188),
                  Color.FromArgb(252, 124, 156),
                  Color.FromArgb(252, 124, 124),
                  Color.FromArgb(252, 156, 124),
                  Color.FromArgb(252, 188, 124),
                  Color.FromArgb(252, 220, 124),
                  Color.FromArgb(252, 252, 124),
                  Color.FromArgb(220, 252, 124),
                  Color.FromArgb(188, 252, 124),
                  Color.FromArgb(156, 252, 124),
                  Color.FromArgb(124, 252, 124),
                  Color.FromArgb(124, 252, 156),
                  Color.FromArgb(124, 252, 188),
                  Color.FromArgb(124, 252, 220),
                  Color.FromArgb(124, 252, 252),
                  Color.FromArgb(124, 220, 252),
                  Color.FromArgb(124, 188, 252),
                  Color.FromArgb(124, 156, 252),
                  Color.FromArgb(180, 180, 252),
                  Color.FromArgb(196, 180, 252),
                  Color.FromArgb(216, 180, 252),
                  Color.FromArgb(232, 180, 252),
                  Color.FromArgb(252, 180, 252),
                  Color.FromArgb(252, 180, 232),
                  Color.FromArgb(252, 180, 216),
                  Color.FromArgb(252, 180, 196),
                  Color.FromArgb(252, 180, 180),
                  Color.FromArgb(252, 196, 180),
                  Color.FromArgb(252, 216, 180),
                  Color.FromArgb(252, 232, 180),
                  Color.FromArgb(252, 252, 180),
                  Color.FromArgb(232, 252, 180),
                  Color.FromArgb(216, 252, 180),
                  Color.FromArgb(196, 252, 180),
                  Color.FromArgb(180, 252, 180),
                  Color.FromArgb(180, 252, 196),
                  Color.FromArgb(180, 252, 216),
                  Color.FromArgb(180, 252, 232),
                  Color.FromArgb(180, 252, 252),
                  Color.FromArgb(180, 232, 252),
                  Color.FromArgb(180, 216, 252),
                  Color.FromArgb(180, 196, 252),
                  Color.FromArgb(0, 0, 112),
                  Color.FromArgb(28, 0, 112),
                  Color.FromArgb(56, 0, 112),
                  Color.FromArgb(84, 0, 112),
                  Color.FromArgb(112, 0, 112),
                  Color.FromArgb(112, 0, 84),
                  Color.FromArgb(112, 0, 56),
                  Color.FromArgb(112, 0, 28),
                  Color.FromArgb(112, 0, 0),
                  Color.FromArgb(112, 28, 0),
                  Color.FromArgb(112, 56, 0),
                  Color.FromArgb(112, 84, 0),
                  Color.FromArgb(112, 112, 0),
                  Color.FromArgb(84, 112, 0),
                  Color.FromArgb(56, 112, 0),
                  Color.FromArgb(28, 112, 0),
                  Color.FromArgb(0, 112, 0),
                  Color.FromArgb(0, 112, 28),
                  Color.FromArgb(0, 112, 56),
                  Color.FromArgb(0, 112, 84),
                  Color.FromArgb(0, 112, 112),
                  Color.FromArgb(0, 84, 112),
                  Color.FromArgb(0, 56, 112),
                  Color.FromArgb(0, 28, 112),
                  Color.FromArgb(56, 56, 112),
                  Color.FromArgb(68, 56, 112),
                  Color.FromArgb(84, 56, 112),
                  Color.FromArgb(96, 56, 112),
                  Color.FromArgb(112, 56, 112),
                  Color.FromArgb(112, 56, 96),
                  Color.FromArgb(112, 56, 84),
                  Color.FromArgb(112, 56, 68),
                  Color.FromArgb(112, 56, 56),
                  Color.FromArgb(112, 68, 56),
                  Color.FromArgb(112, 84, 56),
                  Color.FromArgb(112, 96, 56),
                  Color.FromArgb(112, 112, 56),
                  Color.FromArgb(96, 112, 56),
                  Color.FromArgb(84, 112, 56),
                  Color.FromArgb(68, 112, 56),
                  Color.FromArgb(56, 112, 56),
                  Color.FromArgb(56, 112, 68),
                  Color.FromArgb(56, 112, 84),
                  Color.FromArgb(56, 112, 96),
                  Color.FromArgb(56, 112, 112),
                  Color.FromArgb(56, 96, 112),
                  Color.FromArgb(56, 84, 112),
                  Color.FromArgb(56, 68, 112),
                  Color.FromArgb(80, 80, 112),
                  Color.FromArgb(88, 80, 112),
                  Color.FromArgb(96, 80, 112),
                  Color.FromArgb(104, 80, 112),
                  Color.FromArgb(112, 80, 112),
                  Color.FromArgb(112, 80, 104),
                  Color.FromArgb(112, 80, 96),
                  Color.FromArgb(112, 80, 88),
                  Color.FromArgb(112, 80, 80),
                  Color.FromArgb(112, 88, 80),
                  Color.FromArgb(112, 96, 80),
                  Color.FromArgb(112, 104, 80),
                  Color.FromArgb(112, 112, 80),
                  Color.FromArgb(104, 112, 80),
                  Color.FromArgb(96, 112, 80),
                  Color.FromArgb(88, 112, 80),
                  Color.FromArgb(80, 112, 80),
                  Color.FromArgb(80, 112, 88),
                  Color.FromArgb(80, 112, 96),
                  Color.FromArgb(80, 112, 104),
                  Color.FromArgb(80, 112, 112),
                  Color.FromArgb(80, 104, 112),
                  Color.FromArgb(80, 96, 112),
                  Color.FromArgb(80, 88, 112),
                  Color.FromArgb(0, 0, 64),
                  Color.FromArgb(16, 0, 64),
                  Color.FromArgb(32, 0, 64),
                  Color.FromArgb(48, 0, 64),
                  Color.FromArgb(64, 0, 64),
                  Color.FromArgb(64, 0, 48),
                  Color.FromArgb(64, 0, 32),
                  Color.FromArgb(64, 0, 16),
                  Color.FromArgb(64, 0, 0),
                  Color.FromArgb(64, 16, 0),
                  Color.FromArgb(64, 32, 0),
                  Color.FromArgb(64, 48, 0),
                  Color.FromArgb(64, 64, 0),
                  Color.FromArgb(48, 64, 0),
                  Color.FromArgb(32, 64, 0),
                  Color.FromArgb(16, 64, 0),
                  Color.FromArgb(0, 64, 0),
                  Color.FromArgb(0, 64, 16),
                  Color.FromArgb(0, 64, 32),
                  Color.FromArgb(0, 64, 48),
                  Color.FromArgb(0, 64, 64),
                  Color.FromArgb(0, 48, 64),
                  Color.FromArgb(0, 32, 64),
                  Color.FromArgb(0, 16, 64),
                  Color.FromArgb(32, 32, 64),
                  Color.FromArgb(40, 32, 64),
                  Color.FromArgb(48, 32, 64),
                  Color.FromArgb(56, 32, 64),
                  Color.FromArgb(64, 32, 64),
                  Color.FromArgb(64, 32, 56),
                  Color.FromArgb(64, 32, 48),
                  Color.FromArgb(64, 32, 40),
                  Color.FromArgb(64, 32, 32),
                  Color.FromArgb(64, 40, 32),
                  Color.FromArgb(64, 48, 32),
                  Color.FromArgb(64, 56, 32),
                  Color.FromArgb(64, 64, 32),
                  Color.FromArgb(56, 64, 32),
                  Color.FromArgb(48, 64, 32),
                  Color.FromArgb(40, 64, 32),
                  Color.FromArgb(32, 64, 32),
                  Color.FromArgb(32, 64, 40),
                  Color.FromArgb(32, 64, 48),
                  Color.FromArgb(32, 64, 56),
                  Color.FromArgb(32, 64, 64),
                  Color.FromArgb(32, 56, 64),
                  Color.FromArgb(32, 48, 64),
                  Color.FromArgb(32, 40, 64),
                  Color.FromArgb(44, 44, 64),
                  Color.FromArgb(48, 44, 64),
                  Color.FromArgb(52, 44, 64),
                  Color.FromArgb(60, 44, 64),
                  Color.FromArgb(64, 44, 64),
                  Color.FromArgb(64, 44, 60),
                  Color.FromArgb(64, 44, 52),
                  Color.FromArgb(64, 44, 48),
                  Color.FromArgb(64, 44, 44),
                  Color.FromArgb(64, 48, 44),
                  Color.FromArgb(64, 52, 44),
                  Color.FromArgb(64, 60, 44),
                  Color.FromArgb(64, 64, 44),
                  Color.FromArgb(60, 64, 44),
                  Color.FromArgb(52, 64, 44),
                  Color.FromArgb(48, 64, 44),
                  Color.FromArgb(44, 64, 44),
                  Color.FromArgb(44, 64, 48),
                  Color.FromArgb(44, 64, 52),
                  Color.FromArgb(44, 64, 60),
                  Color.FromArgb(44, 64, 64),
                  Color.FromArgb(44, 60, 64),
                  Color.FromArgb(44, 52, 64),
                  Color.FromArgb(44, 48, 64),
                  Color.FromArgb(0, 0, 0),
                  Color.FromArgb(0, 0, 0),
                  Color.FromArgb(0, 0, 0),
                  Color.FromArgb(0, 0, 0),
                  Color.FromArgb(0, 0, 0),
                  Color.FromArgb(0, 0, 0),
                  Color.FromArgb(0, 0, 0),
                  Color.FromArgb(0, 0, 0)
               };
      }
    }

    private static Color[] Sample16
    {
      get
      {
        return new[]
        {
          Color.FromArgb(0, 0, 0),
          Color.FromArgb(0, 0, 168),
          Color.FromArgb(0, 168, 0),
          Color.FromArgb(0, 168, 168),
          Color.FromArgb(168, 0, 0),
          Color.FromArgb(168, 0, 168),
          Color.FromArgb(168, 84, 0),
          Color.FromArgb(168, 168, 168),
          Color.FromArgb(84, 84, 84),
          Color.FromArgb(84, 84, 252),
          Color.FromArgb(84, 252, 84),
          Color.FromArgb(84, 252, 252),
          Color.FromArgb(252, 84, 84),
          Color.FromArgb(252, 84, 252),
          Color.FromArgb(252, 252, 84),
          Color.FromArgb(252, 252, 252)
        };
      }
    }

    private static string[] Sample16Names
    {
      get
      {
        return new[]
        {
          "        Alpha",
          "      Beta",
          "      Gamma",
          "    Delta",
          "      Epsilon",
          "    Zeta",
          "     Eta",
          "  Theta",
          "     Iota",
          "    Kappa",
          "    Lambda",
          "   Mu",
          "    Nu",
          "   Xi",
          "   Omnicron",
          "  Pi"
        };
      }
    }

    #endregion Private Properties

    #region Public Methods

    [Test]
    public void CanLoad_WithData_IsTrue()
    {
      // arrange
      FractintPaletteSerializer target;
      Stream data;
      bool actual;

      data = new MemoryStream(Data);

      target = new FractintPaletteSerializer();

      // act
      actual = target.CanLoad(data);

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    public void CanLoad_WithFileName_IsTrue()
    {
      // arrange
      FractintPaletteSerializer target;
      bool actual;
      string fileName;

      fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\default.map");

      target = new FractintPaletteSerializer();

      // act
      actual = target.CanLoad(fileName);

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    public void CanLoad_WithInvalid_isFalse()
    {
      // arrange
      FractintPaletteSerializer target;
      bool actual;
      byte[] data;

      target = new FractintPaletteSerializer();

      data = Encoding.ASCII.GetBytes("alpha beta gamma\r\ndelta epsilon zeta");

      // act
      actual = target.CanLoad(new MemoryStream(data));

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    public void Extensions_ReturnsValues()
    {
      // arrange
      FractintPaletteSerializer target;
      string[] expected;
      string[] actual;

      expected = new[]
                 {
                   "map"
                 };

      target = new FractintPaletteSerializer();

      // act
      actual = target.Extensions;

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Load_HandlesLessThan256Colors()
    {
      // arrange
      FractintPaletteSerializer target;
      Color[] expected;
      Color[] actual;
      string fileName;

      fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\16.map");
      expected = FractintPaletteSerializerTests.Sample16;

      target = new FractintPaletteSerializer();

      // act
      actual = target.Load(fileName);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Load_HandlesMoreThan256Colors()
    {
      // arrange
      FractintPaletteSerializer target;
      Color[] expected;
      Color[] actual;
      string fileName;

      fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\260.map");
      expected = Sample;
      Array.Resize(ref expected, 260);
      expected[256] = Color.FromArgb(0, 0, 0);
      expected[257] = Color.FromArgb(255, 0, 0);
      expected[258] = Color.FromArgb(0, 255, 0);
      expected[259] = Color.FromArgb(0, 0, 255);

      target = new FractintPaletteSerializer();

      // act
      actual = target.Load(fileName);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Load_HandlesNames()
    {
      // arrange
      FractintPaletteSerializer target;
      string[] expected;
      string fileName;

      fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\16.map");

      expected = FractintPaletteSerializerTests.Sample16Names;

      target = new FractintPaletteSerializer();

      // act
      target.Load(fileName, out string[] actual);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Load_WithData_ReturnsPalette()
    {
      // arrange
      FractintPaletteSerializer target;
      Color[] expected;
      Color[] actual;
      Stream data;

      data = new MemoryStream(Data);
      expected = Sample;

      target = new FractintPaletteSerializer();

      // act
      actual = target.Load(data);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Load_WithFileName_ReturnsPalette()
    {
      // arrange
      FractintPaletteSerializer target;
      Color[] expected;
      Color[] actual;
      string fileName;

      fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\default.map");
      expected = Sample;

      target = new FractintPaletteSerializer();

      // act
      actual = target.Load(fileName);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Save_WritesNames()
    {
      // arrange
      FractintPaletteSerializer target;
      MemoryStream output;
      Color[] data;
      string[] names;
      string expected;
      string actual;

      expected = @"0 0 0         Alpha
0 0 168       Beta
0 168 0       Gamma
0 168 168     Delta
168 0 0       Epsilon
168 0 168     Zeta
168 84 0      Eta
168 168 168   Theta
84 84 84      Iota
84 84 252     Kappa
84 252 84     Lambda
84 252 252    Mu
252 84 84     Nu
252 84 252    Xi
252 252 84    Omnicron
252 252 252   Pi
";
      output = new MemoryStream();
      data = FractintPaletteSerializerTests.Sample16;
      names = FractintPaletteSerializerTests.Sample16Names;

      target = new FractintPaletteSerializer();

      // act
      target.Save(output, data, names);

      // assert
      actual = Encoding.UTF8.GetString(output.ToArray());
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Save_WritesValueData()
    {
      // arrange
      FractintPaletteSerializer target;
      MemoryStream output;
      Color[] data;
      byte[] expected;
      byte[] actual;

      expected = Data;
      output = new MemoryStream();
      data = Sample;

      target = new FractintPaletteSerializer();

      // act
      target.Save(output, data);

      // assert
      actual = output.ToArray();
      CollectionAssert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}