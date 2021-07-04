
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using Snitz.Base;
using PetaPoco;
using SnitzConfig;


namespace PhotoAlbum.Models
{
    [TableName("IMAGE_CAT",prefixType = Extras.TablePrefixTypes.Forum)]
    [PrimaryKey("CAT_ID")]
    [ExplicitColumns]
    public class AlbumCategory
    {
        [Column("CAT_ID")]
        public int CatId { get; set; }
        [Column("MEMBER_ID")]
        public int MemberId { get; set; }
        [Column("CAT_DESC")]
        public string Description { get; set; }
    }

    [TableName("IMAGES", prefixType = Extras.TablePrefixTypes.Forum)]
    [PrimaryKey("I_ID")]
    [ExplicitColumns]
    public class AlbumImage
    {
        [Column("I_ID")]
        public int Id { get; set; }

        [Column("I_MID")]
        public int MemberId { get; set; }
        [Column("I_CAT")]
        public int CatId { get; set; }

        [Column("I_WIDTH")]
        public int Width { get; set; }
        [Column("I_HEIGHT")]
        public int Height { get; set; }
        [Column("I_SIZE")]
        public int Size { get; set; }
        [Column("I_VIEWS")]
        public int Views { get; set; }

        /// <summary>
        /// Original FileName
        /// </summary>
        [Column("I_LOC")]
        public string Location { get; set; }
        [Column("I_DESC")]
        public string Description { get; set; }
        [Column("I_TYPE")]
        public string Mime { get; set; }

        [Column("I_DATE")]
        public string Timestamp { get; set; }

        [Column("I_GROUP_ID")]
        public int Group { get; set; }

        [Column("I_SCIENTIFICNAME")]
        public string ScientificName { get; set; }

        [Column("I_NORWEGIANNAME")]
        public string CommonName { get; set; }
        /// <summary>
        /// Do not show to other Members
        /// </summary>
        [Column("I_PRIVATE")]
        public bool IsPrivate { get; set; }
        /// <summary>
        /// DO not use as Featured Image
        /// </summary>
        [Column("I_NOTFEATURED")]
        public bool DoNotFeature { get; set; }

        [ResultColumn]
        public string MemberName { get; set; }
        [ResultColumn]
        public string GroupName { get; set; }
        [ResultColumn]
        public string ImageName { get; set; }

        //public byte[] ImageData { get; set; }

        public System.Drawing.Image Img { get; set; }

        public void GenerateThumbnail()
        {
            var rootfolder = this.RootFolder;
            
            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/" + rootfolder + "/PhotoAlbum/thumbs/")))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/" + rootfolder + "/PhotoAlbum/thumbs/"));
            }
            HttpContext.Current.Response.ContentType = "image/bmp";

            string fullFileName =
                HttpContext.Current.Server.MapPath("~/" + rootfolder + "/PhotoAlbum/" + this.ImageName);
            string thumbFileName =
                HttpContext.Current.Server.MapPath("~/" + rootfolder + "/PhotoAlbum/thumbs/" + this.ImageName);

            Image image = Image.FromFile(fullFileName);
            ImageCodecInfo jpgInfo = ImageCodecInfo.GetImageEncoders().First(codecInfo => codecInfo.MimeType == "image/jpeg");


            try
            {
                var thumbSize = ClassicConfig.GetIntValue("INTMAXTHUMBSIZE");
                var finalImage = ClassicConfig.GetValue("STRTHUMBTYPE") == "scaled" ? Extras.ScaleImage(image, thumbSize, thumbSize) : Extras.CropImage(image, thumbSize, thumbSize);
                using (EncoderParameters encParams = new EncoderParameters(1))
                {
                    encParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)100);
                    //quality should be in the range [0..100] .. 100 for max, 0 for min (0 best compression)
                    finalImage.Save(thumbFileName, jpgInfo, encParams);
                }
                finalImage.Dispose();
            }
            catch { }


            image.Dispose();            
        }

        private static Image SquareThumbnail(Image image)
        {
            Bitmap bitmap=null;
            Image finalImage=null;
            try
            {
                int left = 0;
                int top = 0;
                int targetWidth = 80;
                int srcWidth;
                int targetHeight = 80;
                int srcHeight;
                bitmap = new System.Drawing.Bitmap(80, 80);
                double croppedHeightToWidth = (double) targetHeight/targetWidth;
                double croppedWidthToHeight = (double) targetWidth/targetHeight;

                if (image.Width > image.Height)
                {
                    srcWidth = (int) (Math.Round(image.Height*croppedWidthToHeight));
                    if (srcWidth < image.Width)
                    {
                        srcHeight = image.Height;
                        left = (image.Width - srcWidth)/2;
                    }
                    else
                    {
                        srcHeight = (int) Math.Round(image.Height*((double) image.Width/srcWidth));
                        srcWidth = image.Width;
                        top = (image.Height - srcHeight)/2;
                    }
                }
                else
                {
                    srcHeight = (int) (Math.Round(image.Width*croppedHeightToWidth));
                    if (srcHeight < image.Height)
                    {
                        srcWidth = image.Width;
                        top = (image.Height - srcHeight)/2;
                    }
                    else
                    {
                        srcWidth = (int) Math.Round(image.Width*((double) image.Height/srcHeight));
                        srcHeight = image.Height;
                        left = (image.Width - srcWidth)/2;
                    }
                }
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        new Rectangle(left, top, srcWidth, srcHeight), GraphicsUnit.Pixel);
                }
                finalImage = bitmap;
            }
            catch
            {
            }
            finally
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
            }
            return finalImage;
        }

        
        public string RootFolder
        {
            get
            {
                if (ClassicConfig.GetIntValue("INTPROTECTCONTENT") == 1 &&
                    ClassicConfig.GetIntValue("INTPROTECTPHOTO") == 1)
                {
                    return "ProtectedContent";
                }
                return "Content";
            }
        }

    }

    [TableName("ORG_GROUP", prefixType = Extras.TablePrefixTypes.Forum)]
    [PrimaryKey("O_GROUP_ID")]
    [ExplicitColumns]
    public class AlbumGroup
    {
        [Column("O_GROUP_ID")]
        public int Id { get; set; }
        [Column("O_GROUP_ORDER")]
        public int Order { get; set; }
        [Column("O_GROUP_NAME")]
        public string Description { get; set; }
    }

    public class AlbumList
    {
        //a.MEMBER_ID, a.M_NAME, Count(b.I_ID) AS imgCount, Max(b.I_DATE) AS imgLDate
        [Column("MEMBER_ID")]
        public int MemberId { get; set; }
        [Column("M_NAME")]
        public string Username { get; set; }

        [ResultColumn]
        public int imgCount { get; set; }
        [ResultColumn]
        public string imgLastUpload { get; set; }


    }

    public class Slider
    {
        public string Src { get; set; }
        public string Title { get; set; }
    }
}