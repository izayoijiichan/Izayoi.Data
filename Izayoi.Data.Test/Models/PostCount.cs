// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Test.Models
// @Class     : PostCount
// ----------------------------------------------------------------------
namespace Izayoi.Data.Test.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostCount
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("user_name")]
        public string UserName { get; set; } = string.Empty;

        [Column("count")]
        public int Count { get; set; }
    }
}
