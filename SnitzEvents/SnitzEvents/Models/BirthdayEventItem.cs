using System;
using SnitzCore.Extensions;

namespace SnitzEvents.Models
{
    public class BirthdayEventItem
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public bool IsAllDayEvent { get { return true; } }
        public string Title { get; set; }
        public DateTime? StartDate
        {
            get { return Dob.ToDateTime(); }
            set
            {
                Dob = value.HasValue ? value.Value.ToSnitzDate() : null;
            }
        }

        public string Dob { get; set; }

    }
}