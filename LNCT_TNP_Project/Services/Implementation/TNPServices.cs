using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using LNCT_TNP_Project.DTO;
using LNCT_TNP_Project.Models;
using LNCT_TNP_Project.Repository;

namespace LNCT_TNP_Project.Services.Implementation
{
    public class TNPServices : ITNPServices
    {
        private ITNPRepository _tnpRepository;
       

        public TNPServices(ITNPRepository tnpRepository)
        {
            _tnpRepository = tnpRepository;
        }

        public void ChangePassword(TNPMemberRegisterDTO tnpModel)
        {
            TblTNPMemberRegister obj = new TblTNPMemberRegister();
            obj.TNPID = tnpModel.TNPID;
            obj.Password = tnpModel.Password;
            _tnpRepository.ChangePasswordTnp(obj);
        }

        public List<StudentProfileDTO> GetAllStudent()
        {
            List<StudentProfileDTO> list = new List<StudentProfileDTO>();
            var result = _tnpRepository.GetAllStudent();

            foreach (var item in result)
            {
                StudentProfileDTO stp = new StudentProfileDTO();
                stp.Id = item.Id;
                stp.EmailId = item.EmailId;
                stp.MobileNo = item.MobileNo;
                stp.CurrentAddress = item.CurrentAddress;
                stp.FatherName = item.FatherName;
                stp.DOB = item.DOB;
                stp.StudentID = item.TblStudentRegister.StudentID;
                stp.EnrollmentNo = item.TblStudentRegister.EnrollmentNo;
                stp.Name = item.TblStudentRegister.Name;
                list.Add(stp);

            }
            return list;
        }

        public List<AskQueryDTO> ViewQuery()
        {
            List<AskQueryDTO> list = new List<AskQueryDTO>();
            var result = _tnpRepository.ViewQuery();
            foreach (var item in result)
            {
                AskQueryDTO ask = new AskQueryDTO();
                ask.Id = item.Id;
                ask.Subject = item.SubjectOfQuery;
                ask.Problem = item.Problem;
                ask.StudentID = item.TblStudentRegister.StudentID;
                ask.StudentName = item.TblStudentRegister.Name;
                ask.EnrollmentNo = item.TblStudentRegister.EnrollmentNo;
                list.Add(ask);
               
            }
            return list;
        }

        public TNPMemberRegisterDTO GetTNP(string email)
        {
            TNPMemberRegisterDTO tnp = new TNPMemberRegisterDTO();
            var result = _tnpRepository.GetTNP(email);
            if (result != null)
            {
                tnp.TNPID = result.TNPID;
                tnp.Name = result.Name;
                tnp.EmailID = result.EmailID;
                tnp.Password = result.Password;
                tnp.Department = result.Department;

                return tnp;
            }
            return tnp;
        }

        public bool LoginTnp(TNPMemberRegisterDTO model)
        {
            TblTNPMemberRegister tnp = new TblTNPMemberRegister();
            tnp.TNPID = model.TNPID;
            tnp.EmailID = model.EmailID;
            tnp.Name = model.Name;
            tnp.Password = model.Password;
            tnp.Department = model.Department;
            bool isValid = _tnpRepository.LoginTnp(tnp);
            return isValid;

        }
        
        public void LogoutTnp()
        {
            _tnpRepository.LogoutTnp();
        }

        public void NewPost(NewPostDTO model)
        {
            TblNewPost np = new TblNewPost();
            np.Id = model.Id;
            np.Title = model.Title;
            np.Post = model.Post;
            np.CreatedOn = DateTime.Now;
            np.PostFile = SaveToPhysicalLocation(model.PostFile);
            _tnpRepository.NewPost(np);
        }

        private string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {   
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Project_Files"), fileName);
                file.SaveAs(path);
                return fileName;
            }
            return string.Empty;
        }

       

    }
}