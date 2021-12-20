using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCT_TNP_Project.Models
{
    public class StudentProfileDTO
    {
    
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string FatherName { get; set; }
        public string CurrentAddress { get; set; }
        public DateTime? DOB { get; set; }
        public string BranchName { get; set; }
        public string  DepartmentName { get; set; }
        public string CourseName { get; set; }
        public string EnrollmentNo { get; set; }
        public string Name { get; set; }
        public int StudentID { get; set; }
    }
}