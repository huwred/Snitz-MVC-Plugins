using System;
using System.Collections.Generic;
using System.Data;


namespace SiteManage.Extras
{
    public static class DbManager
    {
        public static string JsonDataTable(DataTable table)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            foreach (DataRow dataRow in table.Rows)
            {
                var row = new Dictionary<string, object>();
                foreach (DataColumn column in table.Columns)
                {
                    if (table.TableName == "SchemaTable")
                    {
                        if (new List<string>
                        {
                            "ColumnName",
                            "DataTypeName",
                            "AllowDBNull",
                            "IsIdentity",
                            "IsAutoIncrement",
                            "ColumnSize"
                        }.Contains(column.ColumnName))
                            row.Add(column.ColumnName.Trim().Replace("Name", ""), dataRow[column]);
                    }
                    else
                    {
                        row.Add(column.ColumnName.Trim(), dataRow[column]);
                    }
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        public static string ColumnSize(int? size, string type, string dbType)
        {
            if (size != null)
            {
                switch (type)
                {
                    case "smallint":
                        if (dbType == "mysql")
                        {
                            return "(" + size.Value + ")";
                        }
                        return "";
                    case "int":
                        if (dbType == "mysql")
                        {
                            return "(" + size.Value + ")";
                        }
                        return "";
                    case "nvarchar":
                    case "varchar":
                        if (size.Value > 8000)
                            return "(max)";
                        return "(" + size.Value + ")";
                    case "date":
                        return "";
                    default:
                        return "";
                }

            }

            return "";
        }

        public static string DefaultVal(string value, string type)
        {
            if (value == null) return "";

            if (!String.IsNullOrEmpty(value))
            {
                switch (type)
                {
                    case "smallint":
                    case "bit":
                    case "int":
                        return "DEFAULT " + value;
                    case "float":
                        return "DEFAULT '" + value + "'";
                    case "nvarchar":
                    case "varchar":
                        return "DEFAULT '" + value + "'";
                    case "date":
                        return "DEFAULT '" + value + "'";
                    default:
                        return value;
                }

            }
            return "";
        }

        public static String ColumnNull(bool value, string dbType)
        {
            if (value)
            {
                if (dbType == "mysql")
                    return "";
                return "NULL";
            }
            return "NOT NULL";
        }

        public static string ColumnType(string value, string dbType)
        {
            switch (dbType)
            {
                case "access":
                    switch (value)
                    {
                        case "smallint":
                            return value;
                        case "int":
                            return value;
                        case "nvarchar":
                        case "varchar":
                            return "text";
                        case "memo":
                            return value;
                        case "date":
                            return value;
                        default:
                            return value;
                    }
                case "mssql":
                    switch (value)
                    {
                        case "smallint":
                            return value;
                        case "int":
                            return value;
                        case "nvarchar":
                        case "varchar":
                            return value;
                        case "memo":
                        case "text":
                            return "nvarchar(MAX)";
                        case "date":
                            return "datetime";
                        case "guid":
                            return "uniqueidentifier";
                        default:
                            return value;
                    }
                case "mysql":
                    switch (value)
                    {
                        case "smallint":
                            return value;
                        case "int":
                            return value;
                        case "nvarchar":
                        case "varchar":
                            return value;
                        case "memo":
                        case "text":
                            return "text";
                        case "date":
                            return "datetime";
                        case "guid":
                            return "uniqueidentifier";
                        default:
                            return value;
                    }
                    break;
            }
            return String.Empty;
        }
    }
}