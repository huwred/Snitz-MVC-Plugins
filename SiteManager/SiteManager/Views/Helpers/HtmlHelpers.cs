using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteManage.Extras;
using SnitzCore.Extensions;
using SnitzDataModel.Extensions;

namespace SiteManage.Views.Helpers
{
    public static class HtmlHelpers
    {
        public static string FormatKB(this HtmlHelper helper, long fileLength)
        {
            return string.Format("{0:N0}", (fileLength / 1024));
        }

        private class ScriptBlock : IDisposable
        {
            private const string scriptsKey = "scripts";
            public static List<string> pageScripts
            {
                get
                {
                    if (HttpContext.Current.Items[scriptsKey] == null)
                        HttpContext.Current.Items[scriptsKey] = new List<string>();
                    return (List<string>)HttpContext.Current.Items[scriptsKey];
                }
            }

            WebViewPage webPageBase;

            public ScriptBlock(WebViewPage webPageBase)
            {
                this.webPageBase = webPageBase;
                this.webPageBase.OutputStack.Push(new StringWriter());
            }

            public void Dispose()
            {
                pageScripts.Add(((StringWriter)this.webPageBase.OutputStack.Pop()).ToString());
            }
        }

        public static IDisposable BeginScripts(this HtmlHelper helper)
        {
            return new ScriptBlock((WebViewPage)helper.ViewDataContainer);
        }

        public static MvcHtmlString PageScripts(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(string.Join(Environment.NewLine, ScriptBlock.pageScripts.Select(s => s.ToString())));
        }
        public static string TruncateLongString(this string str, int maxLength)
        {
            if (String.IsNullOrWhiteSpace(str))
                return str;
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }
        public static MvcHtmlString DisplayNameForEnum<TModel, TEnum>(this HtmlHelper<TModel> html, TEnum expression)
        {
            //html.ViewData[""]
            var resourceDisplayName = LangResources.Utility.ResourceManager.GetLocalisedString(expression.GetType().Name + "_" + expression);
            resourceDisplayName = resourceDisplayName.Replace("[[LASTVISIT]]", ((DateTime)html.ViewData["LastVisitDateTime"]).ToFormattedString());
            return string.IsNullOrWhiteSpace(resourceDisplayName) ? MvcHtmlString.Create(String.Format("[[{0}_{1}]]", expression.GetType().Name, expression)) : MvcHtmlString.Create(resourceDisplayName);

        }

    }

}