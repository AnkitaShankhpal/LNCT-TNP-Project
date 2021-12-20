using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCT_TNP_Project.DTO
{
    public class StudentSSCDTO
    {
        public int Id { get; set; }
        public string Percentage { get; set; }
        public string SchoolName { get; set; }
        public string Board { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<System.DateTime> YOP { get; set; }
    }
}