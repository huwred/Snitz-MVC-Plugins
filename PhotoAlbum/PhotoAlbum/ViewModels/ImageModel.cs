using System.Collections.Generic;
using PhotoAlbum.Models;

namespace PhotoAlbum.ViewModels
{
    public class ImageModel
    {
        List<string> _images = new List<string>();

        public ImageModel()
        {
            _images = new List<string>();
        }

        public List<string> Images
        {
            get { return _images; }
            set { _images = value; }
        }
        public AlbumImage CurrentImage { get; set; }
        public int CurrentIdx { get; set; }
    }
}