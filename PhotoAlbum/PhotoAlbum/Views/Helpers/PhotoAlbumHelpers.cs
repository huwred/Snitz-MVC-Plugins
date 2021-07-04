using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using LangResources.Utility;
using SnitzConfig;

namespace PhotoAlbum.Views.Helpers
{
    public static class PhotoAlbumHelpers
    {
        public static string CurrentAction(this UrlHelper urlHelper)
        {
            var routeValueDictionary = urlHelper.RequestContext.RouteData.Values;
            // in case using virtual dirctory 
            var rootUrl = urlHelper.Content("~/");
            return string.Format("{0}{1}/{2}/", rootUrl, routeValueDictionary["controller"], routeValueDictionary["action"]);
        }

            public static string ImageUrlFor(this HtmlHelper helper, string filename, string date,bool thumbnail=false)
            {
                UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                string imgpath = urlHelper.Content("~/Content/PhotoAlbum/");
                if (ClassicConfig.GetIntValue("INTPROTECTCONTENT") == 1 &&
                    ClassicConfig.GetIntValue("INTPROTECTPHOTO") == 1)
                {
                    imgpath = urlHelper.Content("~/ProtectedContent/PhotoAlbum/");
                }
                if (thumbnail)
                {
                    imgpath += "thumbs/";
                }
            // Put some caching logic here if you want it to perform better
                if (!File.Exists(helper.ViewContext.HttpContext.Server.MapPath(imgpath + filename)))
                {
                    if (!File.Exists(helper.ViewContext.HttpContext.Server.MapPath(imgpath + date + "_" + filename)))
                    {
                            return urlHelper.Content("~/content/images/notfound_lg.jpg");
                }
                    return urlHelper.Content(imgpath + date + "_" + filename);
                }
            return urlHelper.Content(imgpath + filename);
        }

        public static MvcHtmlString ActionLinkConfirm(this HtmlHelper helper, string title, string action, string controller, object routeValues, string tagclass)
        {
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

            var tagid = Guid.NewGuid().ToString();

            var tag = new TagBuilder("a");
            tag.MergeAttribute("href", "#");
            tag.MergeAttribute("title", title);
            tag.MergeAttribute("data-toggle", "tooltip");
            tag.MergeAttribute("rel", "nofollow");
            tag.MergeAttribute("onclick", "BootstrapDialog.confirm({title: '" + title + "', message: '" + ResourceManager.GetLocalisedString("Are_you_sure", "labels") + "', callback: function(ok) {if(ok) $('#" + tagid + "')[0].click(); } })");
            tag.InnerHtml = "<i class='" + tagclass + "'></i>";

            var hiddentag = new TagBuilder("a");
            hiddentag.AddCssClass("hidden");
            hiddentag.MergeAttribute("id", tagid);
            hiddentag.MergeAttribute("href", urlHelper.Action(action, controller, routeValues));

            var sb = new StringBuilder();
            sb.AppendLine(hiddentag.ToString(TagRenderMode.Normal));
            sb.AppendLine(tag.ToString(TagRenderMode.Normal));

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        } 
    }
}