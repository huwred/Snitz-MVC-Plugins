
using SnitzCore.Filters;

namespace SiteManage.Models
{
    public class TableEditRow
    {
        [Required(ErrorMessage = "Table Name required")]
        public string TableName { get; set; }
        [Required(ErrorMessage = "Column Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field Type required")]
        public string DataType { get; set; }
        public int Length { get; set; }
        public bool AllowNull { get; set; }

        public bool Identity { get; set; }
        public bool AutoIncrement { get; set; }

        public bool IsNew { get; set; }
        public string Default { get; set; }
    }
}