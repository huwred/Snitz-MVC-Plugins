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
    
    #line 1 "..\..\Views\Admin\_BookmarkAdmin.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Admin\_BookmarkAdmin.cshtml"
    using SnitzConfig;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Admin/_BookmarkAdmin.cshtml")]
    public partial class _Views_Admin__BookmarkAdmin_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Admin__BookmarkAdmin_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"strBookmark\"");

WriteLiteral(" class=\"control-label col-xs-3\"");

WriteLiteral(">");

            
            #line 5 "..\..\Views\Admin\_BookmarkAdmin.cshtml"
                                                       Write(ResourceManager.GetLocalisedString("bmTitle","Bookmarks"));

            
            #line default
            #line hidden
WriteLiteral(":</label>\r\n    <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n        <input");

WriteLiteral(" class=\"yesno-checkbox\"");

WriteLiteral(" id=\"strBookmark\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"strBookmarks\"");

WriteLiteral(" data-size=\"mini\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 342), Tuple.Create("\"", 399)
            
            #line 7 "..\..\Views\Admin\_BookmarkAdmin.cshtml"
                                       , Tuple.Create(Tuple.Create("", 352), Tuple.Create<System.Object, System.Int32>(ClassicConfig.GetValue("STRBOOKMARK") == "1"
            
            #line default
            #line hidden
, 352), false)
);

WriteLiteral("  />\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
