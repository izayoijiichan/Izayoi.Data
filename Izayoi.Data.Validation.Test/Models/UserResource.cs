// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Validation.Test.Models
// @Class     : UserResource
// ----------------------------------------------------------------------
namespace Izayoi.Data.Validation.Test.Models
{
    using Izayoi.Data.Validation.Test.Resources;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserResource
    {
        [Display(Name = nameof(Models.User_Id), ResourceType = typeof(Models))]
        [Required(ErrorMessageResourceName = nameof(DataAnnotations.RequiredAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
        public int? Id { get; set; }

        [Display(Name = nameof(Models.User_Name), ResourceType = typeof(Models))]
        [Required(ErrorMessageResourceName = nameof(DataAnnotations.RequiredAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
        [StringLength(10, ErrorMessageResourceName = nameof(DataAnnotations.StringLengthAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
        public string? Name { get; set; }

        [Display(Name = nameof(Models.User_Age), ResourceType = typeof(Models))]
        [Required(ErrorMessageResourceName = nameof(DataAnnotations.RequiredAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
        [Range(0, 200, ErrorMessageResourceName = nameof(DataAnnotations.RangeAttribute_ValidationError), ErrorMessageResourceType = typeof(DataAnnotations))]
        public byte? Age { get; set; }
    }
}
