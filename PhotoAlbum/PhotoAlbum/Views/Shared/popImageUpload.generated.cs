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
    
    #line 2 "..\..\Views\Shared\popImageUpload.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Shared\popImageUpload.cshtml"
    using SnitzConfig;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/popImageUpload.cshtml")]
    public partial class _Views_Shared_popImageUpload_cshtml : System.Web.Mvc.WebViewPage<PhotoAlbum.ViewModels.UploadViewModel>
    {
        public _Views_Shared_popImageUpload_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

WriteLiteral("      <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(">&times;</button>\r\n         <h4");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(">");

            
            #line 8 "..\..\Views\Shared\popImageUpload.cshtml"
                            Write(ResourceManager.GetLocalisedString("lblUpload","PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n      </div>\r\n      <div");

WriteLiteral(" class=\"modal-body container-fluid\"");

WriteLiteral(">\r\n");

            
            #line 11 "..\..\Views\Shared\popImageUpload.cshtml"
          
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\Shared\popImageUpload.cshtml"
           using (Html.BeginForm("Upload", "PhotoAlbum", FormMethod.Post, new { @class = "form-horizontal", enctype = "multipart/form-data", role = "form", id = "galleryUploadForm" }))
          {

            
            #line default
            #line hidden
WriteLiteral("              <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                  <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">&nbsp;</div>\r\n                  <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                      ");

            
            #line 16 "..\..\Views\Shared\popImageUpload.cshtml"
                 Write(String.Format(ResourceManager.GetLocalisedString("maxFileSize", "labels"), ClassicConfig.GetValue("INTMAXIMAGESIZE")));

            
            #line default
            #line hidden
WriteLiteral(" <br />\r\n");

WriteLiteral("                      ");

            
            #line 17 "..\..\Views\Shared\popImageUpload.cshtml"
                 Write(String.Format(ResourceManager.GetLocalisedString("allowedFiles", "labels"), ClassicConfig.GetValue("STRIMAGETYPES")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                      ");

            
            #line 18 "..\..\Views\Shared\popImageUpload.cshtml"
                 Write(Html.ValidationSummary(false, null, new { @class = "alert-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                  </div>\r\n              </div>\r\n");

WriteLiteral("              <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                  <label");

WriteLiteral(" class=\"control-label col-sm-4\"");

WriteLiteral(" for=\"Description\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\Shared\popImageUpload.cshtml"
                                                                     Write(ResourceManager.GetLocalisedString("lblDescription", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(":</label>\r\n                  <div");

WriteLiteral(" class=\"col-sm-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                      ");

            
            #line 24 "..\..\Views\Shared\popImageUpload.cshtml"
                 Write(Html.TextBoxFor(m => m.Description, new { @class = "form-control", placeholder = ResourceManager.GetLocalisedString("lblDescription", "PhotoAlbum"), id = "Description" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                  </div>\r\n              </div>\r\n");

            
            #line 27 "..\..\Views\Shared\popImageUpload.cshtml"
              if (ViewBag.DisplayAll)
              {

            
            #line default
            #line hidden
WriteLiteral("                  <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                      <label");

WriteLiteral(" class=\"control-label col-sm-4\"");

WriteLiteral(" for=\"ScientificName\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\Shared\popImageUpload.cshtml"
                                                                            Write(ResourceManager.GetLocalisedString("lblScientificName", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(":</label>\r\n                      <div");

WriteLiteral(" class=\"col-sm-8\"");

WriteLiteral(">\r\n                          <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"ScientificName\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 2018), Tuple.Create("\"", 2102)
            
            #line 32 "..\..\Views\Shared\popImageUpload.cshtml"
                     , Tuple.Create(Tuple.Create("", 2032), Tuple.Create<System.Object, System.Int32>(ResourceManager.GetLocalisedString("lblScientificName", "PhotoAlbum")
            
            #line default
            #line hidden
, 2032), false)
);

WriteLiteral(" id=\"ScientificName\"");

WriteLiteral(">\r\n                      </div>\r\n                  </div>\r\n");

WriteLiteral("                  <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                      <label");

WriteLiteral(" class=\"control-label col-sm-4\"");

WriteLiteral(" for=\"CommonName\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\Shared\popImageUpload.cshtml"
                                                                        Write(ResourceManager.GetLocalisedString("lblLocalName", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(":</label>\r\n                      <div");

WriteLiteral(" class=\"col-sm-8\"");

WriteLiteral(">\r\n                          <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"CommonName\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 2508), Tuple.Create("\"", 2587)
            
            #line 38 "..\..\Views\Shared\popImageUpload.cshtml"
                 , Tuple.Create(Tuple.Create("", 2522), Tuple.Create<System.Object, System.Int32>(ResourceManager.GetLocalisedString("lblLocalName", "PhotoAlbum")
            
            #line default
            #line hidden
, 2522), false)
);

WriteLiteral(" id=\"CommonName\"");

WriteLiteral(">\r\n                      </div>\r\n                  </div>\r\n");

WriteLiteral("                  <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                      <label");

WriteLiteral(" class=\"control-label col-sm-4\"");

WriteLiteral(" for=\"Group\"");

WriteLiteral(">");

            
            #line 42 "..\..\Views\Shared\popImageUpload.cshtml"
                                                                   Write(ResourceManager.GetLocalisedString("lblGroup", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(":</label>\r\n                      <div");

WriteLiteral(" class=\"col-sm-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                          ");

            
            #line 44 "..\..\Views\Shared\popImageUpload.cshtml"
                     Write(Html.DropDownListFor(m => m.Group, Model.GroupList, "Please Select", new { @class = "form-control", id = "Group" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                      </div>\r\n                  </div>\r\n");

WriteLiteral("                  <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"showCaption\"");

WriteLiteral(" name=\"showCaption\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" />\r\n");

            
            #line 48 "..\..\Views\Shared\popImageUpload.cshtml"
              }
              else
              {
                  
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\Shared\popImageUpload.cshtml"
             Write(Html.HiddenFor(m => m.ScientificName));

            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\Shared\popImageUpload.cshtml"
                                                        
                  
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Shared\popImageUpload.cshtml"
             Write(Html.HiddenFor(m => m.CommonName));

            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Shared\popImageUpload.cshtml"
                                                    
                  
            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\Shared\popImageUpload.cshtml"
             Write(Html.HiddenFor(m => m.Group));

            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\Shared\popImageUpload.cshtml"
                                               


            
            #line default
            #line hidden
WriteLiteral("                  <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                      <div");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral("></div>\r\n                      <div");

WriteLiteral(" class=\"col-sm-8 checkbox\"");

WriteLiteral("><label><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"showCaption\"");

WriteLiteral(" name=\"showCaption\"");

WriteLiteral(" /> ");

            
            #line 57 "..\..\Views\Shared\popImageUpload.cshtml"
                                                                                                                     Write(ResourceManager.GetLocalisedString("lblShowCaption", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</label></div>\r\n                  </div>\r\n");

            
            #line 59 "..\..\Views\Shared\popImageUpload.cshtml"
              }

            
            #line default
            #line hidden
WriteLiteral("              <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                  <div");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral("></div>\r\n                  <div");

WriteLiteral(" class=\"col-sm-8 checkbox\"");

WriteLiteral("><label>");

            
            #line 62 "..\..\Views\Shared\popImageUpload.cshtml"
                                                   Write(Html.CheckBoxFor(m => m.MarkAsPrivate, new { id = "MarkAsPrivate" }));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 62 "..\..\Views\Shared\popImageUpload.cshtml"
                                                                                                                         Write(ResourceManager.GetLocalisedString("lblPrivate", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</label></div>\r\n              </div>\r\n");

WriteLiteral("              <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                  <div");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral("></div>\r\n                  <div");

WriteLiteral(" class=\"col-sm-8 checkbox\"");

WriteLiteral("><label>");

            
            #line 66 "..\..\Views\Shared\popImageUpload.cshtml"
                                                   Write(Html.CheckBoxFor(m => m.MarkAsDoNotFeature, new { id = "MarkAsDoNotFeature" }));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 66 "..\..\Views\Shared\popImageUpload.cshtml"
                                                                                                                                   Write(ResourceManager.GetLocalisedString("lblDoNotFeature", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(" </label></div>\r\n              </div>\r\n");

WriteLiteral("              <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                  <label");

WriteLiteral(" class=\"control-label col-sm-4\"");

WriteLiteral(" for=\"Image\"");

WriteLiteral(">");

            
            #line 69 "..\..\Views\Shared\popImageUpload.cshtml"
                                                               Write(ResourceManager.GetLocalisedString("lblImage", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral(":</label>\r\n                  <div");

WriteLiteral(" class=\"col-sm-8\"");

WriteLiteral(">\r\n                      <div");

WriteLiteral(" id=\"dZUpload\"");

WriteLiteral(" class=\"dropzone\"");

WriteLiteral(">\r\n                          <div");

WriteLiteral(" class=\"fallback\"");

WriteLiteral(">\r\n                              <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                                  <label");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                                      <span");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">\r\n");

WriteLiteral("                                          ");

            
            #line 76 "..\..\Views\Shared\popImageUpload.cshtml"
                                     Write(ResourceManager.GetLocalisedString("btnBrowse", "labels"));

            
            #line default
            #line hidden
WriteLiteral(" <input");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(" type=\"file\"");

WriteLiteral(" accept=\"image/*\"");

WriteLiteral(" name=\"ImageFile\"");

WriteLiteral(" id=\"ImageFile\"");

WriteLiteral(">\r\n                                      </span>\r\n                               " +
"   </label>\r\n                                  <input");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" readonly=\"\"");

WriteLiteral(" id=\"Image\"");

WriteLiteral(">\r\n                              </div>\r\n                          </div>\r\n      " +
"                </div>\r\n                  </div>\r\n              </div>\r\n");

            
            #line 85 "..\..\Views\Shared\popImageUpload.cshtml"

          }

            
            #line default
            #line hidden
WriteLiteral("          <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n              <div");

WriteLiteral(" class=\"col-sm-6 pull-right text-right\"");

WriteLiteral(">\r\n                  <input");

WriteLiteral(" type=\"button\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5616), Tuple.Create("\"", 5682)
            
            #line 89 "..\..\Views\Shared\popImageUpload.cshtml"
, Tuple.Create(Tuple.Create("", 5624), Tuple.Create<System.Object, System.Int32>(ResourceManager.GetLocalisedString("btnCancel", "labels")
            
            #line default
            #line hidden
, 5624), false)
);

WriteLiteral(" class=\"btn modal-close-btn btn-danger\"");

WriteLiteral(" />\r\n                  <input");

WriteLiteral(" type=\"button\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5765), Tuple.Create("\"", 5829)
            
            #line 90 "..\..\Views\Shared\popImageUpload.cshtml"
, Tuple.Create(Tuple.Create("", 5773), Tuple.Create<System.Object, System.Int32>(ResourceManager.GetLocalisedString("btnSave", "labesl")
            
            #line default
            #line hidden
, 5773), false)
);

WriteLiteral(" class=\"btn btn-success\"");

WriteLiteral(" id=\"albumUpload\"");

WriteLiteral(" />\r\n              </div>\r\n          </div>\r\n      </div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    $(document).ready(function (){
        setRequiredFields();
        var galleryDropzone = new Dropzone(""#dZUpload"", {
            //forceFallback: true,
            url: window.SnitzVars.baseUrl + 'PhotoAlbum/Upload',
            maxFiles: 1,
            autoProcessQueue: false,
            addRemoveLinks: true,
            maxFilesize: 10,
            acceptedFiles: """);

            
            #line 105 "..\..\Views\Shared\popImageUpload.cshtml"
                       Write(ClassicConfig.GetValue("STRIMAGETYPES"));

            
            #line default
            #line hidden
WriteLiteral(@""",
            accept: function (file, done) {
                if (file.name.length > 255) {
                    done(""Filename exceeds 255 characters!"");
                }
                else { done(); }
            },
            dictDefaultMessage: """);

            
            #line 112 "..\..\Views\Shared\popImageUpload.cshtml"
                            Write(Html.Raw(ResourceManager.GetLocalisedString("UploadImage", "Dropzone")));

            
            #line default
            #line hidden
WriteLiteral("\", //\"Drop File here to upload\"\r\n            paramName: \"ImageFile\",\r\n           " +
" init: function () {\r\n\r\n                var submitButton = document.querySelecto" +
"r(\"#albumUpload\");\r\n                var wrapperThis = this;\r\n\r\n                s" +
"ubmitButton.addEventListener(\"click\", function (e) {\r\n                    $.vali" +
"dator.unobtrusive.parse($(\"#galleryUploadForm\"));\r\n\r\n                    if ($(\"" +
"#galleryUploadForm\").valid()) {\r\n                        e.preventDefault();\r\n  " +
"                      e.stopPropagation();\r\n\r\n                        wrapperThi" +
"s.processQueue();\r\n                    }\r\n                });\r\n                \r" +
"\n            }\r\n        });\r\n\r\n        galleryDropzone.on(\"sending\", function (d" +
"ata, xhr, formData) {\r\n            formData.append(\"Description\", $(\"#Descriptio" +
"n\").val());\r\n            formData.append(\"ScientificName\", $(\"#ScientificName\")." +
"val());\r\n            formData.append(\"CommonName\", $(\"#CommonName\").val());\r\n   " +
"         formData.append(\"Group\", $(\"#Group\").val());\r\n            formData.appe" +
"nd(\"MarkAsPrivate\", $(\"#MarkAsPrivate\").is(\':checked\'));\r\n            formData.a" +
"ppend(\"MarkAsDoNotFeature\", $(\"#MarkAsDoNotFeature\").is(\':checked\'));\r\n         " +
"   formData.append(\"showCaption\", $(\"#showCaption\").is(\':checked\'));\r\n        })" +
";\r\n\r\n        galleryDropzone.on(\"complete\", function (data) {\r\n            //Fil" +
"e Upload response from the server\r\n            var arr = data.xhr.responseText.s" +
"plit(\'|\');\r\n            if (arr[0].replace(\'\"\', \'\') === \'Error\') {\r\n            " +
"    BootstrapDialog.alert(\r\n                    {\r\n                        title" +
": \"Error \",\r\n                        message: arr[1]\r\n                    });\r\n " +
"           } else {\r\n                $(\'#modal-gallery-upload\').modal(\'hide\');\r\n" +
"                if ($(\"#editorDiv\").length > 0) {\r\n                    var paren" +
"tDiv = $(\"#editorDiv\");\r\n                    var textId = parentDiv.find(\".bbc-c" +
"ode-editor\")[0].id;\r\n                    //alert(arr[2]);\r\n                    i" +
"f (arr[2].replace(\'\"\', \'\')==\"true\") {\r\n                        $(\"#\" + textId).i" +
"nsertAtCaret(\"[cimage=\" + arr[1].replace(\'\"\', \'\') + \"]\");\r\n                    }" +
" else {\r\n                        $(\"#\" + textId).insertAtCaret(\"[image=\" + arr[1" +
"].replace(\'\"\', \'\') + \"]\");\r\n                    }\r\n                    \r\n\r\n     " +
"           } else {\r\n                    location.reload();\r\n                }\r\n" +
"            }\r\n        });\r\n\r\n    });\r\n\r\n</script>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
