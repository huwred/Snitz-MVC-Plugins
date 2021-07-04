using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BbCodeFormatter;
using Snitz.Base;
using SnitzDataModel.Extensions;

namespace SnitzEvents.Views.Helpers
{
    public static class HtmlHelpers
    {
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
    public static class EventApplicationHelpers
    {
        public static MvcHtmlString RadioButtonForSelectList<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            SelectList listOfValues, Enumerators.Position position = Enumerators.Position.Horizontal)
        {
            //var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string fullName = ExpressionHelper.GetExpressionText(expression);
            var value = ModelMetadata.FromLambdaExpression(
                            expression, htmlHelper.ViewData
                        ).Model;

            var sb = new StringBuilder();

            if (listOfValues != null)
            {

                // Create a radio button for each item in the list 
                foreach (SelectListItem item in listOfValues)
                {
                    if (item.Value == value.ToString())
                    {
                        item.Selected = true;
                    }
                    // Generate an id to be given to the radio button field 
                    var id = string.Format("rb_{0}_{1}",
                      fullName.Replace("[", "").Replace(
                      "]", "").Replace(".", "_"), item.Value);

                    // Create and populate a radio button using the existing html helpers 
                    var label = htmlHelper.Label(id, item.Text); //HttpUtility.HtmlEncode(item.Text)
                    //var radio = htmlHelper.RadioButtonFor(expression, item.Value, new { id = id }).ToHtmlString();
                    var radio = htmlHelper.RadioButton(fullName, item.Value, item.Selected, new { id }).ToHtmlString();

                    // Create the html string that will be returned to the client 
                    // e.g. <input data-val="true" data-val-required=
                    //   "You must select an option" id="TestRadio_1" 
                    //    name="TestRadio" type="radio"
                    //   value="1" /><label for="TestRadio_1">Line1</label> 
                    sb.AppendFormat("<{2} class=\"RadioButton\" name=\"{3}\">{0} {1}</{2}>",
                       radio, label, (position == Enumerators.Position.Horizontal ? "span" : "div"), BbCodeProcessor.Format(fullName));
                }
            }

            return MvcHtmlString.Create(sb.ToString());
        }
   
      public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, Dictionary<int, string> listInfo,List<int> subs, object htmlAttributes = null)
      {
          if (String.IsNullOrEmpty(name))
              throw new ArgumentException("The argument must have a value", "name");
          if (listInfo == null)
              throw new ArgumentNullException(nameof(listInfo));
          if (!listInfo.Any())
              throw new ArgumentException("The list must contain at least one value", nameof(listInfo));
   
          StringBuilder sb = new StringBuilder();
   
          foreach (KeyValuePair<int, string> info in listInfo)
          {
                TagBuilder div = new TagBuilder("div");
              div.AddCssClass("checkbox");

                TagBuilder label = new TagBuilder("label");

                TagBuilder builder = new TagBuilder("input");
              if (subs.Contains(info.Key))
              {
                    builder.MergeAttribute("checked", "checked");
                }

              builder.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
                builder.MergeAttribute("type", "checkbox");
              builder.MergeAttribute("value", info.Key.ToString());
              builder.MergeAttribute("name", name);

              label.InnerHtml = builder.ToString(TagRenderMode.Normal) + info.Value;
                div.InnerHtml = label.ToString(TagRenderMode.Normal);
                sb.Append(div.ToString(TagRenderMode.Normal));
              
          }

            return MvcHtmlString.Create(sb.ToString());
        }

    }
}