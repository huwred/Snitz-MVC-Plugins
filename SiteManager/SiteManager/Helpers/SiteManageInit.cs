using System;
using System.Configuration;
using System.IO;
using System.Web;
using SnitzConfig;
using SnitzDataModel;

namespace SiteManage.Helpers
{
    public class Setup
    {

        public void Start()
        {
            ////Check if the DB table does NOT exist
            StartProcess(Guid.NewGuid().ToString(),
                !Config.TableExists("FORUM_DONATION") ? "~/App_Data/dbsDonations.xml" : "~/App_Data/dbsDonations_update.xml");
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
                var dbsProcessor = new DbsFileProcessor(path) { _dbType = dbtype };
                if (!dbsProcessor.Applied)
                {
                    dbsProcessor.Add(id);
                    dbsProcessor.Process(id);
                }
            }
        }
    }
}