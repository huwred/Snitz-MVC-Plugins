using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Mvc;
using LangResources.Utility;
//using MvcBreadCrumbs;
using Newtonsoft.Json;
using PhotoAlbum.Helpers;
using PhotoAlbum.Models;
using PhotoAlbum.ViewModels;
using Snitz.Base;
using SnitzConfig;
using SnitzCore.Extensions;
using SnitzDataModel.Extensions;
using SnitzMembership;
using System.Web.UI;
using SnitzCore.Filters;
using SnitzDataModel.Controllers;

namespace PhotoAlbum.Controllers
{

    public class PhotoAlbumController : BaseController
    {
        //
        // GET: /PhotoAlbums/
        /// <summary>
        /// Show list of all members albums
        /// </summary>
        /// <param name="pagenum"></param>
        /// <param name="sortOrder"></param>
        /// <param name="sortCol"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public ActionResult Index(int pagenum = 1, string sortOrder = "asc", string sortCol = "user", string term = "")
        {
            //BreadCrumb.SetLabel(ResourceManager.GetLocalisedString("mnuMemberAlbums", "PhotoAlbum"));
            try
            {
                using (PhotoRepository db = new PhotoRepository(-1, 50))
                {
                    var model = db.AlbumIndex(pagenum, sortOrder, sortCol, term);
                    ViewBag.SortUser = ViewBag.SortDate = ViewBag.SortCount = "asc";
                    ViewBag.SortDir = sortOrder;
                    switch (sortCol)
                    {
                        case "user":
                            ViewBag.SortUser = sortOrder == "asc" ? "desc" : "asc";
                            break;
                        case "date":
                            ViewBag.SortDate = sortOrder == "asc" ? "desc" : "asc";
                            break;
                        case "count":
                            ViewBag.SortCount = sortOrder == "asc" ? "desc" : "asc";
                            break;
                    }
                    ViewBag.SortBy = sortCol;
                    ViewBag.SearchTerm = term;
                    return View("Index",model);
                }
            }
            catch (System.Exception ex)
            {
                ViewBag.Message = ex.Message;
                //This view is in main Snitz Views, just set a ViewBag.Message
                return View("Error");
            }


        }

        /// <summary>
        /// Show All images in Main album
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pagenum"></param>
        /// <param name="sortby"></param>
        /// <param name="groupFilter"></param>
        /// <param name="sortOrder"></param>
        /// <param name="showThumbs"></param>
        /// <param name="speciesOnly"></param>
        /// <returns></returns>
        public ActionResult Album(string id, int pagenum = 1, string sortby = "date", int groupFilter = -1,
            string sortOrder = "desc", bool showThumbs = true, bool speciesOnly = true)
        {
            int pagesize = 24;

            //BreadCrumb.Clear();
            //BreadCrumb.Add(Url.Action("Index", "PhotoAlbum"), ResourceManager.GetLocalisedString("mnuCommonAlbum"));

            using (PhotoRepository db = new PhotoRepository(-1, pagesize))
            {
                int filter = 0;
                if (groupFilter > 0)
                {
                    filter = groupFilter;
                }

                var images = db.GetSpeciesEntries(pagenum, sortby: sortby, filter: filter, speciesOnly: speciesOnly, sortDesc: sortOrder == "asc" ? "" : "1");
                ViewBag.Username = id;
                ViewBag.MemberId = 0;

                ViewBag.IsOwner = false;
                ViewBag.Display = 0;
                ViewBag.SortBy = sortby;
                ViewBag.SortPage = sortOrder;
                ViewBag.SortHead = sortOrder == "asc" ? "desc" : "asc";
                ViewBag.SortDir = sortOrder;// == "asc" ? "desc" : "asc";
                //Paging info
                ViewBag.Page = pagenum;
                ViewBag.PageCount = db.Pagecount;

                var vm = new SpeciesAlbum();

                vm.GroupList = GetGroupList();
                vm.Images = images;
                vm.Thumbs = showThumbs;
                vm.SpeciesOnly = speciesOnly;
                vm.SortBy = sortby;


                vm.GroupFilter = filter;
                ViewBag.JsonParams = JsonConvert.SerializeObject(vm);
                return View(vm);
                
            }

        }

        /// <summary>
        /// Show a Members photo Album
        /// </summary>
        /// <param name="id"></param>
        /// <param name="display"> 0=thumbs,1=details,2=list,3=slideshow</param>
        /// <param name="pagenum"></param>
        /// <param name="sortby"></param>
        /// <param name="sortorder"></param>
        /// <returns></returns>
        public ActionResult Member(string id, int display = 0, int pagenum = 1, string sortby = "date",string sortorder = "desc", int uid=0)
        {
            int pagesize = 50;
            if (display == 2)
                pagesize = 30;
            if (display == 1)
                pagesize = 15;
            if (display == 3)
                pagesize = 50;
            //BreadCrumb.Clear();
            //BreadCrumb.Add(Url.Action("Index", "PhotoAlbum"), ResourceManager.GetLocalisedString("mnuCommonAlbum"));
            int memberid = SnitzMembership.WebSecurity.GetUserId(id);

            using (PhotoRepository db = new PhotoRepository(memberid, pagesize))
            {
                //var images = db.GetAllEntries(pagenum,sortby,sortOrder);
                var images = db.GetSpeciesEntries(pagenum, sortby, 0, false, new List<string>() { "MemberId" }, memberid.ToString(),
                    sortDesc: sortorder == "asc" ? "" : "1");
                ViewBag.Username = id;
                ViewBag.MemberId = memberid;
                //todo: Remove Dummy Member
                ViewBag.IsOwner = (memberid == WebSecurity.CurrentUserId);
                ViewBag.Display = display;
                TempData["Display"] = display;
                ViewBag.SortBy = sortby;
                ViewBag.SortPage = sortorder;
                ViewBag.SortHead = sortorder == "asc" ? "desc" : "asc";
                ViewBag.SortDir = sortorder;
                //Paging info
                ViewBag.Page = pagenum;
                ViewBag.PageCount = db.Pagecount;
                SpeciesAlbum param = new SpeciesAlbum
                {
                    SortBy = sortby,
                    SortDesc = sortorder == "asc" ? "" : "1",
                    GroupFilter = 0,
                    SrchUser = true,
                    SrchTerm = id,
                    SpeciesOnly = false
                };
                ViewBag.JsonParams = JsonConvert.SerializeObject(param);
                return View(images);
            }

        }

        public ActionResult MemberImages(string id, int display = 0, int pagenum = 1, string sortby = "date",string sortorder = "desc", int uid=0)
        {
            int pagesize = 50;
            if (display == 2)
                pagesize = 30;
            if (display == 1)
                pagesize = 15;
            if (display == 3)
                pagesize = 50;

            int memberid = SnitzMembership.WebSecurity.GetUserId(id);

            using (PhotoRepository db = new PhotoRepository(memberid, pagesize))
            {
                //var images = db.GetAllEntries(pagenum,sortby,sortOrder);
                var images = db.GetSpeciesEntries(pagenum, sortby, 0, false, new List<string>() { "MemberId" }, memberid.ToString(),
                    sortDesc: sortorder == "asc" ? "" : "1");
                ViewBag.Username = id;
                ViewBag.MemberId = memberid;
                //todo: Remove Dummy Member
                ViewBag.IsOwner = (memberid == WebSecurity.CurrentUserId);
                ViewBag.Display = display;
                TempData["Display"] = display;
                ViewBag.SortBy = sortby;
                ViewBag.SortPage = sortorder;
                ViewBag.SortHead = sortorder == "asc" ? "desc" : "asc";
                ViewBag.SortDir = sortorder;
                //Paging info
                ViewBag.Page = pagenum;
                ViewBag.PageCount = db.Pagecount;
                SpeciesAlbum param = new SpeciesAlbum
                {
                    SortBy = sortby,
                    SortDesc = sortorder == "asc" ? "" : "1",
                    GroupFilter = 0,
                    SrchUser = true,
                    SrchTerm = id,
                    SpeciesOnly = false
                };
                ViewBag.JsonParams = JsonConvert.SerializeObject(param);
                return PartialView(images);
            }

        }

        /// <summary>
        /// Displays the images in a Carousel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="photoid"></param>
        /// <returns></returns>
        public ActionResult Gallery(string id, int photoid = 0, int pagenum = 1, string searchparams = null)
        {
            //todo:test member
            SpeciesAlbum param = JsonConvert.DeserializeObject<SpeciesAlbum>(searchparams);

            //BreadCrumb.Clear();
            List<string> searchin = new List<string>();
            if (!String.IsNullOrWhiteSpace(param.SrchTerm))
            {
                if (param.SrchDesc)
                {
                    searchin.Add("Desc");
                }
                if (param.SrchLocName)
                {
                    searchin.Add("CommonName");
                }
                if (param.SrchSciName)
                {
                    searchin.Add("ScientificName");
                }
                if (param.SrchUser)
                {
                    searchin.Add("Member");
                }
                if (param.SrchId)
                {
                    searchin.Add("Id");
                }
            }
            

            using (PhotoRepository db = new PhotoRepository(-1, 1))
            {
                //var images = db.GetSpeciesEntries(pagenum, param.SortBy, param.GroupFilter, param.SpeciesOnly, searchin,
                //    param.SrchTerm, param.SortDesc);

                //bool found = false || photoid == 0;
                //while (!found)
                //{
                //    if (images[0].Id == photoid)
                //    {
                //        found = true;
                //        continue;
                //    }
                //    pagenum += 1;
                //    images = db.GetSpeciesEntries(pagenum, param.SortBy, param.GroupFilter, param.SpeciesOnly, searchin,
                //        param.SrchTerm, param.SortDesc);
                //}
                if (photoid != 0)
                {

                    pagenum = db.FindImagePage(photoid, param.SortBy, param.GroupFilter, param.SpeciesOnly, searchin, param.SrchTerm, param.SortDesc == "desc" ? "1" : param.SortDesc == "1" ? "1" : "");
                    pagenum += 1;

                }
                var images = db.GetSpeciesEntries(pagenum, param.SortBy, param.GroupFilter, param.SpeciesOnly, searchin,param.SrchTerm, param.SortDesc == "desc" ? "1" : param.SortDesc == "1" ? "1" : "");
                var imageFiles = new ImageModel();

                imageFiles.CurrentIdx = pagenum;
                imageFiles.CurrentImage = images[0];

                ViewBag.Username = id;
                string imagename = Url.Content("~/") + images[0].RootFolder +  "/PhotoAlbum/";
                imageFiles.Images.AddRange(images.Select(f => imagename + f.ImageName));
                ViewBag.JsonParams = searchparams;
                ViewBag.footer = images[0].MemberName + " - " +
                                 images[0].Timestamp.ToSnitzDateTime().ToFormattedString() + "<br/>" + images[0].Views +
                                 " " + ResourceManager.GetLocalisedString("lblViews", "PhotoAlbum");
                ViewBag.title = string.Format("{0}, {1}, {2}", images[0].CommonName, images[0].ScientificName,
                    images[0].Description);

                return View(imageFiles);

            }

        }

        public JsonResult Next(int id, string member, string searchparams = null)
        {
            SpeciesAlbum param = JsonConvert.DeserializeObject<SpeciesAlbum>(searchparams);
            List<string> searchin = new List<string>();
            if (!String.IsNullOrWhiteSpace(param.SrchTerm))
            {
                if (param.SrchDesc)
                {
                    searchin.Add("Desc");
                }
                if (param.SrchLocName)
                {
                    searchin.Add("CommonName");
                }
                if (param.SrchSciName)
                {
                    searchin.Add("ScientificName");
                }
                if (param.SrchUser)
                {
                    searchin.Add("Member");
                }
                if (param.SrchId)
                {
                    searchin.Add("Id");
                }
            }

            using (PhotoRepository db = new PhotoRepository(-1, 1))
            {
                var images = db.GetSpeciesEntries(id, param.SortBy, param.GroupFilter, param.SpeciesOnly, searchin,
                    param.SrchTerm, param.SortDesc == "desc" ? "1" : param.SortDesc == "1" ? "1" : "");
                //var images = db.GetSpeciesEntries(id, "id", 0, false);  //
                //db.GetAllEntries(-1);bundles/jqueryui
                if (id <= 0)
                    id = (int)db.Pagecount;
                if (id >= (int)db.Pagecount)
                    id = 0;

                var footer = images[0].MemberName + " - " + images[0].Timestamp.ToSnitzDateTime().ToFormattedString() +
                             "<br/>" + images[0].Views + " " + ResourceManager.GetLocalisedString("lblViews", "PhotoAlbum");
                var title = string.Format("{0}, {1}, {2}", images[0].CommonName, images[0].ScientificName,
                    images[0].Description);
                var src = "";
                src = GetImagePath(images[0]);

                return Json(new { src = src, title = title, idx = id, desc = footer }, JsonRequestBehavior.AllowGet);

            }
        }

        #region Admin

        public ActionResult Admin()
        {
            using (PhotoRepository db = new PhotoRepository())
            {
                AdminAlbumViewModel vm = new AdminAlbumViewModel();
                ViewBag.Disabled = "";
                vm.Protected = ClassicConfig.GetIntValue("INTPROTECTPHOTO") == 1;
                vm.Groups = db.AlbumGroups();
                vm.PublicAlbum = ClassicConfig.GetIntValue("INTCOMMONALBUM") == 1;
                vm.MemberAlbums = ClassicConfig.GetValue("STRPHOTOALBUM") == "1";
                vm.FeaturedPhoto = ClassicConfig.GetIntValue("INTFEATUREDPHOTO") == 1;
                ViewBag.NoImages = !db.PhotoIdList().Any();
                if (ViewBag.NoImages)
                {
                    ViewBag.Disabled = "disabled";
                }
                return View("Admin", vm);
            }

        }

        public ActionResult Enable()
        {
            return PartialView("_Enable");
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult SaveGroup(AlbumGroup model)
        {
            string message = "Success";
            using (PhotoRepository db = new PhotoRepository())
            {
                if (model.Id == 0)
                {
                    db.Add(model);
                    message = "Group added successfully";
                }
                else
                {
                    db.Save(model);
                    message = "Group updated successfully";
                }

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.Authorize]
        public JsonResult DeleteGroup(AlbumGroup model)
        {
            string message = "Delete failed";
            using (PhotoRepository db = new PhotoRepository())
            {
                db.Delete(model);
                message = "Delete Success";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveLimits(FormCollection form)
        {
            string message = "Updated: ";
            try
            {
                foreach (var key in form.AllKeys)
                {
                    string dictKey = key.ToUpper(CultureInfo.CurrentCulture);
                    if (ClassicConfig.ConfigDictionary.ContainsKey(dictKey))
                    {
                        ClassicConfig.ConfigDictionary[dictKey] = form[dictKey];
                    }
                    else
                    {
                        ClassicConfig.ConfigDictionary.Add(dictKey, form[dictKey]);
                    }
                    ClassicConfig.Update(new[] {dictKey});
                    message += dictKey + ", ";
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                message += e.Message;
            }

            //ClassicConfig.Update(new[] { "INTCOMMONALBUM" });
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveConfigBool(string id, string value)
        {
            string message = "Success";
            if (ClassicConfig.ConfigDictionary.ContainsKey(id))
            {
                ClassicConfig.ConfigDictionary[id] = value == "true" ? "1" : "0";
            }
            else
            {
                ClassicConfig.ConfigDictionary.Add(id, value == "true" ? "1" : "0");
            }
            ClassicConfig.Update(new[] {id});
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        #endregion

        [System.Web.Mvc.HttpPost]
        public ActionResult Member(SpeciesAlbum album, string id, int display = 0, int pagenum = 1)
        {
            int pagesize = 50;
            if (display == 2)
                pagesize = 30;
            if (display == 1)
                pagesize = 15;
            if (display == 3)
                pagesize = 50;

            int memberid = SnitzMembership.WebSecurity.GetUserId(id);

            using (PhotoRepository db = new PhotoRepository(memberid, pagesize))
            {
                //var images = db.GetAllEntries(pagenum,sortby,sortOrder);
                var images = db.GetSpeciesEntries(pagenum, album.SortBy, 0, false, new List<string>() {"MemberId"}, memberid.ToString(),
                    sortDesc: album.SortDesc);
                ViewBag.Username = id;
                ViewBag.MemberId = memberid;
                //todo: Remove Dummy Member
                ViewBag.IsOwner = (memberid == WebSecurity.CurrentUserId);
                ViewBag.Display = display;
                ViewBag.SortBy = album.SortBy;
                ViewBag.SortDir = album.SortDesc == "1" ? "desc" : "asc";
                ViewBag.SortPage = ViewBag.SortDir;
                ViewBag.SortHead = ViewBag.SortDir == "asc" ? "desc" : "asc";
                //Paging info
                ViewBag.Page = pagenum;
                ViewBag.PageCount = db.Pagecount;
                SpeciesAlbum param = new SpeciesAlbum
                {
                    SortBy = album.SortBy,
                    SortDesc = album.SortDesc,
                    GroupFilter = 0,
                    SrchUser = true,
                    SrchTerm = id,
                    SpeciesOnly = false
                };
                ViewBag.JsonParams = JsonConvert.SerializeObject(param);
                return View(images);
            }

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Album(SpeciesAlbum album, int pagenum = 1)
        {
            int pagesize = 24;

            //BreadCrumb.Clear();
            //BreadCrumb.Add(Url.Action("Index", "PhotoAlbum"), ResourceManager.GetLocalisedString("mnuCommonAlbum"));
            int filter = (int) album.GroupFilter;
            List<string> searchin = new List<string>();
            if (!String.IsNullOrWhiteSpace(album.SrchTerm))
            {
                if (album.SrchDesc)
                {
                    searchin.Add("Desc");
                }
                if (album.SrchLocName)
                {
                    searchin.Add("CommonName");
                }
                if (album.SrchSciName)
                {
                    searchin.Add("ScientificName");
                }
                if (album.SrchUser)
                {
                    searchin.Add("Member");
                }
                if (album.SrchId)
                {
                    searchin.Add("Id");
                }
            }

            using (PhotoRepository db = new PhotoRepository(-1, pagesize))
            {
                var images = db.GetSpeciesEntries(pagenum, album.SortBy, (int) album.GroupFilter, album.SpeciesOnly,
                    searchin, album.SrchTerm, album.SortDesc == "asc" ? "" : "1");

                ViewBag.MemberId = 0;

                ViewBag.IsOwner = false;
                ViewBag.Display = 0;
                ViewBag.SortBy = album.SortBy;
                ViewBag.SortDir = album.SortDesc == "1" ? "desc" : album.SortDesc == "desc" ? "desc" : "asc";
                ViewBag.SortPage = album.SortDesc == "1" ? "desc" : album.SortDesc == "desc" ? "desc" : "asc";
                //Paging info
                ViewBag.Page = pagenum;
                ViewBag.PageCount = db.Pagecount;
                album.GroupList = GetGroupList();
                album.Images = images;
                ViewBag.JsonParams = JsonConvert.SerializeObject(album);
                ViewBag.SortPage = ViewBag.SortDir;
                ViewBag.SortHead = ViewBag.SortDir == "asc" ? "desc" : "asc";
                return View(album);
                
            }


        }

        [NonAction]
        private SelectList GetGroupList()
        {
            SelectListItem selListItem = new SelectListItem() {Value = "0", Text = "All"};

            //Create a list of select list items - this will be returned as your select list
            List<SelectListItem> groupList = new List<SelectListItem>();
            //Add select list item to list of selectlistitems
            groupList.Add(selListItem);

            using (PhotoRepository db = new PhotoRepository())
            {
                groupList.AddRange(new SelectList(db.AlbumGroups(), "Id", "Description"));
            }


            var gList = new SelectList(groupList, "Value", "Text", 0);

            foreach (var item in gList)
            {
                var lname = "Group_" + item.Text.Replace(" ", ""); //ResourceManager.GetKey(item.Text);
                if (!String.IsNullOrEmpty(lname))
                    item.Text = ResourceManager.GetLocalisedString(lname, "PhotoAlbum");
            }
            return gList;
        }

        public PartialViewResult MemberSlideShow(string id, int photoid = 0, int pagenum = 1, string sortby = "date",string sortorder = "desc")
        {
            int memberid = SnitzMembership.WebSecurity.GetUserId(id);
            //BreadCrumb.Clear();


            using (PhotoRepository db = new PhotoRepository(-1,100))
            {
                var images = db.GetSpeciesEntries(1, sortby, 0, false, new List<string>() {"MemberId"}, memberid.ToString(), sortorder == "asc" ? "" : "1");
                string imagepath = Url.Content("~/" + images[0].RootFolder + "/PhotoAlbum/");

                var imageFiles = new ImageModel();
                int idx = images.FindIndex(i => i.Id == photoid);
                imageFiles.CurrentIdx = idx < 0 ? 0 : idx;
                imageFiles.CurrentImage = images[0];
                imageFiles.Images.AddRange(images.Select(f => imagepath + f.ImageName));
                ViewBag.Username = id;

                SpeciesAlbum param = new SpeciesAlbum
                {
                    SortBy = sortby,
                    SortDesc = sortorder,
                    GroupFilter = 0,
                    SrchUser = true,
                    SrchTerm = id,
                    SpeciesOnly = false
                };
                ViewBag.JsonParams = JsonConvert.SerializeObject(param);
                return PartialView("_MemberSlideShow", imageFiles);
            }

        }


        private string GetImagePath(AlbumImage image, bool view = false)
        {
            string imgpath = Url.Content("~/Content/PhotoAlbum/");
            if (ClassicConfig.GetIntValue("INTPROTECTCONTENT") == 1 &&
                    ClassicConfig.GetIntValue("INTPROTECTPHOTO") == 1)
            {
                imgpath = Url.Content("~/ProtectedContent/PhotoAlbum/");
            }
            if (System.IO.File.Exists(Server.MapPath(imgpath + image.Timestamp + "_" + image.Location)))
            {
                if (view)
                {
                    PhotoRepository.UpdateViews(image);
                }

                return Url.Content(imgpath + image.Timestamp + "_" + image.Location);
            }
            if (System.IO.File.Exists(Server.MapPath(imgpath + image.Location)))
            {
                if (view)
                {
                    PhotoRepository.UpdateViews(image);
                }

                return Url.Content(imgpath + image.Location);
            }
            return Url.Content("~/content/images/notfound_lg.jpg");

        }

        //
        // GET: /PhotoAlbum/Edit/5
        /// <summary>
        /// Show edit image form
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[BreadCrumb(NoBreadCrumb = true)]
        [System.Web.Mvc.Authorize]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Edit(int id)
        {
            var img = new PhotoRepository().GetImage(id);
            return PartialView("popEditImage", img);
        }

        [System.Web.Mvc.Authorize]
        public ActionResult TogglePrivacy(int id, bool state = false)
        {
            if (HttpContext.Request.UrlReferrer != null)
            {
                var referer = HttpContext.Request.UrlReferrer.PathAndQuery;
                PhotoRepository.SetPrivacy(id);

                return Redirect(referer);
            }
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.Authorize]
        public ActionResult ToggleDoNotFeature(int id, bool state = false)
        {
            if (HttpContext.Request.UrlReferrer != null)
            {
                var referer = HttpContext.Request.UrlReferrer.PathAndQuery;
                PhotoRepository.SetDoNotFeature(id);

                return Redirect(referer);
            }
            return RedirectToAction("Index");
        }

        //[BreadCrumb(NoBreadCrumb = true)]
        [DoNotLogActionFilter]
        public ThumbnailResult ThumbNail(int id)
        {
            return new ThumbnailResult(id);
        }

        //[BreadCrumb(NoBreadCrumb = true)]
        [DoNotLogActionFilter]
        public FileResult GetPhotoThumbnail(int id, int width = 320, int height = 240)
        {
            try
            {
                using (PhotoRepository db = new PhotoRepository(-1))
                {
                    // Loading photos’ info from database ...
                    var photo = db.GetImage(id);

                    if (photo != null)
                    {
                        var path = HostingEnvironment.MapPath(GetImagePath(photo));
                        string owner = null;
                        try
                        {
                            owner = MemberManager.GetUser(photo.MemberId).UserName;
                        }
                        catch (Exception)
                        {
                            owner = ResourceManager.GetLocalisedString("lblUnknown", "labels");

                        }

                        // Save a thumbnail of the file
                        byte[] fileBytes = System.IO.File.ReadAllBytes(path);

                        System.Drawing.Image i;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ms.Write(fileBytes, 0, fileBytes.Length);
                            i = System.Drawing.Image.FromStream(ms);
                        }

                        // Create the thumbnail
                        System.Drawing.Image thumbnail = i.GetThumbnailImage(width, height, () => false, IntPtr.Zero);

                        WebImage wi = new WebImage(path);

                        wi.Resize(width, height, true, true) // Resizing the image to 100x100 px on the fly...
                            .Crop(1, 1); // Cropping it to remove 1px border at top and left sides (bug in WebImage)

                        var image = wi.GetBytes();

                        // Return byte array.
                        return File(image, "image/" + wi.ImageFormat);

                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                //This view is in main Snitz Views, just set a ViewBag.Message
                throw;
            }
                

            //throw new HttpException(404, "Not found");
            // Loading a default photo for realties that don't have a Photo
            //new WebImage(HostingEnvironment.MapPath(@"~/Content/images/nophoto100x100.png")).Write();
            return File(new WebImage(HostingEnvironment.MapPath(@"~/Content/images/notfound.png")).GetBytes(),"image/png");
        }

        public JsonResult GetCaption(int id)
        {
            using (PhotoRepository db = new PhotoRepository(-1))
            {
                // Loading photo info from database ...
                var photo = db.GetImage(id);
                if (!String.IsNullOrWhiteSpace(photo.Description))
                {
                    return Json(photo.Description, JsonRequestBehavior.AllowGet);
                }
                    
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
        //[BreadCrumb(NoBreadCrumb = true)]
        public ActionResult GetPhoto(int id)
        {
            using (PhotoRepository db = new PhotoRepository(-1))
            {
                    // Loading photo info from database ...
                var photo = db.GetImage(id);

                if (!String.IsNullOrWhiteSpace(photo.Location))
                {
                    var path = HostingEnvironment.MapPath(GetImagePath(photo,true));
                    var wi = new WebImage(path);
                    var imgFormat = wi.ImageFormat;
                    
                    //var image = wi.GetBytes();
                    byte[] image = System.IO.File.ReadAllBytes(path);
                    // Return byte array as jpeg. TODO: Add filename?
                    return base.File(path, "image/" + imgFormat );

                }
                
            }

            return File(new WebImage(HostingEnvironment.MapPath(@"~/Content/images/notfound_lg.png")).GetBytes(), "image/png");
            //throw new HttpException(404, "Not found");
        }

        //
        // POST: /PhotoAlbum/Edit/5
        /// <summary>
        /// Save changed image information
        /// </summary>
        /// <param name="image"></param>
        /// <param name="ImageFile"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize]
        public ActionResult Edit(AlbumImage image, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //is there a new image
                    if (ImageFile != null)
                    {
                        //delete the old image and thumb
                        try
                        {
                            System.IO.File.Delete(Server.MapPath("~/" + image.RootFolder + "/PhotoAlbum/" + image.Timestamp + "_" + image.Location));
                            System.IO.File.Delete(Server.MapPath("~/" + image.RootFolder + "/PhotoAlbum/thumbs/" + image.Timestamp + "_" + image.Location));
                        }
                        catch{}

                        //save new image
                        image.Location = AlbumExtensions.GetSafeFilename(Path.GetFileName(ImageFile.FileName));
                        System.Drawing.Image img = System.Drawing.Image.FromStream(ImageFile.InputStream);
                        
                        image.Img = img;
                        image.Width = img.Width;
                        image.Height = img.Height;
                        image.Views = 0;
                        image.Size = (int) (ImageFile.InputStream.Length / 1024);
                        image.Timestamp = DateTime.UtcNow.ToSnitzDate();

                        TempData["message"] = ImageFile.FileName + ResourceManager.GetLocalisedString("lblSaved","labels");
                    }

                    PhotoRepository.SaveImage(image);
                    //todo: Remove Dummy Member
                    //var user = "HuwR"; 
                    var user = MemberManager.GetUser(image.MemberId).UserName;
                    return RedirectToAction("Member",new {id=user,display=1});
                }
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("popEditImage", image);
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                //This view is in main Snitz Views, just set a ViewBag.Message
                return View("Error");
            }
        }

        //
        // GET: /PhotoAlbum/Delete/5
        /// <summary>
        /// Delete images
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[BreadCrumb(NoBreadCrumb = true)]
        [System.Web.Mvc.Authorize] 
        public ActionResult Delete(int id)
        {
            if (HttpContext.Request.UrlReferrer != null)
            {
                var referer = HttpContext.Request.UrlReferrer.PathAndQuery;

                using ( PhotoRepository db = new PhotoRepository())
                {
                    db.DeleteImages(new[] {id});
                }
                return Redirect(referer);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Show the uplaod form
        /// </summary>
        /// <returns></returns>
        //[BreadCrumb(NoBreadCrumb = true)]
        [System.Web.Mvc.Authorize]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult UploadFile(bool fields=true)
        {
            var model = new UploadViewModel {Group = -1,MarkAsDoNotFeature=false};
            using (PhotoRepository db = new PhotoRepository())
            {
                model.GroupList = new SelectList(db.AlbumGroups(), "Id", "Description");
            }
                
            
            foreach (var item in model.GroupList)
            {
                var lname = "Group_" + item.Text.Replace(" ", "");
                item.Text = ResourceManager.GetLocalisedString(lname, "EnumDescriptions");
            }
            ViewBag.DisplayAll = fields;
            return PartialView("popImageUpload",model);
        }

        [DoNotLogActionFilter]
        public PartialViewResult FeaturedImage()
        {
            using (PhotoRepository db = new PhotoRepository())
            {
                    var ids = db.PhotoIdList().ToList();
                Random r = new Random();
                int index = r.Next(0, ids.Count); // list.Count for List<T>

                int oneRandom = ids[index];

                var photo = db.GetImage(oneRandom);

                string owner = null;
                try
                {
                    owner = MemberManager.GetUser(photo.MemberId).UserName;
                }
                catch (Exception)
                {
                    owner = ResourceManager.GetLocalisedString("lblUnknown", "labels");

                }

                photo.MemberName = owner;
                return PartialView("_FeaturedImage", photo);      
                
            }

        }

        [DoNotLogActionFilter]
        public PartialViewResult GetFeaturedImage(int id)
        {
            using (PhotoRepository db = new PhotoRepository())
            {

                var photo = db.GetImage(id);

                string owner = null;
                try
                {
                    owner = MemberManager.GetUser(photo.MemberId).UserName;
                }
                catch (Exception)
                {
                    owner = ResourceManager.GetLocalisedString("lblUnknown", "labels");

                }

                photo.MemberName = owner;
                return PartialView("_Featured", photo);
            }

        }
        public string GetImageUrl(int id, bool thumbnail = true)
        {
            using (PhotoRepository db = new PhotoRepository())
            {

                var photo = db.GetImage(id);

                string imgpath = Url.Content("~/Content/PhotoAlbum/");
                if (ClassicConfig.GetIntValue("INTPROTECTCONTENT") == 1 &&
                    ClassicConfig.GetIntValue("INTPROTECTPHOTO") == 1)
                {
                    imgpath = Url.Content("~/ProtectedContent/PhotoAlbum/");
                }
                if (thumbnail)
                {
                    imgpath += "thumbs/";
                }
            
                // Put some caching logic here if you want it to perform better
                if (!System.IO.File.Exists(Server.MapPath(imgpath + photo.Location)))
                {
                    if (!System.IO.File.Exists(Server.MapPath(imgpath + photo.Timestamp + "_" + photo.Location)))
                    {
                        return Url.Content("~/content/images/notfound_lg.jpg");
                    }
                    return Url.Content(imgpath + photo.Timestamp + "_" + photo.Location);
                }
                return Url.Content(imgpath + photo.Location);
                
            }

        }

        /// <summary>
        /// Post the image
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="ImageFile"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize]
        public JsonResult Upload()
        {
            
            AlbumImage image = new AlbumImage();
            try
            {
                //todo: Remove Dummy Member
                //image.MemberId = 20;
                image.MemberId = WebSecurity.CurrentUserId;
                image.ScientificName = Request.Form["ScientificName"];
                image.CommonName = Request.Form["CommonName"];
                image.Group = Convert.ToInt32(Request.Form["Group"]??"-1");
                image.Views = 0;
                image.IsPrivate = Convert.ToBoolean(Request.Form["MarkAsPrivate"]);
                image.DoNotFeature = Convert.ToBoolean(Request.Form["MarkAsDoNotFeature"]);
                //todo: do some validation as no modalstste

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i]; //Uploaded file                                       
                    if (file != null)
                    {
                        image.Size = file.ContentLength;
                        if (image.Size > Convert.ToInt32(ClassicConfig.GetValue("INTMAXIMAGESIZE"))*1024*1024)
                        {
                            return Json(ResourceManager.GetLocalisedString("lblError", "labels") + "|" + ResourceManager.GetLocalisedString("errTooLarge", "PhotoAlbum"));
                        }

                        image.Mime = file.ContentType;

                        var extension = Path.GetExtension(file.FileName);
                        if (extension != null)
                        {
                            string fileExt = extension.ToLower();
                            bool contains = false;
                            foreach (string name in ClassicConfig.GetValue("STRIMAGETYPES").ToLower().Split(','))
                            {
                                if (fileExt.Contains(name) || name == image.Mime)
                                    contains = true;
                            }
                            if (!contains)
                            {
                                return Json(ResourceManager.GetLocalisedString("lblError", "labels") + "|" + ResourceManager.GetLocalisedString("errType", "PhotoAlbum"));
                            }
                        }

                        image.Description = Request.Form.AllKeys.Contains("Description") ? Request.Form["Description"] : file.FileName;
                        image.Location = AlbumExtensions.GetSafeFilename(Path.GetFileName(file.FileName));

                        System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);

                        image.Width = img.Width;
                        image.Height = img.Height;
                        image.Size = (int) (file.InputStream.Length/1024);
                        image.Timestamp = DateTime.UtcNow.ToSnitzDate();
                        string fullFileName = Server.MapPath("~/" + image.RootFolder + "/PhotoAlbum/" + image.Timestamp + "_" + image.Location);
                        file.SaveAs(fullFileName);
                        img.Dispose();
                        TempData["message"] = file.FileName + ResourceManager.GetLocalisedString("lblSaved", "labels");
                    }
                    //file.SaveAs(Path.Combine(uploadPath, fileName)); //File will be saved in users folder
                }
                using (PhotoRepository db = new PhotoRepository())
                {
                    db.AddImage(image);
                }
                    
                return Json(image.Location + "|" + image.Id + "|" + Request.Form["showCaption"]);
            }
            catch (Exception ex)
            {
                return Json("Error|" + ex.Message + "\r\nStackTrace:" + ex.StackTrace + "\r\nInnerException" + ex.InnerException);
            }

        }

        [System.Web.Mvc.Authorize]
        public ActionResult DeleteImages(FormCollection form)
        {
            if (form.HasKeys())
            {
                if (form.AllKeys.Contains("imgDelete"))
                {
                    //parse the ids
                    var ids = AlbumExtensions.StringToIntList(form["imgDelete"]);
                    if (HttpContext.Request.UrlReferrer != null)
                    {
                        var referer = HttpContext.Request.UrlReferrer.PathAndQuery;

                        using (PhotoRepository db = new PhotoRepository())
                        {
                            db.DeleteImages(ids);
                        }
                        return Redirect(referer);
                    }
                }
            }
            return RedirectToAction("Index");
        }

    }

}
