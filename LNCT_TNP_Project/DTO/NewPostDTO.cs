using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCT_TNP_Project.Models
{
    public class NewPostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
        public HttpPostedFileBase PostFile { get; set; }

    }
}