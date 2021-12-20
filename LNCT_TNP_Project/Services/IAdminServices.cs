using LNCT_TNP_Project.DTO;
using LNCT_TNP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNCT_TNP_Project.Services
{
    public interface IAdminServices
    {
       
        bool Login(AdminDTO model);
        void Logout();
        void AddStudent(StudentRegisterDTO model);
        void AddTNP(TNPMemberRegisterDTO tnpModel);
        List<StudentRegisterDTO> GetAllStudent();
        List<TNPMemberRegisterDTO> GetAllTNP();
        StudentRegisterDTO GetStudent(int id);
        TNPMemberRegisterDTO GetTNP(int id);
        bool UpdateStudent(int id,StudentRegisterDTO model);
        bool UpdateTNP(TNPMemberRegisterDTO tnpModel);
        StudentRegisterDTO Delete(int id);
        TNPMemberRegisterDTO DeleteTNP(int id);
      
    }
}
