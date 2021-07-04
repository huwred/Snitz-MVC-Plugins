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
    
    #line 2 "..\..\Views\PhotoAlbum\Member.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\PhotoAlbum\Member.cshtml"
    using MvcBreadCrumbs;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\PhotoAlbum\Member.cshtml"
    using PhotoAlbum.Views.Helpers;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\PhotoAlbum\Member.cshtml"
    using SnitzConfig;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/PhotoAlbum/Member.cshtml")]
    public partial class _Views_PhotoAlbum_Member_cshtml : System.Web.Mvc.WebViewPage<System.Collections.Generic.List<PhotoAlbum.Models.AlbumImage>>
    {
        public _Views_PhotoAlbum_Member_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\PhotoAlbum\Member.cshtml"
  
    ViewBag.Title = String.Format(ResourceManager.GetLocalisedString("lblAlbum", "PhotoAlbum"), ViewBag.Username);
    

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("styles", () => {

WriteLiteral("\r\n\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 355), Tuple.Create("\"", 394)
, Tuple.Create(Tuple.Create("", 362), Tuple.Create<System.Object, System.Int32>(Href("~/Content/plugincss/bjqs.min.css")
, 362), false)
);

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 424), Tuple.Create("\"", 477)
, Tuple.Create(Tuple.Create("", 431), Tuple.Create<System.Object, System.Int32>(Href("~/Content/plugincss/jquery.contextMenu.min.css")
, 431), false)
);

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 16 "..\..\Views\PhotoAlbum\Member.cshtml"
Write(Html.Raw(Config.ThemeCss("plugincss/photoalbum.min.css")));

            
            #line default
            #line hidden
WriteLiteral(@"
    <style>
        .modal-content {
            max-width: 800px !important;
            margin: 30px auto !important;
        }
        #SlideshowImages {
            width: 100%;
            height: 85%;
            max-height: 85%;
            display: block;
        }
        td:first-child + td + td, td:first-child + td + td + td { /* third column, fourth column */
            overflow: hidden;
            text-overflow: ellipsis;
        }

    </style>

");

});

DefineSection("breadcrumb", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 38 "..\..\Views\PhotoAlbum\Member.cshtml"
Write(Html.Raw(BreadCrumb.Display()));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n<h5>\r\n");

WriteLiteral("    ");

            
            #line 42 "..\..\Views\PhotoAlbum\Member.cshtml"
Write(String.Format(ResourceManager.GetLocalisedString("lblAlbum", "PhotoAlbum"), ViewBag.Username));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 43 "..\..\Views\PhotoAlbum\Member.cshtml"
 if (User.Identity.IsAuthenticated && ViewBag.IsOwner)
{
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\PhotoAlbum\Member.cshtml"
Write(Html.ActionLink(" ", "UploadFile", "PhotoAlbum", null, new { @class = "gallery-link pull-right fa fa-upload fa-1_5x", title = ResourceManager.GetLocalisedString("lblUpload", "PhotoAlbum"), data_toggle = "tooltip" }));

            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                                                                                                                                                                         }

            
            #line default
            #line hidden
WriteLiteral("</h5>\r\n<hr");

WriteLiteral(" class=\"title\"");

WriteLiteral(" />\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-6\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n");

            
            #line 52 "..\..\Views\PhotoAlbum\Member.cshtml"
                
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\PhotoAlbum\Member.cshtml"
                 using (Ajax.BeginForm("MemberImages", new { id = ViewBag.Username }, new AjaxOptions()
                {
                    UpdateTargetId = "ImageContainer",
                    InsertionMode = InsertionMode.Replace,
                    OnSuccess = "refreshsort",
                    HttpMethod = "POST"
                }))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\'", 2091), Tuple.Create("\'", 2115)
            
            #line 61 "..\..\Views\PhotoAlbum\Member.cshtml"
, Tuple.Create(Tuple.Create("", 2099), Tuple.Create<System.Object, System.Int32>(ViewBag.Display
            
            #line default
            #line hidden
, 2099), false)
);

WriteLiteral(" name=\"display\"");

WriteLiteral(" id=\"display-template\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(" />\r\n                        <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                            <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"album-sortby\"");

WriteLiteral(" name=\"SortBy\"");

WriteLiteral(">\r\n                                <option");

WriteLiteral(" value=\"id\"");

WriteLiteral("\r\n                                        ");

            
            #line 65 "..\..\Views\PhotoAlbum\Member.cshtml"
                                         if (ViewBag.SortBy == "id") { 
            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                  Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                                             }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 66 "..\..\Views\PhotoAlbum\Member.cshtml"
                               Write(ResourceManager.GetLocalisedString("optSortId"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </option>\r\n                                <opt" +
"ion");

WriteLiteral(" value=\"date\"");

WriteLiteral("\r\n                                        ");

            
            #line 69 "..\..\Views\PhotoAlbum\Member.cshtml"
                                         if (ViewBag.SortBy == "date") { 
            
            #line default
            #line hidden
            
            #line 69 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                    Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 69 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                                               }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 70 "..\..\Views\PhotoAlbum\Member.cshtml"
                               Write(ResourceManager.GetLocalisedString("optSortDate"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </option>\r\n                                <opt" +
"ion");

WriteLiteral(" value=\"desc\"");

WriteLiteral("\r\n                                        ");

            
            #line 73 "..\..\Views\PhotoAlbum\Member.cshtml"
                                         if (ViewBag.SortBy == "desc") { 
            
            #line default
            #line hidden
            
            #line 73 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                    Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 73 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                                               }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 74 "..\..\Views\PhotoAlbum\Member.cshtml"
                               Write(ResourceManager.GetLocalisedString("optSortDesc"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </option>\r\n                                <opt" +
"ion");

WriteLiteral(" value=\"file\"");

WriteLiteral("\r\n                                        ");

            
            #line 77 "..\..\Views\PhotoAlbum\Member.cshtml"
                                         if (ViewBag.SortBy == "file") { 
            
            #line default
            #line hidden
            
            #line 77 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                    Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 77 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                                               }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 78 "..\..\Views\PhotoAlbum\Member.cshtml"
                               Write(ResourceManager.GetLocalisedString("optSortFile"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </option>\r\n                            </select" +
">\r\n                        </span>\r\n                        <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                            <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"SortOrder\"");

WriteLiteral(" id=\"album-sortdesc\"");

WriteLiteral(">\r\n                                <option");

WriteLiteral(" value=\"desc\"");

WriteLiteral("\r\n                                        ");

            
            #line 85 "..\..\Views\PhotoAlbum\Member.cshtml"
                                         if (ViewBag.SortDir.ToLower() == "desc") { 
            
            #line default
            #line hidden
            
            #line 85 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                               Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 85 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                                                          }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\PhotoAlbum\Member.cshtml"
                               Write(ResourceManager.GetLocalisedString("optDesc", "Controls"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </option>\r\n                                <opt" +
"ion");

WriteLiteral(" value=\"asc\"");

WriteLiteral("\r\n                                        ");

            
            #line 89 "..\..\Views\PhotoAlbum\Member.cshtml"
                                         if (ViewBag.SortDir.ToLower() == "asc") { 
            
            #line default
            #line hidden
            
            #line 89 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                              Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 89 "..\..\Views\PhotoAlbum\Member.cshtml"
                                                                                                         }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 90 "..\..\Views\PhotoAlbum\Member.cshtml"
                               Write(ResourceManager.GetLocalisedString("optAsc", "Controls"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </option>\r\n                            </select" +
">\r\n                        </span>\r\n                    </div>\r\n");

            
            #line 95 "..\..\Views\PhotoAlbum\Member.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-6 text-right view-select\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 99 "..\..\Views\PhotoAlbum\Member.cshtml"
       Write(Ajax.RawActionLink("<li class='fa fa-th'></li>", "MemberImages", new { id = ViewBag.Username, display = 0, pagenum = 1 }, new AjaxOptions()
       {
           UpdateTargetId = "ImageContainer",
           InsertionMode = InsertionMode.Replace,
           OnSuccess = "refreshlazyload",
           HttpMethod = "GET"
       }, new { data_toggle = "tooltip" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 106 "..\..\Views\PhotoAlbum\Member.cshtml"
       Write(Ajax.RawActionLink("<li class='fa fa-align-justify'></li>", "MemberImages", new { id = ViewBag.Username, display = 2, pagenum = 1 }, new AjaxOptions()
       {
           UpdateTargetId = "ImageContainer",
           InsertionMode = InsertionMode.Replace,
           OnSuccess = "refreshlazyload",
                HttpMethod = "GET"
       }, new { data_toggle = "tooltip" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 113 "..\..\Views\PhotoAlbum\Member.cshtml"
       Write(Ajax.RawActionLink("<li class='fa fa-list'></li>", "MemberImages", new { id = ViewBag.Username, display = 1, pagenum = 1 }, new AjaxOptions()
       {
           UpdateTargetId = "ImageContainer",
           InsertionMode = InsertionMode.Replace,
           OnSuccess = "refreshlazyload",
           HttpMethod = "GET"
       }, new { data_toggle = "tooltip" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 120 "..\..\Views\PhotoAlbum\Member.cshtml"
       Write(Ajax.RawActionLink("<li class='fa fa-film'></li>", "MemberSlideShow", new { id = ViewBag.Username, display = 3, pagenum = 1 }, new AjaxOptions()
       {
           UpdateTargetId = "ImageContainer",
           InsertionMode = InsertionMode.Replace,
           OnSuccess = "refreshlazyload",
           HttpMethod = "GET"
       }, new { data_toggle = "tooltip" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">&nbsp;</div>\r\n    <input");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6125), Tuple.Create("\"", 6149)
            
            #line 130 "..\..\Views\PhotoAlbum\Member.cshtml"
, Tuple.Create(Tuple.Create("", 6133), Tuple.Create<System.Object, System.Int32>(ViewBag.Display
            
            #line default
            #line hidden
, 6133), false)
);

WriteLiteral(" id=\"display-type\"");

WriteLiteral(" />\r\n    <input");

WriteLiteral(" id=\"lastPageID\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6213), Tuple.Create("\"", 6245)
            
            #line 131 "..\..\Views\PhotoAlbum\Member.cshtml"
, Tuple.Create(Tuple.Create("", 6221), Tuple.Create<System.Object, System.Int32>((int)ViewBag.Page + 1
            
            #line default
            #line hidden
, 6221), false)
);

WriteLiteral(" />\r\n    <div");

WriteLiteral(" class=\"row-fluid\"");

WriteLiteral(" id=\"ImageContainer\"");

WriteLiteral(">\r\n\r\n");

WriteLiteral("        ");

            
            #line 134 "..\..\Views\PhotoAlbum\Member.cshtml"
   Write(Html.Partial("MemberImages"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <br />\r\n        <div");

WriteLiteral(" style=\"clear: both;\"");

WriteLiteral(">\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n        </div>\r\n\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"row text-center album-copyright\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 144 "..\..\Views\PhotoAlbum\Member.cshtml"
   Write(Html.Raw(String.Format(ResourceManager.GetLocalisedString("lblMemberCopy"), "<a href='" + Url.Action("UserProfile", "Account", new { id = ViewBag.Username }, null) + "'>" + ViewBag.Username + "</a>")));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"json-data\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6790), Tuple.Create("\"", 6817)
            
            #line 147 "..\..\Views\PhotoAlbum\Member.cshtml"
, Tuple.Create(Tuple.Create("", 6798), Tuple.Create<System.Object, System.Int32>(ViewBag.JsonParams
            
            #line default
            #line hidden
, 6798), false)
);

WriteLiteral(" />\r\n<div");

WriteLiteral(" id=\"modal-gallery-upload\"");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" role=\"dialog\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(" id=\"modal-upload-container\"");

WriteLiteral("></div>\r\n</div>\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 7037), Tuple.Create("\"", 7068)
, Tuple.Create(Tuple.Create("", 7043), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/dropzone.min.js")
, 7043), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 7115), Tuple.Create("\"", 7165)
, Tuple.Create(Tuple.Create("", 7121), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/pluginjs/jquery.ui.position.min.js")
, 7121), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 7212), Tuple.Create("\"", 7262)
, Tuple.Create(Tuple.Create("", 7218), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/pluginjs/jquery.contextMenu.min.js")
, 7218), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 7309), Tuple.Create("\"", 7361)
, Tuple.Create(Tuple.Create("", 7315), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/pluginjs/snitz.gallery.upload.min.js")
, 7315), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 7408), Tuple.Create("\"", 7456)
, Tuple.Create(Tuple.Create("", 7414), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/pluginjs/snitz.photoalbum.min.js")
, 7414), false)
);

WriteLiteral("></script>\r\n\r\n    <script>\r\n        var disp1 = $(\'#display-template\').val();\r\n  " +
"      var pagecount = \'");

            
            #line 163 "..\..\Views\PhotoAlbum\Member.cshtml"
                    Write(ViewBag.PageCount);

            
            #line default
            #line hidden
WriteLiteral(@"';
        var lastpage = 1;
        var pagenum = 1;
        var timing = 10000;
        var imgTimeout = null;

            var scrollFunction = function(){
                var mostOfTheWayDown = ($(document).height() - 200);
                disp1 = $('#display-template').val();
                
                if (disp1 === '0' && $(window).scrollTop() + $(window).height() >= mostOfTheWayDown) {
                    $(window).unbind('scroll');
                    pagenum = parseInt($('input#lastPageID').val()) + 1;

                    if (pagenum <= parseInt(pagecount) && pagenum !== lastpage) {
                        lastpage = pagenum;
                        var url = '");

            
            #line 179 "..\..\Views\PhotoAlbum\Member.cshtml"
                              Write(Url.Action("MemberImages", "PhotoAlbum", new {id = ViewBag.Username, mid = ViewBag.MemberId, display = ViewBag.Display, sortby = ViewBag.SortBy, sortOrder = ViewBag.SortPage}));

            
            #line default
            #line hidden
WriteLiteral("\' + \"&pagenum=\" + pagenum;\r\n\r\n                        $.ajax({\r\n                 " +
"           type: \'POST\',\r\n                            url: url,\r\n               " +
"             success: function(response) {\r\n                                last" +
"page = pagenum;\r\n                                $(\'#display-type\').val($(\'.view" +
"bag-diplay\').data(\'val\'));\r\n                                $(\'div#ImageContaine" +
"r\').append(response);\r\n                                $(\'input#lastPageID\').val" +
"(pagenum);\r\n                                $(window).bind(\'scroll\',scrollFuncti" +
"on);\r\n                            },\r\n                            error: functio" +
"n(xhr, textStatus, error) {\r\n                                console.log(xhr.sta" +
"tusText);\r\n                                console.log(textStatus);\r\n           " +
"                     console.log(error);\r\n                                $.fall" +
"r(\'show\',\r\n                                    {\r\n                              " +
"          content: \'Request Sending Failed! Try Again after few minutes.\'\r\n     " +
"                               });\r\n                            }\r\n             " +
"           });\r\n                    }\r\n                }\r\n            };\r\n      " +
"  $(document).ready(function() {\r\n            \r\n            $(window).bind(\'scro" +
"ll\', scrollFunction);\r\n\r\n            try {\r\n                Dropzone.autoDiscove" +
"r = false;\r\n            } catch (e) {\r\n                console.log(Snitzres.DZNo" +
"tLoaded);\r\n            }\r\n            $(\'.view-select a\').on(\'click\',\r\n         " +
"       function() {\r\n\r\n                    $(\'.view-select a\').removeClass(\'sele" +
"cted\');\r\n                    $(this).addClass(\'selected\');\r\n\r\n                })" +
";\r\n\r\n        });\r\n\r\n        var refreshlazyload = function () {\r\n            var" +
" disp = $(\'.viewbag-diplay\').data(\'val\');\r\n            $(\'#display-template\').va" +
"l(disp);\r\n\r\n            $(window).unbind(\"scroll\");\r\n            if (disp === 0)" +
" {\r\n                pagenum = 1;\r\n                lastpage = 1;\r\n               " +
" $(\'input#lastPageID\').val(pagenum);\r\n                $(window).bind(\'scroll\',sc" +
"rollFunction);\r\n            }\r\n            window.lazyload();\r\n        };\r\n\r\n   " +
"     function refreshsort(data) {\r\n            var disp = $(\'.viewbag-diplay\').d" +
"ata(\'val\');\r\n            $(\'#display-template\').val(disp);\r\n            lazyload" +
"();\r\n        };\r\n\r\n        function loop() {\r\n            var idx = $(\'#galleryI" +
"mage\').data(\"id\") + 1;\r\n            var searchdata = $(\"#json-data\").val();\r\n   " +
"         $.ajax({\r\n                type: \"GET\",\r\n                url: \'");

            
            #line 248 "..\..\Views\PhotoAlbum\Member.cshtml"
                 Write(Url.Action("Next", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(@"' +
                    '/' +
                    idx +
                    '?member=' +
                    $('#galleryImage').data(""user"") +
                    '&searchparams=' +
                    searchdata,
                success: function(data) {
                    $('#galleryImage').fadeOut(500,
                        function() {
                            $('#galleryImage').attr('src', data.src);
                            $('#galleryImage').fadeIn(500);
                        });
                    $('#galleryImage').data(""id"", data.idx);
                    $('#galleryImageLbl').html(data.title);
                    $('#galleryImageFooterLbl').html(data.desc);
                    if (timing > 0) {
                        imgTimeout = window.setTimeout(loop, timing);
                    }
                },
                error: function(error) {
                    clearTimeout(imgTimeout);
                    BootstrapDialog.alert({
                        title: Snitzres.ErrTitle,
                        message: error
                    });
                }
            });

        }

    </script>
");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591