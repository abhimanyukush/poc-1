using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace POC_Abhi.Model
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        public long Salary { get; set; }
        [Range(18,50)]
        public int Age { get; set; }
        public string Country { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
