using System;
using System.Collections.Generic;
using PetaPoco;
using Snitz.Base;
using SnitzCore.Extensions;
using SnitzCore.Filters;
using SnitzDataModel.Database;
using SnitzEvents.Helpers;

namespace SnitzEvents.Models
{
    [TableName("CAL_EVENTS", prefixType = Extras.TablePrefixTypes.None)]
    [PrimaryKey("C_ID")]
    [ExplicitColumns]
    public class CalendarEventItem : SnitzDataContext.Record<CalendarEventItem>
    {
        [Column("C_ID")]
        public int Id { get; set; }
        [Column("TOPIC_ID")]
        public int TopicId { get; set; }
        [Column("EVENT_ALLDAY")]
        public bool IsAllDayEvent { get; set; }
        [Column("EVENT_DATE")]
        public String Start { get; set; }
        [Column("EVENT_ENDDATE")]
        public String End { get; set; }
        [Column("EVENT_RECURS")]
        public CalEnums.CalRecur Recurs { get; set; }
        [Column("EVENT_DAYS")]
        public string RecurDays { get; set; }

        [ResultColumn]
        public string Title { get; set; }
        [ResultColumn]
        public string Description { get; set; }
        [ResultColumn]
        public string Author { get; set; }
        [ResultColumn]
        public DateTime? StartDate
        {
            get { return Start.ToDateTime(); }
            set
            {
                Start = value.HasValue ? value.Value.ToSnitzDate() : null;
            }
        }
        [ResultColumn]
        public DateTime? EndDate
        {
            get { return End.ToDateTime(); }
            set
            {
                End = value.HasValue ? value.Value.ToSnitzDate() : null;
            }
        }

        public IEnumerable<string> SelectedDays { get; set; }
         
        public int[] Days { get; set; }

        public CalendarEventItem()
        {
            StartDate = null;
            EndDate = null;
            TopicId = -1;
        }
    }

    [TableName("CAL_EVENTS", prefixType = Extras.TablePrefixTypes.None)]
    [PrimaryKey("C_ID")]
    [ExplicitColumns]
    public class ClubCalendarEventItem : CalendarEventItem
    {
        [Column("EVENT_TITLE")]
        [Required]
        public new string EventTitle { get; set; }
        [Column("EVENT_DETAILS")]
        public new string Description { get; set; }
        [Column("DATE_ADDED")]
        public string Posted { get; set; }

        [Column("CLUB_ID")]
        public int ClubId { get; set; }
        [Column("CAT_ID")]
        public int CatId { get; set; }
        [Column("LOC_ID")]
        public int LocId { get; set; }
        [Column("AUTHOR_ID")]
        public int PostedById { get; set; }


        [ResultColumn]
        public string CategoryName { get; set; }
        [ResultColumn]
        public string ClubName { get; set; }
        [ResultColumn]
        public string ClubAbbr { get; set; }
        [ResultColumn]
        public string Location { get; set; }

        [ResultColumn]
        public DateTime? PostedDate
        {
            get { return Posted.ToDateTime(); }
            set
            {
                Posted = value.HasValue ? value.Value.ToSnitzDate() : null;
            }
        }
    }

    [TableName("EVENT_CAT", prefixType = Extras.TablePrefixTypes.None)]
    [PrimaryKey("CAT_ID")]
    [ExplicitColumns]
    public class ClubCalendarCategory : SnitzDataContext.Record<ClubCalendarCategory>
    {
        [Column("CAT_ID")]
        public int Id { get; set; }

        [Column("CAT_NAME")]
        public String Name { get; set; }

        [Column("CAT_ORDER")]
        public int Order { get; set; }
    }

    [TableName("EVENT_CLUB", prefixType = Extras.TablePrefixTypes.None)]
    [PrimaryKey("CLUB_ID")]
    [ExplicitColumns]
    public class ClubCalendarClub : SnitzDataContext.Record<ClubCalendarClub>
    {
        [Column("CLUB_ID")]
        public int Id { get; set; }

        [Column("CLUB_L_NAME")]
        public String LongName { get; set; }
        [Column("CLUB_S_NAME")]
        public String ShortName { get; set; }
        [Column("CLUB_ABBR")]
        public String Abbreviation { get; set; }
        [Column("CLUB_ORDER")]
        public int Order { get; set; }
        [Column("CLUB_DEF_LOC")]
        public int DefLocId { get; set; }
    }

    [TableName("EVENT_LOCATION", prefixType = Extras.TablePrefixTypes.None)]
    [PrimaryKey("LOC_ID")]
    [ExplicitColumns]
    public class ClubCalendarLocation : SnitzDataContext.Record<ClubCalendarLocation>
    {
        [Column("LOC_ID")]
        public int Id { get; set; }

        [Column("LOC_NAME")]
        public String Name { get; set; }

        [Column("LOC_ORDER")]
        public int Order { get; set; }
    }

    [TableName("EVENT_SUBSCRIPTIONS", prefixType = Extras.TablePrefixTypes.None)]
    [PrimaryKey("SUB_ID")]
    [ExplicitColumns]
    public class ClubCalendarSubscriptions : SnitzDataContext.Record<ClubCalendarSubscriptions>
    {
        [Column("SUB_ID")]
        public int Id { get; set; }

        [Column("CLUB_ID")]
        public int ClubId { get; set; }
        [Column("MEMBER_ID")]
        public int MemberId { get; set; }
    }

    public class CatSummary
    {
        public int CatId { get; set; }
        public string Name { get; set; }
        public int EventCount { get; set; }
    }
}