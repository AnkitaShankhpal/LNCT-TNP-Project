using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCT_TNP_Project.Models
{
    public class AskQueryDTO
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Problem { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string EnrollmentNo { get; set; }
    }
}