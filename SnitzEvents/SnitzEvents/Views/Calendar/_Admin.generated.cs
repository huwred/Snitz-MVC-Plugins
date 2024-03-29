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
    
    #line 1 "..\..\Views\Calendar\_Admin.cshtml"
    using System.Net.Configuration;
    
    #line default
    #line hidden
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
    
    #line 4 "..\..\Views\Calendar\_Admin.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Calendar\_Admin.cshtml"
    using SnitzConfig;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Calendar\_Admin.cshtml"
    using SnitzDataModel.Extensions;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Calendar\_Admin.cshtml"
    using SnitzEvents.Views.Helpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Calendar/_Admin.cshtml")]
    public partial class _Views_Calendar__Admin_cshtml : System.Web.Mvc.WebViewPage<SnitzEvents.ViewModels.CalAdminViewModel>
    {
        public _Views_Calendar__Admin_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 10 "..\..\Views\Calendar\_Admin.cshtml"
 using (Html.BeginForm("SaveSettings", "Calendar", FormMethod.Post, new { @class = "form-horizontal" }))
{
    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Calendar\_Admin.cshtml"
            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"IsPublic\"");

WriteLiteral(" class=\"control-label col-xs-3\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\Calendar\_Admin.cshtml"
                                                        Write(ResourceManager.GetLocalisedString("calIsPublic", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" class=\"yesno-checkbox\"");

WriteLiteral(" id=\"IsPublic\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"IsPublic\"");

WriteLiteral(" data-size=\"mini\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 1026), Tuple.Create("\"", 1051)
            
            #line 23 "..\..\Views\Calendar\_Admin.cshtml"
                                  , Tuple.Create(Tuple.Create("", 1036), Tuple.Create<System.Object, System.Int32>(Model.IsPublic
            
            #line default
            #line hidden
, 1036), false)
);

WriteLiteral(" value=\"true\"");

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"UpcomingEvents\"");

WriteLiteral(" class=\"control-label col-xs-3\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\Calendar\_Admin.cshtml"
                                                              Write(ResourceManager.GetLocalisedString("calUpcomingWidget", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" class=\"yesno-checkbox\"");

WriteLiteral(" id=\"UpcomingEvents\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"UpcomingEvents\"");

WriteLiteral(" data-size=\"mini\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 1467), Tuple.Create("\"", 1498)
            
            #line 31 "..\..\Views\Calendar\_Admin.cshtml"
                                              , Tuple.Create(Tuple.Create("", 1477), Tuple.Create<System.Object, System.Int32>(Model.UpcomingEvents
            
            #line default
            #line hidden
, 1477), false)
);

WriteLiteral(" value=\"true\"");

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"MaxRecords\"");

WriteLiteral(" class=\"control-label col-xs-3\"");

WriteLiteral(">");

            
            #line 37 "..\..\Views\Calendar\_Admin.cshtml"
                                                          Write(ResourceManager.GetLocalisedString("calMaxRecords", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 40 "..\..\Views\Calendar\_Admin.cshtml"
       Write(Html.TextBoxFor(m => m.MaxRecords, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"FirstDayofWeek\"");

WriteLiteral(" class=\"control-label col-xs-3\"");

WriteLiteral(">");

            
            #line 44 "..\..\Views\Calendar\_Admin.cshtml"
                                                              Write(ResourceManager.GetLocalisedString("calFirstDayofWeek", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 47 "..\..\Views\Calendar\_Admin.cshtml"
       Write(Html.EnumDropDownListFor(m => m.FirstDayofWeek, new { @class = "form-control" }, ""));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"ShowBirthdays\"");

WriteLiteral(" class=\"checkbox col-xs-3 col-xs-offset-3\"");

WriteLiteral(">");

            
            #line 51 "..\..\Views\Calendar\_Admin.cshtml"
                                                                        Write(Html.CheckBoxFor(m => m.ShowBirthdays));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 51 "..\..\Views\Calendar\_Admin.cshtml"
                                                                                                                Write(ResourceManager.GetLocalisedString("calShowBDays", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <label");

WriteLiteral(" for=\"PublicHolidays\"");

WriteLiteral(" class=\"checkbox col-xs-3 col-xs-offset-3\"");

WriteLiteral(">");

            
            #line 55 "..\..\Views\Calendar\_Admin.cshtml"
                                                                         Write(Html.CheckBoxFor(m => m.PublicHolidays));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 55 "..\..\Views\Calendar\_Admin.cshtml"
                                                                                                                  Write(ResourceManager.GetLocalisedString("calPublicHolidays", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n        <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 57 "..\..\Views\Calendar\_Admin.cshtml"
       Write(Html.DropDownListFor(model => model.CountryCode, new SelectList(Model.Countries, "CountryCode", "Name"), new { @class = "form-control", id = "eventCountry" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n            <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"Region\"");

WriteLiteral(" id=\"countryRegion\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                <option");

WriteLiteral(" value=\'\'");

WriteLiteral(">No Regions</option>\r\n            </select>\r\n        </div>\r\n        <span");

WriteLiteral(" class=\"col-xs-10 small text-right\"");

WriteLiteral(">Public holiday data supplied by <a");

WriteLiteral(" href=\"http://kayaposoft.com/enrico/\"");

WriteLiteral(" title=\"Enrico Service is a free service written in PHP providing public holidays" +
" for several countries\"");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(">Enrico</a></span>\r\n    </div>\r\n");

            
            #line 66 "..\..\Views\Calendar\_Admin.cshtml"
    if (Config.TableExists("EVENT_SUBSCRIPTIONS"))
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"col-xs-12\"");

WriteLiteral("><h4>Club/Society Events Add On</h4></div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"EnableEvents\"");

WriteLiteral(" class=\"control-label col-xs-3\"");

WriteLiteral(">");

            
            #line 70 "..\..\Views\Calendar\_Admin.cshtml"
                                                                Write(ResourceManager.GetLocalisedString("PluginTitle", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" class=\"yesno-checkbox\"");

WriteLiteral(" id=\"EnableEvents\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"EnableEvents\"");

WriteLiteral(" data-size=\"mini\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 3874), Tuple.Create("\"", 3903)
            
            #line 72 "..\..\Views\Calendar\_Admin.cshtml"
                                              , Tuple.Create(Tuple.Create("", 3884), Tuple.Create<System.Object, System.Int32>(Model.EnableEvents
            
            #line default
            #line hidden
, 3884), false)
);

WriteLiteral(" value=\"true\"");

WriteLiteral(" />\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"ShowInCalendar\"");

WriteLiteral(" class=\"control-label col-xs-3\"");

WriteLiteral(">");

            
            #line 78 "..\..\Views\Calendar\_Admin.cshtml"
                                                                  Write(ResourceManager.GetLocalisedString("lblShowInCalendar", "Events"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" class=\"yesno-checkbox\"");

WriteLiteral(" id=\"ShowInCalendar\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"ShowInCalendar\"");

WriteLiteral(" data-size=\"mini\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 4351), Tuple.Create("\"", 4382)
            
            #line 80 "..\..\Views\Calendar\_Admin.cshtml"
                                                  , Tuple.Create(Tuple.Create("", 4361), Tuple.Create<System.Object, System.Int32>(Model.ShowInCalendar
            
            #line default
            #line hidden
, 4361), false)
);

WriteLiteral(" value=\"true\"");

WriteLiteral(" />\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"form-group clearfix\"");

WriteLiteral(">\r\n\r\n            <label");

WriteLiteral(" class=\"control-label col-xs-3\"");

WriteLiteral(">Allowed Roles</label>\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 89 "..\..\Views\Calendar\_Admin.cshtml"
           Write(Html.TextBoxFor(m => m.Roles, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <label");

WriteLiteral(" class=\"small text-muted\"");

WriteLiteral(">restrict access to specific Roles, comma seperated list.</label>\r\n            </" +
"div>\r\n        </div>\r\n");

            
            #line 93 "..\..\Views\Calendar\_Admin.cshtml"

    }


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-success col-xs-offset-10\"");

WriteLiteral(">Save</button>\r\n    </div>\r\n");

            
            #line 99 "..\..\Views\Calendar\_Admin.cshtml"
}

            
            #line default
            #line hidden
            
            #line 100 "..\..\Views\Calendar\_Admin.cshtml"
 if (Config.TableExists("EVENT_SUBSCRIPTIONS"))
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"panel panel-primary panel-body clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 103 "..\..\Views\Calendar\_Admin.cshtml"
   Write(Html.Action("Admin", "Events"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

            
            #line 105 "..\..\Views\Calendar\_Admin.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 107 "..\..\Views\Calendar\_Admin.cshtml"
 using (Html.BeginScripts())
{

            
            #line default
            #line hidden
WriteLiteral("    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        $(document).ready(function () {
            $(""#eventCountry"").change(function () {
                populateRegions($(this).val());
            });
            populateRegions($(""#eventCountry"").val());
        });
        function populateRegions(country) {
                var subItems="""";
                $.getJSON(""");

            
            #line 118 "..\..\Views\Calendar\_Admin.cshtml"
                      Write(Url.Action("GetRegions","Calendar"));

            
            #line default
            #line hidden
WriteLiteral("\", { id: country }, function (data) {\r\n                    subItems = \"\";\r\n      " +
"              $.each(data, function (index, item) {\r\n                        if " +
"(item === \'");

            
            #line 121 "..\..\Views\Calendar\_Admin.cshtml"
                                 Write(ClassicConfig.GetValue("STRCALREGION"));

            
            #line default
            #line hidden
WriteLiteral(@"') {
                            subItems += ""<option value='"" + item + ""' selected>"" + item + ""</option>"";
                        } else {
                            subItems += ""<option value='"" + item + ""'>"" + item + ""</option>"";
                        }
                    });
                    if (subItems.length > 1) {
                        subItems = ""<option value=''>Select Region</option>"" + subItems;
                        $(""#countryRegion"").html(subItems);
                        $(""#countryRegion"").show();
                    } else {
                        subItems = ""<option value=''>No Regions</option>"";
                        $(""#countryRegion"").html(subItems);
                        $(""#countryRegion"").hide();
                    }

                });
        }
    </script>
");

            
            #line 140 "..\..\Views\Calendar\_Admin.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
