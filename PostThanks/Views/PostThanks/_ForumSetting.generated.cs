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
    
    #line 1 "..\..\Views\PostThanks\_ForumSetting.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\PostThanks\_ForumSetting.cshtml"
    using PostThanks.Views.Helpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/PostThanks/_ForumSetting.cshtml")]
    public partial class _Views_PostThanks__ForumSetting_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_PostThanks__ForumSetting_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n        <label>");

            
            #line 6 "..\..\Views\PostThanks\_ForumSetting.cshtml"
          Write(ResourceManager.GetLocalisedString("ForumSettingTitle", "Thanks"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"strThanks\"");

WriteLiteral(" class=\"control-label col-xs-6\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"strThanks\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"strThanks\"");

WriteLiteral(" data-size=\"mini\"");

WriteLiteral(" data-id=\"");

            
            #line 9 "..\..\Views\PostThanks\_ForumSetting.cshtml"
                                                                                            Write(ViewBag.ForumId);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 451), Tuple.Create("\"", 479)
            
            #line 9 "..\..\Views\PostThanks\_ForumSetting.cshtml"
                                             , Tuple.Create(Tuple.Create("", 461), Tuple.Create<System.Object, System.Int32>(ViewBag.IsAllowed
            
            #line default
            #line hidden
, 461), false)
);

WriteLiteral(" />\r\n");

WriteLiteral("                ");

            
            #line 10 "..\..\Views\PostThanks\_ForumSetting.cshtml"
           Write(ResourceManager.GetLocalisedString("ForumSetting", "Thanks"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </label>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");

            
            #line 16 "..\..\Views\PostThanks\_ForumSetting.cshtml"
 using (Html.BeginScripts())
{

            
            #line default
            #line hidden
WriteLiteral(@"    <script>
        $(document)
            .ready(function () {

                $('#strThanks').change(function () {
                    var id = $(this).data('id');
                    $.ajax(
                        {
                            url: SnitzVars.baseUrl + 'PostThanks/ForumSettings/' + id + '?check=' + this.checked,
                            async: false,
                            success: function (response) {
                                //alert('saved');
                            },
                            error: function (jqXHR, textStatus, errorThrown) {
                                BootstrapDialog.show({
                                    type: BootstrapDialog.TYPE_WARNING,
                                    title: textStatus,
                                    message: errorThrown
                                });
                            }
                        });
                });

            });
    </script>
");

            
            #line 43 "..\..\Views\PostThanks\_ForumSetting.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591