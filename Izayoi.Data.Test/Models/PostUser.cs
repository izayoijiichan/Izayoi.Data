// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Test.Models
// @Class     : PostUser
// ----------------------------------------------------------------------
namespace Izayoi.Data.Test.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostUser
    {
        [Column("post_id")]
        public int PostId { get; set; }

        [Column("posted_at")]
        public DateTime PostedAt { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("user_name")]
        public string UserName { get; set; } = string.Empty;

        [Column("comment")]
        public string Comment { get; set; } = string.Empty;
    }
}
