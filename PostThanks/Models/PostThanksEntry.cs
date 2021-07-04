using PetaPoco;
using Snitz.Base;

namespace PostThanks.Models
{
    [TableName("THANKS", prefixType = Extras.TablePrefixTypes.Member)]
    [ExplicitColumns]
    public class PostThanksEntry
    {
        [Column("TOPIC_ID")]
        public int TopicId { get; set; }

        [Column("MEMBER_ID")]
        public int UserId { get; set; }

        [Column("REPLY_ID")]
        public int ReplyId { get; set; }

        //public Topic Topic { get; set; }
        //public Member Author { get; set; }
        //public Forum Forum { get; set; }
        [ResultColumn]
        public string Username { get; set; }
    }

    public class UserThanksCount
    {
        public int TopicCount { get; set; }
        public int ReplyCount { get; set; }
    }
}
