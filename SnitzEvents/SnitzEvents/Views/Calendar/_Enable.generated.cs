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
    
    #line 1 "..\..\Views\Calendar\_Enable.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Calendar\_Enable.cshtml"
    using SnitzConfig;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Calendar/_Enable.cshtml")]
    public partial class _Views_Calendar__Enable_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Calendar__Enable_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Enabled\"");

WriteLiteral(" class=\"control-label col-xs-3\"");

WriteLiteral(">");

            
            #line 4 "..\..\Views\Calendar\_Enable.cshtml"
                                                   Write(ResourceManager.GetLocalisedString("calTitle", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n    <div");

WriteLiteral(" class=\"col-xs-4 col-sm-1\"");

WriteLiteral(">\r\n        <input");

WriteLiteral(" class=\"yesno-checkbox\"");

WriteLiteral(" id=\"Enabled\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"Enabled\"");

WriteLiteral(" data-size=\"mini\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 334), Tuple.Create("\"", 395)
            
            #line 6 "..\..\Views\Calendar\_Enable.cshtml"
                              , Tuple.Create(Tuple.Create("", 344), Tuple.Create<System.Object, System.Int32>(ClassicConfig.GetIntValue("INTCALEVENTS",0) == 1
            
            #line default
            #line hidden
, 344), false)
);

WriteLiteral(" value=\"true\"");

WriteLiteral(" />\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
