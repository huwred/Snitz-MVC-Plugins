using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BbCodeFormatter;
using ImageComments.Models;
using LangResources.Utility;
using Postal;
using SnitzConfig;
using SnitzCore.Extensions;
using SnitzDataModel.Controllers;
using SnitzDataModel.Database;
using SnitzDataModel.Models;
using SnitzMembership;
using SnitzMembership.Models;

namespace ImageComments.Controllers
{
    public class ImageCommentController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comments(int id, int pagenum = 1)
        {
            ViewBag.ImageId = id;
            ViewBag.NewPost = null;
            using (CommentRepository db = new CommentRepository())
            {
                ViewBag.AuthorId = db.GetMemberId(id);
                var vm = db.GetComments(id);
                return View(vm);
            }

        }

        public PartialViewResult ShowComments(int id)
        {
            ViewBag.Comments = ResourceManager.GetLocalisedString("lblNo","labels");

            using (CommentRepository db = new CommentRepository())
            {
                var vm = db.GetComments(id);
                if (vm.Count > 0)
                {
                    ViewBag.Comments = ResourceManager.GetLocalisedString("lblYes", "labels");
                }
                ViewBag.AuthorId = db.GetMemberId(id);
            }
            return PartialView("_CommentIcon", id);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(FormCollection form)
        {
            using (SnitzDataContext db = new SnitzDataContext())
            {
                ImageComment comment = new ImageComment();
                comment.ImageId = Convert.ToInt32(form["ImageId"]);
                comment.Comment = form["Comment"];
                comment.MemberId = WebSecurity.CurrentUserId;
                comment.TimeStamp = DateTime.UtcNow.ToSnitzDate();
                db.Save(comment);

            }
            UserProfile author = null;
            using (CommentRepository db = new CommentRepository())
            {
                int id = db.GetMemberId(Convert.ToInt32(form["ImageId"]));
                author = MemberManager.GetUser(id);
            }
            var user = MemberManager.GetUser(WebSecurity.CurrentUserName);
            PrivateMessage msg = new PrivateMessage
            {
                ToUsername = author.UserName,
                ToMemberId = author.UserId,
                FromMemberId = WebSecurity.CurrentUserId,
                Subject = ResourceManager.GetLocalisedString("CommentedOnImage", "PhotoAlbum"),// "You were mentioned in a Post",
                Message = String.Format(ResourceManager.GetLocalisedString("CommentedOnMessage", "PhotoAlbum"), WebSecurity.CurrentUserName, Config.ForumUrl.Trim(), form["ImageId"]),
                SentDate = DateTime.UtcNow,
                Read = 0,
                ShowOutBox = 0
            };
            msg.Save();
            if (author.PrivateMessageNotify == 1 && ClassicConfig.AllowEmail)
            {
                SendImageCommentNotification(author, user,form["ImageId"]);
            }
            using (CommentRepository db2 = new CommentRepository())
            {
                var vm = db2.GetComments(Convert.ToInt32(form["ImageId"]));
                ViewBag.NewPost = true;
                return View("Comments",vm);
            }

        }

        [Authorize]
        public ActionResult DelComment(int id, int imgid)
        {

            using (CommentRepository db = new CommentRepository())
            {
                db.Delete(id);
                var vm = db.GetComments(imgid);
                ViewBag.NewPost = true;
                return View("Comments", vm);
            }

        }

        public static void SendImageCommentNotification(UserProfile recipient, UserProfile sender, string imageid)
        {
            if (!ClassicConfig.AllowEmail)
                return;
            dynamic email = new Email("ImageCommentEmail");
            email.To = recipient.Email;
            email.Subject = ResourceManager.GetLocalisedString("CommentedOnImage", "PhotoAlbum");
            email.Username = recipient.UserName;
            email.Sender = ClassicConfig.ForumEmail;
            email.FromUsername = sender.UserName;
            email.ForumTitle = BbCodeProcessor.Format(Config.ForumTitle, false, false);
            email.Imagelink = String.Format("{0}ImageComment/Comments/{1}?pagenum=-1", Config.ForumUrl, imageid);
            email.Send();
        }


    }
}