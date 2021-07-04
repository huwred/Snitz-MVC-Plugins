using System;
using System.Web.Mvc;
using PostThanks.Models;
using SnitzDataModel.Controllers;
using SnitzMembership;


namespace PostThanks.Controllers
{
    
    public class PostThanksController : BaseController
    {
        //
        // GET: /PostThanks/
        /// <summary>
        /// Displays Icon for Post Thanks
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <param name="replyid"></param>
        /// <param name="showcount"></param>
        /// <returns></returns>
        public ActionResult Index(int id, int replyid = 0, bool showcount = false, bool showlink = true)
        {

            if (!PostThanksRepository.IsAllowedForum(id))
            {
                return new EmptyResult();
            }
            using (PostThanksRepository b = new PostThanksRepository(WebSecurity.CurrentUserId))
            {

                var vm = new PostThanksViewModel
                {
                    UserId = WebSecurity.CurrentUserId,
                    TopicId = id,
                    ReplyId = replyid,
                    Thanked = false,
                    ShowCount = showcount,
                    Showlink = showlink
                };
                vm.Thanked = b.IsThanked(id, replyid);
                vm.ThanksCount = b.Count(id, replyid);
                vm.PostAuthor = b.IsAuthor(id, replyid);

                return PartialView("_Thanks", vm);
            }


        }



        //
        // GET: /Thank
        /// <summary>
        /// Thanks a postc
        /// </summary>
        /// <param name="id">Id of Topic</param>
        /// <param name="replyid"></param>
        /// <param name="returnUrl">Url of calling page</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult Thank(int id, int replyid, string returnUrl)
        {
            using (PostThanksRepository b = new PostThanksRepository(WebSecurity.CurrentUserId))
            {
                b.AddThanks(id, replyid);
            }

            return Redirect(returnUrl + "#" + replyid);

        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult Members(int id, int replyid)
        {
            using (PostThanksRepository b = new PostThanksRepository(WebSecurity.CurrentUserId))
            {
                var members = b.Members(id, replyid);
                return PartialView("_Members", members);
            }

        }

        /// <summary>
        /// Un Thank
        /// </summary>
        /// <param name="replyid"></param>
        /// <param name="returnUrl"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UnThank(int id, int replyid, string returnUrl = "")
        {
            using (PostThanksRepository b = new PostThanksRepository(WebSecurity.CurrentUserId))
            {

                b.DeleteThanks(id, replyid);
            }
            //return View(form);
            return Redirect(returnUrl + "#" + replyid);

        }

        #region Admin
        public PartialViewResult ForumThanks(int id)
        {
            ViewBag.ForumId = id;
            ViewBag.IsAllowed = PostThanksRepository.IsForumAllowed(id);
            return PartialView("_ForumSetting");
        }

        public ActionResult ForumSettings(int id, string check)
        {
            try
            {
                PostThanksRepository.SetAllowThanks(id, check=="true"?1:0);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Problem updating F_ALLOWTHANKS in Forum";
                ViewBag.ErrTitle = "Error: Thanks";
                return View("_Error");
            }

            return new EmptyResult();
        }
        #endregion

        #region Profile
        public PartialViewResult ThanksProfile(int id)
        {
            var vm = new PostThanksProfile
            {
                Received = PostThanksRepository.MemberCountReceived(id),
                Given = PostThanksRepository.MemberCountGiven(id)
            };


            return PartialView("_Profile", vm);

        }

        #endregion

    }
}
