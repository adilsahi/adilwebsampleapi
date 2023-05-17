using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domains.Models
{
    public class EmployeeFilterModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [RegularExpression("male|female|other", ErrorMessage = "The Gender must be either 'Male', 'Female' or 'Other' only.")]
        public string? Gender { get; set; }
    }
}
