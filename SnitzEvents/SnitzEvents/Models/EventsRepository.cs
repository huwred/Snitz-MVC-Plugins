using System;
using System.Collections.Generic;
using System.Linq;
using PetaPoco;
using SnitzConfig;
using SnitzCore.Extensions;
using SnitzDataModel.Database;
using SnitzDataModel.Extensions;
using SnitzEvents.Helpers;
using SnitzEvents.ViewModels;
using SnitzMembership;

namespace SnitzEvents.Models
{
    public class EventsRepository : IDisposable
    {

        public CalendarEventItem GetById(int id)
        {
            var sql = new Sql();
            sql.Select("ce.*,COALESCE(t.T_SUBJECT,ce.EVENT_TITLE) collate Danish_Norwegian_CI_AS As Title");
            sql.From("CAL_EVENTS ce");
            sql.LeftJoin("FORUM_TOPICS t").On("ce.TOPIC_ID=t.TOPIC_ID");
            sql.Where("ce.C_ID=@0", id);
            using (var context = new SnitzDataContext())
            {
                return context.FirstOrDefault<CalendarEventItem>(sql);

            }
        }

        public ClubCalendarEventItem GetClubEventById(int id)
        {
            var sql = new Sql();
            sql.Select("ce.*, m.M_NAME AS Author");
            sql.From("CAL_EVENTS ce");
            sql.LeftJoin("FORUM_MEMBERS m").On("ce.AUTHOR_ID=m.MEMBER_ID");
            sql.Where("ce.C_ID=@0", id);
            using (var context = new SnitzDataContext())
            {
                return context.FirstOrDefault<ClubCalendarEventItem>(sql);

            }
        }

        public IEnumerable<CalendarEventItem> GetAllEvents(string start, string end)
        {
            var sql = new Sql();
            sql.Select("ce.*,t.T_SUBJECT As Title, t.T_MESSAGE AS Description, m.M_NAME AS Author");
            sql.From("CAL_EVENTS ce");
            sql.InnerJoin("FORUM_TOPICS t").On("ce.TOPIC_ID=t.TOPIC_ID");
            sql.LeftJoin("FORUM_MEMBERS m").On("t.T_AUTHOR=m.MEMBER_ID");
            sql.Where("ce.TOPIC_ID IS NOT NULL");
            if (start != null && end != null)
            {
                sql.Where("EVENT_DATE >= @0 OR EVENT_DATE <= @0", toEnglishNumber(start), toEnglishNumber(end));
            }
            else if (start != null)
            {
                sql.Where("EVENT_DATE >= @0", toEnglishNumber(start));
            }
            else if (end != null)
            {
                sql.Where("EVENT_DATE <= @0", toEnglishNumber(end));
            }
            sql.OrderBy("ce.EVENT_DATE");

            using (var context = new SnitzDataContext())
            {
                var calevents = context.Fetch<CalendarEventItem>(sql);
                return calevents;

            }
        }

        public IEnumerable<ClubCalendarEventItem> GetAllClubEvents(string catid, string old, string start, string end)
        {
            var sql = new Sql();
            sql.Select(
                "ce.* , m.M_NAME AS Author,c.CAT_NAME As CategoryName,cl.CLUB_L_NAME AS ClubName, cl.CLUB_ABBR AS ClubAbbr,l.LOC_NAME AS Location");
            sql.From("CAL_EVENTS ce");
            sql.LeftJoin("FORUM_MEMBERS m").On("ce.AUTHOR_ID=m.MEMBER_ID");
            sql.LeftJoin("EVENT_CAT c").On("ce.CAT_ID=c.CAT_ID");
            sql.LeftJoin("EVENT_CLUB cl").On("ce.CLUB_ID=cl.CLUB_ID");
            sql.LeftJoin("EVENT_LOCATION l").On("ce.LOC_ID=l.LOC_ID");

            if (start != null)
                start = toEnglishNumber(start).Replace("T", "").Replace(":", "");
            if (end != null)
                end = toEnglishNumber(end).Replace("T", "").Replace(":", "");

            int cid = Convert.ToInt32(catid);
            if (cid > 0)
            {
                sql.Where("ce.CAT_ID=@0", Convert.ToInt32(catid));
            }
            else if (Convert.ToInt32(old) < 0)
            {
                start = null;
                end = DateTime.UtcNow.ToSnitzServerDateString(ClassicConfig.ForumServerOffset);
            }
            sql.Where("ce.CLUB_ID IS NOT NULL");
            if (start != null && end != null)
            {
                sql.Where("ce.EVENT_DATE >= @0 AND ce.EVENT_DATE <= @1", start, end);
            }
            else if (start != null)
            {
                sql.Where("ce.EVENT_DATE >= @0", start);
            }
            else if (end != null)
            {
                sql.Where("ce.EVENT_DATE <= @0", end);
            }
            sql.OrderBy("ce.EVENT_DATE");

            using (var context = new SnitzDataContext())
            {
                var events = context.Fetch<ClubCalendarEventItem>(sql);
                return events;
            }
        }

        public IEnumerable<BirthdayEventItem> GetBirthdays(string start, string end)
        {
            var sdate = DateTime.Parse(toEnglishNumber(start));
            var edate = DateTime.Parse(toEnglishNumber(end));

            var s = toEnglishNumber(start).Replace("-", "").Replace("/", "");
            var e = toEnglishNumber(end).Replace("-", "").Replace("/", "");

            var thisyear = DateTime.UtcNow.Year;

            //string month = DateTime.Parse(start).Month.ToString().PadLeft(2,'0');
            //var e = edate.ToSnitzDOBString();
            if (edate - sdate > new TimeSpan(366, 0, 0, 0)) //don't show on year view
            {
                return new List<BirthdayEventItem>();
            }
            var sql = new Sql();
            sql.Select("MEMBER_ID As MemberId, REPLACE(M_DOB, SUBSTRING(M_DOB, 1, 4), '" + thisyear + "') + '120000' As Dob, M_NAME As Title");
            sql.From("FORUM_MEMBERS");
            sql.Where("M_STATUS=1 AND M_DOB IS NOT NULL AND M_DOB <> '' ");
            //sql.Where("SUBSTRING(M_DOB, 5, 2)='@0'",month);
            sql.Where("REPLACE(M_DOB, SUBSTRING(M_DOB, 1, 4), '" + thisyear + "')  >= @0 AND REPLACE(M_DOB, SUBSTRING(M_DOB, 1, 4), '" + thisyear + "') <=@1", s, e);

            //sql.Where("SUBSTRING(M_DOB, 5, 4)  >= @0 AND SUBSTRING(M_DOB, 5, 4) <=@1", s, e);

            using (var context = new SnitzDataContext())
            {
                try
                {
                    return context.Query<BirthdayEventItem>(sql);
                }
                catch (Exception ex)
                {
                    return new List<BirthdayEventItem>();

                }
                

            }
        }


        public void SaveEvent(CalendarEventItem eventItem, bool processrecurring = true)
        {
            try
            {

                if (processrecurring && eventItem.Recurs != CalEnums.CalRecur.None)
                {
                    ProcessRecurringEvent(eventItem);
                }
                else
                {
                    using (var context = new SnitzDataContext())
                    {
                        context.Save("CAL_EVENTS", "C_ID", eventItem);
                    }                    
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ProcessRecurringEvent(CalendarEventItem eventItem)
        {
            var limit = ClassicConfig.GetIntValue("INTCALMAXRECORDS");
            if (!eventItem.StartDate.HasValue)
            {
                return;
            }
            using (var context = new SnitzDataContext())
            {
                switch (eventItem.Recurs)
                {
                    case CalEnums.CalRecur.EveryDay:
                        //parse the recuring days
                        bool expires = false;
                        eventItem.RecurDays = string.Join(",", eventItem.SelectedDays);
                        DateTime origStart = eventItem.StartDate.Value;
                        DateTime? origEnd = eventItem.EndDate;
                        if (origEnd.HasValue)
                        {
                            if (origStart.DayOfYear != origEnd.Value.DayOfYear)
                            {
                                expires = true;

                                DateTime newdate = origEnd.Value;
                                if (newdate.TimeOfDay <= origStart.TimeOfDay)
                                {
                                    eventItem.IsAllDayEvent = true;
                                    eventItem.EndDate = null;
                                }
                                else
                                {
                                    eventItem.EndDate = origStart.WithTime(newdate);
                                }
                                
                            }
                        }
                        List<int> days= new List<int>();
                        foreach (string day in eventItem.SelectedDays)
                        {
							int daynum = (int)Enum.Parse(typeof(CalEnums.CalDays), day);
							if(daynum==0)
								daynum = 99;
                            days.Add(daynum);
                        }
                        if (days.Count > 1)
                        {
                            //if more than one day, reduce the limit for each day
                            limit = limit/days.Count;
                        }
                        //what day is the start
                        DayOfWeek firstday = origStart.DayOfWeek;
                        days.Sort();
						int ifd = (int)firstday;
						if(ifd==0)
							ifd=99;

                        if (!days.Contains((int) firstday))
                        {
							int dow = days[0];
							if (dow == 99)
								dow = 0;
                            var newstart = origStart.Next((DayOfWeek) dow);
                            eventItem.StartDate = newstart;
                            origStart = newstart;
                            
                        }
                        context.Save("CAL_EVENTS", "C_ID", eventItem);
                        //ad the first event
                        foreach (int day in days)
                        {
                            //reset to first event start
                            int dow = day;
							if(day==99)
                                dow = 0;
                            eventItem.StartDate = origStart;
                            //find the next iteration
                            var newstart = origStart.Next((DayOfWeek)dow);
                            eventItem.StartDate = newstart;
                            if (eventItem.EndDate.HasValue && expires)
                            {
                                var newend = eventItem.EndDate.Value.Next((DayOfWeek)dow);
                                eventItem.EndDate = newend;
                            }
                            for (int i = 0; i < limit; i++)
                            {
                                var start = eventItem.StartDate;
                                eventItem.Id = 0;
                                if (expires)
                                {
                                    if (start.Value.Date > origEnd.Value.Date)
                                        break;
                                    
                                }                                
                                context.Save("CAL_EVENTS", "C_ID", eventItem);
                                var end = eventItem.EndDate;
                                eventItem.StartDate = start.Value.Next((DayOfWeek)dow);
                                if (end.HasValue && expires)
                                {
                                    eventItem.EndDate = end.Value.Next((DayOfWeek)dow);
                                }
                            }
                        }

                        break;

                    case CalEnums.CalRecur.EveryWeek:
                        for (int i = 0; i < limit; i++)
                        {
                            context.Save("CAL_EVENTS", "C_ID", eventItem);

                            var start = eventItem.StartDate;
                            var end = eventItem.EndDate;

                            var startday = start.Value.DayOfWeek;
                            start = start.Value.Next(startday);

                            eventItem.StartDate = start;
                            eventItem.Id = 0;
                            if (end.HasValue)
                            {
                                var thisday = end.Value.DayOfWeek;
                                end = end.Value.Next(thisday);
                                eventItem.EndDate = end;
                            }

                        }
                        break;
                    case CalEnums.CalRecur.EveryOtherWeek:
                        for (int i = 0; i < limit; i++)
                        {
                            context.Save("CAL_EVENTS", "C_ID", eventItem);

                            var start = eventItem.StartDate;
                            var end = eventItem.EndDate;
                            var today = start.Value.DayOfWeek;

                            eventItem.StartDate = start.Value.Next(today).Next(today);
                            eventItem.Id = 0;
                            if (end.HasValue)
                            {
                                var thisday = end.Value.DayOfWeek;
                              
                                eventItem.EndDate = end.Value.Next(thisday).Next(thisday);
                            }

                        }
                        break;
                    case CalEnums.CalRecur.EveryMonth:
                        for (int i = 0; i < limit; i++)
                        {
                            context.Save("CAL_EVENTS", "C_ID", eventItem);

                            var start = eventItem.StartDate;
                            var end = eventItem.EndDate;
                            start = start.Value.AddMonths(1);
                            eventItem.StartDate = start;
                            eventItem.Id = 0;
                            if (end.HasValue)
                            {
                                end = end.Value.AddMonths(1);
                                eventItem.EndDate = end.Value;
                            }

                        }
                        break;
                    case CalEnums.CalRecur.EveryYear:
                        for (int i = 0; i < limit; i++)
                        {
                            context.Save("CAL_EVENTS", "C_ID", eventItem);

                            var start = eventItem.StartDate;
                            var end = eventItem.EndDate;
                            start = start.Value.AddYears(1);
                            eventItem.StartDate = start;
                            eventItem.Id = 0;
                            if (end.HasValue)
                            {
                                end = end.Value.AddYears(1);
                                eventItem.EndDate = end.Value;
                            }

                        }
                        break;
                } 
                //context.Insert("CAL_EVENTS", "C_ID", eventItem);

            }



        }

        public void SaveForum(CalForumAuth forumauth)
        {
            using (var context = new SnitzDataContext())
            {
                context.Execute("UPDATE FORUM_FORUM SET F_ALLOWEVENTS=@0 WHERE FORUM_ID=@1",(int)forumauth.Allowed,forumauth.ForumId);

            }
        }

        public object GetForumAuth(int id)
        {
            using (var context = new SnitzDataContext())
            {
                return context.ExecuteScalar<int>("SELECT F_ALLOWEVENTS FROM FORUM_FORUM WHERE FORUM_ID=@0", id);

            }
        }
        public bool TopicHasEvent(int topicid)
        {
            var sql = new Sql();
            sql.Select("ce.TOPIC_ID");
            sql.From("CAL_EVENTS ce");
            sql.Where("ce.TOPIC_ID=@0", topicid);
            using (var context = new SnitzDataContext())
            {
                var res = context.SingleOrDefault<int>(sql);
                return res != 0;
            }
        }
        public IEnumerable<CalendarEventItem> GetTopicEvent(int topicid)
        {
            var sql = new Sql();
            sql.Select("ce.*,t.T_SUBJECT As Title");
            sql.From("CAL_EVENTS ce");
            sql.LeftJoin("FORUM_TOPICS t").On("ce.TOPIC_ID=t.TOPIC_ID");
            sql.Where("ce.TOPIC_ID=@0", topicid);
            sql.OrderBy("ce.EVENT_DATE");
            using (var context = new SnitzDataContext())
            {
                var res =  context.Query<CalendarEventItem>(sql);
                return res;
            }
        }

        public void Delete(int eventid)
        {
            using (var context = new SnitzDataContext())
            {
                context.Delete<CalendarEventItem>("WHERE C_ID=@0", eventid);
            }
        }
        public void SubDelete(int clubid,int memberid)
        {
            using (var context = new SnitzDataContext())
            {
                context.Delete<ClubCalendarSubscriptions>("WHERE CLUB_ID=@0 AND MEMBER_ID=@1", clubid, memberid);
            }
        }
        public void DeleteFromNow(int topicId)
        {
            var curDate = DateTime.UtcNow.ToSnitzDate();
            using (var context = new SnitzDataContext())
            {
                context.Delete<CalendarEventItem>("WHERE TOPIC_ID=@0 AND EVENT_DATE > @1", topicId,curDate);
            }
        }

        public void DeleteAll(int topicId)
        {
            using (var context = new SnitzDataContext())
            {
                context.Delete<CalendarEventItem>("WHERE TOPIC_ID=@0", topicId);
            }
        }

        public IEnumerable<Pair<int, string>> GetCategories()
        {
            using (var context = new SnitzDataContext())
            {
                return context.Fetch<Pair<int, string>>("SELECT CAT_ID AS 'Key',CAT_NAME AS 'Value' FROM EVENT_CAT ORDER BY CAT_ORDER");

            }
        }

        public IEnumerable<Pair<int, string>> GetLocations()
        {
            using (var context = new SnitzDataContext())
            {
                return context.Fetch<Pair<int, string>>("SELECT LOC_ID AS 'Key',LOC_NAME AS 'Value' FROM EVENT_LOCATION ORDER BY LOC_ORDER");

            }
        }

        public IEnumerable<Pair<int, string>> GetClubsList()
        {
            using (var context = new SnitzDataContext())
            {
                return context.Fetch<Pair<int, string>>("SELECT CLUB_ID AS 'Key',CLUB_S_NAME AS 'Value' FROM EVENT_CLUB ORDER BY CLUB_ORDER");

            }
        }

        public void Dispose()
        {

        }

        public IEnumerable<int> GetSubsList()
        {
            using (var context = new SnitzDataContext())
            {
                return context.Fetch<int>("SELECT CLUB_ID FROM EVENT_SUBSCRIPTIONS WHERE MEMBER_ID=@0", WebSecurity.CurrentUserId);

            }
        }
        public List<CatSummary> GetCategorySummaryList(string startDate)
        {
            
            using (var context = new SnitzDataContext())
            {
                var sql = new Sql();
                sql.Select("c.CAT_ID AS CatId ,c.CAT_NAME As Name, COUNT(ce.C_ID) as EventCount");
                sql.From("CAL_EVENTS ce");
                sql.LeftJoin("EVENT_CAT c").On("c.CAT_ID=ce.CAT_ID");
                sql.Where("ce.CAT_ID IS NOT NULL ");
                if (startDate != null)
                {
                    sql.Where(" ce.EVENT_DATE >= '" + startDate.Replace("-", "") + "'");
                }
                sql.GroupBy("c.CAT_NAME,c.CAT_ID");
                return context.Fetch<CatSummary>(sql);
            }
        }

        public string OldestEvent()
        {
            using (var context = new SnitzDataContext())
            {
                string top = "TOP 1";
                string limit = "";
                if (context.dbtype == "mysql")
                {
                    top = "";
                    limit = "LIMIT 1";
                }
                var evnt = context.SingleOrDefault<ClubCalendarEventItem>("SELECT " + top + " * FROM CAL_EVENTS ORDER BY EVENT_DATE " + limit);
                if (evnt != null)
                {
                    if (evnt.StartDate != null) return evnt.StartDate.Value.AddDays(-1).ToString("yyyy-MM-dd");
                }
            }
            return null;
        }

        public EditListViewModel GetEventCategory(int id)
        {
            using (var context = new SnitzDataContext())
            {
                var cat = context.SingleOrDefault<ClubCalendarCategory>("SELECT * FROM EVENT_CAT WHERE CAT_ID=@0  ",id);
                return new EditListViewModel() {Id = cat.Id, Name = cat.Name, Order = cat.Order};
            }

        }

        public EditListViewModel GetEventLocation(int id)
        {
            using (var context = new SnitzDataContext())
            {
                var loc = context.SingleOrDefault<ClubCalendarLocation>("SELECT * FROM EVENT_LOCATION WHERE LOC_ID=@0  ", id);
                return new EditListViewModel() { Id = loc.Id, Name = loc.Name, Order = loc.Order };
            }
        }

        public ClubCalendarClub GetEventClub(int id)
        {
            using (var context = new SnitzDataContext())
            {
                var club = context.SingleOrDefault<ClubCalendarClub>("SELECT * FROM EVENT_CLUB WHERE CLUB_ID=@0  ", id);
                return club;
            }
        }

        public void SaveEventCategory(EditListViewModel vm)
        {
            using (var context = new SnitzDataContext())
            {
                var cat = context.SingleOrDefault<ClubCalendarCategory>("SELECT * FROM EVENT_CAT WHERE CAT_ID=@0  ", vm.Id) ??
                           new ClubCalendarCategory();
                cat.Name = vm.Name;
                cat.Order = vm.Order;
                cat.Save();
            }
        }

        public void SaveEventLocation(EditListViewModel vm)
        {
            using (var context = new SnitzDataContext())
            {
                var loc = context.SingleOrDefault<ClubCalendarLocation>("SELECT * FROM EVENT_LOCATION WHERE LOC_ID=@0  ", vm.Id) ??
                    new ClubCalendarLocation();
                loc.Name = vm.Name;
                loc.Order = vm.Order;
                loc.Save();
            }
        }

        public void HasSubscription(int itemId, int currentUserId)
        {
            using (var context = new SnitzDataContext())
            {
                var subs = context.SingleOrDefault<int>("SELECT CLUB_ID FROM EVENT_SUBSCRIPTIONS WHERE MEMBER_ID=@0  ",
                    currentUserId);
            }
        }
        private string toEnglishNumber(string input)
        {
            string englishNumbers = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    englishNumbers += char.GetNumericValue(input, i);
                }
                else
                {
                    englishNumbers += input[i].ToString();
                }
            }
            return englishNumbers;
        }
    }

}