//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LNCT_TNP_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblStudentHSC
    {
        public int Id { get; set; }
        public string Percentage { get; set; }
        public string SchoolName { get; set; }
        public string Board { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<System.DateTime> YOP { get; set; }
    
        public virtual TblStudentRegister TblStudentRegister { get; set; }
    }
}
