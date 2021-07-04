using System;
using System.Configuration;
using System.IO;
using System.Web;
using SnitzConfig;
using SnitzDataModel;
using SnitzDataModel.Database;

namespace ForumWidgets.Helpers
{
    public class Setup
    {

        public static bool TableExists()
        {

            using (var db = new SnitzDataContext())
            {
                return Config.TableExists("FORUM_WIDGETS");
            }
            
        }

        public void Start()
        {
            ////Check if the DB table does NOT exist
            if (!TableExists())
            {
                StartProcess(Guid.NewGuid().ToString(), "~/App_Data/dbsWidgets.xml");
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
}