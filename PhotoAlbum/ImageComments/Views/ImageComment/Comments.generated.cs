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
    
    #line 1 "..\..\Views\ImageComment\Comments.cshtml"
    using BbCodeFormatter;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\ImageComment\Comments.cshtml"
    using ImageComments.Models;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\ImageComment\Comments.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\ImageComment\Comments.cshtml"
    using SnitzCore.Extensions;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\ImageComment\Comments.cshtml"
    using SnitzDataModel.Extensions;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\ImageComment\Comments.cshtml"
    using WebSecurity = SnitzMembership.WebSecurity;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ImageComment/Comments.cshtml")]
    public partial class _Views_ImageComment_Comments_cshtml : System.Web.Mvc.WebViewPage<List<ImageComments.Models.ImageComment>>
    {
        public _Views_ImageComment_Comments_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

            
            #line 10 "..\..\Views\ImageComment\Comments.cshtml"
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\ImageComment\Comments.cshtml"
      
        Layout = "~/Views/Shared/_LayoutNoMenu.cshtml";
        ViewBag.Title = ResourceManager.GetLocalisedString("lblImgComments", "PhotoAlbum"); //"Image Comments";
    
            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"container-fluid text-center\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\ImageComment\Comments.cshtml"
        
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\ImageComment\Comments.cshtml"
         if (ViewBag.NewPost == null)
        {
            using (Html.BeginForm("AddComment", "ImageComment", FormMethod.Post, new { role = "form", id = "addCommentForm" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n                    <img");

WriteAttribute("id", Tuple.Create(" id=\"", 739), Tuple.Create("\"", 764)
, Tuple.Create(Tuple.Create("", 744), Tuple.Create("img_", 744), true)
            
            #line 20 "..\..\Views\ImageComment\Comments.cshtml"
, Tuple.Create(Tuple.Create("", 748), Tuple.Create<System.Object, System.Int32>(ViewBag.ImageId
            
            #line default
            #line hidden
, 748), false)
);

WriteAttribute("src", Tuple.Create(" src=\"", 765), Tuple.Create("\"", 836)
            
            #line 20 "..\..\Views\ImageComment\Comments.cshtml"
, Tuple.Create(Tuple.Create("", 771), Tuple.Create<System.Object, System.Int32>(Html.Action("GetImageUrl","PhotoAlbum", new{id=ViewBag.ImageId})
            
            #line default
            #line hidden
, 771), false)
);

WriteLiteral(" />\r\n                </div>\r\n");

            
            #line 22 "..\..\Views\ImageComment\Comments.cshtml"


            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"form-horizontal col-xs-8\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"ImageId\"");

WriteAttribute("value", Tuple.Create(" value=\"", 979), Tuple.Create("\"", 1003)
            
            #line 24 "..\..\Views\ImageComment\Comments.cshtml"
, Tuple.Create(Tuple.Create("", 987), Tuple.Create<System.Object, System.Int32>(ViewBag.ImageId
            
            #line default
            #line hidden
, 987), false)
);

WriteLiteral(" />\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-sm-9\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(" for=\"Comment\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\ImageComment\Comments.cshtml"
                                                                  Write(ResourceManager.GetLocalisedString("lblComment", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(": </label>\r\n                            <textarea");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"Comment\"");

WriteLiteral(" name=\"Comment\"");

WriteLiteral(" rows=\"4\"");

WriteLiteral(" maxlength=\"500\"");

WriteLiteral("></textarea>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"col-sm-2\"");

WriteLiteral(">\r\n                            <button");

WriteLiteral(" class=\"btn btn-sm btn-success\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\ImageComment\Comments.cshtml"
                                                              Write(ResourceManager.GetLocalisedString("lblSubmit", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n                        </div>\r\n                    </div>\r\n          " +
"      </div>\r\n");

            
            #line 35 "..\..\Views\ImageComment\Comments.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <hr");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(" />\r\n");

            
            #line 37 "..\..\Views\ImageComment\Comments.cshtml"

        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 39 "..\..\Views\ImageComment\Comments.cshtml"
         if (Model.Count == 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"row-fluid text-center\"");

WriteLiteral(">");

            
            #line 41 "..\..\Views\ImageComment\Comments.cshtml"
                                          Write(ResourceManager.GetLocalisedString("lblNoComments", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 42 "..\..\Views\ImageComment\Comments.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"row-fluid text-left\"");

WriteLiteral(">\r\n                <dl");

WriteLiteral(" class=\"col-sm-8 col-sm-offset-4 img-comment\"");

WriteLiteral(">\r\n");

            
            #line 47 "..\..\Views\ImageComment\Comments.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\ImageComment\Comments.cshtml"
                     foreach (ImageComment comment in Model)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <dt>\r\n");

WriteLiteral("                            ");

            
            #line 50 "..\..\Views\ImageComment\Comments.cshtml"
                       Write(comment.PostedBy);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 50 "..\..\Views\ImageComment\Comments.cshtml"
                                         Write(comment.PostedOn.ToClientTime().ToFormattedString());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 51 "..\..\Views\ImageComment\Comments.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\ImageComment\Comments.cshtml"
                             if (comment.MemberId == WebSecurity.CurrentUserId || ViewBag.AuthorId == WebSecurity.CurrentUserId || User.IsAdministrator())
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span");

WriteLiteral(" class=\"pull-right flip\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\"", 2526), Tuple.Create("\"", 2621)
            
            #line 53 "..\..\Views\ImageComment\Comments.cshtml"
, Tuple.Create(Tuple.Create("", 2533), Tuple.Create<System.Object, System.Int32>(Url.Action("DelComment", "ImageComment", new {id = comment.Id, imgid= comment.ImageId})
            
            #line default
            #line hidden
, 2533), false)
);

WriteLiteral(" class=\"del-comment\"");

WriteLiteral(" title=\"Delete Comment\"");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash fa-1_5x\"");

WriteLiteral("></i></a></span>\r\n");

            
            #line 54 "..\..\Views\ImageComment\Comments.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </dt>\r\n");

WriteLiteral("                        <dd>");

            
            #line 56 "..\..\Views\ImageComment\Comments.cshtml"
                       Write(Html.Raw(BbCodeProcessor.Format(comment.Comment, false)));

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n");

            
            #line 57 "..\..\Views\ImageComment\Comments.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </dl>\r\n            </div>\r\n");

            
            #line 60 "..\..\Views\ImageComment\Comments.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

        }
    }
}
#pragma warning restore 1591
