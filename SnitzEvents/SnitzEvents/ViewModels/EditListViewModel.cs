using SnitzEvents.Models;

namespace SnitzEvents.ViewModels
{
    public class EditListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public string ListType { get; set; }
    }
    public class EditClubViewModel
    {
        public int Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Abbr { get; set; }
        public int Order { get; set; }
        public ClubCalendarLocation DefaultLocation { get; set; }

    }
}