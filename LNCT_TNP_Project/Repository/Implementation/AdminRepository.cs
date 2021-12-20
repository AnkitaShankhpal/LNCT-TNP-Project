using LNCT_TNP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Data.Entity;

namespace LNCT_TNP_Project.Repository.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private LNCT_TNP_DBEntities context;

        public AdminRepository()
        {
            context = new LNCT_TNP_DBEntities();
        }

        public void AddStudent(TblStudentRegister model)
        {
            context.TblStudentRegisters.Add(model);
            context.SaveChanges();
        }

        public void AddTNP(TblTNPMemberRegister tnpModel)
        {
            context.TblTNPMemberRegisters.Add(tnpModel);
            context.SaveChanges();
        }

        public TblStudentRegister Delete(int id)
        {
            var delt = context.TblStudentRegisters.FirstOrDefault(x => x.StudentID == id);
          
            if (delt != null)
            {
                context.Entry(delt).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return delt;
        }

        public TblTNPMemberRegister DeleteTNP(int id)
        {
            var tnpDelete = context.TblTNPMemberRegisters.FirstOrDefault(x => x.TNPID == id);
            if (tnpDelete != null)
            {
                context.TblTNPMemberRegisters.Remove(tnpDelete);
                context.SaveChanges();
            }
            return tnpDelete;
        }

        public List<TblStudentRegister> GetAllStudent()
        {
            return context.TblStudentRegisters.OrderBy(ord => ord.CreatedOn).ToList();
        }

        public List<TblTNPMemberRegister> GetAllTNP()
        {
            return context.TblTNPMemberRegisters.ToList();
        }

        public TblStudentRegister GetStudent(int id)
        {
            var result = context.TblStudentRegisters.FirstOrDefault(x => x.StudentID == id);
            return result;
        }

        public TblTNPMemberRegister GetTNPDetail(int id)
        {
            var result = context.TblTNPMemberRegisters.FirstOrDefault(x => x.TNPID == id);
            return result;
        }

        public bool Login(TblAdmin model)
        {
            bool isVaild = context.TblAdmins.Any(x => x.EmailAddress == model.EmailAddress && x.Password == model.Password);
            if (isVaild)
            {
                FormsAuthentication.SetAuthCookie(model.EmailAddress, false);
                return isVaild;
            }

            return isVaild;
        }

        public void Logout() {

            FormsAuthentication.SignOut();
        }

        public bool UpdateStudent(int id, TblStudentRegister model)
        {
            var student = context.TblStudentRegisters.FirstOrDefault(x => x.StudentID == id);
            if (student != null) {
                student.Name = model.Name;
                student.EnrollmentNo = model.EnrollmentNo;
                student.Password = model.Password;
                student.StudentID = model.StudentID;
                student.ModifiedOn = DateTime.Now;
            }
            
            
            context.SaveChanges();
            return true;
        }

        public bool UpdateTNP(TblTNPMemberRegister tnpModel)
        {
            var tnp = context.TblTNPMemberRegisters.FirstOrDefault(x=>x.TNPID == tnpModel.TNPID);
            if (tnp != null) {
                tnp.TNPID = tnpModel.TNPID;
                tnp.Name = tnpModel.Name;
                tnp.EmailID = tnpModel.EmailID;
                tnp.Password = tnpModel.Password;
                tnp.Department = tnpModel.Department;
                tnp.ModifiedOn = DateTime.Now;

                context.Entry(tnp).State = EntityState.Modified;
                context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}