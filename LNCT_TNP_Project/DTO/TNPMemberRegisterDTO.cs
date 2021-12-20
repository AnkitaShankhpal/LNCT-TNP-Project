using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LNCT_TNP_Project.Models
{
    public class TNPMemberRegisterDTO
    {
        public int TNPID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}