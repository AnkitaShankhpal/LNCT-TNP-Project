using LNCT_TNP_Project.CustomFilter;
using LNCT_TNP_Project.DTO;
using LNCT_TNP_Project.Models;
using LNCT_TNP_Project.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNCT_TNP_Project.Controllers
{
    [ExceptionHandler]
    public class TNPController : Controller
    {
        private ITNPServices _tnpServices;

        public TNPController(ITNPServices tnpServices)
        {
            _tnpServices = tnpServices;
        }
        
        [HttpPost]
        public ActionResult LoginTnp(TNPMemberRegisterDTO tnpModel)
        {
            bool isValid = _tnpServices.LoginTnp(tnpModel);
            if (isValid)
            {
                var result = _tnpServices.GetTNP(tnpModel.EmailID);
                Session["EmailID"] = result.EmailID;
                //Session["Password"] = result.Password;
                Session["TNPID"] = result.TNPID;
                Session["Name"] = result.Name;
                Session["Department"] = result.Department;
                return RedirectToAction("TNP_Notice_Board", "TNP");
            }
            else
            {
                ModelState.AddModelError("Error", "Invalid EmailAddress and Password");
                TempData["message"] = "Invalid EmailAddress and Password";
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult TnpChangePassword()
        {
            if (Session["EmailID"] != null)
            {
                string email = Convert.ToString(Session["EmailID"]);
                var result = _tnpServices.GetTNP(email);
                return View(result);
            }
            else
            {
                return RedirectToAction("LoginTnp");
            }
        }

        [HttpPost]
        public ActionResult TnpChangePassword(TNPMemberRegisterDTO tnpModel)
        {
            _tnpServices.ChangePassword(tnpModel);
            return RedirectToAction("TNP_Notice_Board");
        }

        public ActionResult Index()
        {
            if (Session["EmailID"] != null)
            {
                return View(_tnpServices.GetAllStudent());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult New_Post()
        {
            if (Session["EmailID"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult New_Post(NewPostDTO model)
        {
            if (model != null)
            {
                _tnpServices.NewPost(model);
            }
            return View();
            //return RedirectToAction("Notice_Board", "StudentProfile");
        }
     
        // GET: TNP
        public ActionResult TNP_Notice_Board()
        {

            if (Session["TNPID"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: TNP/Details/5
        public ActionResult GetTNPProfile(string email)
        {
            if (Session["TNPID"] != null)
            {
                var result = _tnpServices.GetTNP(email);
                
                return View(result);
            }
            return RedirectToAction("Index", "Home");

        }

        public ActionResult ViewQuery()
        {
            if (Session["TNPID"] != null)
            {
                return View(_tnpServices.ViewQuery());
            }
            return RedirectToAction("Index", "Home");

        }

        public ActionResult LogoutTnp()
        {
           
            if (Session["TNPID"] != null)
            {
                _tnpServices.LogoutTnp();
               
            }
            return RedirectToAction("Index", "Home");
        }

    }   
}
