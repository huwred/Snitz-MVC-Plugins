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
    
    #line 2 "..\..\Views\Bookmark\_Bookmarks.cshtml"
    using BbCodeFormatter;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Bookmark\_Bookmarks.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\Bookmark\_Bookmarks.cshtml"
    using SnitzCore.Extensions;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Bookmark\_Bookmarks.cshtml"
    using SnitzDataModel.Extensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Bookmark/_Bookmarks.cshtml")]
    public partial class _Views_Bookmark__Bookmarks_cshtml : System.Web.Mvc.WebViewPage<BookMarks.Models.BookmarkViewModel>
    {
        public _Views_Bookmark__Bookmarks_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

WriteLiteral("<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Views\Bookmark\_Bookmarks.cshtml"
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Bookmark\_Bookmarks.cshtml"
     using (Html.BeginForm("Index", "Bookmark", new {userid=Model.UserId, pagenum = 1, readcookie = false }, FormMethod.Get))
    {   

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"col-xs-5 col-sm-6 padding-sm\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\Bookmark\_Bookmarks.cshtml"
       Write(Html.EnumDropDownListFor(m => m.ActiveSince, new { onchange = "$(this).closest('form').submit();", @class = "form-control" },((DateTime)ViewData["LastVisitDateTime"]).ToFormattedString()));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"col-xs-7 col-sm-6 padding-sm\"");

WriteLiteral(">  \r\n");

WriteLiteral("            ");

            
            #line 16 "..\..\Views\Bookmark\_Bookmarks.cshtml"
       Write(Html.EnumDropDownListFor(m => m.Refresh, new { onchange = "$(this).closest('form').submit();", @class = "form-control" },""));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

WriteLiteral("        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" value=\"1\"");

WriteLiteral(" id=\"pagenum\"");

WriteLiteral(" name=\"pagenum\"");

WriteLiteral("/>\r\n");

WriteLiteral("        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" value=\"false\"");

WriteLiteral(" id=\"readcookie\"");

WriteLiteral(" name=\"readcookie\"");

WriteLiteral("/>\r\n");

            
            #line 20 "..\..\Views\Bookmark\_Bookmarks.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n<div");

WriteLiteral(" class=\"row-fluid clearfix\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\Bookmark\_Bookmarks.cshtml"
                      Write(Html.Partial("_BookmarkPager", Model));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n</div> \r\n");

            
            #line 25 "..\..\Views\Bookmark\_Bookmarks.cshtml"
 using(Html.BeginForm("Delete","Bookmark",new{returnUrl=this.Request.RawUrl})){


            
            #line default
            #line hidden
WriteLiteral("<table");

WriteLiteral(" class=\"table table-condensed\"");

WriteLiteral(">\r\n    <thead>\r\n        <tr>\r\n            <th>");

            
            #line 30 "..\..\Views\Bookmark\_Bookmarks.cshtml"
           Write(ResourceManager.GetLocalisedString("lblForum","labels"));

            
            #line default
            #line hidden
WriteLiteral(" </th>\r\n            <th>");

            
            #line 31 "..\..\Views\Bookmark\_Bookmarks.cshtml"
           Write(ResourceManager.GetLocalisedString("lblTopic","labels"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n            <th>");

            
            #line 32 "..\..\Views\Bookmark\_Bookmarks.cshtml"
           Write(ResourceManager.GetLocalisedString("Started", "BookMarks"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n            <th>");

            
            #line 33 "..\..\Views\Bookmark\_Bookmarks.cshtml"
           Write(ResourceManager.GetLocalisedString("lblLastPost","labels"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n            <th><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"checkAll\"");

WriteLiteral(" value=\"1\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1629), Tuple.Create("\"", 1697)
            
            #line 34 "..\..\Views\Bookmark\_Bookmarks.cshtml"
, Tuple.Create(Tuple.Create("", 1637), Tuple.Create<System.Object, System.Int32>(ResourceManager.GetLocalisedString("tipCheckAll","Tooltip")
            
            #line default
            #line hidden
, 1637), false)
);

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral("/> \r\n            <button");

WriteLiteral(" id=\"delete_button\"");

WriteLiteral(" class=\"btn btn-xs btn-primary\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1794), Tuple.Create("\"", 1868)
            
            #line 35 "..\..\Views\Bookmark\_Bookmarks.cshtml"
, Tuple.Create(Tuple.Create("", 1802), Tuple.Create<System.Object, System.Int32>(ResourceManager.GetLocalisedString("tipDeleteSelected","Tooltip")
            
            #line default
            #line hidden
, 1802), false)
);

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o fa-1_5x\"");

WriteLiteral("></i></button>\r\n            </th>\r\n        </tr>\r\n\r\n    </thead>\r\n  <tbody>\r\n");

            
            #line 41 "..\..\Views\Bookmark\_Bookmarks.cshtml"
 foreach (var bookmark in Model.Bookmarks)
{

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n        <td>");

            
            #line 44 "..\..\Views\Bookmark\_Bookmarks.cshtml"
       Write(Html.ActionLink(bookmark.Forum.Subject,"Posts","Forum",new{id=bookmark.Forum.Id,pagenum=1},null));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td><a");

WriteAttribute("href", Tuple.Create(" href=\"", 2188), Tuple.Create("\"", 2267)
            
            #line 45 "..\..\Views\Bookmark\_Bookmarks.cshtml"
, Tuple.Create(Tuple.Create("", 2195), Tuple.Create<System.Object, System.Int32>(Url.Action("Posts", "Topic", new {id = bookmark.TopicId, pagenum = -1})
            
            #line default
            #line hidden
, 2195), false)
);

WriteLiteral(">");

            
            #line 45 "..\..\Views\Bookmark\_Bookmarks.cshtml"
                                                                                          Write(Html.Raw(BbCodeProcessor.Format(bookmark.Topic.Subject)));

            
            #line default
            #line hidden
WriteLiteral("</a></td>\r\n        <td>");

            
            #line 46 "..\..\Views\Bookmark\_Bookmarks.cshtml"
       Write(bookmark.Topic.Date.Value.ToFormattedString());

            
            #line default
            #line hidden
WriteLiteral(" by ");

            
            #line 46 "..\..\Views\Bookmark\_Bookmarks.cshtml"
                                                         Write(Html.ActionLink(bookmark.Author.Username, "UserProfile", "Account", new { id = bookmark.Author.Id }, new { title = ResourceManager.GetLocalisedString("tipViewProfile","Tooltip"), data_toggle = "tooltip" }));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td><a");

WriteAttribute("href", Tuple.Create(" href=\"", 2626), Tuple.Create("\"", 2772)
            
            #line 47 "..\..\Views\Bookmark\_Bookmarks.cshtml"
, Tuple.Create(Tuple.Create("", 2633), Tuple.Create<System.Object, System.Int32>(Url.Action("Posts", "Topic", new {id = bookmark.TopicId, pagenum = -1,archived = bookmark.Topic.Archived})
            
            #line default
            #line hidden
, 2633), false)
, Tuple.Create(Tuple.Create("", 2740), Tuple.Create("#", 2740), true)
            
            #line 47 "..\..\Views\Bookmark\_Bookmarks.cshtml"
                                                 , Tuple.Create(Tuple.Create("", 2741), Tuple.Create<System.Object, System.Int32>(bookmark.Topic.LastPostReplyId
            
            #line default
            #line hidden
, 2741), false)
);

WriteLiteral(" data-toggle=\"tooltip\"");

WriteAttribute("title", Tuple.Create(" title=\"", 2795), Tuple.Create("\"", 2864)
            
            #line 47 "..\..\Views\Bookmark\_Bookmarks.cshtml"
                                                                                                               , Tuple.Create(Tuple.Create("", 2803), Tuple.Create<System.Object, System.Int32>(ResourceManager.GetLocalisedString("tipLastPost","Tooltip")
            
            #line default
            #line hidden
, 2803), false)
, Tuple.Create(Tuple.Create(" ", 2863), Tuple.Create("", 2863), true)
);

WriteLiteral(">");

            
            #line 47 "..\..\Views\Bookmark\_Bookmarks.cshtml"
                                                                                                                                                                                                                                                         Write(bookmark.Topic.LastPostDate.Value.ToFormattedString());

            
            #line default
            #line hidden
WriteLiteral("</a> by ");

            
            #line 47 "..\..\Views\Bookmark\_Bookmarks.cshtml"
                                                                                                                                                                                                                                                                                                                       Write(Html.ActionLink(bookmark.Topic.EditedBy, "UserProfile", "Account", new { id = bookmark.Topic.LastPostAuthorId }, new { title = ResourceManager.GetLocalisedString("tipViewProfile","Tooltip"), data_toggle = "tooltip" }));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"delete-me\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3204), Tuple.Create("\"", 3224)
            
            #line 48 "..\..\Views\Bookmark\_Bookmarks.cshtml"
, Tuple.Create(Tuple.Create("", 3212), Tuple.Create<System.Object, System.Int32>(bookmark.Id
            
            #line default
            #line hidden
, 3212), false)
);

WriteLiteral("/></td>\r\n    </tr>    \r\n");

            
            #line 50 "..\..\Views\Bookmark\_Bookmarks.cshtml"

}

            
            #line default
            #line hidden
WriteLiteral("  </tbody>\r\n</table>\r\n");

            
            #line 54 "..\..\Views\Bookmark\_Bookmarks.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
