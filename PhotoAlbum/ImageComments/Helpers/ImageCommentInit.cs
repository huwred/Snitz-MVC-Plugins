using System;
using System.Configuration;
using System.IO;
using System.Web;
using SnitzConfig;
using SnitzDataModel;
using SnitzDataModel.Database;

namespace Helpers
{
    public class Setup
    {

        public static bool TableExists()
        {
            return Config.TableExists("FORUM_IMAGES");
 		}

        public void Start()
        {
            ////Check if the DB table does NOT exist
            if (!TableExists())
            {
                StartProcess(Guid.NewGuid().ToString(), "~/App_Data/dbsImageComments.xml");
            }
            else
            {
                StartProcess(Guid.NewGuid().ToString(), "~/App_Data/dbsImageCommentsUpdate.xml");
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