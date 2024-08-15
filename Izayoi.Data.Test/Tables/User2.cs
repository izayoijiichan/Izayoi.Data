// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Test.Tables
// @Class     : User2
// ----------------------------------------------------------------------
namespace Izayoi.Data.Test.Tables
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("users2")]
    public class User2
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("age")]
        public byte? Age { get; set; }

        [Column("gender")]
        public GenderType? Gender { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted")]
        public bool? Deleted { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(CreatedAt)}: {CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss.fff")}, {nameof(UpdatedAt)}: {UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss.fff")}, {nameof(Deleted)}: {Deleted}";
        }
    }
}
