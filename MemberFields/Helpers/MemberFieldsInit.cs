using System;
using System.Configuration;
using System.IO;
using System.Web;
using MemberFields.Models;
using SnitzConfig;
using SnitzDataModel;
using SnitzDataModel.Database;

// ReSharper disable once CheckNamespace
namespace Helpers
{
    public class Setup
    {
        const string TableName = "USERFIELDS";


        public static bool TableExists()
        {
            return Config.TableExists(ConfigurationManager.AppSettings["memberTablePrefix"] + TableName);

 		}

        public void Start()
        {
            //Check if the DB table does NOT exist
            if (!TableExists())
            {
                StartProcess(Guid.NewGuid().ToString(), "~/App_Data/dbsMemberFields.xml");
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
        /// <summary>
        /// Returns the value of a property
        /// </summary>
        /// <param name="memberid">Members Id</param>
        /// <param name="propertyname">Name of Property</param>
        /// <returns>PropertyValue</returns>
        public static object GetPropertyValue(int memberid, string propertyname)
        {
            return MemberFieldsRepository.GetValue(memberid, propertyname).PropertyValue;
        }
    }
}