using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BbCodeFormatter;
using LangResources.Utility;
using SnitzConfig;
using SnitzDataModel.Extensions;

namespace SiteManage.Views.Helpers
{
    public static class ApplicationHelpers
    {
        /// <summary>
        /// Renders the yes-no toggle switch
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="labeltext">Text shown on switch</param>
        /// <param name="key">CONFIG VARIABLE</param>
        /// <param name="disabled"></param>
        /// <param name="labelCss"></param>
        /// <param name="controlCss"></param>
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

            controls.InnerHtml += input;
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
                help.Attributes["style"] = "margin-top:7px";
                help.Attributes["title"] = BbCodeProcessor.Format(helpString,true,true);
                col.InnerHtml += help;
                controlGroup.InnerHtml += col.InnerHtml;
            }


            return MvcHtmlString.Create(controlGroup.InnerHtml);
        }

    }
}