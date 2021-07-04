using System.Web.Mvc;
using PetaPoco;
using Snitz.Base;


namespace ForumWidgets.Models
{
    [PetaPoco.TableName("WIDGETS", prefixType = Extras.TablePrefixTypes.Forum)]
    [PrimaryKey("W_ID")]
    [ExplicitColumns]
    public class ForumWidget
    {
        [PetaPoco.Column("W_ID")]
        public int Id { get; set; }

        [PetaPoco.Column("W_NAME")]
        public string Name { get; set; }
        [PetaPoco.Column("W_HTML")]
        [AllowHtml] 
        public string HtmlString { get; set; }

    }
}
