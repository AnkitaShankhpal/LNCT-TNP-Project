using LNCT_TNP_Project.DTO;
using LNCT_TNP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNCT_TNP_Project.Services
{
    public interface IStudentProfileServices
    {
        void AddStudentProfile(StudentProfileDTO model);
        void AddStudentAcademics(StudentAcademicDTO acdmodel);
        void ChangePassword(StudentRegisterDTO model);
        List<StudentProfileDTO> GetAllStudent();
        StudentProfileDTO GetStudent(int id);
        StudentAcademicDTO GetStudentAcademic(int id);
        StudentRegisterDTO GetRegisterStudent(string rollNo);
        void Edit(StudentProfileDTO model);
        StudentProfileDTO Delete(int id);
        void AskQuery(AskQueryDTO model);
        List<NewPostResponseDTO> Notice();
        bool Login(StudentRegisterDTO model);
        void Logout();
       
    }
}
