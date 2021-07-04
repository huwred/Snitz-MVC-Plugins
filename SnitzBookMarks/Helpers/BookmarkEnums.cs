using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BookMarks.Helpers
{
    public static class BookmarkEnums
    {
        //public enum ActiveRefresh
        //{
        //    None = 0,
        //    Minute = 60,
        //    FiveMinute = 300,
        //    TenMinute = 600,
        //    FifteenMinute = 900
        //}

        public enum ActiveTopicsSince
        {
            All=0,
            LastVisit,
            LastHour,
            LastDay,
            LastWeek,
            LastMonth,
            Registration
        }
    }

    public static class HtmlHelpers
    {
        public static MvcHtmlString ActionLinkConfirm(this HtmlHelper helper, string title, string action, string controller, object routeValues, string tagclass, bool btn = false)
        {
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

            var tagid = Guid.NewGuid().ToString();

            var tag = new TagBuilder("a");
            tag.MergeAttribute("href", "#");

            tag.MergeAttribute("title", title);
            tag.MergeAttribute("data-toggle", "tooltip");
            tag.MergeAttribute("rel", "nofollow");
            tag.MergeAttribute("onclick", "BootstrapDialog.confirm({title: '" + title + "', message: '" + LangResources.Utility.ResourceManager.GetLocalisedString("Are_you_sure", "labels") + "', callback: function(ok) {if(ok) $('#" + tagid + "')[0].click(); } })");
            if (btn)
            {
                tag.MergeAttribute("class", tagclass);
                tag.InnerHtml = title;
            }
            else
            {
                tag.InnerHtml = "<i class='" + tagclass + "'></i>";
            }


            var hiddentag = new TagBuilder("a");
            hiddentag.AddCssClass("hidden");
            hiddentag.MergeAttribute("id", tagid);
            hiddentag.MergeAttribute("href", urlHelper.Action(action, controller, routeValues));

            var sb = new StringBuilder();
            sb.AppendLine(hiddentag.ToString(TagRenderMode.Normal));
            sb.AppendLine(tag.ToString(TagRenderMode.Normal));

            return new MvcHtmlString(sb.ToString());
        }

    }
}