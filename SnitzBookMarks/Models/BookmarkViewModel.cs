using System.Collections.Generic;
using BookMarks.Helpers;
using Snitz.Base;


namespace BookMarks.Models
{
    public class BookmarkViewModel
    {
        public int UserId { get; set; }
        public List<BookmarkEntry> Bookmarks { get; set; }
        public Enumerators.ActiveRefresh Refresh { get; set; }
        public BookmarkEnums.ActiveTopicsSince ActiveSince { get; set; }

    }
}