using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BbCodeFormatter;
using SnitzConfig;
using SnitzCore.Extensions;
using SnitzDataModel.Controllers;
using SnitzDataModel.Extensions;
using SnitzEvents.Models;
using SnitzEvents.ViewModels;


namespace SnitzEvents.Controllers
{

    public class EventsController : BaseController
    {
        [HttpGet]
        [AuthorizePublic(SnitzVar = "INTCALPUBLIC")]
        public ActionResult Index(int id=0, int old=0)
        {
            var vm = new AgendaViewModel
            {
                Categories = new Dictionary<int, string>(),
                Locations = new Dictionary<int, string>(),
                Clubs = new Dictionary<int, string>(),
                AllowedRoles = new List<string>()
            };
            using (EventsRepository db = new EventsRepository())
            {
                foreach (KeyValuePair<int, string> cat in db.GetCategories().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Categories.Add(cat.Key, BbCodeProcessor.Format(cat.Value));
                }
                foreach (KeyValuePair<int, string> loc in db.GetLocations().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Locations.Add(loc.Key, BbCodeProcessor.Format(loc.Value));
                }
                foreach (KeyValuePair<int, string> club in db.GetClubsList().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Clubs.Add(club.Key, BbCodeProcessor.Format(club.Value));
                }
                if(!String.IsNullOrWhiteSpace(ClassicConfig.GetValue("STRRESTRICTROLES")))
                    vm.AllowedRoles = ClassicConfig.GetValue("STRRESTRICTROLES").Split(',').ToList();

                if (id == -1 )
                {
                    ViewBag.StartDate = db.OldestEvent();
                    ViewBag.OldNew = -1;
                }else if (old < 0)
                {
                    ViewBag.OldNew = -1;
                    ViewBag.StartDate = db.OldestEvent();
                }
                else
                {
                    ViewBag.StartDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                    ViewBag.OldNew = 0;
                }
                ViewBag.CatSummary = db.GetCategorySummaryList(ViewBag.StartDate);
            }
            ViewBag.CatFilter = id;
            ViewBag.TotalEvents = 0;
            foreach (CatSummary cat in ViewBag.CatSummary)
            {
                ViewBag.TotalEvents += cat.EventCount;
            }
            return View(vm);
        }
        [HttpGet]
        public ActionResult Event(int id)
        {
            using (EventsRepository db = new EventsRepository())
            {
                var vm = new ClubEventViewModel();
                var evnt = db.GetClubEventById(id) ?? new ClubCalendarEventItem();
                vm.Id = evnt.Id;
                vm.Title = evnt.EventTitle;
                vm.Description = evnt.Description;
                vm.CatId = evnt.CatId;
                vm.ClubId = evnt.ClubId;
                vm.LocId = evnt.LocId;
                vm.StartDate = evnt.StartDate;
                vm.EndDate = evnt.EndDate;

                vm.Categories = new Dictionary<int, string>();
                vm.Locations = new Dictionary<int, string>();
                vm.Clubs = new Dictionary<int, string>();
                foreach (KeyValuePair<int, string> forum in db.GetCategories().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Categories.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                foreach (KeyValuePair<int, string> forum in db.GetLocations().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Locations.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                foreach (KeyValuePair<int, string> forum in db.GetClubsList().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Clubs.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                if (!String.IsNullOrWhiteSpace(ClassicConfig.GetValue("STRRESTRICTROLES")))
                    vm.AllowedRoles = ClassicConfig.GetValue("STRRESTRICTROLES").Split(',').ToList();
                return View(vm);
            }

        }

        [HttpPost]
        public ActionResult Filtered(FormCollection form)
        {
            var vm = new AgendaViewModel
            {
                Categories = new Dictionary<int, string>(),
                Locations = new Dictionary<int, string>(),
                Clubs = new Dictionary<int, string>()
            };

            return View("Index",vm);
        }
        [HttpGet]
        [Authorize]
        public ActionResult AddEditEvent(int id)
        {
            using (EventsRepository db = new EventsRepository())
            {
                var vm = new ClubEventViewModel();
                var evnt = db.GetClubEventById(id) ?? new ClubCalendarEventItem();
                vm.Id = evnt.Id;
                vm.Title = evnt.EventTitle;
                vm.Description = evnt.Description;
                vm.CatId = evnt.CatId;
                vm.ClubId = evnt.ClubId;
                vm.LocId = evnt.LocId;
                vm.StartDate = evnt.StartDate;
                vm.EndDate = evnt.EndDate;

                vm.Categories = new Dictionary<int, string>();
                vm.Locations = new Dictionary<int, string>();
                vm.Clubs = new Dictionary<int, string>();
                foreach (KeyValuePair<int, string> forum in db.GetCategories().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Categories.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                foreach (KeyValuePair<int, string> forum in db.GetLocations().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Locations.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                foreach (KeyValuePair<int, string> forum in db.GetClubsList().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Clubs.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                
                return View(vm);
            }

        }

        [HttpPost]
        [Authorize]
        public ActionResult AddEditEvent(ClubEventViewModel vm)
        {
            if (ModelState.IsValid)
            {
                ClubCalendarEventItem newevent = new ClubCalendarEventItem();
                if (vm.Id > 0)
                    newevent.Id = vm.Id;
                newevent.Title = vm.Title;
                newevent.EventTitle = vm.Title;
                newevent.Description = vm.Description;
                newevent.CatId = vm.CatId;
                newevent.ClubId = vm.ClubId;
                newevent.LocId = vm.LocId;
                newevent.Start = vm.StartDate.Value.ToSnitzServerDateString(ClassicConfig.ForumServerOffset);
                newevent.End = vm.EndDate.Value.ToSnitzServerDateString(ClassicConfig.ForumServerOffset); ;
                newevent.PostedDate = DateTime.UtcNow;
                newevent.PostedById = SnitzMembership.WebSecurity.CurrentUserId;

                newevent.Save();
                vm.Id = newevent.Id;
                //TODO: process club subscriptions
                return RedirectToAction("Index");
            }

            vm.Categories = new Dictionary<int, string>();
            vm.Locations = new Dictionary<int, string>();
            vm.Clubs = new Dictionary<int, string>();
            using (EventsRepository db = new EventsRepository())
            {
                foreach (KeyValuePair<int, string> forum in db.GetCategories().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Categories.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                foreach (KeyValuePair<int, string> forum in db.GetLocations().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Locations.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                foreach (KeyValuePair<int, string> forum in db.GetClubsList().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Clubs.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
            }
            return View(vm);

        }

        [Authorize]
        public JsonResult RemoveEvent(int id)
        {
            using (EventsRepository db = new EventsRepository())
            {
                try
                {
                    db.Delete(id);
                    return Json("Success");
                }
                catch (Exception)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Problem removing Event");
                }
                
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult EventSubs()
        {
            var vm = new SubscribeModel();

            using (EventsRepository db = new EventsRepository())
            {
                vm.SelectedSources = db.GetSubsList();

                return View(vm);
            }
        }
        [HttpPost]
        public ActionResult EventSubs(SubscribeModel vm)
        {
            if (ModelState.IsValid)
            {
                using (EventsRepository db = new EventsRepository())
                {
                    var currentsubs = db.GetSubsList().ToList();

                    var removesubs = from item in currentsubs
                                where !vm.SelectedSources.Contains(item)
                                select item;

                    foreach (var ii in removesubs)
                    {
                        db.SubDelete(ii, SnitzMembership.WebSecurity.CurrentUserId);
                    }

                    var addsubs = from item in vm.SelectedSources
                                  where !currentsubs.Contains(item)
                                select item;

                    foreach (var source in addsubs)
                    {
                        ClubCalendarSubscriptions sub = new ClubCalendarSubscriptions();
                        sub.ClubId = source;
                        sub.MemberId = SnitzMembership.WebSecurity.CurrentUserId;
                        sub.Save();
                    }
                    vm.SelectedSources = db.GetSubsList();
                    


                }
                

            }
            return View(vm);

        }
        [HttpGet]
        public JsonResult GetClubCalendarEvents(string id,string old, int calendar = 0, string start = "", string end = "")
        {
            //2018-09-23
            IEnumerable<ClubCalendarEventItem> eventDetails = new List<ClubCalendarEventItem>();
            using (EventsRepository db = new EventsRepository())
            {
                if (calendar == 0 || (calendar == 1 && ClassicConfig.GetIntValue("INTCALSHOWEVENTS") == 1))
                {
                    eventDetails = db.GetAllClubEvents(id,old,start.Replace("-", ""),end.Replace("-", ""));
                }
                if (calendar == 1)
                {
                    var eventList = from item in eventDetails
                        select new
                        {
                            id = "_ce" + item.Id,
                            title = WebUtility.HtmlDecode(BbCodeProcessor.Format(item.EventTitle)),
                            author = item.Author,
                            //description = BbCodeProcessor.Format(item.Description),
                            start = item.StartDate.Value.ToString("s"),
                            end = item.EndDate.HasValue ? item.EndDate.Value.ToString("s") : "",
                            allDay = item.IsAllDayEvent,
                            editable = false,
                            //location = item.Location,
                            //club = item.ClubAbbr,
                            //clublong = item.ClubName,
                            //category = item.CategoryName,
                            //posted = item.PostedDate.Value.ToString("s"),
                            className = "event-club",
                            url = Url.Action("Event",new { id = item.Id})
                        };
                    return Json(eventList.ToArray(), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var eventList = from item in eventDetails
                        select new
                        {
                            id = item.Id,
                            title = WebUtility.HtmlDecode(BbCodeProcessor.Format(item.EventTitle)),
                            author = item.Author,
                            currentuser = SnitzMembership.WebSecurity.CurrentUserName,
                            description = BbCodeProcessor.Format(item.Description),
                            start = item.StartDate.Value.ToString("s"),
                            enddate = item.EndDate.HasValue ? item.EndDate.Value.ToString("s") : "",
                            allDay = item.IsAllDayEvent,
                            editable = (item.Author == SnitzMembership.WebSecurity.CurrentUserName) || User.IsAdministrator(),
                            location = item.Location,
                            club = item.ClubAbbr,
                            clublong = item.ClubName,
                            category = item.CategoryName,
                            posted = item.PostedDate.Value.ToString("s"),
                            url = ""
                        };
                    return Json(eventList.ToArray(), JsonRequestBehavior.AllowGet);                    
                }


            }

        }

    #region Admin Actions

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public PartialViewResult Admin()
        {
            var vm = new EventsAdminViewModel
            {
                
                Categories = new Dictionary<int, string>(),
                Locations = new Dictionary<int, string>(),
                Clubs = new Dictionary<int, string>()
            };

            using (EventsRepository db = new EventsRepository())
            {
                foreach (KeyValuePair<int, string> forum in db.GetCategories().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Categories.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                foreach (KeyValuePair<int, string> forum in db.GetLocations().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Locations.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                foreach (KeyValuePair<int, string> forum in db.GetClubsList().ToDictionary(t => t.Key, t => t.Value))
                {
                    vm.Clubs.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
            }
            return PartialView("_Admin",vm);
        }

        [HttpGet]
        [Authorize(Roles ="Administrator")]
        public PartialViewResult AddEditCategory(int id)
        {
            if (id == 0)
            {
                EditListViewModel vm = new EditListViewModel() {ListType = "cat", Order = 99 };
                return PartialView("_AddEditListItem", vm);
            }
            using (EventsRepository db = new EventsRepository())
            {
                EditListViewModel vm = db.GetEventCategory(id);
                vm.ListType = "cat";
                return PartialView("_AddEditListItem",vm);
            }

        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public PartialViewResult AddEditLocation(int id)
        {
            if (id == 0)
            {
                EditListViewModel vm = new EditListViewModel() { ListType = "loc" , Order=99};
                return PartialView("_AddEditListItem", vm);
            }
            using (EventsRepository db = new EventsRepository())
            {
                EditListViewModel vm = db.GetEventLocation(id);
                vm.ListType = "loc";
                return PartialView("_AddEditListItem",vm);
            }

        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public PartialViewResult AddEditClub(int id)
        {
            var Locations = new Dictionary<int, string>();
            using (EventsRepository db = new EventsRepository())
            {
                foreach (KeyValuePair<int, string> forum in db.GetLocations().ToDictionary(t => t.Key, t => t.Value))
                {
                    Locations.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }
                
            }
            ViewBag.Locations = Locations;
            if (id == 0)
            {
                ClubCalendarClub vm = new ClubCalendarClub() { Order = 99 };
                return PartialView("_AddEditClubItem", vm);
            }
            using (EventsRepository db = new EventsRepository())
            {
                ClubCalendarClub vm = db.GetEventClub(id);
                return PartialView("_AddEditClubItem", vm);
            }

        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddEditClub(ClubCalendarClub vm)
        {
            if (ModelState.IsValid)
            {
                vm.Save();
                return RedirectToAction("ModConfiguration", "Admin");
            }
            var locations = new Dictionary<int, string>();
            using (EventsRepository db = new EventsRepository())
            {
                foreach (KeyValuePair<int, string> forum in db.GetLocations().ToDictionary(t => t.Key, t => t.Value))
                {
                    locations.Add(forum.Key, BbCodeProcessor.Format(forum.Value));
                }

            }
            ViewBag.Locations = locations;
            return PartialView("_AddEditClubItem", vm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddEditItem(EditListViewModel vm)
        {
            if (ModelState.IsValid)
            {
                using (EventsRepository db = new EventsRepository())
                {
                    switch (vm.ListType)
                    {
                        case "cat":
                            db.SaveEventCategory(vm);

                            break;
                        case "loc":
                            db.SaveEventLocation(vm);
                            break;

                    }
                }
                return RedirectToAction("ModConfiguration", "Admin");
            }
            return PartialView("_AddEditListItem", vm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public JsonResult Delete(int id, string t)
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            switch (t)
            {
                case "cat":
                    try
                    {
                        ClubCalendarCategory.Delete(id);
                        return Json(new { success = true, responseText = "Delete success!" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        return Json(e.Message);
                    }
                    break;
                case "club":
                    try
                    {
                        ClubCalendarClub.Delete(id);
                        return Json(new { success = true, responseText = "Delete success!" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        return Json(e.Message);
                    }
                    break;
                case "loc":
                    try
                    {
                        ClubCalendarLocation.Delete(id);
                        return Json(new { success = true, responseText = "Delete success!" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        return Json(e.Message);
                    }
                    break;
            }
            
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Problem removing list item");
        }

    #endregion

    }
}
