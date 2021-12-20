using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCT_TNP_Project.DTO
{
    public class StudentAcademicDTO
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public string SSC_Percentage { get; set; }
        public string SSC_SchoolName { get; set; }
        public string SSC_Board { get; set; }
        public string SSC_YOP { get; set; }
        public string HSC_Percentage { get; set; }
        public string HSC_SchoolName { get; set; }
        public string HSC_Board { get; set; }
        public string HSC_YOP { get; set; }
        public string Diploma_Percentage { get; set; }
        public string Diploma_YOP { get; set; }
        public string UG_Percentage { get; set; }
        public string UG_YOP { get; set; }
        public string UG_Back { get; set; }
        public string UG_YearGap { get; set; }
        public string PG_Percentage { get; set; }
        public string PG_YOP { get; set; }
        public string PG_Back { get; set; }
        public string PG_YearGap { get; set; }
        public int DepartmentID { get; set; }
        public int CourseID { get; set; }
        public int BranchID { get; set; }
    }
}