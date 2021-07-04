using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace PhotoAlbum.Models
{
    public class ThumbnailResult : ActionResult
    {

        public ThumbnailResult(int id)
        {
            string virtualPath = "";
            this.FolderRoot = "Content";
            using (var data = new PhotoRepository(-1))
            {
                _img = data.GetEntryById(id);
                virtualPath = _img.Timestamp + "_" + _img.Location;
                this.FolderRoot = _img.RootFolder;
            }
            this.VirtualPath = virtualPath;
        }
        public string VirtualPath { get; set; }
        public string FolderRoot { get; set; }
        private AlbumImage _img { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "image/bmp";

            string fullFileName = 
                context.HttpContext.Server.MapPath("~/" + this.FolderRoot + "/PhotoAlbum/thumbs/" + VirtualPath);
            if (!File.Exists(fullFileName))
            {
                fullFileName =
                    context.HttpContext.Server.MapPath("~/" + this.FolderRoot + "/PhotoAlbum/thumbs/" + _img.Location);
            }


            try
            {
                Image image = Image.FromFile(fullFileName);
                ImageCodecInfo jpgInfo = ImageCodecInfo.GetImageEncoders().First(codecInfo => codecInfo.MimeType == "image/jpeg");
                Image finalImage = image;

                using (EncoderParameters encParams = new EncoderParameters(1))
                {
                    encParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)100);
                    //quality should be in the range [0..100] .. 100 for max, 0 for min (0 best compression)
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        finalImage.Save(ms, jpgInfo, encParams);
                        context.HttpContext.Response.BinaryWrite(ms.ToArray());
                        context.HttpContext.Response.End();
                    }
                }
                image.Dispose();
            }
            catch { }


        }
    }
}