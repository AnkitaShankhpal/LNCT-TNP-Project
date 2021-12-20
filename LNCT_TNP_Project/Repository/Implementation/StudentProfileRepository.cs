using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using LNCT_TNP_Project.Models;

namespace LNCT_TNP_Project.Repository.Implementation
{
    public class StudentProfileRepository : IStudentProfileRepository
    {

        private LNCT_TNP_DBEntities context;

        public StudentProfileRepository()
        {
            context = new LNCT_TNP_DBEntities();
        }

        public void AddStudentProfile(TblStudentProfile model)
        {
            var addStud = context.TblStudentProfiles.FirstOrDefault(x => x.StudentID == model.StudentID);
            if (addStud == null)
            {
                context.TblStudentProfiles.Add(model);
                context.SaveChanges();
            }
            else if (addStud != null)
            {
                addStud.EmailId = model.EmailId;
                addStud.MobileNo = model.MobileNo;
                addStud.FatherName = model.FatherName;
                addStud.CurrentAddress = model.CurrentAddress;
                addStud.DOB = model.DOB;
                context.Entry(addStud).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
      
        }

        public void AddStudentAcademic(TblStudentAcademic acdmodel)
        {
            var addAcademic = context.TblStudentAcademics.FirstOrDefault(x => x.StudentID == acdmodel.StudentID);
            if (addAcademic == null)
            {
                context.TblStudentAcademics.Add(acdmodel);
                context.SaveChanges();
            }
            else if (addAcademic != null)
            {
                addAcademic.SSC_Percentage = acdmodel.SSC_Percentage;
                addAcademic.SSC_SchoolName = acdmodel.SSC_SchoolName;
                addAcademic.SSC_Board = acdmodel.SSC_Board;
                addAcademic.PG_YOP = acdmodel.PG_YOP;
                addAcademic.HSC_Percentage = acdmodel.HSC_Percentage;
                addAcademic.HSC_SchoolName = acdmodel.HSC_SchoolName;
                addAcademic.HSC_Board = acdmodel.HSC_Board;
                addAcademic.HSC_YOP = acdmodel.HSC_YOP;
                addAcademic.Diploma_Percentage = acdmodel.Diploma_Percentage;
                addAcademic.Diploma_YOP = acdmodel.Diploma_YOP;
                addAcademic.UG_Percentage = acdmodel.UG_Percentage;
                addAcademic.UG_YearGap = acdmodel.UG_YearGap;
                addAcademic.UG_YOP = acdmodel.UG_YOP;
                addAcademic.UG_Back = acdmodel.UG_Back;
                addAcademic.PG_Percentage = acdmodel.PG_Percentage;
                addAcademic.PG_YearGap = acdmodel.PG_YearGap;
                addAcademic.PG_YOP = acdmodel.PG_YOP;
                addAcademic.PG_Back = acdmodel.PG_Back;
                addAcademic.BranchID = acdmodel.BranchID;
                addAcademic.CourseID = acdmodel.CourseID;
                addAcademic.DepartmentID = acdmodel.DepartmentID;

                context.Entry(addAcademic).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TblStudentProfile Delete(int id)
        {
            TblStudentProfile model = context.TblStudentProfiles.FirstOrDefault(x => x.Id == id);
            if (model != null) {
                context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
           
            return model;
        }

        public void Edit(TblStudentProfile model)
        {
            //context.TblStudentProfiles.Add(model);
            context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

        }

        public List<TblStudentProfile> GetAllStudent()
        {
            return context.TblStudentProfiles.ToList();
        }

        public TblStudentProfile GetStudent(int id)
        {
            var result = context.TblStudentProfiles.FirstOrDefault(x => x.StudentID == id);
            return result;
        }

        public TblStudentAcademic GetStudentAcademic(int id)
        {
            var result = context.TblStudentAcademics.FirstOrDefault(x => x.StudentID == id);
            if (result != null) {
                return result;
            }
            return result;
        }

        public bool Login(TblStudentRegister model)
        {
            bool isVaild = context.TblStudentRegisters.Any(x => x.EnrollmentNo == model.EnrollmentNo && x.Password == model.Password);
            if (isVaild)
            {

                FormsAuthentication.SetAuthCookie(model.EnrollmentNo, false);
                return isVaild;
            }

            return isVaild;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public TblStudentRegister GetRegisterStudent(string rollNo)
        {
            var result = context.TblStudentRegisters.FirstOrDefault(x => x.EnrollmentNo == rollNo);
            return result;
        }

        public void ChangePassword(TblStudentRegister model)
        {
            var chanpass = context.TblStudentRegisters.FirstOrDefault(x => x.StudentID == model.StudentID);
            if (chanpass != null) {
                chanpass.StudentID = model.StudentID;
                chanpass.Password = model.Password;
                context.Entry(chanpass).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void AskQuery(AskQuery model)
        {
            if (model != null)
            {
                context.AskQueries.Add(model);
                context.SaveChanges();
            }
        }

        public List<TblNewPost> Notice()
        {
           return context.TblNewPosts.OrderByDescending(ord => ord.CreatedOn).ToList();
        }
    }
}