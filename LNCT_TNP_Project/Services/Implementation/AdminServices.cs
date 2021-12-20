using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LNCT_TNP_Project.DTO;
using LNCT_TNP_Project.Models;
using LNCT_TNP_Project.Repository;

namespace LNCT_TNP_Project.Services.Implementation
{
    public class AdminServices : IAdminServices
    {
        private IAdminRepository _admRepository;

        public AdminServices(IAdminRepository admRepository)
        {
            _admRepository = admRepository;

        }

        public void AddStudent(StudentRegisterDTO model)
        {
            TblStudentRegister str = new TblStudentRegister();
            str.EnrollmentNo = model.EnrollmentNo;
            str.Name = model.Name;
            str.Password = model.Password;
            str.CreatedOn = DateTime.Now;
            _admRepository.AddStudent(str);
        }

        public void AddTNP(TNPMemberRegisterDTO tnpModel)
        {
            TblTNPMemberRegister tnp = new TblTNPMemberRegister();
            //tnp.TNPID = tnpModel.TNPID;
            tnp.EmailID = tnpModel.EmailID;
            tnp.Name = tnpModel.Name;
            tnp.Password = tnpModel.Password;
            tnp.Department = tnpModel.Department;
            tnp.CreatedOn = DateTime.Now;
            tnp.ModifiedOn = DateTime.Now;
            _admRepository.AddTNP(tnp);
        }

        public StudentRegisterDTO Delete(int id)
        {
            StudentRegisterDTO stdDelete = new StudentRegisterDTO();
            var result = _admRepository.Delete(id);
            stdDelete.StudentID = result.StudentID;
            stdDelete.EnrollmentNo = result.EnrollmentNo;
            stdDelete.Name = result.Name;
            stdDelete.Password = result.Password;
            

            return stdDelete;
        }

        public TNPMemberRegisterDTO DeleteTNP(int id)
        {
            TNPMemberRegisterDTO tnpDelete = new TNPMemberRegisterDTO();
            var result = _admRepository.DeleteTNP(id);
            tnpDelete.TNPID = result.TNPID;
            tnpDelete.Name = result.Name;
            tnpDelete.EmailID = result.EmailID;
            tnpDelete.Password = result.Password;
            tnpDelete.Department = result.Department;

            return tnpDelete;
        }

        public List<StudentRegisterDTO> GetAllStudent()
        {
            List<StudentRegisterDTO> list = new List<StudentRegisterDTO>();
            var result = _admRepository.GetAllStudent();
            foreach (var item in result)
            {
                StudentRegisterDTO str = new StudentRegisterDTO();
                str.StudentID = item.StudentID;
                str.Name = item.Name;
                str.EnrollmentNo = item.EnrollmentNo;
                str.Password = item.Password;
                list.Add(str);
            }
            return list;
        }

        public List<TNPMemberRegisterDTO> GetAllTNP()
        {
            List<TNPMemberRegisterDTO> list = new List<TNPMemberRegisterDTO>();
            var result = _admRepository.GetAllTNP();
            foreach (var item in result)
            {
                TNPMemberRegisterDTO tnp = new TNPMemberRegisterDTO();
                tnp.TNPID = item.TNPID;
                tnp.EmailID = item.EmailID;
                tnp.Name = item.Name;
                tnp.Password = item.Password;
                tnp.Department = item.Department;
                tnp.CreatedOn = item.CreatedOn;
                tnp.ModifiedOn = item.ModifiedOn;

                list.Add(tnp);
            }
            return list;
        }

        public StudentRegisterDTO GetStudent(int id)
        {
            StudentRegisterDTO str = new StudentRegisterDTO();
            var result = _admRepository.GetStudent(id);
            str.StudentID = result.StudentID;
            str.Name = result.Name;
            str.EnrollmentNo = result.EnrollmentNo;
            str.Password = result.Password;

            return str;
        }

        public TNPMemberRegisterDTO GetTNP(int id)
        {
            TNPMemberRegisterDTO tnp = new TNPMemberRegisterDTO();
            var result = _admRepository.GetTNPDetail(id);
            tnp.TNPID = result.TNPID;
            tnp.EmailID = result.EmailID;
            tnp.Name = result.Name;
            tnp.Password = result.Password;

            return tnp;
        }

        public bool Login(AdminDTO model)
        {
            TblAdmin obj = new TblAdmin();
            obj.EmailAddress = model.EmailAddress;
            obj.Password = model.Password;
            bool isvalid = _admRepository.Login(obj);
            return isvalid;
        }

        public void Logout()
        {
            _admRepository.Logout();
        }

        public bool UpdateStudent(int id, StudentRegisterDTO model)
        {
            TblStudentRegister str = new TblStudentRegister();

            str.StudentID = model.StudentID;
            str.Name = model.Name;
            str.EnrollmentNo = model.EnrollmentNo;
            str.Password = model.Password;
            return (_admRepository.UpdateStudent(str.StudentID, str));
        }

        public bool UpdateTNP(TNPMemberRegisterDTO tnpModel)
        {
            TblTNPMemberRegister tnp = new TblTNPMemberRegister();

            tnp.TNPID = tnpModel.TNPID;
            tnp.Name = tnpModel.Name;
            tnp.Password = tnpModel.Password;
            tnp.Department = tnpModel.Department;
            tnp.EmailID = tnpModel.EmailID;
            tnp.ModifiedOn = DateTime.Now;

            return (_admRepository.UpdateTNP(tnp));
        }
    }
}