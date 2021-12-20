using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LNCT_TNP_Project.Models
{
    public class StudentLoginDTO
    {
        [Required(ErrorMessage = "Enter your EnrollmentNo")]
        public string EnrollmentNo { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
    }
}