using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;
using PostThanks.Models;
using SnitzConfig;
using SnitzDataModel;
using SnitzDataModel.Database;

namespace PostThanks.Helpers
{
    public class Setup
    {
        const string TableName = "THANKS";


        public static bool TableExists()
        {
            return Config.TableExists(ConfigurationManager.AppSettings["forumTablePrefix"] + TableName);

 		}

        public void Start()
        {
            //Check if the DB table does NOT exist
            if (!TableExists())
            {
                StartProcess(Guid.NewGuid().ToString(), "~/App_Data/dbsPostThanks.xml");
            }

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
        public static bool Allowed(int id)
        {
            return PostThanksRepository.IsForumAllowed(id);
        }
    }
}