// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Test.Tables
// @Class     : Decimal
// ----------------------------------------------------------------------
namespace Izayoi.Data.Test.Tables
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("decimals")]
    public class Dec
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("single")]
        public float Single { get; set; }

        [Column("double")]
        public double Double { get; set; }

        [Column("decimal")]
        public decimal Decimal { get; set; }
    }
}
