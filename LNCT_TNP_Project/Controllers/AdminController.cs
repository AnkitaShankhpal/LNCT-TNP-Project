
using LNCT_TNP_Project.DTO;
using LNCT_TNP_Project.Models;
using LNCT_TNP_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNCT_TNP_Project.Controllers
{
    public class AdminController : Controller
    {
        private IAdminServices _admServices;

        public AdminController(IAdminServices admServices)
        {
            _admServices = admServices;
        }
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminDTO model)
        {
            bool isvalid = _admServices.Login(model);

            if (isvalid)
            {
                return RedirectToAction("AdminHome", "Admin");
            }
            else
            {
                ModelState.AddModelError("Error", "Invalid EmailAddress and Password");
            }
            return View();

        }

        public ActionResult AdminHome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminHome(StudentRegisterDTO model, string addedData)
        {
            if (addedData != null)
            {
                TNPMemberRegisterDTO tnpModel = Newtonsoft.Json.JsonConvert.DeserializeObject<TNPMemberRegisterDTO>(addedData);
                _admServices.AddTNP(tnpModel);
                return Json(new { result = true, url = Url.Action("TNPIndex", "Admin") });
            }
            
             _admServices.AddStudent(model);
             return Json(new { result = true, url = Url.Action("StudentIndex", "Admin") });
            
        }

        public ActionResult StudentIndex()
        {
            var result = _admServices.GetAllStudent();
            return View(result);
        }

        public ActionResult TNPIndex()
        {
            var result = _admServices.GetAllTNP();
            return View(result);
        }

        public JsonResult StudentDetails(int id)
        {
            return Json(_admServices.GetStudent(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult TNPDetails(int id)
        {
            return Json(_admServices.GetTNP(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditStudent(string editableData)
        {
            StudentRegisterDTO model = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentRegisterDTO>(editableData);
            _admServices.UpdateStudent(model.StudentID, model);
            return Json(new { result = true, url = Url.Action("StudentIndex", "Admin") });
        }

        [HttpPost]
        public ActionResult EditTNP(string editableData)
        {
            TNPMemberRegisterDTO tnpModel = Newtonsoft.Json.JsonConvert.DeserializeObject<TNPMemberRegisterDTO>(editableData);
            _admServices.UpdateTNP(tnpModel);
            return Json(new { result = true, url = Url.Action("TNPIndex", "Admin") });
        }

        public ActionResult Logout()
        {
            _admServices.Logout();
            return RedirectToAction("Login");
        }

        public ActionResult Delete(int id)
        {
            StudentRegisterDTO result = new StudentRegisterDTO();
            result = _admServices.GetStudent(id);
            return View(result);
            
        }

        [HttpPost]
        public ActionResult Delete(int id, string confirmButton)
        {
            StudentRegisterDTO result = new StudentRegisterDTO();
            result = _admServices.Delete(id);
            //return View();
            //return Json(true,JsonRequestBehavior.AllowGet);
            return Json(new { result = true, url = Url.Action("StudentIndex", "Admin") });
        }

        public ActionResult DeleteTNP(int id)
        {
            TNPMemberRegisterDTO result = new TNPMemberRegisterDTO();
            result = _admServices.GetTNP(id);
            return View(result);

        }

        [HttpPost]
        public ActionResult DeleteTNP(int id, string confirmButton)
        {
            TNPMemberRegisterDTO result = new TNPMemberRegisterDTO();
            result = _admServices.DeleteTNP(id);

            return Json(new { result = true, url = Url.Action("TNPIndex", "Admin") });
        }

       
    }
}
