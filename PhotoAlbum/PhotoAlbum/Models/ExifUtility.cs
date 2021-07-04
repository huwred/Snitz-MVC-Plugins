using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace PhotoAlbum.Models
{


    public class ExifUtility
    {
        public StringBuilder GetImageExif(string imagePath)
        {
            var data = new StringBuilder();

            var directories = ImageMetadataReader.ReadMetadata(imagePath);

// print out all metadata
            foreach (var directory in directories)
            foreach (var tag in directory.Tags)
                data.AppendLine($"{directory.Name} - {tag.Name} = {tag.Description}");

// access the date time
            var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            var dateTime = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTime);
            data.AppendLine(dateTime.ToString());
            return data;
        }
    }
}