using LNCT_TNP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNCT_TNP_Project.Repository
{
    public interface IStudentProfileRepository
    {
        void AddStudentProfile(TblStudentProfile model);
        void AddStudentAcademic(TblStudentAcademic acdmodel);
        void ChangePassword(TblStudentRegister model);
        List<TblStudentProfile> GetAllStudent();
        TblStudentProfile GetStudent(int id);
        TblStudentAcademic GetStudentAcademic(int id);
        TblStudentRegister GetRegisterStudent(string rollNo);
        void Edit(TblStudentProfile model);
        TblStudentProfile Delete(int id);
        void AskQuery(AskQuery model);
        List<TblNewPost> Notice();
        bool Login(TblStudentRegister model);
        void Logout();
    }
}
