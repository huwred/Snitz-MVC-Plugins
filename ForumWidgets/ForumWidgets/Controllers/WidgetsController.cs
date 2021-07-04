using System.Web.Mvc;
using ForumWidgets.Models;
using SnitzCore.Filters;
using SnitzDataModel.Controllers;
using SnitzDataModel.Extensions;


namespace ForumWidgets.Controllers
{

    public class WidgetsController : BaseController
    {
        [DoNotLogActionFilter]
        public ContentResult Display(string name)
        {
            string htmlText = null;
            using (WidgetRepository b = new WidgetRepository())
            {
                htmlText = b.GetByName(name);
            }
            if(htmlText != null)
                return Content("<div class='side-box hidden-xs'>" + htmlText + "</div>");

            return Content("");
        }
        //
        // GET: /Widgets/
        /// <summary>
        /// Returns a list of widgets
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult Admin()
        {
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }
            using (WidgetRepository b = new WidgetRepository())
            {
                ViewBag.PageCount = b.Pagecount;
                ViewBag.PageSize = 10;
                return View(b.GetAllWidgets());
            }

            
        }

        //
        // GET: /Widget/Add
        /// <summary>
        /// Add a Html Widget
        /// </summary>
        /// <param name="id">Id of Topic</param>
        /// <param name="returnUrl">Url of calling page</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpPost,ValidateInput(false)]
        public ContentResult Add(ForumWidget widget)
        {
            using (WidgetRepository b = new WidgetRepository())
            {
                b.AddForumWidget(widget.Name, widget.HtmlString);
            }

            return Content("Success");

        }

        public PartialViewResult AddWidget()
        {
            return PartialView("popAddWidget",new ForumWidget());

        }
        //
        // GET: /Widget/Delete/5
        /// <summary>
        /// Remove a Widget
        /// </summary>
        /// <param name="id">Id of Widget</param>
        /// <param name="returnUrl">Url of calling page</param>
        /// <returns></returns>   
        [Authorize(Roles = "Administrator")]     
        public ActionResult Delete(int id)
        {
            using (WidgetRepository b = new WidgetRepository())
            {
                b.DeleteWidget(id);
                TempData["Success"] = "Widget Deleted";
            }

            return RedirectToAction("Admin");

        }
        [HttpPost,ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Save(ForumWidget widget)
        {
            if (ModelState.IsValid)
            {
                using (WidgetRepository b = new WidgetRepository())
                {
                    b.SaveWidget(widget);
                }
                TempData["Success"] = "Widget Saved";
            }
            return RedirectToAction("Admin");
        }
    }
}
