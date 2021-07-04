using System;
using System.Collections.Generic;
using System.Linq;
using PetaPoco;
using SnitzDataModel.Database;


namespace MemberFields.Models
{
    /// <summary>
    /// MemberFields Database queries
    /// </summary>
    public static class MemberFieldsRepository
    {
        /// <summary>
        /// Get extended property for a Member
        /// </summary>
        /// <param name="memberid">ID of Member</param>
        /// <param name="property">Property Name</param>
        /// <returns></returns>
        public static MemberProfile GetValue(int memberid, string property)
        {
            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();

                sql.Select("P.*,f.USR_SHORTNAME AS PropertyName,f.USR_FIELDTYPE AS PropertyType,f.USR_OPTIONAL AS Optional,f.USR_PRIVATE AS Private");
                sql.From(context.MemberTablePrefix + "MEMBERFIELDS P");
                sql.LeftJoin(context.MemberTablePrefix + "USERFIELDS f").On("P.USR_FIELD_ID = f.USR_FIELD_ID");
                sql.Where("P.MEMBER_ID=@0", memberid);
                sql.Where("f.USR_SHORTNAME=@0", property);
                MemberProfile profField = context.SingleOrDefault<MemberProfile>(sql);
                if (profField == null)
                {
                    profField = new MemberProfile
                    {
                        MemberId = memberid,
                        PropertyName = property
                    };
                    var prop = GetProperty(property);
                    profField.PropertyId = prop.Id;
                    profField.PropertyType = prop.FieldType;
                    profField.PropertyValue = prop.DefaultValue??"";
                    profField.Private = prop.Private;
                    profField.Optional = prop.Optional;
                }
                return profField;                
            }

        }
        public static MemberProfile GetValueInternal(int memberid, string property)
        {
            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();

                sql.Select("P.*,f.USR_SHORTNAME AS PropertyName,f.USR_FIELDTYPE AS PropertyType");
                sql.From(context.MemberTablePrefix + "MEMBERFIELDS P");
                sql.LeftJoin(context.MemberTablePrefix + "USERFIELDS f").On("P.USR_FIELD_ID = f.USR_FIELD_ID");
                sql.Where("P.MEMBER_ID=@0", memberid);
                sql.Where("f.USR_SHORTNAME=@0", property);
                MemberProfile profField = context.SingleOrDefault<MemberProfile>(sql);
                return profField;
            }

        }
        /// <summary>
        /// Save extended property for a Member
        /// </summary>
        /// <param name="memberid"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SaveValue(int memberid, string property, string value)
        {
            var sql = new Sql();

            int fieldid = GetPropertyId(property);
            MemberProfile profile = GetValueInternal(memberid, property);
            if (profile == null)
            {
                sql.Append("INSERT INTO " + SnitzDataContext.Record<MemberProfile>.repo.MemberTablePrefix + "MEMBERFIELDS (MEMBER_ID,USR_FIELD_ID,USR_VALUE) VALUES(@0,@1,@2)", memberid, fieldid, value);
                SnitzDataContext.Record<MemberProfile>.repo.Execute(sql);
            }
            else
            {
                profile.PropertyValue = value;
                sql.Append("UPDATE " + SnitzDataContext.Record<MemberProfile>.repo.MemberTablePrefix + "MEMBERFIELDS SET USR_VALUE=@0 WHERE MEMBER_ID=@1 AND USR_FIELD_ID=@2", value, memberid, fieldid);
                SnitzDataContext.Record<MemberProfile>.repo.Execute(sql);
            }

        }

        /// <summary>
        /// Get all extended properties for a Member
        /// </summary>
        /// <param name="memberid">ID of Member</param>
        /// <returns></returns>
        public static IEnumerable<MemberProfile> GetValues(int memberid)
        {
            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                //                SELECT a.*,b.*
                //FROM FORUM_EXPROFILEFIELDS a
                //LEFT JOIN FORUM_MEMBEREXPROF b ON b.FIELD_ID = a.FIELD_ID AND b.MEMBER_ID = 1
                sql.Select("COALESCE(P.MEMBER_ID," + memberid + ") AS MEMBER_ID,f.USR_FIELD_ID,COALESCE(P.USR_VALUE,'') AS USR_VALUE,f.USR_SHORTNAME AS PropertyName,f.USR_FIELDTYPE AS PropertyType,f.USR_OPTIONAL AS Optional,f.USR_PRIVATE AS Private");
                sql.From(context.MemberTablePrefix + "USERFIELDS f");
                sql.LeftJoin(context.MemberTablePrefix + "MEMBERFIELDS P").On("P.USR_FIELD_ID = f.USR_FIELD_ID AND P.MEMBER_ID=" + memberid);
                //sql.Where("P.MEMBER_ID=@0", _memberid);
                return context.Query<MemberProfile>(sql);


            }
        }
        public static IEnumerable<MemberProfile> GetValues(int memberid,string[] properties)
        {
            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                //                SELECT a.*,b.*
                //FROM FORUM_EXPROFILEFIELDS a
                //LEFT JOIN FORUM_MEMBEREXPROF b ON b.FIELD_ID = a.FIELD_ID AND b.MEMBER_ID = 1
                sql.Select("COALESCE(P.MEMBER_ID," + memberid + ") AS MEMBER_ID,f.USR_FIELD_ID,COALESCE(P.USR_VALUE,'') AS USR_VALUE,f.USR_SHORTNAME AS PropertyName,f.USR_FIELDTYPE AS PropertyType,f.USR_OPTIONAL AS Optional,f.USR_PRIVATE AS Private");
                sql.From(context.MemberTablePrefix + "USERFIELDS f");
                sql.LeftJoin(context.MemberTablePrefix + "MEMBERFIELDS P").On("P.USR_FIELD_ID = f.USR_FIELD_ID AND P.MEMBER_ID=" + memberid);
                sql.Where("f.USR_SHORTNAME IN (" + string.Join(",", properties.Select(item => "'" + item + "'")) + ")");
                return context.Query<MemberProfile>(sql);


            }
        }
        public static IEnumerable<MemberProfile> GetValuesExcluded(int memberid, string[] excluded)
        {
            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                //                SELECT a.*,b.*
                //FROM FORUM_EXPROFILEFIELDS a
                //LEFT JOIN FORUM_MEMBEREXPROF b ON b.FIELD_ID = a.FIELD_ID AND b.MEMBER_ID = 1
                sql.Select("COALESCE(P.MEMBER_ID," + memberid + ") AS MEMBER_ID,f.USR_FIELD_ID,COALESCE(P.USR_VALUE,'') AS USR_VALUE,f.USR_SHORTNAME AS PropertyName,f.USR_FIELDTYPE AS PropertyType,f.USR_OPTIONAL AS Optional,f.USR_PRIVATE AS Private");
                sql.From(context.MemberTablePrefix + "USERFIELDS f");
                sql.LeftJoin(context.MemberTablePrefix + "MEMBERFIELDS P").On("P.USR_FIELD_ID = f.USR_FIELD_ID AND P.MEMBER_ID=" + memberid);
                sql.Where("f.USR_SHORTNAME NOT IN (" + string.Join(",", excluded.Select(item => "'" + item + "'")) + ")");
                return context.Query<MemberProfile>(sql);


            }
        }

        /// <summary>
        /// Get properties of Extended Field
        /// </summary>
        /// <param name="fieldid">ID of Extended Property</param>
        /// <returns></returns>
        public static ExtendedProfile GetField(int fieldid)
        {
            using (var context = new SnitzDataContext())
            {
                return context.SingleOrDefault<ExtendedProfile>("SELECT * FROM " + context.MemberTablePrefix + "USERFIELDS WHERE USR_FIELD_ID=@0", fieldid);
            }
        }

        /// <summary>
        /// Fetch List of Profile fields
        /// </summary>
        /// <returns>List of ExtendedProfiles</returns>
        public static List<ExtendedProfile> GetFields()
        {
            using (var context = new SnitzDataContext())
            {
                var fields = context.Fetch<ExtendedProfile>("SELECT * FROM " + context.MemberTablePrefix + "USERFIELDS");
                return fields;
            }
        }

        /// <summary>
        /// Add a new Extended Profile Field
        /// </summary>
        /// <param name="vm"></param>
        public static void CreateField(ExtendedProfile vm)
        {
            using (var context = new SnitzDataContext())
            {
                context.Save(vm);
            }
        }

        /// <summary>
        /// Delete Profile Field
        /// </summary>
        /// <param name="fieldid"></param>
        public static void DeleteField(int fieldid)
        {
            var prof = GetField(fieldid);
            if (prof != null)
            {
                SnitzDataContext.Record<MemberProfile>.repo.Delete(prof);
                //TODO: Delete Members properties
            }
        }
        public static ExtendedProfile GetProperty(string property)
        {
            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();

                sql.Select("*");
                sql.From(context.MemberTablePrefix + "USERFIELDS");
                sql.Where("USR_SHORTNAME=@0", property);
                var retVal = context.SingleOrDefault<ExtendedProfile>(sql);
                return retVal;
            }
        }

        /// <summary>
        /// Get Field_id from property name
        /// </summary>
        /// <param name="property">Name of Property</param>
        /// <returns>FIELD_ID</returns>
        private static int GetPropertyId(string property)
        {
            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();

                sql.Select("USR_FIELD_ID");
                sql.From(context.MemberTablePrefix + "USERFIELDS");
                sql.Where("USR_SHORTNAME=@0", property);
                var retVal = context.SingleOrDefault<int>(sql);
                return retVal;
            }
        }

    }

}