using LNCT_TNP_Project.Repository;
using LNCT_TNP_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LNCT_TNP_Project.Models;
using LNCT_TNP_Project.DTO;
using LNCT_TNP_Project.CustomFilter;

namespace LNCT_TNP_Project.Controllers
{
    [ExceptionHandler]
    public class StudentProfileController : Controller
    {
        //Implemented Dependency Injection.
        private IStudentProfileServices _stdpServices;
        private IAdminServices _admServices;

        public StudentProfileController(IStudentProfileServices StdpServices, IAdminServices _AdmServices)
        {
            _stdpServices = StdpServices;
            _admServices = _AdmServices;
        }


        [HttpPost]
        public ActionResult Std_Login(StudentRegisterDTO model)
        {

            bool isvalid = _stdpServices.Login(model);
            if (isvalid)
            {
                var result = _stdpServices.GetRegisterStudent(model.EnrollmentNo);
                Session["EnrollmentNo"] = result.EnrollmentNo;
                Session["Name"] = result.Name;
                Session["StudentID"] = result.StudentID;
                Session["Password"] = result.StudentID;
                return RedirectToAction("Notice_Board", "StudentProfile");
            }
            else
            {
                ModelState.AddModelError("Error", "Invalid EmailAddress and Password");
                TempData["message"] = "Invalid EmailAddress and Password";
                return RedirectToAction("Index", "Home");
            }
            
        }
        
        public ActionResult Notice_Board()
        {
            if (Session["StudentID"] != null)
            {
                return View(_stdpServices.Notice());
            }
            return RedirectToAction("Index", "Home");
           
        }

        public ActionResult AskQuery()
        {
            if (Session["StudentID"] != null)
            {
               
                return View();

            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult AskQuery(AskQueryDTO model)
        {
            model.StudentID = model.StudentID == 0 ? Convert.ToInt32(Session["StudentID"]) : model.StudentID;
            _stdpServices.AskQuery(model);
            return View();
        }

        public ActionResult Change_Password()
        {
            if (Session["Password"] != null)
            {
                string rollNo = Convert.ToString(Session["EnrollmentNo"]);
                var result = _stdpServices.GetRegisterStudent(rollNo);
                return View(result);
            }
            else {
                return RedirectToAction("Index", "Home");
            }
          
        }

        [HttpPost]
        public ActionResult Change_Password(StudentRegisterDTO model)
        {
            _stdpServices.ChangePassword(model);
            //return RedirectToAction("Index");
            return RedirectToAction("Notice_Board");
        }

        // GET: StudentProfile
        public ActionResult Index()
        {
             return View(_stdpServices.GetAllStudent());  
        }

        // GET: StudentProfile/Details
        public JsonResult GetStudentDetails(int id)
        {
            return Json(_stdpServices.GetStudent(id), JsonRequestBehavior.AllowGet);
        }

        // GET: StudentProfile/Details
        public JsonResult GetStudenAcademictDetails(int id)
        {
            var result = _stdpServices.GetStudentAcademic(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: StudentProfile/CreateOREdit
        public ActionResult Create()
        {
            if (Session["StudentID"] != null)
            {
                int id = Convert.ToInt32(Session["StudentID"]);
                var result = _stdpServices.GetStudent(id);
                return View(result);
            }
            else{

                return RedirectToAction("Index", "Home");
            }
          
        }

        // POST: StudentProfile/CreateOREdit
        [HttpPost]
        public ActionResult Create(StudentProfileDTO model)
        {
                model.StudentID = model.StudentID == 0 ? Convert.ToInt32(Session["StudentID"]) : model.StudentID;
                _stdpServices.AddStudentProfile(model);
            //return RedirectToAction("Index");
             return View();
               
        }

        // GET: StudentProfile/CreateAcademicOREdit
        public ActionResult CreateAcademic()
        {
            if (Session["StudentID"] != null)
            {
                int id = Convert.ToInt32(Session["StudentID"]);
                var result = _stdpServices.GetStudentAcademic(id);
                return Json(_stdpServices.GetStudentAcademic(id), JsonRequestBehavior.AllowGet);
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        
        }

        // POST: StudentProfile/CreateAcademicOREdit
        [HttpPost]
        public ActionResult CreateAcademic(string editableData)
        {
            StudentAcademicDTO model= Newtonsoft.Json.JsonConvert.DeserializeObject<StudentAcademicDTO>(editableData);
            model.StudentID = model.StudentID == 0 ? Convert.ToInt32(Session["StudentID"]) : model.StudentID;
            _stdpServices.AddStudentAcademics(model);
            return Json(new { result = true});
        }


        // GET: StudentProfile/Delete/5
        public ActionResult StdDelete(int id)
        {
            StudentProfileDTO result = new StudentProfileDTO();
            result = _stdpServices.GetStudent(id);
            return View(result);
           
        }

        // POST: StudentProfile/Delete/5
        [HttpPost]
        public ActionResult StdDelete(int id, string confirmButton)
        {
             StudentProfileDTO result = new StudentProfileDTO();
             result = _stdpServices.Delete(id);

            //return Json(true, JsonRequestBehavior.AllowGet);
            return Json(new { result = true, url = Url.Action("Index", "StudentProfile") });
            //return View("Index");
        }

        public ActionResult Std_Logout()
        {
            if (Session["StudentID"] != null)
            {
                _stdpServices.Logout();
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }

        }
    }
}
