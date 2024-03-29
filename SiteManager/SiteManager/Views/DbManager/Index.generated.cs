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
    
    #line 1 "..\..\Views\DbManager\Index.cshtml"
    using System.Data;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 2 "..\..\Views\DbManager\Index.cshtml"
    using SnitzConfig;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DbManager/Index.cshtml")]
    public partial class _Views_DbManager_Index_cshtml : System.Web.Mvc.WebViewPage<System.Data.DataTable>
    {
        public _Views_DbManager_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\DbManager\Index.cshtml"
  
    ViewBag.Title = "Database Manager";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("styles", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 8 "..\..\Views\DbManager\Index.cshtml"
Write(Html.Raw(Config.ThemeCss("plugincss/dbmanager.min.css")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("<header");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row-fluid\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-6\"");

WriteLiteral(">\r\n            <hgroup>\r\n                <h4>Database Manager</h4>\r\n             " +
"   <h6");

WriteLiteral(" class=\"text-warning\"");

WriteLiteral(@">
                    Please use this tool with care, you are editing your LIVE database. Take a backup before making any changes.<br />
                    We shall not be liable for any direct, indirect, special or consequential damages resulting from the loss of use, data, or projects, arising out of or in connection with the use or performance of this tool.
                </h6>
            </hgroup>

        </div>
    </div>

</header>
");

            
            #line 25 "..\..\Views\DbManager\Index.cshtml"
 if (Roles.IsUserInRole("Administrator"))
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"container-fluid body-content\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-2 border\"");

WriteLiteral(" >\r\n            <h4>Table List</h4>\r\n            <div");

WriteLiteral(" class=\"table-bordered\"");

WriteLiteral(" style=\"max-height: 480px; overflow: auto;\"");

WriteLiteral(">\r\n                <ul");

WriteLiteral(" class=\"list-unstyled\"");

WriteLiteral(">\r\n\r\n");

            
            #line 33 "..\..\Views\DbManager\Index.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\DbManager\Index.cshtml"
                     foreach (DataRow row in Model.Rows)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <li>\r\n");

WriteLiteral("                            ");

            
            #line 36 "..\..\Views\DbManager\Index.cshtml"
                       Write(Ajax.ActionLink(
                                (string) row[2],
                                "Table",
                                "DbManager",
                                new {id = row[2]},

                                new AjaxOptions {OnSuccess = "linkSuccess", OnFailure = "linkFailure"}
                                ));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </li>\r\n");

            
            #line 45 "..\..\Views\DbManager\Index.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </ul>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-9\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row-fluid\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"btn-toolbar\"");

WriteLiteral(" role=\"toolbar\"");

WriteLiteral(" aria-label=\"Toolbar with button groups\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"btn-group mr-2\"");

WriteLiteral(" role=\"group\"");

WriteLiteral(" aria-label=\"First group\"");

WriteLiteral(">\r\n                        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-secondary\"");

WriteLiteral(" id=\"btn-sql\"");

WriteLiteral(" title=\"Query window\"");

WriteLiteral(">SQL</button>\r\n                        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-secondary\"");

WriteLiteral(" id=\"btn-create-table\"");

WriteLiteral(" title=\"New Table\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-table\"");

WriteLiteral("></i></button>\r\n\r\n                        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-secondary\"");

WriteLiteral(" id=\"btn-backup\"");

WriteLiteral(" title=\"Backup database\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-database\"");

WriteLiteral("></i></button>\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(" role=\"group\"");

WriteLiteral(" aria-label=\"Second group\"");

WriteLiteral(" id=\"table-buttons\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2611), Tuple.Create("\"", 2657)
            
            #line 60 "..\..\Views\DbManager\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2618), Tuple.Create<System.Object, System.Int32>(Url.Action("EditTable",new{col="NEW"})
            
            #line default
            #line hidden
, 2618), false)
);

WriteLiteral(" class=\"btn btn-primary row-add\"");

WriteLiteral(" id=\"btn-new-col\"");

WriteLiteral(" title=\"Add Column\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-columns\"");

WriteLiteral("></i></a>\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2788), Tuple.Create("\"", 2834)
            
            #line 61 "..\..\Views\DbManager\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2795), Tuple.Create<System.Object, System.Int32>(Url.Action("DropTable",new{col="NEW"})
            
            #line default
            #line hidden
, 2795), false)
);

WriteLiteral(" class=\"btn btn-primary row-add\"");

WriteLiteral(" id=\"btn-new-col\"");

WriteLiteral(" title=\"Drop Table\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash\"");

WriteLiteral("></i></a>\r\n                    </div>\r\n                </div>\r\n            </div>" +
"\r\n            <p></p>\r\n            <div");

WriteLiteral(" id=\"query-panel\"");

WriteLiteral(" class=\"row-fluid\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n");

            
            #line 67 "..\..\Views\DbManager\Index.cshtml"
                
            
            #line default
            #line hidden
            
            #line 67 "..\..\Views\DbManager\Index.cshtml"
                 using (Html.BeginForm("Query", "DbManager"))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"row-fluid\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                            <textarea");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"sqlQuery\"");

WriteLiteral(" id=\"sqlQuery\"");

WriteLiteral("></textarea>\r\n                            <input");

WriteLiteral(" id=\"runQuery\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"Execute Query\"");

WriteLiteral(" />\r\n                        </div>\r\n                    </div>\r\n");

            
            #line 75 "..\..\Views\DbManager\Index.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n\r\n            <div");

WriteLiteral(" class=\"row-fluid\"");

WriteLiteral(" id=\"create-panel\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n");

            
            #line 80 "..\..\Views\DbManager\Index.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\DbManager\Index.cshtml"
                     using (Html.BeginForm("CreateTable", "DbManager"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral("><button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">Create Table</button></span>\r\n                            <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"TableName\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"Table Name\"");

WriteLiteral(" />\r\n                        </div>\r\n");

            
            #line 86 "..\..\Views\DbManager\Index.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row-fluid\"");

WriteLiteral(" id=\"backup-panel\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n");

            
            #line 91 "..\..\Views\DbManager\Index.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 91 "..\..\Views\DbManager\Index.cshtml"
                     using (Html.BeginForm("BackupDatabase", "DbManager"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral("><button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">Backup Database</button></span>\r\n                            <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"BackupFile\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"Backup Filename\"");

WriteLiteral(" />\r\n                            ");

WriteLiteral("\r\n\r\n                        </div>\r\n");

WriteLiteral("                        <span");

WriteLiteral(" class=\"control-label danger\"");

WriteLiteral(">");

            
            #line 99 "..\..\Views\DbManager\Index.cshtml"
                                                      Write(Html.Raw(ViewBag.Message));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

WriteLiteral("                        <span");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">Backups will be placed in sqlBackups in your forums App_Data folder</span>\r\n");

            
            #line 101 "..\..\Views\DbManager\Index.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n            </div>\r\n\r\n            <p></p>\r\n            <d" +
"iv");

WriteLiteral(" id=\"result-panel\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row-fluid\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                        <h5");

WriteLiteral(" id=\"resultLabel\"");

WriteLiteral(">&nbsp;</h5>\r\n                    </div>\r\n                </div>\r\n               " +
" <div");

WriteLiteral(" class=\"row-fluid\"");

WriteLiteral(" >\r\n                    <div");

WriteLiteral(" id=\"result\"");

WriteLiteral(" style=\"overflow: auto; max-width: 90%; max-height: 400px; margin-bottom: 6px;\"");

WriteLiteral("></div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>" +
"\r\n");

            
            #line 119 "..\..\Views\DbManager\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("    <a");

WriteLiteral(" id=\"bottom\"");

WriteLiteral("></a>\r\n");

WriteLiteral("    <div");

WriteLiteral(" id=\'editModal\'");

WriteLiteral(" class=\'modal fade in\'");

WriteLiteral(" data-url=\'");

            
            #line 121 "..\..\Views\DbManager\Index.cshtml"
                                                   Write(Url.Action("EditTable", "DbManager"));

            
            #line default
            #line hidden
WriteLiteral("\'");

WriteLiteral(" aria-labelledby=\"myModalLabel\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">&times; </button>\r\n                    <h4");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(" id=\"myModalLabel\"");

WriteLiteral(">Add/Edit Column</h4>\r\n                </div>\r\n                <div");

WriteLiteral(" id=\'editContainer\'");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"container text-center\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-spinner fa-pulse fa-3x fa-fw\"");

WriteLiteral("></i>\r\n                        <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">Loading...</span>\r\n                    </div>\r\n                </div>\r\n         " +
"   </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 137 "..\..\Views\DbManager\Index.cshtml"
}

            
            #line default
            #line hidden
DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 6666), Tuple.Create("\"", 6727)
            
            #line 139 "..\..\Views\DbManager\Index.cshtml"
, Tuple.Create(Tuple.Create("", 6672), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/pluginjs/json-to-table.min.js")
            
            #line default
            #line hidden
, 6672), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 6774), Tuple.Create("\"", 6838)
            
            #line 140 "..\..\Views\DbManager\Index.cshtml"
, Tuple.Create(Tuple.Create("", 6780), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/pluginjs/snitz.sitemanage.min.js")
            
            #line default
            #line hidden
, 6780), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n");

});

        }
    }
}
#pragma warning restore 1591
