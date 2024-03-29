﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 2 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
    using SnitzCore.Extensions;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
    using SnitzEvents.Helpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/DisplayTemplates/CalendarEventItem.cshtml")]
    public partial class _Views_Shared_DisplayTemplates_CalendarEventItem_cshtml_ : System.Web.Mvc.WebViewPage<SnitzEvents.Models.CalendarEventItem>
    {
        public _Views_Shared_DisplayTemplates_CalendarEventItem_cshtml_()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
Write(Html.LabelFor(m => m.TopicId));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Start\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">");

            
            #line 8 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
                                        Write(ResourceManager.GetLocalisedString("lblStartDate", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("    ");

            
            #line 9 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
Write(Html.LabelFor(m => m.StartDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"End\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
                                      Write(ResourceManager.GetLocalisedString("lblEndDate", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("    ");

            
            #line 13 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
Write(Html.LabelFor(m => m.EndDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n        <label>");

            
            #line 17 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
          Write(Html.LabelFor(m => m.IsAllDayEvent));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 17 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
                                               Write(ResourceManager.GetLocalisedString("lblAllDay", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Recurs\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
                                         Write(ResourceManager.GetLocalisedString("lblRecurs", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("    ");

            
            #line 22 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
Write(Html.LabelFor(m => m.Recurs));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 22 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
                             Write(Html.LabelFor(m => m.Days));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" id=\"cal-dow\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n");

            
            #line 25 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
      var numList = Enum.GetValues(typeof(CalEnums.CalDays));
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 26 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
     foreach (object radiotext in numList)
    {

            
            #line default
            #line hidden
WriteLiteral("        <label");

WriteLiteral(" class=\"small radio-inline\"");

WriteLiteral("><input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"Days\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1192), Tuple.Create("\"", 1217)
            
            #line 28 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
  , Tuple.Create(Tuple.Create("", 1200), Tuple.Create<System.Object, System.Int32>((int)radiotext
            
            #line default
            #line hidden
, 1200), false)
);

WriteLiteral("> ");

            
            #line 28 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"
                                                                                                Write(radiotext.ToString());

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

            
            #line 29 "..\..\Views\Shared\DisplayTemplates\CalendarEventItem.cshtml"

    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
