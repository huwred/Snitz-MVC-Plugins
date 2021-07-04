
using System.Web.Mvc;
using ForumWidgets.Models;



namespace WWW.Controllers
{

    public class WidgetsController : BaseController
    {
        public ActionResult Display(string name)
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
        [HttpPost]
        public ActionResult Add(ForumWidget widget)
        {
            using (WidgetRepository b = new WidgetRepository())
            {
                b.AddForumWidget(widget.Name, widget.HtmlString);
            }

            return Content("Success");

        }

        public ActionResult AddWidget()
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
            }

            return RedirectToAction("Admin");

        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Save(ForumWidget widget)
        {
            if (ModelState.IsValid)
            {
                using (WidgetRepository b = new WidgetRepository())
                {
                    b.SaveWidget(widget);
                }                
            }
            return RedirectToAction("Admin");
        }
    }
}
