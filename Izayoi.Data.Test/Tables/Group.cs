// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Test.Tables
// @Class     : Group
// ----------------------------------------------------------------------
namespace Izayoi.Data.Test.Tables
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("groups")]
    public class Group
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}
