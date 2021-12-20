using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LNCT_TNP_Project.Models
{
    public class StudentRegisterDTO
    {
        public int StudentID { get; set; }
        public string EnrollmentNo { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}