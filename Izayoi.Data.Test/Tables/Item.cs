// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Test.Tables
// @Class     : Item
// ----------------------------------------------------------------------
namespace Izayoi.Data.Test.Tables
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("items")]
    public class Item
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}
