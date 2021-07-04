using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Mvc;
using BbCodeFormatter;
using LangResources.Utility;
using Newtonsoft.Json;
using Snitz.Base;
using SnitzConfig;
using SnitzCore.Extensions;
using SnitzCore.Filters;
using SnitzDataModel.Controllers;
using SnitzDataModel.Extensions;
using SnitzEvents.Helpers;
using SnitzEvents.Models;
using SnitzEvents.ViewModels;




namespace SnitzEvents.Controllers
{

    public class CalendarController : BaseController
    {
        [AuthorizePublic(SnitzVar = "INTCALPUBLIC")]
        public ActionResult Index()
        {
            try
            {
                ViewData["Countries"] = GetCountries();
            }
            catch (Exception ex)
            {
                ViewBag.ErrTitle = "Calendar Index:";
                ViewBag.Error = ex.Message;
                return View("Error");
            }

            return View("Index");
        }

        [DoNotLogActionFilter]
        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client, VaryByParam = "id",
             NoStore = true)]
        public ContentResult EventIcon(int id)
        {
            using (EventsRepository db = new EventsRepository())
            {
                if (db.TopicHasEvent(id))
                {
                    var evt = db.GetTopicEvent(id).ToList();
                    var start = evt.First().StartDate;
                    var end = evt.Last().EndDate ?? evt.Last().StartDate;
                    var allday = evt.Last().IsAllDayEvent;

                    if (start.Value.Day == end.Value.Day)
                    {
                        if (allday)
                        {
                            return
                                Content("<i class='fa fa-calendar' title='" +
                                        String.Format("{0:dd/MM/yyyy}", start) +
                                        "' data-toggle='tooltip' ></i>");
                        }
                        else
                        {
                            return
                                Content("<i class='fa fa-calendar' title='" +
                                        String.Format("{0:dd/MM/yyyy HH:mm} to {1:HH:mm}", start, end) +
                                        "' data-toggle='tooltip' ></i>");
                        }
                    }
                    return
                        Content("<i class='fa fa-calendar' title='" +
                                String.Format("{0:dd/MM/yyyy HH:mm} to {1:dd/MM/yyyy HH:mm}", start, end) +
                                "' data-toggle='tooltip' ></i>");
                }
            }
            return Content("");
        }

        [DoNotLogActionFilter]
        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client, VaryByParam = "id",
             NoStore = true)]
        public ContentResult EventInfoTag(int id)
        {
            using (EventsRepository db = new EventsRepository())
            {
                if (db.TopicHasEvent(id))
                {
                    var evt = db.GetTopicEvent(id).ToList();
                    var start = evt.First().StartDate;
                    var end = evt.Last().EndDate ?? evt.Last().StartDate;
                    var allday = evt.Last().IsAllDayEvent;

                    if (start.Value.Day == end.Value.Day)
                    {
                        if (allday)
                        {
                            return
                                Content("<span class='text-info event-label'><i class='fa fa-calendar' ></i> " +
                                        ResourceManager.GetLocalisedString("TopicEventTitle", "Event") + ' ' +
                                        start.Value.ToFormattedString(false) +
                                        ResourceManager.GetLocalisedString("AllDayEvent", "Event") + "</span><br />");
                        }
                        else
                        {
                            return
                                Content("<span class='text-info event-label'><i class='fa fa-calendar'></i> " +
                                        ResourceManager.GetLocalisedString("TopicEventTitle", "Event") + ' ' +
                                        String.Format("{0} - {1:HH:mm}", start.Value.ToFormattedString(), end) + "</span><br />");
                        }
                    }
                    return
                        Content("<span class='text-info event-label'><i class='fa fa-calendar' ></i> " +
                                ResourceManager.GetLocalisedString("TopicEventTitle", "Event") + ' ' +
                                String.Format("{0} - {1}", start.Value.ToFormattedString(), end.Value.ToFormattedString()) + "</span><br />");
                }
            }
            return Content("");
        }

        #region Admin Actions

        [Authorize(Roles = "Administrator")]
        public ActionResult Admin()
        {
            int dow = ClassicConfig.GetIntValue("INTFIRSTDAYOFWEEK");
            try
            {
                var vm = new CalAdminViewModel
                {
                    Enabled = ClassicConfig.GetIntValue("INTCALEVENTS") == 1,
                    EnableEvents = ClassicConfig.GetIntValue("INTCLUBEVENTS") == 1,
                    ShowInCalendar = ClassicConfig.GetIntValue("INTCALSHOWEVENTS") == 1,
                    MaxRecords = ClassicConfig.GetIntValue("INTCALMAXRECORDS") == 0
                        ? 20
                        : ClassicConfig.GetIntValue("INTCALMAXRECORDS"),
                    FirstDayofWeek = (CalEnums.CalDays) dow,
                    UpcomingEvents = ClassicConfig.GetIntValue("INTCALUPCOMINGEVENTS") == 1,
                    ShowBirthdays = ClassicConfig.GetIntValue("INTCALSHOWBDAYS") == 1,
                    PublicHolidays = ClassicConfig.GetIntValue("INTCALPUBLICHOLIDAYS") == 1,
                    CountryCode = ClassicConfig.GetValue("STRCALCOUNTRY"),
                    Region = ClassicConfig.GetValue("STRCALREGION"),
                    IsPublic = ClassicConfig.GetIntValue("INTCALPUBLIC") == 1,
                    Roles = ClassicConfig.GetValue("STRRESTRICTROLES"),
                    Countries = GetCountries()
                };
                return PartialView("_Admin", vm);
            }
            catch (Exception ex)
            {
                ViewBag.ErrTitle = "Calendar Admin:";
                ViewBag.Error = ex.Message;
                return View("Error");
            }

        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Enable()
        {
            return PartialView("_Enable");
        }
        [Authorize(Roles = "Administrator")]
        public RedirectResult SaveSettings(CalAdminViewModel settings)
        {
            try
            {
                var updateMsg = "";
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("INTCALEVENTS", settings.Enabled ? "1" : "0");
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("INTCLUBEVENTS",
                    settings.EnableEvents ? "1" : "0");
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("INTCALSHOWEVENTS",
                    settings.ShowInCalendar ? "1" : "0");
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("INTFIRSTDAYOFWEEK",
                    ((int) settings.FirstDayofWeek).ToString());
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("INTCALUPCOMINGEVENTS",
                    settings.UpcomingEvents ? "1" : "0");

                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("INTCALMAXRECORDS",
                    settings.MaxRecords.ToString());
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("INTCALSHOWBDAYS",
                    settings.ShowBirthdays ? "1" : "0");
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("INTCALPUBLICHOLIDAYS",
                    settings.PublicHolidays ? "1" : "0");
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("INTCALPUBLIC", settings.IsPublic ? "1" : "0");
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("STRCALCOUNTRY", settings.CountryCode);
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("STRCALREGION", settings.Region ?? "");
                ClassicConfig.ConfigDictionary.CreateNewOrUpdateExisting("STRRESTRICTROLES", settings.Roles);
                ClassicConfig.Update(new[]
                {
                    "INTCALEVENTS", "INTCLUBEVENTS", "INTFIRSTDAYOFWEEK", "INTCALMAXRECORDS", "INTCALSHOWBDAYS",
                    "INTCALUPCOMINGEVENTS",
                    "INTCALPUBLICHOLIDAYS", "INTCALPUBLIC", "STRCALCOUNTRY", "STRCALREGION", "STRRESTRICTROLES",
                    "INTCALSHOWEVENTS"
                });

                TempData["successMessage"] = "Event settings updated ";
            }
            catch (Exception e)
            {
                TempData["errTitle"] = "Update problem";
                TempData["errMessage"] = e.Message;

            }

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        [DoNotLogActionFilter]
        [Authorize(Roles = "Administrator, Moderator")]
        public ActionResult ForumEventSettings(int id)
        {
            CalForumAuth auth = new CalForumAuth
            {
                ForumId = id,
                Allowed = CalEnums.CalAllowed.None
            };
            if (id > 0)
            {
                using (EventsRepository db = new EventsRepository())
                {
                    auth.Allowed = (CalEnums.CalAllowed) db.GetForumAuth(id);
                }
            }
            return PartialView("_ForumEventSetting", auth);
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [DoNotLogActionFilter]
        public JsonResult SaveForum(CalForumAuth forumauth)
        {
            try
            {
                using (EventsRepository db = new EventsRepository())
                {
                    db.SaveForum(forumauth);
                }
                return Json(new {success = true, responseText = "Forum event setting updated"});
            }
            catch (Exception e)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;

                return Json(e.Message);
            }

        }

        #endregion

        [DoNotLogActionFilter]
        public ActionResult TopicEvent(int id)
        {
            if (CanPostEvents(id))
            {
                return PartialView("_TopicEvent", new CalendarEventItem());
            }
            return Content("");
        }

        public ActionResult TopicEventEdit(int id, int forumid, int page = 1)
        {
            if (CanPostEvents(forumid))
            {
                if (id > 0)
                {
                    using (EventsRepository db = new EventsRepository())
                    {
                        var evt = db.GetTopicEvent(id).ToList();
                        if (page < 1)
                            page = 1;
                        if (page > evt.Count)
                            page = evt.Count;
                        if (evt.Any())
                        {
                            var vm = evt.Skip(page - 1).Take(1).First();
                            if (vm.RecurDays != null)
                            {
                                vm.SelectedDays = vm.RecurDays.Split(',');
                            }
                            if (vm.Recurs != CalEnums.CalRecur.None)
                            {
                                ViewBag.Message = "Recurring Event";
                            }
                            ViewBag.Page = page;
                            ViewBag.Pages = evt.Count;
                            ViewBag.ForumId = forumid;
                            return PartialView("_TopicEventEdit", vm);
                        }
                    }
                    return Content("");
                }
                return Content("No TopicId provided");
            }
            return Content("");
        }

        [DoNotLogActionFilter]
        public JsonResult SaveEvent(CalendarEventItem eventItem)
        {
            List<string> errors = new List<string>();

            //no startdate so just return

            if (!eventItem.IsAllDayEvent && !eventItem.EndDate.HasValue)
            {
                //If no end date, make it all day
                eventItem.IsAllDayEvent = true;
            }
            if (ModelState.IsValid)
            {
                //Save the event here
                string eventData = "Start: " + eventItem.StartDate;
                if (eventItem.IsAllDayEvent)
                {
                    eventData += "\nAll day event";
                }
                else if (eventItem.EndDate.HasValue)
                {
                    eventData += "\nEnd: " + eventItem.EndDate;
                }
                using (EventsRepository db = new EventsRepository())
                {
                    db.SaveEvent(eventItem);
                }
                return Json(new {success = true, responseText = "Topic added as Event \n" + eventData});
            }
            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            Response.StatusCode = (int) HttpStatusCode.BadRequest;

            return Json(errors);

        }

        [ValidateInput(false)]
        [DoNotLogActionFilter]
        [HttpPost]
        public JsonResult EditEvent(CalendarEventItem eventItem)
        {
            if (eventItem.SelectedDays != null)
            {
                eventItem.RecurDays = string.Join(",", eventItem.SelectedDays);
                eventItem.SelectedDays = null;
            }
            using (EventsRepository db = new EventsRepository())
            {
                CalendarEventItem eventFromDb = db.GetById(eventItem.Id);
                IList diffProperties = new ArrayList();
                foreach (var item in eventFromDb.GetType().GetProperties())
                {
                    if (!Object.Equals(
                        item.GetValue(eventFromDb, null),
                        eventItem.GetType().GetProperty(item.Name).GetValue(eventItem, null)))
                    {
                        diffProperties.Add(item);
                    }
                }
                if (diffProperties.Count > 0)
                {
                    try
                    {
                        //todo: check what changed, if just the dates then don't redo the event
                        foreach (var property in diffProperties)
                        {
                            if (property is CalEnums.CalRecur || (((PropertyInfo) property).Name == "RecurDays"))
                            {
                                //recurring event change
                                //clear the events and re-add with new data
                                db.DeleteAll(eventItem.TopicId);
                                db.SaveEvent(eventItem);

                            }
                            else
                            {
                                db.SaveEvent(eventItem, false);
                            }
                        }
                        return Json(new { success = true, responseText = "Event Updated" });
                        //return Content("Event Updated");
                    }
                    catch (Exception ex)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        return Json(new { success = false, responseText = ex.Message });

                    }

                }
                //check for deletion
                if (Request.Form["EventDelete"] != "0")
                {
                    string del = Request.Form["EventDelete"];
                    switch (del)
                    {
                        case "1":
                            //This event
                            db.Delete(eventItem.Id);
                            //return  Content("This occurrence deleted");
                            return Json(new { success = true, responseText = "This occurrence deleted" });
                        case "2":
                            //All events
                            db.DeleteAll(eventItem.TopicId);
                            //return Content("All occurrences deleted");
                            return Json(new { success = true, responseText = "All occurrences deleted" });
                        case "3":
                            //Future events
                            db.DeleteFromNow(eventItem.TopicId);
                            //return Content("All future occurrences deleted");
                            return Json(new { success = true, responseText = "All future occurrences deleted" });
                    }
                }
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { success = false, responseText = "There was a problem" });
            //return Json("There was a problem");
        }

        #region data fetch

        public JsonResult GetCalendarEvents()
        {
            using (EventsRepository db = new EventsRepository())
            {
                IEnumerable<CalendarEventItem> eventDetails = db.GetAllEvents(null, null);
                var urlPath = Url.Action("Posts", "Topic");

                var eventList = from item in eventDetails
                    let itemStartDate = item.StartDate
                    where itemStartDate != null
                    select new
                    {
                        id = item.TopicId,
                        title = WebUtility.HtmlDecode(BbCodeProcessor.Format(item.Title)),
                        author = item.Author,
                        description = BbCodeProcessor.Format(item.Description),
                        start = itemStartDate.Value.ToString("s"),
                        end = item.EndDate?.ToString("s") ?? "",
                        allDay = item.IsAllDayEvent,
                        editable = false,
                        url = urlPath + "/" + item.TopicId
                    };
                try
                {
                var test = eventList.ToArray();

                return Json(test, JsonRequestBehavior.AllowGet);

                }catch(Exception ex)
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }

        }

        [DoNotLogActionFilter]
        public JsonResult GetUpcomingEvents(int count)
        {
            using (EventsRepository db = new EventsRepository())
            {
                IEnumerable<CalendarEventItem> eventDetails = db.GetAllEvents(DateTime.UtcNow.ToSnitzDate(),
                    DateTime.UtcNow.AddMonths(1).ToSnitzDate());
                var urlPath = Url.Action("Posts", "Topic");

                var eventList = from item in eventDetails.Take(count)
                    select new
                    {
                        id = item.TopicId,
                        title = BbCodeProcessor.Format(item.Title),
                        start = item.StartDate.Value.ToString("s"),
                        end = item.EndDate.HasValue ? item.EndDate.Value.ToString("s") : "",
                        allDay = item.IsAllDayEvent,
                        editable = false,
                        url = urlPath + "/" + item.TopicId
                    };

                return Json(eventList.ToArray(), JsonRequestBehavior.AllowGet);
            }

        }

        [DoNotLogActionFilter]
        [OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.Client, VaryByParam = "start",
             NoStore = true)]
        public JsonResult GetBirthDays()
        {
            var start = Request.QueryString["start"];
            var end = Request.QueryString["end"];
            var today = DateTime.UtcNow;
            List<BirthdayEventItem> eventDetails = new List<BirthdayEventItem>();
            if (ClassicConfig.GetIntValue("INTCALSHOWBDAYS") == 1 && User.Identity.IsAuthenticated)
            {
                try
                {
                    eventDetails = MemberBirthdays(start, end).ToList();
                }
                catch (Exception ex)
                {
                    eventDetails = new List<BirthdayEventItem>();
                }

            }

            try
            {
                var eventList = from item in eventDetails
                    let itemStartDate = item.StartDate
                    where itemStartDate != null
                    select new
                                {
                                    id = item.MemberId,
                                    title = " " + item.Title,
                                    start = itemStartDate.Value.ToString("s"), //item.StartDate.Value.WithYear(today).ToString("s"),
                                    allDay = true,
                                    editable = false,
                                    url = "",
                                    className = "event-birthday"
                                };
                var returnArray = eventList.ToArray();
                return Json(returnArray, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex.InnerException);
            }


        }

        [DoNotLogActionFilter]
        public JsonResult GetHolidays(string country = "")
        {
            try
            {
                var start = Request.QueryString["start"];
                var end = Request.QueryString["end"];
                List<PublicHoliday> rootObject = new List<PublicHoliday>();
                if (ClassicConfig.GetIntValue("INTCALPUBLICHOLIDAYS") == 1)
                {
                    if (country == "")
                        country = ClassicConfig.GetValue("STRCALCOUNTRY");
                    rootObject = PublicHolidays(country.Split('|')[0], start, end);
                }

                var eventList = from item in rootObject
                    select new
                    {
                        title = " " + item.Localname,
                        start = new DateTime(item.Date.Year, item.Date.Month, item.Date.Day, 12, 0, 0).ToString("s"),
                        allDay = true,
                        editable = false,
                        url = "",
                        className = "public-holiday"
                    };

                return Json(eventList.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json("Problem getting public holidays", JsonRequestBehavior.AllowGet);
            }

        }

        [DoNotLogActionFilter]
        public JsonResult GetRegions(string id)
        {
            var ctry = id.Split('|')[0];
            try
            {
                var country = GetCountries().SingleOrDefault(c => c.CountryCode == ctry);
                if (country == null)
                {
                    throw new Exception("Invalid country code");
                }
                return Json(country.Regions, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                List<string> errors = new List<string>();
                //..some processing
                errors.Add(ex.Message);
                //..some processing
                errors.Add(ex.InnerException.Message);
                return Json(errors);
            }



        }

        #endregion


        #region private methods

        [DoNotLogActionFilter]
        [NonAction]
        private bool CanPostEvents(int forumid)
        {
            using (EventsRepository db = new EventsRepository())
            {
                var forumauth = db.GetForumAuth(forumid);
                if ((CalEnums.CalAllowed) forumauth == CalEnums.CalAllowed.Admins &&
                    SnitzMembership.WebSecurity.IsAdministrator)
                {
                    return true;
                }
                if ((CalEnums.CalAllowed) forumauth == CalEnums.CalAllowed.AdminsModerators &&
                    (SnitzMembership.WebSecurity.IsAdministrator || SnitzMembership.WebSecurity.IsModerator))
                {
                    return true;
                }
                if ((CalEnums.CalAllowed) forumauth == CalEnums.CalAllowed.Members &&
                    SnitzMembership.WebSecurity.IsAuthenticated)
                {
                    return true;
                }
            }
            return false;
        }

        [DoNotLogActionFilter]
        [NonAction]
        private List<EnricoCountry> GetCountries()
        {
            var service = new InMemoryCache(600);

            return service.GetOrSet("cal.countries", FetchJsonCountries);
        }

        [DoNotLogActionFilter]
        [NonAction]
        private List<PublicHoliday> PublicHolidays(string country, string start, string end)
        {
            string[] cReg = country.Split('|');

            try
            {
                var s = DateTime.Parse(start).ToString("dd-MM-yyyy");
                var e = DateTime.Parse(end).ToString("dd-MM-yyyy");
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var json =
                    new WebClient().DownloadString(
                        String.Format(
                            "https://kayaposoft.com/enrico/json/v1.0/index.php?action=getPublicHolidaysForDateRange&fromDate={0}&toDate={1}&country={2}&region={3}",
                            s, e, cReg[0], (cReg.Length > 1 ? cReg[1] : "")));
                return JsonConvert.DeserializeObject<List<PublicHoliday>>(json);
            }
            catch (Exception)
            {
                return new List<PublicHoliday>();
            }

        }

        [DoNotLogActionFilter]
        [NonAction]
        private IEnumerable<BirthdayEventItem> MemberBirthdays(string start, string end)
        {
            using (EventsRepository db = new EventsRepository())
            {
                try
                {
                    return db.GetBirthdays(start, end);
                }
                catch (Exception ex)
                {
                    return new List<BirthdayEventItem>();
                }
                
            }
        }

        [NonAction]
        private List<EnricoCountry> FetchJsonCountries()
        {

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                Uri myUri = new Uri("https://kayaposoft.com/enrico/json/v1.0?action=getSupportedCountries", UriKind.Absolute);
                WebClient client = new WebClient();

                var json = client.DownloadString(myUri); // new WebClient().DownloadString("https://kayaposoft.com/enrico/json/v1.0?action=getSupportedCountries");
                var countries = JsonConvert.DeserializeObject<List<EnricoCountry>>(json);
                return countries;
            }
            catch (Exception ex)
            {
                EnricoCountry ec = new EnricoCountry();
                ec.CountryCode = "eng";
                ec.Name = "Error: " + ex.InnerException.Message;
                return new List<EnricoCountry>() { ec };

            }

        }

        #endregion
    }
}