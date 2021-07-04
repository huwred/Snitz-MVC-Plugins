using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookMarks.Helpers;
using BookMarks.Models;
using LangResources.Utility;
using Snitz.Base;
using SnitzDataModel.Controllers;
using SnitzDataModel.Models;
using SnitzMembership;


namespace WWW.Controllers
{
    public class BookmarkController : BaseController
    {
        //
        // GET: /Bookmark/
        /// <summary>
        /// Returns a list of users bookmarks
        /// </summary>
        /// <param name="userid">Id of the user</param>
        /// <param name="pagenum"></param>
        /// <returns></returns>
        public ActionResult Index(int userid = 0, int pagenum = 1, BookmarkEnums.ActiveTopicsSince activesince = BookmarkEnums.ActiveTopicsSince.LastVisit, Enumerators.ActiveRefresh refresh = Enumerators.ActiveRefresh.None, bool readcookie = true)
        {
            var vm = new BookmarkViewModel();
            if (userid == 0)
            {
                userid = WebSecurity.CurrentUserId;
            }
            vm.UserId = userid;

            var refreshcookie = SnitzCookie.GetCookieValue("BookmarkRefresh");
            ViewBag.Page = pagenum;

            if (refreshcookie != null && refresh == Enumerators.ActiveRefresh.None)
            {
                refresh = (Enumerators.ActiveRefresh)(Convert.ToInt32(refreshcookie));
            }
            if (readcookie)
            {
                var activesinceCookie = SnitzCookie.GetCookieValue("BookmarksSince");
                if (activesinceCookie != null)
                {
                    activesince = (BookmarkEnums.ActiveTopicsSince)(Convert.ToInt32(activesinceCookie));
                }

            }
            using (BookmarkRepository b = new BookmarkRepository(userid))
            {
                var user = MemberManager.GetUser(userid);
                ViewBag.PageCount = b.Pagecount;
                vm.Bookmarks = b.GetPaged(pagenum,activesince,SnitzCookie.GetLastVisitDate(),user.Created);
                
            }
            vm.ActiveSince = activesince;
            vm.Refresh = refresh;

            ViewBag.RefreshSeconds = (int)vm.Refresh * 1000;
            SnitzCookie.SetCookie("BookmarkRefresh", ((int)vm.Refresh).ToString());
            SnitzCookie.SetCookie("BookmarksSince", ((int)activesince).ToString());
           
            
            return View(vm);
        }

        //
        // GET: /Bookmark/Add
        /// <summary>
        /// Bookmark a Topic
        /// </summary>
        /// <param name="id">Id of Topic</param>
        /// <param name="returnUrl">Url of calling page</param>
        /// <returns></returns>
        public ActionResult Add(int id, string returnUrl)
        {
            using (BookmarkRepository b = new BookmarkRepository(WebSecurity.CurrentUserId))
            {
                b.AddBookMark(id);
            }
            
            return Redirect(returnUrl);

        }

        //
        // GET: /Bookmark/Delete/5
        /// <summary>
        /// Remove a Bookmark
        /// </summary>
        /// <param name="id">Id of Bookmark</param>
        /// <param name="returnUrl">Url of calling page</param>
        /// <returns></returns>        
        public ActionResult Delete(int id, string returnUrl)
        {
            using (BookmarkRepository b = new BookmarkRepository(WebSecurity.CurrentUserId))
            {
                b.DeleteBookMark(id);
            }
            TempData["successMessage"] = ResourceManager.GetLocalisedString("Deleted","Bookmarks");
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);

        }

        /// <summary>
        /// Remove selected Bookmarks
        /// </summary>
        /// <param name="form"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(FormCollection form, string returnUrl)
        {
            List<int> bookmarks = StringToIntList(form["delete-me"]).ToList();

            using (BookmarkRepository b = new BookmarkRepository(WebSecurity.CurrentUserId))
            {
                b.DeleteBookMarks(bookmarks);
            }
            //return View(form);
            return Redirect(returnUrl);

        }

        [NonAction]
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
    }
}
