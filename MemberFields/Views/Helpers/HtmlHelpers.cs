using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BbCodeFormatter;
using LangResources.Utility;
using SnitzConfig;

namespace MemberFields.Views.Helpers
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

                /// <summary>
        /// Renders a CONFIG VARIABLE (key) as yes-no toggle switch and optionally a help icon if a langresource is defined for the key
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="labeltext">Text shown on switch</param>
        /// <param name="key">CONFIG_VARIABLE</param>
        /// <param name="disabled">set to "disabled" to disable the control</param>
        /// <param name="labelCss">non default label css</param>
        /// <param name="controlCss">non default control css</param>
        /// <returns></returns>
        public static MvcHtmlString ConfigToggle(this HtmlHelper helper, string labeltext, string key, string disabled = "", string labelCss = "control-label col-xs-8 col-sm-3", string controlCss = "col-xs-4 col-sm-1", bool hiddeninput = true)
        {
            string value = ClassicConfig.GetValue(key.ToUpper());

            TagBuilder controlGroup = new TagBuilder("div");
            //controlGroup.AddCssClass("form-group");

            TagBuilder label = new TagBuilder("label");
            label.AddCssClass("control-label");
            label.AddCssClass(labelCss);
            label.InnerHtml = labeltext;

            TagBuilder controls = new TagBuilder("div");
            controls.AddCssClass(controlCss);

            TagBuilder input = new TagBuilder("input");
            input.AddCssClass("yesno-checkbox " + disabled);
            if (!String.IsNullOrEmpty(disabled))
            {
                input.Attributes.Add("disabled", "");
            }
            input.Attributes["data-size"] = "mini";
            input.Attributes["type"] = "checkbox";
            input.Attributes["id"] = key.ToLower();
            input.Attributes["name"] = key.ToLower();
            if (value == "1")
            {
                input.Attributes["checked"] = "true";
            }

            input.Attributes["value"] = "1";

            TagBuilder hidden = new TagBuilder("input");
            hidden.Attributes["type"] = "hidden";
            hidden.Attributes["id"] = "hdn" + key.ToLower();
            hidden.Attributes["name"] = key.ToLower();
            hidden.Attributes["value"] = "0";

            controls.InnerHtml += input.ToString(TagRenderMode.SelfClosing);
            if (hiddeninput)
                controls.InnerHtml += hidden;
            controlGroup.InnerHtml += label;
            controlGroup.InnerHtml += controls;
            var helpString = ResourceManager.GetKey(key);
            if (helpString != null)
            {
                TagBuilder col = new TagBuilder("div");
                //col.AddCssClass("col-xs-1");
                TagBuilder help = new TagBuilder("i");
                help.AddCssClass("fa fa-question-circle fa-1_5x pull-left");
                help.Attributes["data-toggle"] = "tooltip";
                help.Attributes["data-html"] = "true";
                help.Attributes["style"] = "margin-top:7px";
                help.Attributes["title"] = BbCodeProcessor.Format(helpString,true,true);
                col.InnerHtml += help;
                controlGroup.InnerHtml += col.InnerHtml;
            }


            return MvcHtmlString.Create(controlGroup.InnerHtml);
        }

    }

}