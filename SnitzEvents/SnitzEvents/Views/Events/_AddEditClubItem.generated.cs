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
    
    #line 1 "..\..\Views\Events\_AddEditClubItem.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Events/_AddEditClubItem.cshtml")]
    public partial class _Views_Events__AddEditClubItem_cshtml : System.Web.Mvc.WebViewPage<SnitzEvents.Models.ClubCalendarClub>
    {
        public _Views_Events__AddEditClubItem_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    <!-- Form itself -->\r\n");

            
            #line 6 "..\..\Views\Events\_AddEditClubItem.cshtml"
    
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\Events\_AddEditClubItem.cshtml"
     using (Html.BeginForm("AddEditClub", "Events", FormMethod.Post, new { id = "editItemForm" }))
    {


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"Id\"");

WriteLiteral(" id=\"Id\"");

WriteAttribute("value", Tuple.Create(" value=\"", 315), Tuple.Create("\"", 332)
            
            #line 10 "..\..\Views\Events\_AddEditClubItem.cshtml"
, Tuple.Create(Tuple.Create("", 323), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 323), false)
);

WriteLiteral(" />\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(" for=\"ShortName\"");

WriteLiteral(">Short Name</label>\r\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"ShortName\"");

WriteLiteral(" id=\"ShortName\"");

WriteLiteral(" placeholder=\"Short name\"");

WriteAttribute("value", Tuple.Create(" value=\"", 569), Tuple.Create("\"", 593)
            
            #line 13 "..\..\Views\Events\_AddEditClubItem.cshtml"
                                         , Tuple.Create(Tuple.Create("", 577), Tuple.Create<System.Object, System.Int32>(Model.ShortName
            
            #line default
            #line hidden
, 577), false)
);

WriteLiteral(" />\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(" for=\"LongName\"");

WriteLiteral(">Long Name</label>\r\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"LongName\"");

WriteLiteral(" id=\"LongName\"");

WriteLiteral(" placeholder=\"Long name\"");

WriteAttribute("value", Tuple.Create(" value=\"", 845), Tuple.Create("\"", 868)
            
            #line 17 "..\..\Views\Events\_AddEditClubItem.cshtml"
                                      , Tuple.Create(Tuple.Create("", 853), Tuple.Create<System.Object, System.Int32>(Model.LongName
            
            #line default
            #line hidden
, 853), false)
);

WriteLiteral(" />\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(" for=\"Name\"");

WriteLiteral(">Abbreviation</label>\r\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"Abbreviation\"");

WriteLiteral(" id=\"Abbreviation\"");

WriteLiteral(" placeholder=\"Abbr\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1122), Tuple.Create("\"", 1149)
            
            #line 21 "..\..\Views\Events\_AddEditClubItem.cshtml"
                                        , Tuple.Create(Tuple.Create("", 1130), Tuple.Create<System.Object, System.Int32>(Model.Abbreviation
            
            #line default
            #line hidden
, 1130), false)
);

WriteLiteral(" />\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"form-group clearfix\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"control-label col-xs-2\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\Events\_AddEditClubItem.cshtml"
                                                 Write(ResourceManager.GetLocalisedString("lblEventLocation", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                <div");

WriteLiteral(" class=\"col-xs-5\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 26 "..\..\Views\Events\_AddEditClubItem.cshtml"
               Write(Html.DropDownListFor(model => model.DefLocId, new SelectList(ViewBag.Locations, "Key", "Value"), new { @class = "form-control", @tabindex = 1 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(" for=\"Order\"");

WriteLiteral(">Order</label>\r\n                <input");

WriteLiteral(" type=\"number\"");

WriteLiteral(" class=\"form-control number\"");

WriteLiteral(" id=\"Order\"");

WriteLiteral(" name=\"Order\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1800), Tuple.Create("\"", 1820)
            
            #line 31 "..\..\Views\Events\_AddEditClubItem.cshtml"
                , Tuple.Create(Tuple.Create("", 1808), Tuple.Create<System.Object, System.Int32>(Model.Order
            
            #line default
            #line hidden
, 1808), false)
);

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" id=\"validationSummary\"");

WriteLiteral(" class=\"validation-summary\"");

WriteLiteral(">\r\n            <ul></ul>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"modal-footer\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"btn\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(">Close</a>\r\n            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">Save Changes</a>\r\n        </div>\r\n");

            
            #line 41 "..\..\Views\Events\_AddEditClubItem.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
