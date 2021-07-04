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
        const string TableName = "BOOKMARKS";

 		public static string _SQL_check_if_tables_exists =
          @"if (exists (select * from information_schema.tables where table_name = 'TABLE_NAME')) 
 				begin 
 					select 1 
 				end 
 				select 0";

        public static bool TableExists()
        {
            return Config.TableExists(ConfigurationManager.AppSettings["memberTablePrefix"] + TableName);
 		}

        public void Start()
        {
            //Check if the DB table does NOT exist
            if (!TableExists())
            {
                StartProcess(Guid.NewGuid().ToString(), "~/App_Data/dbsBookmarks.xml");
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
        public static string SayHi()
        {
            return "Hello from Bookmark";
        }
    }
}