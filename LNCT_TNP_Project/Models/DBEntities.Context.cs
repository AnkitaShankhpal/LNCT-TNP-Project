﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LNCT_TNP_DBEntities : DbContext
    {
        public LNCT_TNP_DBEntities()
            : base("name=LNCT_TNP_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblBranch> TblBranches { get; set; }
        public virtual DbSet<TblCourse> TblCourses { get; set; }
        public virtual DbSet<TblDepartment> TblDepartments { get; set; }
        public virtual DbSet<TblStudentDiploma> TblStudentDiplomas { get; set; }
        public virtual DbSet<TblStudentHSC> TblStudentHSCs { get; set; }
        public virtual DbSet<TblStudentPostGraduate> TblStudentPostGraduates { get; set; }
        public virtual DbSet<TblStudentProfile> TblStudentProfiles { get; set; }
        public virtual DbSet<TblStudentRegister> TblStudentRegisters { get; set; }
        public virtual DbSet<TblStudentSSC> TblStudentSSCs { get; set; }
        public virtual DbSet<TblStudentUndertGraduate> TblStudentUndertGraduates { get; set; }
        public virtual DbSet<TblTNPMemberProfile> TblTNPMemberProfiles { get; set; }
        public virtual DbSet<TblAdmin> TblAdmins { get; set; }
        public virtual DbSet<TblStudentAcademic> TblStudentAcademics { get; set; }
        public virtual DbSet<TblTNPMemberRegister> TblTNPMemberRegisters { get; set; }
        public virtual DbSet<ExceptionLogger> ExceptionLoggers { get; set; }
        public virtual DbSet<TblNewPost> TblNewPosts { get; set; }
        public virtual DbSet<AskQuery> AskQueries { get; set; }
    }
}
