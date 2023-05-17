using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domains.Models
{
    public class EmployeeModel
    {
        public int? EmployeeId { get; set; }

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
