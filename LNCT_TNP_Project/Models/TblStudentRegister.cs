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
    
    public partial class TblStudentRegister
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblStudentRegister()
        {
            this.TblStudentDiplomas = new HashSet<TblStudentDiploma>();
            this.TblStudentHSCs = new HashSet<TblStudentHSC>();
            this.TblStudentPostGraduates = new HashSet<TblStudentPostGraduate>();
            this.TblStudentProfiles = new HashSet<TblStudentProfile>();
            this.TblStudentSSCs = new HashSet<TblStudentSSC>();
            this.TblStudentUndertGraduates = new HashSet<TblStudentUndertGraduate>();
            this.TblStudentAcademics = new HashSet<TblStudentAcademic>();
            this.AskQueries = new HashSet<AskQuery>();
        }
    
        public int StudentID { get; set; }
        public string EnrollmentNo { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentDiploma> TblStudentDiplomas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentHSC> TblStudentHSCs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentPostGraduate> TblStudentPostGraduates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentProfile> TblStudentProfiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentSSC> TblStudentSSCs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentUndertGraduate> TblStudentUndertGraduates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentAcademic> TblStudentAcademics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AskQuery> AskQueries { get; set; }
    }
}
