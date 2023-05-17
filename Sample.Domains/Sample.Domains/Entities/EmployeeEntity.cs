using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Sample.Domains.Entities
{
    public class EmployeeEntity
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public float Age { get; set; }

        [Required]
        [RegularExpression("male|female|other", ErrorMessage = "The Gender must be either 'Male', 'Female' or 'Other' only.")]
        public string Gender { get; set; }

        [NotMapped]
        public string FullName { get => $"{FirstName} {LastName}"; }
    }
}