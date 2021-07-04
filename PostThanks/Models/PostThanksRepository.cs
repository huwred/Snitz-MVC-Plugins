using System;
using System.Collections.Generic;
using System.Linq;
using PetaPoco;
using Snitz.Base;
using SnitzDataModel.Database;

namespace PostThanks.Models
{
    public class PostThanksRepository : IDisposable
    {
        private List<PostThanksEntry> _data;
        private int _memberid;

        public PostThanksRepository(int memberid)
        {
            _memberid = memberid;
            Initialize();
        }

        private void Initialize()
        {

            _data = new List<PostThanksEntry>();

            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();

                sql.Select("T.*, e.M_NAME AS Username");
                sql.From(context.ForumTablePrefix + "THANKS T");
                sql.LeftJoin(context.MemberTablePrefix + "MEMBERS e").On("T.MEMBER_ID = e.MEMBER_ID");
                sql.Where("T.MEMBER_ID=@0", _memberid);
                _data = context.Fetch<PostThanksEntry>(sql);
                

            }

        }


        public void AddThanks(int topicid, int replyid = 0)
        {
            try
            {
                using (var context = new SnitzDataContext())
                {
                    context.Execute("INSERT INTO " + context.ForumTablePrefix + "THANKS (MEMBER_ID,TOPIC_ID,REPLY_ID) VALUES(@0,@1,@2)", _memberid,
                        topicid, replyid);
                }

            }
            catch (Exception)
            {

            }
        }

        public bool DeleteThanks(int topicid, int replyid = 0)
        {
            using (var context = new SnitzDataContext())
            {
                return
                    context.Delete<PostThanksEntry>("WHERE MEMBER_ID=@0 AND TOPIC_ID=@1 AND REPLY_ID=@2", _memberid,
                        topicid, replyid) > 0;
            }
        }

        public bool IsThanked(int topicid, int replyid = 0)
        {
            if (_data.SingleOrDefault(c => c.TopicId == topicid && c.ReplyId == replyid) != null)
                return true;

            return false;
        }

        public void Dispose()
        {
            _data.Clear();
            _data = null;
        }


        public int Count(int id, int replyid)
        {

            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                sql.Select("COUNT(TH.TOPIC_ID) AS TotalCount");
                sql.From(context.ForumTablePrefix + "THANKS TH");
                sql.Where("TH.TOPIC_ID=@0 AND TH.REPLY_ID=@1", id,replyid);
                return context.ExecuteScalar<int>(sql);

            }
        }

        public static int MemberCountReceived(int memberid)
        {

            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                sql.Select("COUNT(T.T_AUTHOR) AS TotalCount "); //,SUM(R.R_AUTHOR) AS ReplyCount
                sql.From(context.ForumTablePrefix + "THANKS TH ");
                sql.LeftJoin(context.ForumTablePrefix + "TOPICS T").On("TH.TOPIC_ID = T.TOPIC_ID ");
                sql.LeftJoin(context.ForumTablePrefix + "REPLY R").On("TH.REPLY_ID = R.REPLY_ID ");

                sql.Where("T.T_AUTHOR=@0 OR R.R_AUTHOR=@0", memberid);
                return context.ExecuteScalar<int>(sql);

            }
        }

        public static int MemberCountGiven(int memberid)
        {
            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                sql.Select("COUNT(TH.MEMBER_ID) AS TotalCount "); //,SUM(R.R_AUTHOR) AS ReplyCount
                sql.From(context.ForumTablePrefix + "THANKS TH ");
                sql.Where("TH.MEMBER_ID=@0", memberid);
                return context.ExecuteScalar<int>(sql);

            }
        }
        public bool IsAuthor(int topicid, int replyid)
        {
            Sql sql = new Sql();

            try
            {
                using (var context = new SnitzDataContext())
                {
                    if (replyid > 0)
                    {
                        sql.Select("COUNT(R.R_AUTHOR) ");
                        sql.From(context.ForumTablePrefix + "REPLY R ");
                        sql.Where("R.REPLY_ID=@0", replyid);
                        sql.Where("R.R_AUTHOR=@0", _memberid);
                    }
                    else
                    {
                        sql.Select("COUNT(T.T_AUTHOR) ");
                        sql.From(context.ForumTablePrefix + "TOPICS T ");
                        sql.Where("T.TOPIC_ID=@0", topicid);
                        sql.Where("T.T_AUTHOR=@0", _memberid);
                    }
                    int test = context.ExecuteScalar<int>(sql) ;
                    if (test > 0) return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<string> Members(int id, int replyid)
        {

            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                sql.Select("M.M_NAME "); //,SUM(R.R_AUTHOR) AS ReplyCount
                sql.From(context.ForumTablePrefix + "THANKS TH ");
                sql.LeftJoin(context.MemberTablePrefix + "MEMBERS M").On("TH.MEMBER_ID = M.MEMBER_ID ");
                sql.Where("TH.TOPIC_ID=@0 AND TH.REPLY_ID=@1 ", id,replyid);
                return context.Fetch<string>(sql);

            }
        }

        public static bool IsForumAllowed(int forumid)
        {

            return ThanksForums().Contains(forumid);

        }
        public static bool IsAllowedForum(int topicid)
        {

            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                sql.Select("FORUM_ID");
                sql.From(context.ForumTablePrefix + "TOPICS");
                sql.Where("TOPIC_ID=@0", topicid);
                var forumid = context.SingleOrDefault<int>(sql);
                return ThanksForums().Contains(forumid);
            }
        }
        public static void SetAllowThanks(int id, int check)
        {
            using (var context = new SnitzDataContext())
            {
                context.Execute("UPDATE " + context.ForumTablePrefix + "FORUM SET F_ALLOWTHANKS=@0 WHERE FORUM_ID=@1",check,id);

            }
            var cacheService = new InMemoryCache();
            cacheService.Remove("postthanks.forums");
            cacheService.Remove("category.forums");
        }

        private static List<int> ThanksForums()
        {
            var service = new InMemoryCache(){DoNotExpire=true};
            return service.GetOrSet("postthanks.forums", () =>
            {
                using (var context = new SnitzDataContext())
                {
                    return
                        context.Fetch<int>("SELECT FORUM_ID FROM " + context.ForumTablePrefix +
                                           "FORUM WHERE F_ALLOWTHANKS=1");

                }
            });

        }
    }

}