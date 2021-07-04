using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using SiteManage.Extras;
using SiteManage.Models;
using SnitzDataModel.Controllers;
using SnitzDataModel.Database;
using SnitzCore;

namespace SiteManage.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class DbManagerController : BaseController
    {
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["SnitzConnectionString"].ConnectionString;

        private DbConnection conn;

        public DbManagerController()
        {
            var prv = ConfigurationManager.ConnectionStrings["SnitzConnectionString"].ProviderName;
            var dbtype = "mssql";
            if (prv.ToLower().Contains("mysql"))
            {
                dbtype = "mysql";
            }
            if(dbtype  == "mssql")
            {
                conn = new SqlConnection(_connStr);
            }
            else
            {
                conn = new MySqlConnection(_connStr);
            }

        }

        public ActionResult Index()
        {
            conn.Open();

            DataTable t = conn.GetSchema("Tables", new[] {null, "dbo", null, "BASE TABLE"});
            t.DefaultView.Sort = "table_name ASC";
            t = t.DefaultView.ToTable();

            conn.Close();
            return View(t);

        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult Table(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json("No Table name supplied");
            }
            try
            {
                conn.Open();
                var sqlCmd = conn.CreateCommand();
                sqlCmd.CommandText = "select * from " + id + " where 1=0"; // No data wanted, only schema
                sqlCmd.CommandType = CommandType.Text;

                var sqlDr = sqlCmd.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable t = sqlDr.GetSchemaTable();
                sqlDr.Close();
                conn.Close();
                string json = DbManager.JsonDataTable(t);
                var result = new {Result = json, ID = id};
                return Json(result, JsonRequestBehavior.AllowGet);

                //return json;// "[{\"" + id + "\":" + json + "}]";
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }

        }

        public ActionResult DelColumn(string id, string col)
        {
            //ALTER TABLE table_name DROP COLUMN column_name;
            try
            {
                conn.Open();
                var sqlCmd = conn.CreateCommand();
                sqlCmd.CommandText = "ALTER TABLE " + id + " DROP COLUMN " + col;
                sqlCmd.CommandType = CommandType.Text;

                var sqlDr = sqlCmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            return RedirectToAction("Table",new{id});
        }
        public ActionResult EditTable(string id, string col)
        {
            var row = new TableEditRow() {DataType = "int", TableName = id};
            if (col != "NEW")
            {
                try
                {
                    conn.Open();
                    var sqlCmd = conn.CreateCommand();
                    sqlCmd.CommandText = "select * from " + id + " where 1=0"; // No data wanted, only schema
                    sqlCmd.CommandType = CommandType.Text;

                    var sqlDr = sqlCmd.ExecuteReader();
                    DataTable t = sqlDr.GetSchemaTable();
                    var result = t.Select("ColumnName = '" + col + "'");
                    if (result.Any())
                    {
                        row.Name = col;
                        row.DataType = (string) result[0]["DataTypeName"];
                        row.AllowNull = (bool) result[0]["AllowDBNull"];
                        row.Length = (int) result[0]["ColumnSize"];
                        row.Identity = (bool) result[0]["IsIdentity"];
                        row.AutoIncrement = (bool) result[0]["IsAutoIncrement"];
                        row.IsNew = false;
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int) HttpStatusCode.BadRequest;
                }
            }
            else
            {
                row.IsNew = true;
            }
            return PartialView(row);
        }


        [HttpPost]
        public ActionResult EditTable(TableEditRow row)
        {
            if (ModelState.IsValid)
            {
                var dal = new SnitzDataContext();
                string dbType = dal.dbtype;

                StringBuilder sql = new StringBuilder();
                var xColumn = row.Name;
                var action = "ALTER";
                if (dbType == "mysql" && action == "ALTER")
                {
                    action = "CHANGE";
                }
                if (row.IsNew)
                    action = "ADD";

                if (xColumn != null)
                {
                    sql.AppendFormat("ALTER TABLE {0} {1} ", row.TableName, action);
                    if (dbType == "access" || action != "ADD")
                    {
                        sql.Append(" COLUMN ");
                    }
                    if (dbType == "mysql" && action == "CHANGE")
                    {
                        sql.AppendFormat("{0} {1} {2} {3} {4} {5}",
                            xColumn, xColumn,
                            DbManager.ColumnType(row.DataType, dbType),
                            DbManager.ColumnSize(row.Length, row.DataType, dbType),
                            DbManager.DefaultVal(row.Default, row.DataType),
                            DbManager.ColumnNull(row.AllowNull, dbType));
                    }
                    else
                    {
                        sql.AppendFormat("{0} {1} {2} {3} {4}",
                            xColumn,
                            DbManager.ColumnType(row.DataType, dbType),
                            DbManager.ColumnSize(row.Length, row.DataType, dbType),
                            DbManager.DefaultVal(row.Default, row.DataType),
                            DbManager.ColumnNull(row.AllowNull, dbType));
                    }
                    try
                    {
                        dal.Execute(sql.ToString());
                    }
                    catch (System.Exception ex)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        return Json(ex.Message, JsonRequestBehavior.AllowGet);
                    }
                    

                }
                if(row.IsNew)
                    return Json("Column " + xColumn + " added", JsonRequestBehavior.AllowGet);
                return Json("Column " + xColumn + " updated", JsonRequestBehavior.AllowGet);
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Table Edit Failed", JsonRequestBehavior.AllowGet);
        }
      
        [HttpPost]
        public string Query(FormCollection form)
        {
            if (form.AllKeys.Contains("sqlQuery"))
            {
                if (!String.IsNullOrEmpty(form["sqlQuery"]))
                {
                    string sql = form["sqlQuery"];
                    if (!sql.Contains("Top", StringComparison.OrdinalIgnoreCase))
                    {
                        string pattern = "SELECT";
                        string replacement = "SELECT TOP 500";
                        Regex rgx = new Regex(pattern,RegexOptions.IgnoreCase);
                        sql = rgx.Replace(sql, replacement);
                    }
                    try
                    {
                        conn.Open();
                        var sqlCmd = conn.CreateCommand();
                        sqlCmd.CommandText = sql;
                        sqlCmd.CommandType = CommandType.Text;

                        var sqlDr = sqlCmd.ExecuteReader();
                        var dataTable = new DataTable();
                        dataTable.Load(sqlDr);

                        conn.Close();
                        var json = DbManager.JsonDataTable(dataTable);
                        return json;
                    }
                    catch (Exception ex)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        return ex.Message;
                    }
                }
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return "must provide a query";
        }


        public ActionResult CreateTable(FormCollection form)
        {
            if (String.IsNullOrWhiteSpace(form["TableName"]))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Error = "No Table name provided";
                return View("Error");
            }
            //CREATE TABLE form["TableName"];
            try
            {
                conn.Open();
                var sqlCmd = conn.CreateCommand();
                sqlCmd.CommandText = "CREATE TABLE " + form["TableName"] + "(" + form["TableName"] + "_ID [int] IDENTITY(1,1) NOT NULL)";
                sqlCmd.CommandType = CommandType.Text;

                sqlCmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Error = ex.Message;
                return View("Error");
            }
            return RedirectToAction("Index");

        }

        public ActionResult BackupDatabase(FormCollection form)
        {
            string tempPath = Directory.CreateDirectory(Server.MapPath("~/App_Data/sqlBackups")).FullName;
            string filename = form["BackupFile"];
            if (String.IsNullOrWhiteSpace(filename))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Error = "You must provide a name for the backup";
                return View("Error");
            }
            
            try
            {
                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("USE {0};",conn.Database).AppendLine();
                    sql.AppendFormat("BACKUP DATABASE {0}", conn.Database).AppendLine();
                    sql.AppendFormat("TO DISK = '{0}\\{1}.Bak'", tempPath, filename).AppendLine();
                    sql.AppendLine("WITH FORMAT,");
                    //if(form["Compress"] == "1")
                    //    sql.AppendLine(" COMPRESSION,");
                    sql.AppendFormat("MEDIANAME = '{0}_SQLServerBackups',", conn.Database).AppendLine();
                    sql.AppendFormat("NAME = 'Full Backup of {0}';", conn.Database).AppendLine();

                    conn.Open();
                    var sqlCmd = conn.CreateCommand();
                    sqlCmd.CommandText = sql.ToString();
                    sqlCmd.CommandType = CommandType.Text;

                    sqlCmd.ExecuteNonQuery();

                    conn.Close();

                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ViewBag.Error = ex.Message;
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Error = ex.Message;
                return View("Error");
            }
            ViewBag.Message = "Database will be backed up.<br />";
            conn.Open();

            DataTable t = conn.GetSchema("Tables", new[] { null, "dbo", null, "BASE TABLE" });
            conn.Close();
            return View("Index",t);
        }

        public ActionResult DropTable(string col)
        {
            throw new NotImplementedException();
        }
    }
}