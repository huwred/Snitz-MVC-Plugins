using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Web.Helpers;

namespace PhotoAlbum.Helpers
{
    public static class WebImageExtension
    {
        private static readonly IDictionary<string, ImageFormat> TransparencyFormats =
            new Dictionary<string, ImageFormat>(StringComparer.OrdinalIgnoreCase) { { "png", ImageFormat.Png }, { "gif", ImageFormat.Gif } };

        public static WebImage ResizeIt(this WebImage image, int width)
        {
            double aspectRatio = (double)image.Width / image.Height;
            var height = Convert.ToInt32(width / aspectRatio);

            ImageFormat format;

            if (!TransparencyFormats.TryGetValue(image.ImageFormat.ToLower(), out format))
            {
                return image.Resize(width, height);
            }

            using (Image resizedImage = new Bitmap(width, height))
            {
                using (var source = new Bitmap(new MemoryStream(image.GetBytes())))
                {
                    using (Graphics g = Graphics.FromImage(resizedImage))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(source, 0, 0, width, height);
                    }
                }

                using (var ms = new MemoryStream())
                {
                    resizedImage.Save(ms, format);
                    return new WebImage(ms.ToArray());
                }
            }
        }
    }
    public static class AlbumExtensions
    {
        public static IEnumerable<int> StringToIntList(string str)
        {
            if (String.IsNullOrEmpty(str))
                yield break;

            foreach (var s in str.Split(','))
            {
                int num;
                if (int.TryParse(s, out num))
                    yield return num;
            }
        }
        public static bool Contains(this string source, string toCheck, CompareOptions comp)
        {
            if (source == null)
                return false;
            return CultureInfo.CurrentCulture.CompareInfo.IndexOf(source, toCheck, comp) >= 0;
        }

        public static string GetSafeFilename(string filename)
        {

            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));

        }
    }
}