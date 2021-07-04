using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using BookMarks.Helpers;
using PetaPoco;
using SnitzCore.Extensions;
using SnitzCore.Utility;
using SnitzDataModel.Database;
using SnitzDataModel.Models;
using SnitzMembership;



namespace BookMarks.Models
{
    public class BookmarkRepository : IDisposable
    {
        private List<BookmarkEntry> _data;
        private string _bookmarkTablePrefix;
        private int _memberid;
        public int Pagecount;
        public int Pagesize;

        public BookmarkRepository(int memberid,int pagesize=10)
        {
            _memberid = memberid;
            Pagesize = pagesize;
            Initialize();
        }
        private void Initialize()
        {
            _bookmarkTablePrefix = "FORUM_";
            string tablePrefix = ConfigurationManager.AppSettings["forumTablePrefix"];
            string memberTablePrefix = ConfigurationManager.AppSettings["memberTablePrefix"];

            _data = new List<BookmarkEntry>();
            Sql sql = new Sql();

            sql.Select("B.*,T.*, e.M_NAME AS EditedBy, 0 AS Archived ,Author.*,Forum.*");
            sql.From(_bookmarkTablePrefix + "BOOKMARKS B");
            sql.LeftJoin(tablePrefix + "TOPICS T").On("T.TOPIC_ID=B.B_TOPICID");
            sql.LeftJoin(memberTablePrefix + "MEMBERS e").On("T.T_LAST_POST_AUTHOR = e.MEMBER_ID");
            sql.LeftJoin(memberTablePrefix + "MEMBERS Author").On("Author.MEMBER_ID = T.T_AUTHOR");
            sql.LeftJoin(tablePrefix + "FORUM Forum").On("Forum.FORUM_ID=T.FORUM_ID");
            sql.Where("B.B_MEMBERID=@0", _memberid);
            sql.OrderBy("T.T_LAST_POST");

            using (var context = new SnitzDataContext())
            {
                _data = context.Fetch<BookmarkEntry, Topic, Member, Forum>(sql);

            }
            Pagecount = _data.Count/Pagesize;

            if ((_data.Count % Pagesize) != 0)
                Pagecount++;
        }
        public BookmarkEntry GetEntryById(int id)
        {
            BookmarkEntry b = _data.FirstOrDefault(c => c.Id == id);
            return b;
        }
        public List<BookmarkEntry> GetAllEntries()
        {
            return _data.OrderByDescending(c => c.Id).ToList();
        }
        public List<BookmarkEntry> GetPaged(int pagenum, BookmarkEnums.ActiveTopicsSince activesince, string lastVisitCookie,string memberSince)
        {
            DateTime lastvisitdate=DateTime.MinValue;
            switch (activesince)
            {
                case BookmarkEnums.ActiveTopicsSince.LastVisit:
                    var dateTime = lastVisitCookie.ToDateTime();
                    if (dateTime.HasValue)
                        lastvisitdate = dateTime.Value;
                    break;
                case BookmarkEnums.ActiveTopicsSince.LastHour:
                    lastvisitdate = DateTime.UtcNow.AddHours(-1);
                    break;
                case BookmarkEnums.ActiveTopicsSince.LastDay:
                    lastvisitdate = DateTime.UtcNow.AddHours(-24);
                    break;
                case BookmarkEnums.ActiveTopicsSince.LastWeek:
                    lastvisitdate = DateTime.UtcNow.AddDays(-7);
                    break;
                case BookmarkEnums.ActiveTopicsSince.LastMonth:
                    lastvisitdate = DateTime.UtcNow.AddMonths(-1);
                    break;
                case BookmarkEnums.ActiveTopicsSince.Registration:
                    var sincedate = memberSince.ToDateTime();
                    if (sincedate.HasValue)
                        lastvisitdate = sincedate.Value;
                    break;
                default:
                    lastvisitdate = DateTime.MinValue;
                    break;
            }
            return _data.Where(b=>b.Topic.LastPostDate > lastvisitdate).OrderByDescending(c => c.Topic.LastPostDate).Skip((pagenum-1)*Pagesize).Take(Pagesize).ToList();
        }
        public void AddBookMark(int topicId)
        {
            var bookmark = new BookmarkEntry();
            bookmark.UserId = _memberid;
            bookmark.TopicId = topicId;
            SessionData.Clear("MyBookmarks");
            using (var context = new SnitzDataContext())
            {
                
                context.Save(_bookmarkTablePrefix + "BOOKMARKS", "BOOKMARK_ID", bookmark);

            }
        }
        public bool DeleteBookMark(int id)
        {
            SessionData.Clear("MyBookmarks");
            using (var context = new SnitzDataContext())
            {
                return context.Delete<BookmarkEntry>(id) > 0;
            }
        }

        public static int IsBookmarked(int topicid)
        {
            //return 0;
            if (!SessionData.Contains("MyBookmarks"))
            {
                using (var context = new SnitzDataContext())
                {
                    var bmk = context.Fetch<BookmarkEntry>("WHERE B_MEMBERID=@0", WebSecurity.CurrentUserId) ??
                              new List<BookmarkEntry>();
                    SessionData.Set("MyBookmarks", bmk);
                }

            }
            var found = SessionData.Get<List<BookmarkEntry>>("MyBookmarks").FirstOrDefault(i => i.TopicId == topicid);
            if (found == null)
            {
                return 0;
            }
            return found.Id;

        }

        public void Dispose()
        {
            _data.Clear();
            _data = null;
        }

        public void DeleteBookMarks(IEnumerable<int> bookmarks)
        {
            SessionData.Clear("MyBookmarks");
            using (var context = new SnitzDataContext())
            {
                context.Delete<BookmarkEntry>("WHERE BOOKMARK_ID IN (" + string.Join(", ", bookmarks.Select(n => n.ToString()).ToArray()) + ")");

            }
        }
    }

}