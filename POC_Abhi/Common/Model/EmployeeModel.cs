using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Model
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        public long Salary { get; set; }
        [Range(18, 50,ErrorMessage ="Age should be between 18 and 50")]
        public int Age { get; set; }
        public string Country { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
    }
}
