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
    
    #line 1 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
    using SnitzCore.Extensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Bookmark/_BookmarkPager.cshtml")]
    public partial class _Views_Bookmark__BookmarkPager_cshtml : System.Web.Mvc.WebViewPage<BookMarks.Models.BookmarkViewModel>
    {
        public _Views_Bookmark__BookmarkPager_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div>\r\n");

            
            #line 5 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
    
            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
      
        string controllerName = this.ViewContext.RouteData.Values["controller"].ToString();
        int pagecount = Convert.ToInt32(ViewBag.PageCount);
        int page = ViewBag.Page;
        int intLow = page - 1;
        int intHigh = page + 3;
        if (intLow < 1) { intLow = 1; }
        if (intHigh > pagecount) { intHigh = pagecount; }
        if (intHigh - intLow < 5) { while ((intHigh < intLow + 4) && intHigh < pagecount) { intHigh++; } }
        if (intHigh - intLow < 5) { while ((intLow > intHigh - 4) && intLow > 1) { intLow--; } }
    
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 16 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
     if (pagecount > 1)
    {

            
            #line default
            #line hidden
WriteLiteral("        <ul");

WriteLiteral(" class=\"pager\"");

WriteLiteral(">\r\n");

            
            #line 19 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
            
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
             if (page > 1)
            {

            
            #line default
            #line hidden
WriteLiteral("                <li><span");

WriteLiteral(" class=\"pager-link\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
                                        Write(Html.ActionLink("<<", "Index", controllerName, new { pagenum = 1, activesince = Model.ActiveSince }, htmlAttributes: null));

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n");

WriteLiteral("                <li><span");

WriteLiteral(" class=\"pager-link\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
                                        Write(Html.ActionLink("<", "Index", controllerName, new { pagenum = page - 1, activesince = Model.ActiveSince }, htmlAttributes: null));

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n");

            
            #line 23 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 26 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
            
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
             for (int i = intLow; i < intHigh + 1; i++)
            {
                if (i == page)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <li><span");

WriteLiteral(" class=\"pager-link-current\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
                                                    Write(Html.ActionLink(i.ToLangNum() + "", "Index", controllerName, new { pagenum = i, activesince = Model.ActiveSince }, htmlAttributes: null));

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n");

            
            #line 31 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
                }
                else
                {

            
            #line default
            #line hidden
WriteLiteral("                    <li><span");

WriteLiteral(" class=\"pager-link\"");

WriteLiteral(">");

            
            #line 34 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
                                            Write(Html.ActionLink(i.ToLangNum() + "", "Index", controllerName, new { pagenum = i, activesince = Model.ActiveSince }, htmlAttributes: null));

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n");

            
            #line 35 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
                }
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 37 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
             if (page < pagecount)
            {

            
            #line default
            #line hidden
WriteLiteral("                <li><span");

WriteLiteral(" class=\"pager-link\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
                                        Write(Html.ActionLink(">", "Index", controllerName, new { pagenum = page + 1, activesince = Model.ActiveSince }, htmlAttributes: null));

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n");

WriteLiteral("                <li><span");

WriteLiteral(" class=\"pager-link\"");

WriteLiteral(">");

            
            #line 40 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
                                        Write(Html.ActionLink(">>", "Index", controllerName, new { pagenum = pagecount, activesince = Model.ActiveSince }, htmlAttributes: null));

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n");

            
            #line 41 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </ul>\r\n");

            
            #line 43 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <p></p>\r\n");

            
            #line 47 "..\..\Views\Bookmark\_BookmarkPager.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591