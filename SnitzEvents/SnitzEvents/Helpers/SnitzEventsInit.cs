using System;
using System.Configuration;
using System.IO;
using System.Web;
using SnitzConfig;
using SnitzDataModel;
using SnitzDataModel.Database;
using SnitzEvents.Models;

namespace SnitzEvents.Helpers
{
    public class Setup
    {

        public void Start()
        {
            ////Check if the DB table does NOT exist
            StartProcess(Guid.NewGuid().ToString(),
                !Config.TableExists("CAL_EVENTS") ? "~/App_Data/dbsEvents.xml" : "~/App_Data/dbsUpdateEvents.xml");
        }

        public void StartProcess(string id, string dbsfile)
        {
            var path = HttpContext.Current.Server.MapPath(dbsfile);
            if (File.Exists(path))
            {
                var provider = ConfigurationManager.ConnectionStrings["SnitzConnectionString"].ProviderName;
                var dbtype = "mssql";
                if (provider.StartsWith("MySql"))
                    dbtype = "mysql";
                var dbsProcessor = new DbsFileProcessor(path) {_dbType = dbtype};
                if (!dbsProcessor.Applied)
                {
                    dbsProcessor.Add(id);
                    dbsProcessor.Process(id);
                }
            }
        }


    }

    public static class Methods
    {
        public static bool HasEvent(int topicid)
        {
            using (EventsRepository db = new EventsRepository())
            {
                return db.TopicHasEvent(topicid);
            }
        }

        public static object ForumAuth(int forumid)
        {
            using (EventsRepository db = new EventsRepository())
            {
                return db.GetForumAuth(forumid);
            }
        }
    }
}