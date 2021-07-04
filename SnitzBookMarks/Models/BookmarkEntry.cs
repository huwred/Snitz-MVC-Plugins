using PetaPoco;
using Snitz.Base;
using SnitzDataModel.Models;


namespace BookMarks.Models
{
    [TableName("BOOKMARKS", prefixType = Extras.TablePrefixTypes.Member)]
    [PrimaryKey("BOOKMARK_ID")]
    [ExplicitColumns]
    public class BookmarkEntry
    {
        [Column("BOOKMARK_ID")]
        public int Id { get; set; }
        [Column("B_TOPICID")]
        public int TopicId { get; set; }
        [Column("B_MEMBERID")]
        public int UserId { get; set; }

        public Topic Topic { get; set; }
        public Member Author { get; set; }
        public Forum Forum { get; set; }
    }
}
