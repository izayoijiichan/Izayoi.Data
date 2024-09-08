// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation.Test.Models
// @Class     : User
// ----------------------------------------------------------------------
namespace Izayoi.Data.Validation.Test.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Display(Name = "ID")]
        [Required]
        public int? Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(10)]
        public string? Name { get; set; }

        [Display(Name = "Age")]
        [Required]
        [Range(0, 200)]
        public byte? Age { get; set; }
    }
}
