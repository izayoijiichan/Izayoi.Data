// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Test.Tables
// @Class     : Post
// ----------------------------------------------------------------------
namespace Izayoi.Data.Test.Tables
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("posts")]
    public class Post
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("posted_at")]
        public DateTime PostedAt { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("comment")]
        public string Comment { get; set; } = string.Empty;

        [NotMapped]
        public int IgnoreProperty { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(PostedAt)}: {PostedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")}, {nameof(UserId)}: {UserId}, {nameof(Comment)}: {Comment}";
        }
    }
}
