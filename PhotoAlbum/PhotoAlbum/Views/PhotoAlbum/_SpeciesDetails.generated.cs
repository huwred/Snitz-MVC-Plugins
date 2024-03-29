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
    
    #line 5 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
    using LangResources.Utility;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
    using PetaPoco;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
    using PhotoAlbum.Views.Helpers;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
    using Snitz.Base;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
    using SnitzCore.Extensions;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
    using SnitzDataModel.Extensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/PhotoAlbum/_SpeciesDetails.cshtml")]
    public partial class _Views_PhotoAlbum__SpeciesDetails_cshtml : System.Web.Mvc.WebViewPage<PhotoAlbum.ViewModels.SpeciesAlbum>
    {
        public _Views_PhotoAlbum__SpeciesDetails_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 8 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
  
    string sortIcon = ViewBag.SortDir == "asc" ? "<i class=\"fa fa-sort-desc\"></i>" : "<i class=\"fa fa-sort-asc\"></i>";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<div");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(">\r\n\r\n        <table");

WriteLiteral(" class=\"table table-bordered table-striped\"");

WriteLiteral(">\r\n            <thead>\r\n                <tr");

WriteLiteral(" class=\"bg-primary\"");

WriteLiteral(">\r\n                    <th");

WriteLiteral(" class=\"hidden-xs\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 19 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                   Write(Html.ActionLink( @ResourceManager.GetLocalisedString("Member","General"), "Album", new {  pagenum=ViewBag.Page, sortby="user", sortOrder = ViewBag.SortHead, showThumbs=Model.Thumbs,speciesOnly=Model.SpeciesOnly }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 20 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.SortBy == "user")
                        {
                            
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                       Write(Html.Raw(sortIcon));

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                               
                        } 

            
            #line default
            #line hidden
WriteLiteral("                    </th>\r\n");

            
            #line 25 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                     if (ViewBag.ShowThumbs)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <th");

WriteLiteral(" class=\"col-thumb\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 28 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                   Write(Html.ActionLink( @ResourceManager.GetLocalisedString("lblImage","PhotoAlbum"), "Album", new {  pagenum=ViewBag.Page, sortby="file", sortOrder = ViewBag.SortHead, showThumbs = Model.Thumbs, speciesOnly = Model.SpeciesOnly }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 29 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.SortBy == "file")
                        {
                            
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                       Write(Html.Raw(sortIcon));

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                               
                        } 

            
            #line default
            #line hidden
WriteLiteral("                        </th>\r\n");

            
            #line 34 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <th");

WriteLiteral(" class=\"hidden-xs hidden-sm\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 36 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                   Write(Html.ActionLink( @ResourceManager.GetLocalisedString("lblForumcode","PhotoAlbum"), "Album", new {  pagenum=ViewBag.Page, sortby="id", sortOrder = ViewBag.SortHead, showThumbs = Model.Thumbs, speciesOnly = Model.SpeciesOnly }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 37 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.SortBy == "id")
                        {
                            
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                       Write(Html.Raw(sortIcon));

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                               
                        } 

            
            #line default
            #line hidden
WriteLiteral("                    </th>\r\n                    <th");

WriteLiteral(" class=\"\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 43 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                   Write(Html.ActionLink( @ResourceManager.GetLocalisedString("lblScientificName","PhotoAlbum"), "Album", new {  pagenum=ViewBag.Page, sortby="scientific", sortOrder = ViewBag.SortHead, showThumbs = Model.Thumbs, speciesOnly = Model.SpeciesOnly }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 44 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.SortBy == "scientific")
                        {
                            
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                       Write(Html.Raw(sortIcon));

            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                               
                        } 

            
            #line default
            #line hidden
WriteLiteral("                    </th>\r\n                    <th");

WriteLiteral(" class=\"\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 50 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                   Write(Html.ActionLink( @ResourceManager.GetLocalisedString("lblLocalName","PhotoAlbum"), "Album", new {  pagenum=ViewBag.Page, sortby="localname", sortOrder = ViewBag.SortHead, showThumbs = Model.Thumbs, speciesOnly = Model.SpeciesOnly }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 51 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.SortBy == "localname")
                        {
                            
            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                       Write(Html.Raw(sortIcon));

            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                               
                        } 

            
            #line default
            #line hidden
WriteLiteral("                    </th>\r\n                    <th");

WriteLiteral(" class=\"hidden-xs\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 57 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                   Write(Html.ActionLink( @ResourceManager.GetLocalisedString("lblDescription","PhotoAlbum"), "Album", new {  pagenum=ViewBag.Page, sortby="desc", sortOrder = ViewBag.SortHead, showThumbs = Model.Thumbs, speciesOnly = Model.SpeciesOnly }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 58 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 58 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.SortBy == "desc")
                        {
                            
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                       Write(Html.Raw(sortIcon));

            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                               
                        } 

            
            #line default
            #line hidden
WriteLiteral("                    </th>\r\n                    <th");

WriteLiteral(" class=\"hidden-xs hidden-sm\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 64 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                   Write(Html.ActionLink( @ResourceManager.GetLocalisedString("lblGroup","PhotoAlbum"), "Album", new {  pagenum=ViewBag.Page, sortby="group", sortOrder = ViewBag.SortHead, showThumbs = Model.Thumbs, speciesOnly = Model.SpeciesOnly }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 65 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.SortBy == "group")
                        {
                            
            
            #line default
            #line hidden
            
            #line 67 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                       Write(Html.Raw(sortIcon));

            
            #line default
            #line hidden
            
            #line 67 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                               
                        } 

            
            #line default
            #line hidden
WriteLiteral("                    </th>\r\n                    <th");

WriteLiteral(" class=\"hidden-xs hidden-sm\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 71 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                   Write(Html.ActionLink( @ResourceManager.GetLocalisedString("lblDate","PhotoAlbum"), "Album", new {  pagenum=ViewBag.Page, sortby="date", sortOrder = ViewBag.SortHead, showThumbs = Model.Thumbs, speciesOnly = Model.SpeciesOnly }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 72 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.SortBy == "date")
                        {
                            
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                       Write(Html.Raw(sortIcon));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                               
                        } 

            
            #line default
            #line hidden
WriteLiteral("                    </th>\r\n                    <th");

WriteLiteral(" class=\"hidden-xs hidden-sm\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 78 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                   Write(Html.ActionLink( @ResourceManager.GetLocalisedString("lblViews","PhotoAlbum"), "Album", new {  pagenum=ViewBag.Page, sortby="views", sortOrder = ViewBag.SortHead, showThumbs = Model.Thumbs, speciesOnly = Model.SpeciesOnly }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 79 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.SortBy == "views")
                        {
                            
            
            #line default
            #line hidden
            
            #line 81 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                       Write(Html.Raw(sortIcon));

            
            #line default
            #line hidden
            
            #line 81 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                               
                        } 

            
            #line default
            #line hidden
WriteLiteral("                    </th> \r\n                </tr>\r\n            </thead>\r\n        " +
"    <tbody>\r\n");

            
            #line 87 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                
            
            #line default
            #line hidden
            
            #line 87 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                 foreach (var photo in Model.Images)
                {
                    var imgUrl = Url.Content("~/" + photo.RootFolder + "/PhotoAlbum/thumbs/") + photo.ImageName;

            
            #line default
            #line hidden
WriteLiteral("                    <tr>\r\n                        <td");

WriteLiteral(" class=\"hidden-xs\"");

WriteLiteral(">");

            
            #line 91 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                         Write(Html.ActionLink(photo.MemberName,"Member",new{id=photo.MemberName },new{title=ResourceManager.GetLocalisedString("tipViewMemberAlbum","PhotoAlbum"),data_toggle="tooltip"}));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 92 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 92 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                         if (ViewBag.ShowThumbs)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <td");

WriteLiteral("  class=\"col-thumb\"");

WriteLiteral("><a");

WriteLiteral(" class=\"view-gallery\"");

WriteLiteral(" target=\"_blank\"");

WriteAttribute("href", Tuple.Create(" href=\"", 5653), Tuple.Create("\"", 5777)
            
            #line 94 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                 , Tuple.Create(Tuple.Create("", 5660), Tuple.Create<System.Object, System.Int32>(Url.Action("Gallery", new {id = photo.MemberName, photoid = photo.Id,pagenum=1, searchparams= @ViewBag.JsonParams })
            
            #line default
            #line hidden
, 5660), false)
);

WriteAttribute("title", Tuple.Create(" title=\"", 5778), Tuple.Create("\"", 5856)
            
            #line 94 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                                                                                                                               , Tuple.Create(Tuple.Create("", 5786), Tuple.Create<System.Object, System.Int32>(ResourceManager.GetLocalisedString("lblImage","PhotoAlbum")
            
            #line default
            #line hidden
, 5786), false)
            
            #line 94 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                                                                                                                                                                                           , Tuple.Create(Tuple.Create(" ", 5846), Tuple.Create<System.Object, System.Int32>(photo.Id
            
            #line default
            #line hidden
, 5847), false)
);

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 5862), Tuple.Create("\"", 5922)
            
            #line 94 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                                                                                                                                                                                                                 , Tuple.Create(Tuple.Create("", 5868), Tuple.Create<System.Object, System.Int32>(Html.ImageUrlFor(photo.Location,photo.Timestamp,true)
            
            #line default
            #line hidden
, 5868), false)
);

WriteLiteral("/></a></td>\r\n");

            
            #line 95 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        <td");

WriteLiteral(" class=\"hidden-xs hidden-sm\"");

WriteLiteral(">[image=");

            
            #line 96 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                                          Write(photo.Id);

            
            #line default
            #line hidden
WriteLiteral("]</td>\r\n                        <td");

WriteLiteral(" class=\"\"");

WriteLiteral(">");

            
            #line 97 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                Write(photo.ScientificName);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td");

WriteLiteral(" class=\"\"");

WriteLiteral(">");

            
            #line 98 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                Write(photo.CommonName);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td");

WriteLiteral(" class=\"hidden-xs\"");

WriteLiteral(">");

            
            #line 99 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                         Write(photo.Description);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td");

WriteLiteral(" class=\"hidden-xs hidden-sm\"");

WriteLiteral(">");

            
            #line 100 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                                   Write(photo.GroupName);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td");

WriteLiteral(" class=\"hidden-xs hidden-sm\"");

WriteLiteral(">");

            
            #line 101 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                                   Write(photo.Timestamp.ToSnitzDateTime().ToFormattedString());

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td");

WriteLiteral(" class=\"hidden-xs hidden-sm\"");

WriteLiteral(">");

            
            #line 102 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                                   Write(photo.Views.ToLangNum());

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\r\n                    </tr>\r\n");

            
            #line 105 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("                ");

            
            #line 106 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                 if (!Model.Images.Any())
                {
                    var colspan = 8;
                    if (ViewBag.ShowThumbs)
                    {
                        colspan = 9;
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <tr");

WriteLiteral(" class=\"\"");

WriteLiteral("><td");

WriteAttribute("colspan", Tuple.Create(" colspan=\"", 6836), Tuple.Create("\"", 6854)
            
            #line 113 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
, Tuple.Create(Tuple.Create("", 6846), Tuple.Create<System.Object, System.Int32>(colspan
            
            #line default
            #line hidden
, 6846), false)
);

WriteLiteral(">");

            
            #line 113 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                                                   Write(ResourceManager.GetLocalisedString("lblNoImg", "PhotoAlbum"));

            
            #line default
            #line hidden
WriteLiteral("</td></tr>\r\n");

            
            #line 114 "..\..\Views\PhotoAlbum\_SpeciesDetails.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
