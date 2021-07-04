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
    
    #line 3 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
    using PhotoAlbum.Views.Helpers;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
    using SnitzDataModel.Extensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/PhotoAlbum/_FeaturedImage.cshtml")]
    public partial class _Views_PhotoAlbum__FeaturedImage_cshtml : System.Web.Mvc.WebViewPage<PhotoAlbum.Models.AlbumImage>
    {
        public _Views_PhotoAlbum__FeaturedImage_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
  
    Layout = null;


            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" id=\"featured-image-div\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel panel-primary\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                              Write(ResourceManager.GetLocalisedString("lblFeaturedImage","PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(": <small>");

            
            #line 12 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                                                                                                           Write(Model.Description);

            
            #line default
            #line hidden
WriteLiteral("</small></div>\r\n        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n            <a");

WriteAttribute("href", Tuple.Create(" href=\'", 429), Tuple.Create("\'", 484)
            
            #line 14 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
, Tuple.Create(Tuple.Create("", 436), Tuple.Create<System.Object, System.Int32>(Url.Action("GetFeaturedImage",new{id=Model.Id})
            
            #line default
            #line hidden
, 436), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 506), Tuple.Create("\"", 561)
            
            #line 14 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                  , Tuple.Create(Tuple.Create("", 512), Tuple.Create<System.Object, System.Int32>(Html.ImageUrlFor(Model.Location,Model.Timestamp)
            
            #line default
            #line hidden
, 512), false)
);

WriteLiteral(" ");

WriteLiteral(" alt=\"[Image=");

            
            #line 14 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                                                                                                                                                                                          Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("]\" id=\"featured-img\" /></a>\r\n            <div");

WriteLiteral(" class=\"featured-img-overlay\"");

WriteLiteral(">\r\n                <ul");

WriteLiteral(" class=\"list-unstyled small\"");

WriteLiteral(">\r\n                    <li>");

            
            #line 17 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                   Write(ResourceManager.GetLocalisedString("tipImage", "ToolTip"));

            
            #line default
            #line hidden
WriteLiteral(" [Image=");

            
            #line 17 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                                                                                     Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("]</li>\r\n                    <li>");

            
            #line 18 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                   Write(ResourceManager.GetLocalisedString("lblScientificName","PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(": ");

            
            #line 18 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                                                                                          Write(Model.ScientificName);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    <li>");

            
            #line 19 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                   Write(ResourceManager.GetLocalisedString("lblLocalName","PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(": ");

            
            #line 19 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                                                                                     Write(Model.CommonName);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    <li>");

            
            #line 20 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                   Write(ResourceManager.GetLocalisedString("lblFileName", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(": ");

            
            #line 20 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                                                                                     Write(Model.Location);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    <li>");

            
            #line 21 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                   Write(ResourceManager.GetLocalisedString("lblOwner", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(": ");

            
            #line 21 "..\..\Views\PhotoAlbum\_FeaturedImage.cshtml"
                                                                                  Write(Model.MemberName);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n<" +
"/div>\r\n");

        }
    }
}
#pragma warning restore 1591