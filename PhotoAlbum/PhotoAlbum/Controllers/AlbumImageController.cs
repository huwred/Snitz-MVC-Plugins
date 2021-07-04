using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using PhotoAlbum.Models;

namespace PhotoAlbum.Controllers
{
    public class AlbumImageController : ApiController
    {
        //
        // POST: /AlbumImage/
        //[KeyAuthorize]
        [Route("api/albumimage")]
        [System.Web.Http.AcceptVerbs("GET","POST")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] PostedImage image)
        {
            var logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Debug("/AlbumImage/Post " + image.FileName);
            AlbumImage newimage = new AlbumImage();
            newimage.Timestamp = image.Date;
            newimage.MemberId = image.UserId;
            newimage.Description = image.Description;
            newimage.Group = 0;
            newimage.Location = image.FileName;
            newimage.Width = image.Width;
            newimage.Height = image.Height;
            newimage.Size = image.Size;

            try
            {
                logger.Debug("/AlbumImage/Post AddAPIImage " + newimage.MemberId);
                var id = new PhotoRepository().AddAPIImage(newimage);
                logger.Debug("/AlbumImage/Post AddAPIImage result " + id);
                return Request.CreateResponse(HttpStatusCode.OK, id);

            }
            catch (Exception ex)
            {
                logger.Error("/AlbumImage/Post AddAPIImage Error:" + ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "AlbumImage/Post" + ex.Message);
            }
        }

    }

    public class PostedImage
    {
        public string FileName { get; set; }
        public string Description { get; set; }
        //public FileInfo File { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
    }
}
