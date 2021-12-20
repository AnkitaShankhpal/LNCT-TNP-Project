using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNCT_TNP_Project.DTO
{
    public class AdminDTO
    {
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please enter email")]
        //[EmailAddress(ErrorMessage = "Email is not valid")]
        public string EmailAddress { get; set; }

        //[Required(ErrorMessage = "Please enter passwoard")]
        public string Password { get; set; }
    }
}