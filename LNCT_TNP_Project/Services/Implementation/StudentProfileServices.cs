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
    public class StudentProfileServices : IStudentProfileServices
    {
        //Implemented Dependency Injection.
        private IStudentProfileRepository _stdpRepository;

        public StudentProfileServices(IStudentProfileRepository StdpRepository)
        {
            _stdpRepository = StdpRepository;
        }


        public void AddStudentProfile(StudentProfileDTO model)
        {
           
            TblStudentProfile stp = new TblStudentProfile();

                stp.StudentID = model.StudentID;
                stp.Id = model.Id;
                stp.EmailId = model.EmailId;
                stp.MobileNo = model.MobileNo;
                stp.FatherName = model.FatherName;
                stp.CurrentAddress = model.CurrentAddress;
                stp.DOB = model.DOB;
               _stdpRepository.AddStudentProfile(stp);

        }

        public void AddStudentAcademics(StudentAcademicDTO acdmodel)
        {
            TblStudentAcademic addAcademic = new TblStudentAcademic();

            addAcademic.StudentID = acdmodel.StudentID;
            addAcademic.SSC_Percentage = acdmodel.SSC_Percentage;
            addAcademic.SSC_SchoolName = acdmodel.SSC_SchoolName;
            addAcademic.SSC_Board = acdmodel.SSC_Board;
            addAcademic.SSC_YOP = acdmodel.SSC_YOP;
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

            _stdpRepository.AddStudentAcademic(addAcademic);
        }

        public StudentProfileDTO Delete(int id)
        {
            StudentProfileDTO stpd = new StudentProfileDTO();
            var result = _stdpRepository.Delete(id);
            if (result != null)
            {
                stpd.Id = result.Id;
                return stpd;
            }
            return null;
        }

        public void Edit(StudentProfileDTO model)
        {
            TblStudentProfile stp = new TblStudentProfile();
            //stp.StudentID = model.StudentID;
            _stdpRepository.Edit(stp);
        }

        public List<StudentProfileDTO> GetAllStudent()
        {
            List<StudentProfileDTO> list = new List<StudentProfileDTO>();
            var result = _stdpRepository.GetAllStudent();
           
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

        public StudentRegisterDTO GetRegisterStudent(string rollNo)
        {
            StudentRegisterDTO stpr = new StudentRegisterDTO();
            var result = _stdpRepository.GetRegisterStudent(rollNo);
            stpr.StudentID = result.StudentID;
            stpr.EnrollmentNo = result.EnrollmentNo;
            stpr.Name = result.Name;
            stpr.Password = result.Password;

            return stpr;
        }

        public StudentProfileDTO GetStudent(int id)
        {
            
            StudentProfileDTO stpd = new StudentProfileDTO();
            var result =  _stdpRepository.GetStudent(id);
            if (result != null)
            {
                stpd.Id = result.Id;
                stpd.EmailId = result.EmailId;
                stpd.DOB = result.DOB;
                stpd.MobileNo = result.MobileNo;
                stpd.CurrentAddress = result.CurrentAddress;
                stpd.FatherName = result.FatherName;
                //stpd.DepartmentName = result.TblDepartment.DepartmentName;
                //stpd.CourseName = result.TblCourse.CourseName;
                //stpd.BranchName = result.TblBranch.BranchName;
                stpd.StudentID = result.TblStudentRegister.StudentID;
                stpd.EnrollmentNo = result.TblStudentRegister.EnrollmentNo;
                stpd.Name = result.TblStudentRegister.Name;

                return stpd;
            }
            
                return null;
            

        }

        public StudentAcademicDTO GetStudentAcademic(int id)
        {
            StudentAcademicDTO getAcademic = new StudentAcademicDTO();
            var result = _stdpRepository.GetStudentAcademic(id);
            if (result != null)
            {
                getAcademic.SSC_Percentage = result.SSC_Percentage;
                getAcademic.SSC_SchoolName = result.SSC_SchoolName;
                getAcademic.SSC_Board = result.SSC_Board;
                getAcademic.SSC_YOP = result.SSC_YOP;
                getAcademic.HSC_Percentage = result.HSC_Percentage;
                getAcademic.HSC_SchoolName = result.HSC_SchoolName;
                getAcademic.HSC_Board = result.HSC_Board;
                getAcademic.HSC_YOP = result.HSC_YOP;
                getAcademic.Diploma_Percentage = result.Diploma_Percentage;
                getAcademic.Diploma_YOP = result.Diploma_YOP;
                getAcademic.UG_Percentage = result.UG_Percentage;
                getAcademic.UG_YearGap = result.UG_YearGap;
                getAcademic.UG_YOP = result.UG_YOP;
                getAcademic.UG_Back = result.UG_Back;
                getAcademic.PG_Percentage = result.PG_Percentage;
                getAcademic.PG_YearGap = result.PG_YearGap;
                getAcademic.PG_YOP = result.PG_YOP;
                getAcademic.PG_Back = result.PG_Back;

                return getAcademic;
            }

            return null;
        }

        public bool Login(StudentRegisterDTO model)
        {
            TblStudentRegister obj = new TblStudentRegister();
            obj.StudentID = model.StudentID;
            obj.EnrollmentNo = model.EnrollmentNo;
            obj.Password = model.Password;
            bool isvalid = _stdpRepository.Login(obj);
            return isvalid;
        }

        public void Logout()
        {
            _stdpRepository.Logout();
        }

        public void ChangePassword(StudentRegisterDTO model)
        {
            TblStudentRegister obj = new TblStudentRegister();
            obj.StudentID = model.StudentID;
            obj.Password = model.Password;
           _stdpRepository.ChangePassword(obj);
           
        }

        public void AskQuery(AskQueryDTO model)
        {
            AskQuery ask = new AskQuery();
            ask.Id = model.Id;
            ask.SubjectOfQuery = model.Subject;
            ask.Problem = model.Problem;
            ask.StudentID = model.StudentID;
            ask.CreatedOn = DateTime.Now;

            _stdpRepository.AskQuery(ask);
        }

        public List<NewPostResponseDTO> Notice()
        {
            List<NewPostResponseDTO> list = new List<NewPostResponseDTO>();
            var result = _stdpRepository.Notice();
            foreach (var item in result)
            {
                NewPostResponseDTO npd = new NewPostResponseDTO();
                npd.Id = item.Id;
                npd.Post = item.Post;
                npd.Title = item.Title;
                npd.CreatedOn = item.CreatedOn;
                npd.PostFile = SaveToPhysicalLocation(item.PostFile);
                list.Add(npd);
            }
            return list;
        }

        private string SaveToPhysicalLocation(string file)
        {
            if (file.Length > 0)
            {
                var fileName = Path.GetFileName(file);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Project_Files"), fileName);
      
                return fileName;
            }
            return string.Empty;
        }


    }
}