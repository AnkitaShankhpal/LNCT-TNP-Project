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
    
    public partial class TblCourse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblCourse()
        {
            this.TblStudentProfiles = new HashSet<TblStudentProfile>();
            this.TblStudentAcademics = new HashSet<TblStudentAcademic>();
        }
    
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentProfile> TblStudentProfiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentAcademic> TblStudentAcademics { get; set; }
    }
}
