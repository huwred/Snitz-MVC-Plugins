using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using Snitz.Base;

namespace ImageComments.Models
{
    [TableName("IMAGE_COMMENT", prefixType = Extras.TablePrefixTypes.Forum)]
    [PrimaryKey("I_ID")]
    [ExplicitColumns]
    public class ImageComment
    {
        [Column("I_ID")]
        public int Id { get; set; }
        [Column("I_MEMBERID")]
        public int MemberId { get; set; }
        [Column("I_IMGID")]
        public int ImageId { get; set; }
        [Column("I_DATE")]
        public string TimeStamp { get; set; }
        [Column("I_COMMENT")]
        public string Comment { get; set; }
        [Column("I_Rating")]
        public int Rating { get; set; }

        [ResultColumn]
        public string PostedBy { get; set; }

        public DateTime PostedOn { get { return TimeStamp.ToSnitzDateTime(); } }
    }
}