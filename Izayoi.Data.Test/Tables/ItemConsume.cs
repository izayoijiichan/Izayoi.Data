// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Test.Tables
// @Class     : ItemConsume
// ----------------------------------------------------------------------
namespace Izayoi.Data.Test.Tables
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("item_consumes")]
    public class ItemConsume
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("item_id")]
        public Guid ItemId { get; set; }

        [Column("consume_date")]
        public DateOnly ConsumeDate { get; set; }
    }
}
