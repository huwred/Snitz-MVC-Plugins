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
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using MemberFields;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/EditorTemplates/FieldType.cshtml")]
    public partial class _Views_Shared_EditorTemplates_FieldType_cshtml_ : System.Web.Mvc.WebViewPage<string>
    {
        public _Views_Shared_EditorTemplates_FieldType_cshtml_()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
  
// S = Simple Input
// N = Number Input
// T = Text Area
// C = Check Box
// D = Date
// X = Time
// Z = DateTime
// O = Select Box
// M = Multi-Select Box
// H = Horizontal Radio Buttons
// V = Vertical Radio Buttons

            
            #line default
            #line hidden
WriteLiteral("\r\n<select");

WriteLiteral(" name=\"FieldType\"");

WriteLiteral(" id=\"FieldType\"");

WriteLiteral(" class=\"form-control field-type-select\"");

WriteLiteral(">\r\n    <option");

WriteLiteral(" value=\"S\"");

WriteLiteral(" ");

            
            #line 17 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "S") { 
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        Simple Input\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"T\"");

WriteLiteral(" ");

            
            #line 20 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "T") { 
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        Text Box\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"N\"");

WriteLiteral(" ");

            
            #line 23 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "N") { 
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        Number\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"C\"");

WriteLiteral(" ");

            
            #line 26 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "C") { 
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        True/False\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"D\"");

WriteLiteral(" ");

            
            #line 29 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "D") { 
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        Date\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"X\"");

WriteLiteral(" ");

            
            #line 32 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "X") { 
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        Time\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"Z\"");

WriteLiteral(" ");

            
            #line 35 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "Z") { 
            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        DateTime\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"O\"");

WriteLiteral(" ");

            
            #line 38 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "O") { 
            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        Select Box\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"M\"");

WriteLiteral(" ");

            
            #line 41 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "M") { 
            
            #line default
            #line hidden
            
            #line 41 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 41 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        Select Many\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"H\"");

WriteLiteral(" ");

            
            #line 44 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "H") { 
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        Radio Buttons (Horizontal)\r\n    </option>\r\n    <option");

WriteLiteral(" value=\"V\"");

WriteLiteral(" ");

            
            #line 47 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                       if (Model == "V") { 
            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                      Write(Html.Raw("selected"));

            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\Shared\EditorTemplates\FieldType.cshtml"
                                                                 }
            
            #line default
            #line hidden
WriteLiteral(">\r\n        Radio Buttons (Vertical)\r\n    </option>\r\n</select>");

        }
    }
}
#pragma warning restore 1591
