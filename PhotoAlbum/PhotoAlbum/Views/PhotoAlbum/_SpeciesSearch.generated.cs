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
    
    #line 2 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/PhotoAlbum/_SpeciesSearch.cshtml")]
    public partial class _Views_PhotoAlbum__SpeciesSearch_cshtml : System.Web.Mvc.WebViewPage<PhotoAlbum.ViewModels.SpeciesAlbum>
    {
        public _Views_PhotoAlbum__SpeciesSearch_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
  
    

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"form-inline\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label>");

            
            #line 12 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
              Write(ResourceManager.GetLocalisedString("lblSearchin", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"SrchId\"");

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                   Write(ResourceManager.GetLocalisedString("lblForumcode", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("            ");

            
            #line 16 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
       Write(Html.CheckBoxFor(m => m.SrchId, new { @class = "checkbox" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"SrchUser\"");

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                     Write(ResourceManager.GetLocalisedString("Member", "General"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("            ");

            
            #line 20 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
       Write(Html.CheckBoxFor(m => m.SrchUser, new { @class = "checkbox" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"SrchSciName\"");

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                        Write(ResourceManager.GetLocalisedString("lblScientificName", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
       Write(Html.CheckBoxFor(m => m.SrchSciName, new { @class = "checkbox" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"SrchLocName\"");

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                        Write(ResourceManager.GetLocalisedString("lblLocalName", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("            ");

            
            #line 28 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
       Write(Html.CheckBoxFor(m => m.SrchLocName, new { @class = "checkbox" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"SrchDesc\"");

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                     Write(ResourceManager.GetLocalisedString("lblDescription", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("            ");

            
            #line 32 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
       Write(Html.CheckBoxFor(m => m.SrchDesc, new { @class = "checkbox" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"GroupFilter \"");

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(">");

            
            #line 35 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                         Write(ResourceManager.GetLocalisedString("lblGroup", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("            ");

            
            #line 36 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
       Write(Html.DropDownList("GroupFilter", Model.GroupList, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group pull-right\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"SrchTerm\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                             Write(ResourceManager.GetLocalisedString("lblSearchFor", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("            ");

            
            #line 40 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
       Write(Html.TextBoxFor(m => m.SrchTerm, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">");

            
            #line 41 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                     Write(ResourceManager.GetLocalisedString("Search", "labels"));

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"form-inline\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" id=\"width-check\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"Thumbs\"");

WriteLiteral(">");

            
            #line 48 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                           Write(ResourceManager.GetLocalisedString("lblSearchView", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("&nbsp;</label>\r\n");

WriteLiteral("            ");

            
            #line 49 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
       Write(Html.CheckBoxFor(m => m.Thumbs, new { id = "viewthumbs" }));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 49 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                   Write(ResourceManager.GetLocalisedString("lblShowThumbnails", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"SpeciesOnly\"");

WriteLiteral(">&nbsp;</label>\r\n");

WriteLiteral("            ");

            
            #line 53 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
       Write(Html.CheckBoxFor(m => m.SpeciesOnly, new { id = "speciesonly" }));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 53 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                         Write(ResourceManager.GetLocalisedString("lblShowOnlySpecies", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group pull-right\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                    <select");

WriteLiteral(" class=\"form-control checkbox-inline dropdown-menu1\"");

WriteLiteral(" id=\"album-sortby\"");

WriteLiteral(" name=\"SortBy\"");

WriteLiteral(">\r\n                        <option");

WriteLiteral(" value=\"id\"");

WriteLiteral("\r\n                                ");

            
            #line 60 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                 if (ViewBag.SortBy == "id") { 
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                          Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                                      }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 61 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                       Write(ResourceManager.GetLocalisedString("optSortId", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </option>\r\n                        <option");

WriteLiteral(" value=\"date\"");

WriteLiteral("\r\n                                ");

            
            #line 64 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                 if (ViewBag.SortBy == "date") { 
            
            #line default
            #line hidden
            
            #line 64 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                            Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 64 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                                        }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 65 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                       Write(ResourceManager.GetLocalisedString("optSortDate", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </option>\r\n                        <option");

WriteLiteral(" value=\"user\"");

WriteLiteral("\r\n                                ");

            
            #line 68 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                 if (ViewBag.SortBy == "user") { 
            
            #line default
            #line hidden
            
            #line 68 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                            Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 68 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                                        }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 69 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                       Write(ResourceManager.GetLocalisedString("optSortUser", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </option>\r\n                        <option");

WriteLiteral(" value=\"desc\"");

WriteLiteral("\r\n                                ");

            
            #line 72 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                 if (ViewBag.SortBy == "desc") { 
            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                            Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                                        }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 73 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                       Write(ResourceManager.GetLocalisedString("optSortDesc", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </option>\r\n                        <option");

WriteLiteral(" value=\"file\"");

WriteLiteral("\r\n                                ");

            
            #line 76 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                 if (ViewBag.SortBy == "file") { 
            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                            Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                                        }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 77 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                       Write(ResourceManager.GetLocalisedString("optSortFile", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </option>\r\n                        <option");

WriteLiteral(" value=\"localname\"");

WriteLiteral("\r\n                                ");

            
            #line 80 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                 if (ViewBag.SortBy == "localname") { 
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                 Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                                             }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 81 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                       Write(ResourceManager.GetLocalisedString("optSortCommon", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </option>\r\n                        <option");

WriteLiteral(" value=\"scientific\"");

WriteLiteral("\r\n                                ");

            
            #line 84 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                 if (ViewBag.SortBy == "scientific") { 
            
            #line default
            #line hidden
            
            #line 84 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                  Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 84 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                                              }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 85 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                       Write(ResourceManager.GetLocalisedString("optSortScientific", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </option>\r\n                    </select>\r\n             " +
"   </span>\r\n                <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                    <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"SortOrder\"");

WriteLiteral(" id=\"album-sortdesc\"");

WriteLiteral(">\r\n                        <option");

WriteLiteral(" value=\"desc\"");

WriteLiteral("\r\n                                ");

            
            #line 92 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                 if (ViewBag.SortDir.ToLower() == "desc") { 
            
            #line default
            #line hidden
            
            #line 92 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                       Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 92 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                                                   }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 93 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                       Write(ResourceManager.GetLocalisedString("optDesc", "Controls"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </option>\r\n                        <option");

WriteLiteral(" value=\"asc\"");

WriteLiteral("\r\n                                ");

            
            #line 96 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                 if (ViewBag.SortDir.ToLower() == "asc") { 
            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                                                                                                  }
            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 97 "..\..\Views\PhotoAlbum\_SpeciesSearch.cshtml"
                       Write(ResourceManager.GetLocalisedString("optAsc", "Controls"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </option>\r\n                    </select>\r\n             " +
"   </span>\r\n                ");

WriteLiteral("\r\n            </div>\r\n    </div> \r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">&nbsp;</div>\r\n\r\n    \r\n\r\n");

        }
    }
}
#pragma warning restore 1591
