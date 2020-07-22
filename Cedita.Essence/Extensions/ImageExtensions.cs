// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http.Headers;

namespace Cedita.Essence.Extensions
{
    public static class ImageExtensions
    {
        public static string ImageToBase64(this string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return string.Empty;
            }

            var data = File.ReadAllBytes(filename);
            return Convert.ToBase64String(data);
        }

        public static Bitmap Base64StringToImage(this string base64String)
        {
            Bitmap bmpReturn = null;

            var byteBuffer = Convert.FromBase64String(base64String);

            using (var memoryStream = new MemoryStream(byteBuffer))
            {
                memoryStream.Position = 0;
                bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);
            }

            byteBuffer = null;

            return bmpReturn;
        }

        public static Bitmap MakeImageGrayscale(this Bitmap original)
        {
            var newBitmap = new Bitmap(original.Width, original.Height);

            using (var g = Graphics.FromImage(newBitmap))
            {
                var colorMatrix = new ColorMatrix(
                   new float[][]
                   {
                        new float[] {.3f, .3f, .3f, 0, 0},
                        new float[] {.59f, .59f, .59f, 0, 0},
                        new float[] {.11f, .11f, .11f, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1},
                   });

                using (var attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }

            return newBitmap;
        }

        public static Image ConvertImage(this string filename, string outExt)
        {
            if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(outExt))
            {
                return null;
            }

            var name = Path.GetFileNameWithoutExtension(filename);
            var path = Path.GetDirectoryName(filename);
            var image = Image.FromFile(filename);

            var format = ImageFormat.Icon;

            switch (outExt.ToLowerInvariant())
            {
                case "png":
                    format = ImageFormat.Png;
                    break;
                case "jpg":
                case "jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case "gif":
                    format = ImageFormat.Gif;
                    break;
                case "tif":
                case "tiff":
                    format = ImageFormat.Tiff;
                    break;
                case "bmp":
                    format = ImageFormat.Bmp;
                    break;
            }

            if (format != ImageFormat.Icon)
            {
                image.Save(path + @"/" + name + "." + outExt.ToLowerInvariant(), format);
            }

            return image;
        }
    }
}
