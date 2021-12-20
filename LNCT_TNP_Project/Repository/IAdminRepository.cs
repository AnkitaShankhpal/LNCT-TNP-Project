using LNCT_TNP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNCT_TNP_Project.Repository
{
     public interface IAdminRepository
    {
       
        bool Login(TblAdmin model);
        void Logout();

        void AddStudent(TblStudentRegister model);
        List<TblStudentRegister> GetAllStudent();
        TblStudentRegister GetStudent(int id);
        bool UpdateStudent(int id, TblStudentRegister model);
        TblStudentRegister Delete(int id);
        void AddTNP(TblTNPMemberRegister tnpModel);
        List<TblTNPMemberRegister> GetAllTNP();
        TblTNPMemberRegister GetTNPDetail(int id);
        bool UpdateTNP(TblTNPMemberRegister tnpModel);
        TblTNPMemberRegister DeleteTNP(int id);

    }
}
